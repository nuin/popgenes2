import * as d3 from 'd3';
import type { SimPoint, SimResult } from '$lib/sim/types';

export interface ChartOptions {
	xLabel?: string;
	yLabel?: string;
	yDomain?: [number, number];
}

const VIZ_VARS = [
	'--viz-1', '--viz-2', '--viz-3', '--viz-4',
	'--viz-5', '--viz-6', '--viz-7', '--viz-8'
];

export function renderLineChart(
	container: HTMLElement,
	data: SimResult,
	options: ChartOptions = {}
) {
	const { xLabel = 'Generations', yLabel = 'Allele Frequency', yDomain = [0, 1] } = options;

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

	const colors = VIZ_VARS.map((v) => style.getPropertyValue(v).trim());

	const margin = { top: 24, right: 32, bottom: 52, left: 60 };
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
	const line = d3.line<SimPoint>()
		.x((d) => x(d.generation))
		.y((d) => y(d.frequency))
		.curve(d3.curveCatmullRom.alpha(0.5));

	data.forEach((series, i) => {
		const path = g.append('path')
			.datum(series)
			.attr('fill', 'none')
			.attr('stroke', colors[i % colors.length])
			.attr('stroke-width', 1.8)
			.attr('opacity', lineOpacity)
			.attr('d', line);

		const totalLength = (path.node() as SVGPathElement).getTotalLength();
		path
			.attr('stroke-dasharray', `${totalLength} ${totalLength}`)
			.attr('stroke-dashoffset', totalLength)
			.transition()
			.duration(1200)
			.delay(i * 60)
			.ease(d3.easeQuadOut)
			.attr('stroke-dashoffset', 0);
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
