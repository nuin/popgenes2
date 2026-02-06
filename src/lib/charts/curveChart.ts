import * as d3 from 'd3';

export interface CurvePoint {
	x: number;
	y: number;
}

export interface CurveData {
	points: CurvePoint[];
	color?: string;
	label?: string;
}

export interface CurveChartOptions {
	xLabel?: string;
	yLabel?: string;
	xDomain?: [number, number];
	yDomain?: [number, number];
}

const VIZ_VARS = [
	'--viz-1', '--viz-2', '--viz-3', '--viz-4',
	'--viz-5', '--viz-6', '--viz-7', '--viz-8'
];

export function renderCurveChart(
	container: HTMLElement,
	curves: CurveData[],
	options: CurveChartOptions = {}
) {
	const {
		xLabel = 'p',
		yLabel = 'Frequency',
		xDomain = [0, 1],
		yDomain = [0, 1]
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
	const lineOpacity = parseFloat(style.getPropertyValue('--line-opacity').trim()) || 0.8;
	const colors = VIZ_VARS.map(v => style.getPropertyValue(v).trim());

	const margin = { top: 24, right: 32, bottom: 52, left: 60 };
	const iw = w - margin.left - margin.right;
	const ih = h - margin.top - margin.bottom;

	const svg = d3.select(container)
		.append('svg')
		.attr('width', w)
		.attr('height', h);

	const g = svg.append('g')
		.attr('transform', `translate(${margin.left},${margin.top})`);

	const x = d3.scaleLinear().domain(xDomain).range([0, iw]);
	const y = d3.scaleLinear().domain(yDomain).range([ih, 0]);

	// Grid
	const yTicks = y.ticks(5);
	const xTicks = x.ticks(5);

	g.selectAll('.grid-y')
		.data(yTicks)
		.enter().append('line')
		.attr('x1', 0).attr('x2', iw)
		.attr('y1', d => y(d)).attr('y2', d => y(d))
		.attr('stroke', gridColor)
		.attr('stroke-dasharray', '2,4');

	g.selectAll('.grid-x')
		.data(xTicks)
		.enter().append('line')
		.attr('x1', d => x(d)).attr('x2', d => x(d))
		.attr('y1', 0).attr('y2', ih)
		.attr('stroke', gridColor)
		.attr('stroke-dasharray', '2,4');

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

	// Curves
	const line = d3.line<CurvePoint>()
		.x(d => x(d.x))
		.y(d => y(d.y))
		.curve(d3.curveCatmullRom.alpha(0.5));

	curves.forEach((curve, i) => {
		const strokeColor = curve.color ?? colors[i % colors.length];

		const path = g.append('path')
			.datum(curve.points)
			.attr('fill', 'none')
			.attr('stroke', strokeColor)
			.attr('stroke-width', 2)
			.attr('opacity', lineOpacity)
			.attr('d', line);

		const totalLength = (path.node() as SVGPathElement).getTotalLength();
		path
			.attr('stroke-dasharray', `${totalLength} ${totalLength}`)
			.attr('stroke-dashoffset', totalLength)
			.transition()
			.duration(1000)
			.delay(i * 80)
			.ease(d3.easeQuadOut)
			.attr('stroke-dashoffset', 0);

		// Label
		if (curve.label) {
			const midIdx = Math.floor(curve.points.length * 0.6);
			const midPt = curve.points[midIdx];
			if (midPt) {
				g.append('text')
					.attr('x', x(midPt.x) + 6)
					.attr('y', y(midPt.y) - 6)
					.attr('font-family', 'Inter, sans-serif')
					.attr('font-size', '10px')
					.attr('font-weight', '500')
					.attr('fill', strokeColor)
					.attr('opacity', 0)
					.text(curve.label)
					.transition()
					.delay(800 + i * 80)
					.duration(400)
					.attr('opacity', 0.9);
			}
		}
	});

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
}
