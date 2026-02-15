import * as d3 from 'd3';

export interface HistogramBar {
	label: string;
	value: number;
	color?: string;
}

export interface HistogramOptions {
	xLabel?: string;
	yLabel?: string;
	yDomain?: [number, number];
	overlayValues?: number[]; // Optional overlay line (e.g., expected values)
	overlayLabel?: string;
	overlayColor?: string;
}

export function renderHistogramChart(
	container: HTMLElement,
	bars: HistogramBar[],
	options: HistogramOptions = {}
) {
	const { xLabel = '', yLabel = 'Frequency', yDomain, overlayValues, overlayColor } = options;

	d3.select(container).selectAll('*').remove();

	const rect = container.getBoundingClientRect();
	const w = rect.width;
	const h = rect.height;
	if (w < 10 || h < 10) return;

	const style = getComputedStyle(document.body);
	const axisColor = style.getPropertyValue('--axis').trim();
	const gridColor = style.getPropertyValue('--grid').trim();
	const labelColor = style.getPropertyValue('--label').trim();
	const viz1 = style.getPropertyValue('--viz-1').trim();

	const margin = { top: 24, right: 24, bottom: 52, left: 60 };
	const iw = w - margin.left - margin.right;
	const ih = h - margin.top - margin.bottom;

	const svg = d3.select(container)
		.append('svg')
		.attr('width', w)
		.attr('height', h);

	const g = svg.append('g')
		.attr('transform', `translate(${margin.left},${margin.top})`);

	const x = d3.scaleBand()
		.domain(bars.map(b => b.label))
		.range([0, iw])
		.padding(0.2);

	const maxVal = yDomain
		? yDomain[1]
		: d3.max(bars, b => b.value) ?? 1;

	const y = d3.scaleLinear()
		.domain(yDomain ?? [0, maxVal * 1.1])
		.range([ih, 0]);

	// Grid
	const yTicks = y.ticks(5);
	g.selectAll('.grid-y')
		.data(yTicks)
		.enter().append('line')
		.attr('x1', 0).attr('x2', iw)
		.attr('y1', d => y(d)).attr('y2', d => y(d))
		.attr('stroke', gridColor)
		.attr('stroke-dasharray', '2,4');

	// Axes
	g.append('g')
		.attr('transform', `translate(0,${ih})`)
		.call(d3.axisBottom(x));

	g.append('g')
		.call(d3.axisLeft(y).ticks(5));

	svg.selectAll('.domain').attr('stroke', axisColor);
	svg.selectAll('.tick line').attr('stroke', axisColor);
	svg.selectAll('.tick text')
		.attr('fill', labelColor)
		.attr('font-family', 'Inter, sans-serif')
		.attr('font-size', '10px');

	// Bars
	g.selectAll('.bar')
		.data(bars)
		.enter().append('rect')
		.attr('x', d => x(d.label)!)
		.attr('width', x.bandwidth())
		.attr('y', ih)
		.attr('height', 0)
		.attr('fill', d => d.color ?? viz1)
		.attr('fill-opacity', 0.7)
		.attr('rx', 2)
		.transition()
		.duration(600)
		.delay((_, i) => i * 40)
		.ease(d3.easeQuadOut)
		.attr('y', d => y(d.value))
		.attr('height', d => ih - y(d.value));

	// Overlay line for expected values
	if (overlayValues && overlayValues.length > 0) {
		const overlayData = bars.map((b, i) => ({
			label: b.label,
			value: overlayValues[i] ?? 0
		}));

		const lineColor = overlayColor ?? style.getPropertyValue('--viz-2').trim();

		// Draw line connecting centers of bars
		const line = d3.line<{ label: string; value: number }>()
			.x(d => (x(d.label) ?? 0) + x.bandwidth() / 2)
			.y(d => y(d.value))
			.curve(d3.curveMonotoneX);

		g.append('path')
			.datum(overlayData)
			.attr('fill', 'none')
			.attr('stroke', lineColor)
			.attr('stroke-width', 2)
			.attr('stroke-dasharray', '4,2')
			.attr('d', line);

		// Draw points
		g.selectAll('.overlay-point')
			.data(overlayData)
			.enter().append('circle')
			.attr('cx', d => (x(d.label) ?? 0) + x.bandwidth() / 2)
			.attr('cy', d => y(d.value))
			.attr('r', 3)
			.attr('fill', lineColor);
	}

	// Labels
	if (xLabel) {
		svg.append('text')
			.attr('text-anchor', 'middle')
			.attr('x', margin.left + iw / 2)
			.attr('y', h - 10)
			.attr('font-family', 'Inter, sans-serif')
			.attr('font-size', '11px')
			.attr('font-weight', '500')
			.attr('fill', labelColor)
			.text(xLabel);
	}

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
}
