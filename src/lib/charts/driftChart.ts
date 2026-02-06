import * as d3 from 'd3';
import type { SimPoint, SimResult } from '$lib/sim/types';

export interface DriftChartOptions {
	xLabel?: string;
	yLabel?: string;
	yDomain?: [number, number];
	initialFreq?: number;
	populationSize?: number;
	// Toggle options
	showFixationMarkers?: boolean;
	showMeanLine?: boolean;
	showVarianceEnvelope?: boolean;
	showSummaryStats?: boolean;
	showInitialLine?: boolean;
	thinLines?: boolean;
}

export interface DriftStats {
	fixed: number;
	lost: number;
	polymorphic: number;
	total: number;
}

const VIZ_VARS = [
	'--viz-1', '--viz-2', '--viz-3', '--viz-4',
	'--viz-5', '--viz-6', '--viz-7', '--viz-8'
];

export function computeDriftStats(data: SimResult): DriftStats {
	let fixed = 0;
	let lost = 0;
	let polymorphic = 0;

	data.forEach((series) => {
		if (series.length === 0) return;
		const finalFreq = series[series.length - 1].frequency;
		if (finalFreq >= 0.999) {
			fixed++;
		} else if (finalFreq <= 0.001) {
			lost++;
		} else {
			polymorphic++;
		}
	});

	return { fixed, lost, polymorphic, total: data.length };
}

export function computeMeanTrajectory(data: SimResult): SimPoint[] {
	if (data.length === 0) return [];

	const maxGen = Math.max(...data.map(s => s.length));
	const mean: SimPoint[] = [];

	for (let gen = 0; gen < maxGen; gen++) {
		let sum = 0;
		let count = 0;
		data.forEach((series) => {
			if (series[gen]) {
				sum += series[gen].frequency;
				count++;
			}
		});
		if (count > 0) {
			mean.push({ generation: gen, frequency: sum / count });
		}
	}

	return mean;
}

export function computeVarianceEnvelope(
	initialFreq: number,
	populationSize: number,
	maxGen: number
): { upper: SimPoint[]; lower: SimPoint[] } {
	const upper: SimPoint[] = [];
	const lower: SimPoint[] = [];
	const p = initialFreq;
	const q = 1 - p;

	for (let t = 0; t <= maxGen; t++) {
		// Variance of allele frequency under drift: Var(p) = p*q * (1 - (1 - 1/2N)^t)
		const driftFactor = 1 - Math.pow(1 - 1 / (2 * populationSize), t);
		const variance = p * q * driftFactor;
		const sd = Math.sqrt(variance);

		// 2 standard deviations for ~95% envelope
		const upperBound = Math.min(1, p + 2 * sd);
		const lowerBound = Math.max(0, p - 2 * sd);

		upper.push({ generation: t, frequency: upperBound });
		lower.push({ generation: t, frequency: lowerBound });
	}

	return { upper, lower };
}

