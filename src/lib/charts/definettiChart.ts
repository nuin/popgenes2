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
	const bgColor = style.getPropertyValue('--bg').trim();
	const viz1 = style.getPropertyValue('--viz-1').trim();
	const viz2 = style.getPropertyValue('--viz-2').trim();
	const viz3 = style.getPropertyValue('--viz-3').trim();
	const viz4 = style.getPropertyValue('--viz-4').trim();

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

	// --- Geometric guide group (will be shown on hover) ---
	const guideGroup = g.append('g')
		.attr('class', 'geometric-guides')
		.style('opacity', 0);

	// Vertical line from point to base (showing H)
	const guideLine = guideGroup.append('line')
		.attr('class', 'guide-vertical')
		.attr('stroke', viz3)
		.attr('stroke-width', 1.5)
		.attr('stroke-dasharray', '4,3');

	// Line from base point to left (showing R = aa frequency)
	const guideLineR = guideGroup.append('line')
		.attr('class', 'guide-r')
		.attr('stroke', viz2)
		.attr('stroke-width', 3);

	// Line from base point to right (showing D = AA frequency)
	const guideLineD = guideGroup.append('line')
		.attr('class', 'guide-d')
		.attr('stroke', viz4)
		.attr('stroke-width', 3);

	// Horizontal line from point to left edge (for reading)
	const guideHorizLeft = guideGroup.append('line')
		.attr('class', 'guide-horiz-left')
		.attr('stroke', viz2)
		.attr('stroke-width', 1)
		.attr('stroke-dasharray', '3,3');

	// Horizontal line from point to right edge
	const guideHorizRight = guideGroup.append('line')
		.attr('class', 'guide-horiz-right')
		.attr('stroke', viz4)
		.attr('stroke-width', 1)
		.attr('stroke-dasharray', '3,3');

	// Info panel background
	const infoPanelWidth = 130;
	const infoPanelHeight = 95;
	const infoPanel = guideGroup.append('g')
		.attr('class', 'info-panel');

	infoPanel.append('rect')
		.attr('width', infoPanelWidth)
		.attr('height', infoPanelHeight)
		.attr('rx', 4)
		.attr('fill', bgColor)
		.attr('stroke', gridColor)
		.attr('stroke-width', 1)
		.attr('opacity', 0.95);

	// Info panel text elements
	const infoTextP = infoPanel.append('text')
		.attr('x', 8).attr('y', 16)
		.attr('font-family', 'Inter, sans-serif')
		.attr('font-size', '10px')
		.attr('fill', textColor);

	const infoTextQ = infoPanel.append('text')
		.attr('x', 70).attr('y', 16)
		.attr('font-family', 'Inter, sans-serif')
		.attr('font-size', '10px')
		.attr('fill', textColor);

	// Divider
	infoPanel.append('line')
		.attr('x1', 8).attr('x2', infoPanelWidth - 8)
		.attr('y1', 24).attr('y2', 24)
		.attr('stroke', gridColor);

	// Genotype labels
	const infoTextD = infoPanel.append('text')
		.attr('x', 8).attr('y', 40)
		.attr('font-family', 'Inter, sans-serif')
		.attr('font-size', '10px');

	const infoTextH = infoPanel.append('text')
		.attr('x', 8).attr('y', 56)
		.attr('font-family', 'Inter, sans-serif')
		.attr('font-size', '10px');

	const infoTextR = infoPanel.append('text')
		.attr('x', 8).attr('y', 72)
		.attr('font-family', 'Inter, sans-serif')
		.attr('font-size', '10px');

	// HWE deviation
	const infoTextDev = infoPanel.append('text')
		.attr('x', 8).attr('y', 88)
		.attr('font-family', 'Inter, sans-serif')
		.attr('font-size', '9px')
		.attr('fill', labelColor);

	// Function to show geometric guides for a point
	function showGuides(px: number, py: number, hweHet: number) {
		// Calculate genotype frequencies from coordinates
		// In De Finetti: x = p, y = H
		const p = px;
		const q = 1 - p;
		const H = py;
		const D = p - H / 2;  // AA frequency
		const R = q - H / 2;  // aa frequency

		// Vertical line from point to base
		guideLine
			.attr('x1', x(px)).attr('y1', y(py))
			.attr('x2', x(px)).attr('y2', y(0));

		// Base segments: R (from 0 to p-H/2) shown as distance from aa vertex
		// D shown as distance from AA vertex
		const baseY = y(0);

		// R segment: from aa (x=0) to point's projection showing R
		guideLineR
			.attr('x1', x(0)).attr('y1', baseY + 8)
			.attr('x2', x(R)).attr('y2', baseY + 8);

		// D segment: from AA (x=1) back to show D
		guideLineD
			.attr('x1', x(1)).attr('y1', baseY + 8)
			.attr('x2', x(1 - D)).attr('y2', baseY + 8);

		// Horizontal lines from point to triangle edges
		// Left edge at height py: x = py/2
		const leftEdgeX = py / 2;
		guideHorizLeft
			.attr('x1', x(px)).attr('y1', y(py))
			.attr('x2', x(leftEdgeX)).attr('y2', y(py));

		// Right edge at height py: x = 1 - py/2
		const rightEdgeX = 1 - py / 2;
		guideHorizRight
			.attr('x1', x(px)).attr('y1', y(py))
			.attr('x2', x(rightEdgeX)).attr('y2', y(py));

		// Position info panel - adjust based on point position
		let panelX = x(px) + 15;
		let panelY = y(py) - infoPanelHeight - 10;

		// Keep panel inside visible area
		if (panelX + infoPanelWidth > side) {
			panelX = x(px) - infoPanelWidth - 15;
		}
		if (panelY < 0) {
			panelY = y(py) + 15;
		}

		infoPanel.attr('transform', `translate(${panelX}, ${panelY})`);

		// Update text
		infoTextP.html(`<tspan font-weight="600">p</tspan> = ${p.toFixed(4)}`);
		infoTextQ.html(`<tspan font-weight="600">q</tspan> = ${q.toFixed(4)}`);

		infoTextD
			.attr('fill', viz4)
			.html(`<tspan font-weight="600">D (AA)</tspan> = ${D.toFixed(4)}`);
		infoTextH
			.attr('fill', viz3)
			.html(`<tspan font-weight="600">H (Aa)</tspan> = ${H.toFixed(4)}`);
		infoTextR
			.attr('fill', viz2)
			.html(`<tspan font-weight="600">R (aa)</tspan> = ${R.toFixed(4)}`);

		const deviation = H - hweHet;
		const devSign = deviation >= 0 ? '+' : '';
		infoTextDev.text(`ΔH from HWE: ${devSign}${deviation.toFixed(4)}`);

		guideGroup.style('opacity', 1);
	}

	function hideGuides() {
		guideGroup.style('opacity', 0);
	}

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

		// Observed point with hover interaction
		const pointCircle = g.append('circle')
			.attr('cx', x(pt.p))
			.attr('cy', y(pt.het))
			.attr('r', 0)
			.attr('fill', viz2)
			.attr('fill-opacity', 0.4)
			.attr('stroke', viz2)
			.attr('stroke-width', 1.5)
			.style('cursor', 'pointer')
			.transition()
			.duration(300)
			.attr('r', 5);

		// Add invisible larger hit area for easier hovering
		g.append('circle')
			.attr('cx', x(pt.p))
			.attr('cy', y(pt.het))
			.attr('r', 15)
			.attr('fill', 'transparent')
			.style('cursor', 'pointer')
			.on('mouseenter', () => {
				showGuides(pt.p, pt.het, pt.hweHet);
				d3.select(pointCircle.node()).attr('r', 7);
			})
			.on('mouseleave', () => {
				hideGuides();
				d3.select(pointCircle.node()).attr('r', 5);
			});
	});

	// --- Example point outside parabola (for demonstration) ---
	// Add a static example showing how to read the triangle
	if (points.length === 0) {
		// Show example point when no user points
		const exampleP = 0.7;
		const exampleH = 0.3;
		const exampleHWE = 2 * exampleP * (1 - exampleP);

		const exampleGroup = g.append('g')
			.attr('class', 'example-point')
			.style('opacity', 0);

		// Example point
		exampleGroup.append('circle')
			.attr('cx', x(exampleP))
			.attr('cy', y(exampleH))
			.attr('r', 5)
			.attr('fill', viz2)
			.attr('fill-opacity', 0.3)
			.attr('stroke', viz2)
			.attr('stroke-width', 1.5)
			.attr('stroke-dasharray', '3,2');

		// Label
		exampleGroup.append('text')
			.attr('x', x(exampleP) + 10)
			.attr('y', y(exampleH) - 5)
			.attr('font-family', 'Inter, sans-serif')
			.attr('font-size', '9px')
			.attr('fill', labelColor)
			.text('Hover points for details');

		exampleGroup
			.transition()
			.delay(1200)
			.duration(500)
			.style('opacity', 0.6);
	}
}
