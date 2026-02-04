import * as d3 from 'd3';
import type { ParabolaPoint, GenotypePoint } from '$lib/sim/definetti';
import { TRIANGLE } from '$lib/sim/definetti';

export function renderDeFinettiChart(
	container: HTMLElement,
	parabola: ParabolaPoint[],
	points: GenotypePoint[]
) {
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
	const viz1 = style.getPropertyValue('--viz-1').trim();
	const viz2 = style.getPropertyValue('--viz-2').trim();

	const margin = { top: 24, right: 32, bottom: 52, left: 32 };
	const iw = w - margin.left - margin.right;
	const ih = h - margin.top - margin.bottom;

	// Keep the triangle proportional — use a square mapping region
	const side = Math.min(iw, ih);
	const ox = margin.left + (iw - side) / 2;
	const oy = margin.top + (ih - side) / 2;

	const svg = d3.select(container)
		.append('svg')
		.attr('width', w)
		.attr('height', h);

	const g = svg.append('g')
		.attr('transform', `translate(${ox},${oy})`);

	// Scales: x = [0,1] → [0,side], y = [0,1] → [side,0]
	const x = d3.scaleLinear().domain([0, 1]).range([0, side]);
	const y = d3.scaleLinear().domain([0, 1]).range([side, 0]);

	// --- Triangle ---
	const triPath = [
		[x(TRIANGLE.aa.x), y(TRIANGLE.aa.y)],
		[x(TRIANGLE.AA.x), y(TRIANGLE.AA.y)],
		[x(TRIANGLE.Aa.x), y(TRIANGLE.Aa.y)]
	];

	g.append('polygon')
		.attr('points', triPath.map(p => p.join(',')).join(' '))
		.attr('fill', 'none')
		.attr('stroke', axisColor)
		.attr('stroke-width', 1.5);

	// --- Tick marks along the base ---
	const baseTicks = [0, 0.2, 0.4, 0.6, 0.8, 1.0];
	baseTicks.forEach(t => {
		g.append('line')
			.attr('x1', x(t)).attr('x2', x(t))
			.attr('y1', y(0)).attr('y2', y(0) + 5)
			.attr('stroke', axisColor);

		g.append('text')
			.attr('x', x(t))
			.attr('y', y(0) + 18)
			.attr('text-anchor', 'middle')
			.attr('font-family', 'Inter, sans-serif')
			.attr('font-size', '10px')
			.attr('fill', labelColor)
			.text(t.toFixed(1));
	});

	// --- Internal grid lines (horizontal dashes at het = 0.2, 0.4, etc.) ---
	[0.2, 0.4, 0.6, 0.8].forEach(het => {
		// The triangle at height het spans from left edge to right edge
		// Left edge: line from (0,0) to (0.5,1) → at y=het, x = het/2
		// Right edge: line from (1,0) to (0.5,1) → at y=het, x = 1 - het/2
		const xL = het / 2;
		const xR = 1 - het / 2;
		g.append('line')
			.attr('x1', x(xL)).attr('x2', x(xR))
			.attr('y1', y(het)).attr('y2', y(het))
			.attr('stroke', gridColor)
			.attr('stroke-dasharray', '3,5');
	});

	// --- HWE parabola ---
	const line = d3.line<ParabolaPoint>()
		.x(d => x(d.p))
		.y(d => y(d.het));

	const path = g.append('path')
		.datum(parabola)
		.attr('fill', 'none')
		.attr('stroke', viz1)
		.attr('stroke-width', 2.5)
		.attr('d', line);

	const totalLength = (path.node() as SVGPathElement).getTotalLength();
	path
		.attr('stroke-dasharray', `${totalLength} ${totalLength}`)
		.attr('stroke-dashoffset', totalLength)
		.transition()
		.duration(1000)
		.ease(d3.easeQuadOut)
		.attr('stroke-dashoffset', 0);

	// --- Vertex labels ---
	const labels: { pos: { x: number; y: number }; text: string; dx: number; dy: number }[] = [
		{ pos: TRIANGLE.aa, text: 'aa', dx: -12, dy: 16 },
		{ pos: TRIANGLE.AA, text: 'AA', dx: 12, dy: 16 },
		{ pos: TRIANGLE.Aa, text: 'Aa', dx: 0, dy: -10 }
	];

	labels.forEach(l => {
		g.append('text')
			.attr('x', x(l.pos.x) + l.dx)
			.attr('y', y(l.pos.y) + l.dy)
			.attr('text-anchor', 'middle')
			.attr('font-family', 'Inter, sans-serif')
			.attr('font-size', '12px')
			.attr('font-weight', '600')
			.attr('fill', textColor)
			.text(l.text);
	});

	// --- Axis label ---
	g.append('text')
		.attr('x', x(0.5))
		.attr('y', y(0) + 38)
		.attr('text-anchor', 'middle')
		.attr('font-family', 'Inter, sans-serif')
		.attr('font-size', '11px')
		.attr('font-weight', '500')
		.attr('fill', labelColor)
		.text('Frequency of A (p)');

	// Parabola label
	g.append('text')
		.attr('x', x(0.5))
		.attr('y', y(0.5) - 10)
		.attr('text-anchor', 'middle')
		.attr('font-family', 'Inter, sans-serif')
		.attr('font-size', '10px')
		.attr('font-weight', '500')
		.attr('fill', viz1)
		.attr('opacity', 0)
		.text('HWE: 2pq')
		.transition()
		.delay(800)
		.duration(400)
		.attr('opacity', 0.9);

	// --- User points + connecting lines to HWE ---
	points.forEach((pt) => {
		// Connecting line from observed to HWE expected
		g.append('line')
			.attr('x1', x(pt.p))
			.attr('y1', y(pt.het))
			.attr('x2', x(pt.p))
			.attr('y2', y(pt.hweHet))
			.attr('stroke', gridColor)
			.attr('stroke-width', 1)
			.attr('stroke-dasharray', '2,3')
			.attr('opacity', 0)
			.transition()
			.duration(300)
			.attr('opacity', 0.7);

		// HWE expected point (on parabola)
		g.append('circle')
			.attr('cx', x(pt.p))
			.attr('cy', y(pt.hweHet))
			.attr('r', 0)
			.attr('fill', viz1)
			.attr('fill-opacity', 0.4)
			.attr('stroke', viz1)
			.attr('stroke-width', 1.5)
			.transition()
			.duration(300)
			.attr('r', 4);

		// Observed point
		g.append('circle')
			.attr('cx', x(pt.p))
			.attr('cy', y(pt.het))
			.attr('r', 0)
			.attr('fill', viz2)
			.attr('fill-opacity', 0.4)
			.attr('stroke', viz2)
			.attr('stroke-width', 1.5)
			.transition()
			.duration(300)
			.attr('r', 5);
	});
}