export function renderDriftChart(
	container: HTMLElement,
	data: SimResult,
	options: DriftChartOptions = {},
	onContextMenu?: (event: MouseEvent) => void
) {
	const {
		xLabel = 'Generations',
		yLabel = 'Allele Frequency',
		yDomain = [0, 1],
		initialFreq = 0.5,
		populationSize = 100,
		showFixationMarkers = true,
		showMeanLine = true,
		showVarianceEnvelope = true,
		showSummaryStats = true,
		showInitialLine = true,
		thinLines = true
	} = options;

	d3.select(container).selectAll('*').remove();

	const rect = container.getBoundingClientRect();
	const w = rect.width;
	const h = rect.height;
	if (w < 10 || h < 10) return;

	const style = getComputedStyle(document.body);
	const axisColor = style.getPropertyValue('--axis').trim();
	const gridColor = style.getPropertyValue('--grid').trim();
	const labelColor = style.getPropertyValue('--label').trim();
	const textColor = style.getPropertyValue('--text').trim();
	const bgColor = style.getPropertyValue('--bg').trim();
	const accentColor = style.getPropertyValue('--accent').trim();

	const colors = VIZ_VARS.map((v) => style.getPropertyValue(v).trim());

	const margin = { top: 24, right: showSummaryStats ? 120 : 32, bottom: 52, left: 60 };
	const iw = w - margin.left - margin.right;
	const ih = h - margin.top - margin.bottom;

	const maxGen = data.length > 0
		? d3.max(data, (line) => d3.max(line, (d) => d.generation)) ?? 100
		: 100;

	const svg = d3.select(container)
		.append('svg')
		.attr('width', w)
		.attr('height', h);

	const g = svg.append('g')
		.attr('transform', `translate(${margin.left},${margin.top})`);

	const x = d3.scaleLinear().domain([0, maxGen]).range([0, iw]);
	const y = d3.scaleLinear().domain(yDomain).range([ih, 0]);

	// Grid lines
	const yTicks = y.ticks(5);
	const xTicks = x.ticks(5);

	g.selectAll('.grid-y')
		.data(yTicks)
		.enter().append('line')
		.attr('x1', 0).attr('x2', iw)
		.attr('y1', (d) => y(d)).attr('y2', (d) => y(d))
		.attr('stroke', gridColor)
		.attr('stroke-dasharray', '2,4');

	g.selectAll('.grid-x')
		.data(xTicks)
		.enter().append('line')
		.attr('x1', (d) => x(d)).attr('x2', (d) => x(d))
		.attr('y1', 0).attr('y2', ih)
		.attr('stroke', gridColor)
		.attr('stroke-dasharray', '2,4');

	// Variance envelope (draw first, behind everything)
	if (showVarianceEnvelope && data.length > 0) {
		const envelope = computeVarianceEnvelope(initialFreq, populationSize, maxGen);

		const areaGenerator = d3.area<SimPoint>()
			.x((d) => x(d.generation))
			.y0((d, i) => y(envelope.lower[i].frequency))
			.y1((d) => y(d.frequency))
			.curve(d3.curveBasis);

		g.append('path')
			.datum(envelope.upper)
			.attr('fill', accentColor)
			.attr('opacity', 0.08)
			.attr('d', areaGenerator);
	}

	// Initial frequency line
	if (showInitialLine) {
		g.append('line')
			.attr('x1', 0)
			.attr('x2', iw)
			.attr('y1', y(initialFreq))
			.attr('y2', y(initialFreq))
			.attr('stroke', accentColor)
			.attr('stroke-width', 1)
			.attr('stroke-dasharray', '6,4')
			.attr('opacity', 0.6);

		g.append('text')
			.attr('x', iw + 4)
			.attr('y', y(initialFreq) + 3)
			.attr('font-family', 'Inter, sans-serif')
			.attr('font-size', '9px')
			.attr('fill', accentColor)
			.attr('opacity', 0.8)
			.text(`p₀=${initialFreq}`);
	}

	// Axes
	g.append('g')
		.attr('transform', `translate(0,${ih})`)
		.call(d3.axisBottom(x).ticks(5));

	g.append('g')
		.call(d3.axisLeft(y).ticks(5).tickFormat(d3.format('.2f')));

	svg.selectAll('.domain').attr('stroke', axisColor);
	svg.selectAll('.tick line').attr('stroke', axisColor);
	svg.selectAll('.tick text')
		.attr('fill', labelColor)
		.attr('font-family', 'Inter, sans-serif')
		.attr('font-size', '10px');

	// Data lines
	const lineWidth = thinLines ? 1.2 : 1.8;
	const lineOpacity = thinLines ? 0.5 : 0.8;

	const line = d3.line<SimPoint>()
		.x((d) => x(d.generation))
		.y((d) => y(d.frequency))
		.curve(d3.curveCatmullRom.alpha(0.5));

	data.forEach((series, i) => {
		if (series.length === 0) return;

		const path = g.append('path')
			.datum(series)
			.attr('fill', 'none')
			.attr('stroke', colors[i % colors.length])
			.attr('stroke-width', lineWidth)
			.attr('opacity', lineOpacity)
			.attr('d', line);

		const totalLength = (path.node() as SVGPathElement).getTotalLength();
		path
			.attr('stroke-dasharray', `${totalLength} ${totalLength}`)
			.attr('stroke-dashoffset', totalLength)
			.transition()
			.duration(1200)
			.delay(i * 40)
			.ease(d3.easeQuadOut)
			.attr('stroke-dashoffset', 0);
	});

	// Fixation markers
	if (showFixationMarkers && data.length > 0) {
		const markersGroup = g.append('g').attr('class', 'fixation-markers');

		data.forEach((series, i) => {
			if (series.length === 0) return;
			const finalPoint = series[series.length - 1];
			const finalFreq = finalPoint.frequency;

			if (finalFreq >= 0.999) {
				// Fixed (reached 1) - upward triangle
				markersGroup.append('path')
					.attr('d', d3.symbol().type(d3.symbolTriangle).size(50))
					.attr('transform', `translate(${x(finalPoint.generation)}, ${y(1)}) rotate(0)`)
					.attr('fill', colors[i % colors.length])
					.attr('opacity', 0)
					.transition()
					.delay(1200 + i * 40)
					.duration(300)
					.attr('opacity', 1);
			} else if (finalFreq <= 0.001) {
				// Lost (reached 0) - downward triangle
				markersGroup.append('path')
					.attr('d', d3.symbol().type(d3.symbolTriangle).size(50))
					.attr('transform', `translate(${x(finalPoint.generation)}, ${y(0)}) rotate(180)`)
					.attr('fill', colors[i % colors.length])
					.attr('opacity', 0)
					.transition()
					.delay(1200 + i * 40)
					.duration(300)
					.attr('opacity', 1);
			}
		});
	}

	// Mean trajectory line
	if (showMeanLine && data.length > 1) {
		const meanData = computeMeanTrajectory(data);

		g.append('path')
			.datum(meanData)
			.attr('fill', 'none')
			.attr('stroke', textColor)
			.attr('stroke-width', 2.5)
			.attr('stroke-dasharray', '0')
			.attr('opacity', 0)
			.attr('d', line)
			.transition()
			.delay(1400)
			.duration(600)
			.attr('opacity', 0.9);

		// Label for mean line
		if (meanData.length > 0) {
			const lastMean = meanData[meanData.length - 1];
			g.append('text')
				.attr('x', x(lastMean.generation) + 4)
				.attr('y', y(lastMean.frequency) + 3)
				.attr('font-family', 'Inter, sans-serif')
				.attr('font-size', '9px')
				.attr('font-weight', '600')
				.attr('fill', textColor)
				.attr('opacity', 0)
				.text('μ')
				.transition()
				.delay(1800)
				.duration(300)
				.attr('opacity', 0.9);
		}
	}

	// Summary stats panel
	if (showSummaryStats && data.length > 0) {
		const stats = computeDriftStats(data);
		const statsGroup = svg.append('g')
			.attr('class', 'stats-panel')
			.attr('transform', `translate(${w - margin.right + 16}, ${margin.top})`);

		const statItems = [
			{ label: 'Fixed', value: stats.fixed, pct: (stats.fixed / stats.total * 100).toFixed(0), color: '#22c55e' },
			{ label: 'Lost', value: stats.lost, pct: (stats.lost / stats.total * 100).toFixed(0), color: '#ef4444' },
			{ label: 'Poly', value: stats.polymorphic, pct: (stats.polymorphic / stats.total * 100).toFixed(0), color: accentColor }
		];

		statsGroup.append('text')
			.attr('x', 0)
			.attr('y', 0)
			.attr('font-family', 'Inter, sans-serif')
			.attr('font-size', '9px')
			.attr('font-weight', '600')
			.attr('fill', labelColor)
			.attr('text-transform', 'uppercase')
			.attr('letter-spacing', '0.05em')
			.text('OUTCOMES');

		statItems.forEach((item, i) => {
			const yPos = 20 + i * 28;

			statsGroup.append('text')
				.attr('x', 0)
				.attr('y', yPos)
				.attr('font-family', 'Inter, sans-serif')
				.attr('font-size', '10px')
				.attr('fill', labelColor)
				.text(item.label);

			statsGroup.append('text')
				.attr('x', 0)
				.attr('y', yPos + 12)
				.attr('font-family', 'Inter, sans-serif')
				.attr('font-size', '14px')
				.attr('font-weight', '600')
				.attr('fill', item.color)
				.text(`${item.value}`);

			statsGroup.append('text')
				.attr('x', 28)
				.attr('y', yPos + 12)
				.attr('font-family', 'Inter, sans-serif')
				.attr('font-size', '10px')
				.attr('fill', labelColor)
				.text(`(${item.pct}%)`);
		});
	}

	// Axis labels
	svg.append('text')
		.attr('text-anchor', 'middle')
		.attr('x', margin.left + iw / 2)
		.attr('y', h - 10)
		.attr('font-family', 'Inter, sans-serif')
		.attr('font-size', '11px')
		.attr('font-weight', '500')
		.attr('fill', labelColor)
		.text(xLabel);

	svg.append('text')
		.attr('text-anchor', 'middle')
		.attr('transform', 'rotate(-90)')
		.attr('y', 16)
		.attr('x', -(margin.top + ih / 2))
		.attr('font-family', 'Inter, sans-serif')
		.attr('font-size', '11px')
		.attr('font-weight', '500')
		.attr('fill', labelColor)
		.text(yLabel);

	// --- Crosshair interaction ---
	if (data.length === 0) return;

	const crosshairGroup = g.append('g')
		.attr('class', 'crosshair')
		.style('opacity', 0);

	const crosshairLine = crosshairGroup.append('line')
		.attr('y1', 0)
		.attr('y2', ih)
		.attr('stroke', gridColor)
		.attr('stroke-width', 1)
		.attr('stroke-dasharray', '4,4');

	const genLabel = crosshairGroup.append('text')
		.attr('y', -8)
		.attr('text-anchor', 'middle')
		.attr('font-family', 'Inter, sans-serif')
		.attr('font-size', '10px')
		.attr('font-weight', '600')
		.attr('fill', textColor);

	function findClosestPoint(series: SimPoint[], targetGen: number): SimPoint | null {
		if (series.length === 0) return null;
		let left = 0;
		let right = series.length - 1;
		while (left < right) {
			const mid = Math.floor((left + right) / 2);
			if (series[mid].generation < targetGen) {
				left = mid + 1;
			} else {
				right = mid;
			}
		}
		if (left > 0) {
			const diffLeft = Math.abs(series[left].generation - targetGen);
			const diffLeftMinus = Math.abs(series[left - 1].generation - targetGen);
			if (diffLeftMinus < diffLeft) {
				left = left - 1;
			}
		}
		return series[left];
	}

	// Create dots for visible series (limit to avoid clutter)
	const maxDotsToShow = Math.min(data.length, 8);
	const crosshairDots = data.slice(0, maxDotsToShow).map((_, i) => {
		return crosshairGroup.append('circle')
			.attr('r', 3)
			.attr('fill', colors[i % colors.length])
			.attr('stroke', bgColor)
			.attr('stroke-width', 1);
	});

	// Create overlay rect for mouse events
	g.append('rect')
		.attr('class', 'overlay')
		.attr('width', iw)
		.attr('height', ih)
		.attr('fill', 'transparent')
		.style('cursor', 'crosshair')
		.on('mouseenter', () => {
			crosshairGroup.style('opacity', 1);
		})
		.on('mouseleave', () => {
			crosshairGroup.style('opacity', 0);
		})
		.on('mousemove', function(event) {
			const [mouseX] = d3.pointer(event, this);
			const generation = x.invert(mouseX);
			const clampedGen = Math.max(0, Math.min(maxGen, generation));
			const roundedGen = Math.round(clampedGen);

			crosshairLine.attr('x1', x(roundedGen)).attr('x2', x(roundedGen));
			genLabel.attr('x', x(roundedGen)).text(`Gen ${roundedGen}`);

			// Update dots for visible series
			data.slice(0, maxDotsToShow).forEach((series, i) => {
				const point = findClosestPoint(series, roundedGen);
				if (point) {
					crosshairDots[i]
						.attr('cx', x(point.generation))
						.attr('cy', y(point.frequency));
				}
			});
		})
		.on('contextmenu', function(event) {
			event.preventDefault();
			if (onContextMenu) {
				onContextMenu(event);
			}
		});
}
