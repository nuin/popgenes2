<script lang="ts">
	import TheoryLayout from '$lib/components/TheoryLayout.svelte';
	import { theme } from '$lib/theme';
	import * as d3 from 'd3';

	// Interactive De Finetti diagram state
	let container: HTMLDivElement;
	let p = $state(0.5);
	let isDragging = $state(false);

	// Genotype frequencies
	let AA = $derived(p * p);
	let Aa = $derived(2 * p * (1 - p));
	let aa = $derived((1 - p) * (1 - p));

	function renderDiagram() {
		if (!container) return;

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
		const viz3 = style.getPropertyValue('--viz-3').trim();
		const viz4 = style.getPropertyValue('--viz-4').trim();

		const margin = { top: 30, right: 30, bottom: 50, left: 30 };
		const iw = w - margin.left - margin.right;
		const ih = h - margin.top - margin.bottom;
		const side = Math.min(iw, ih);
		const ox = margin.left + (iw - side) / 2;
		const oy = margin.top + (ih - side) / 2;

		const svg = d3.select(container)
			.append('svg')
			.attr('width', w)
			.attr('height', h);

		const g = svg.append('g')
			.attr('transform', `translate(${ox},${oy})`);

		// Scales
		const x = d3.scaleLinear().domain([0, 1]).range([0, side]);
		const y = d3.scaleLinear().domain([0, 1]).range([side, 0]);

		// Triangle vertices (De Finetti coordinates)
		const TRIANGLE = {
			aa: { x: 0, y: 0 },
			AA: { x: 1, y: 0 },
			Aa: { x: 0.5, y: 1 }
		};

		// Triangle outline
		const triPath = [
			[x(TRIANGLE.aa.x), y(TRIANGLE.aa.y)],
			[x(TRIANGLE.AA.x), y(TRIANGLE.AA.y)],
			[x(TRIANGLE.Aa.x), y(TRIANGLE.Aa.y)]
		];

		g.append('polygon')
			.attr('points', triPath.map(pt => pt.join(',')).join(' '))
			.attr('fill', 'none')
			.attr('stroke', axisColor)
			.attr('stroke-width', 1.5);

		// Base ticks
		[0, 0.2, 0.4, 0.6, 0.8, 1.0].forEach(t => {
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

		// Grid lines
		[0.2, 0.4, 0.6, 0.8].forEach(het => {
			const xL = het / 2;
			const xR = 1 - het / 2;
			g.append('line')
				.attr('x1', x(xL)).attr('x2', x(xR))
				.attr('y1', y(het)).attr('y2', y(het))
				.attr('stroke', gridColor)
				.attr('stroke-dasharray', '3,5');
		});

		// HWE parabola
		const parabolaData = d3.range(0, 1.01, 0.01).map(pVal => ({
			p: pVal,
			het: 2 * pVal * (1 - pVal)
		}));

		const line = d3.line<{ p: number; het: number }>()
			.x(d => x(d.p))
			.y(d => y(d.het));

		g.append('path')
			.datum(parabolaData)
			.attr('fill', 'none')
			.attr('stroke', viz1)
			.attr('stroke-width', 2.5)
			.attr('d', line);

		// Vertex labels
		g.append('text')
			.attr('x', x(0) - 12)
			.attr('y', y(0) + 16)
			.attr('text-anchor', 'middle')
			.attr('font-size', '12px')
			.attr('font-weight', '600')
			.attr('fill', textColor)
			.text('aa');

		g.append('text')
			.attr('x', x(1) + 12)
			.attr('y', y(0) + 16)
			.attr('text-anchor', 'middle')
			.attr('font-size', '12px')
			.attr('font-weight', '600')
			.attr('fill', textColor)
			.text('AA');

		g.append('text')
			.attr('x', x(0.5))
			.attr('y', y(1) - 10)
			.attr('text-anchor', 'middle')
			.attr('font-size', '12px')
			.attr('font-weight', '600')
			.attr('fill', textColor)
			.text('Aa');

		// Axis label
		g.append('text')
			.attr('x', x(0.5))
			.attr('y', y(0) + 38)
			.attr('text-anchor', 'middle')
			.attr('font-size', '11px')
			.attr('font-weight', '500')
			.attr('fill', labelColor)
			.text('Frequency of A (p)');

		// Parabola label
		g.append('text')
			.attr('x', x(0.5))
			.attr('y', y(0.5) - 8)
			.attr('text-anchor', 'middle')
			.attr('font-size', '10px')
			.attr('fill', viz1)
			.text('HWE: 2pq');

		// Current HWE point
		const hweHet = 2 * p * (1 - p);

		// Vertical guide line
		g.append('line')
			.attr('x1', x(p)).attr('x2', x(p))
			.attr('y1', y(0)).attr('y2', y(hweHet))
			.attr('stroke', viz3)
			.attr('stroke-width', 1.5)
			.attr('stroke-dasharray', '4,3');

		// HWE point on parabola
		g.append('circle')
			.attr('cx', x(p))
			.attr('cy', y(hweHet))
			.attr('r', 7)
			.attr('fill', viz1)
			.attr('fill-opacity', 0.3)
			.attr('stroke', viz1)
			.attr('stroke-width', 2);

		// Draggable indicator on base
		const dragCircle = g.append('circle')
			.attr('cx', x(p))
			.attr('cy', y(0))
			.attr('r', 8)
			.attr('fill', viz2)
			.attr('stroke', 'white')
			.attr('stroke-width', 2)
			.style('cursor', 'ew-resize');

		// Drag behavior
		const drag = d3.drag<SVGCircleElement, unknown>()
			.on('start', () => {
				isDragging = true;
			})
			.on('drag', (event) => {
				const newX = Math.max(0, Math.min(side, event.x));
				const newP = newX / side;
				p = Math.round(newP * 100) / 100;
			})
			.on('end', () => {
				isDragging = false;
			});

		dragCircle.call(drag);

		// Labels for current values
		g.append('text')
			.attr('x', x(p))
			.attr('y', y(hweHet) - 15)
			.attr('text-anchor', 'middle')
			.attr('font-size', '10px')
			.attr('fill', textColor)
			.text(`p = ${p.toFixed(2)}, 2pq = ${hweHet.toFixed(3)}`);
	}

	$effect(() => {
		void p;
		void $theme;
		renderDiagram();
	});

	$effect(() => {
		const observer = new ResizeObserver(() => renderDiagram());
		if (container) observer.observe(container);
		return () => observer.disconnect();
	});
</script>

<TheoryLayout
	title="Hardy-Weinberg Equilibrium"
	subtitle="The foundation of population genetics"
	simLinks={[
		{ href: '/definetti', label: 'De Finetti Diagram' },
		{ href: '/frequencies/chi-square', label: 'Chi-Square Test' }
	]}
>
	<h2>The Principle</h2>

	<p>
		The Hardy-Weinberg principle, formulated independently by G.H. Hardy and Wilhelm Weinberg in 1908,
		describes the relationship between allele and genotype frequencies in an <strong>idealized population</strong>.
		It states that allele and genotype frequencies remain constant from generation to generation in the absence
		of evolutionary forces.
	</p>

	<div class="note">
		<strong>Key insight:</strong> Hardy-Weinberg equilibrium serves as a null model against which we can detect
		evolutionary change. Deviations from HWE indicate that evolutionary forces are acting on a population.
	</div>

	<h2>The Equilibrium Equations</h2>

	<p>
		For a single locus with two alleles, <span class="var">A</span> (frequency = <span class="var">p</span>)
		and <span class="var">a</span> (frequency = <span class="var">q</span>), the genotype frequencies at
		equilibrium are:
	</p>

	<div class="equation">
		p + q = 1
		<span class="equation-label">Allele frequencies sum to one</span>
	</div>

	<div class="equation">
		p² + 2pq + q² = 1
		<span class="equation-label">Genotype frequencies at HWE</span>
	</div>

	<p>Where:</p>
	<ul>
		<li><strong>p²</strong> = frequency of AA homozygotes</li>
		<li><strong>2pq</strong> = frequency of Aa heterozygotes</li>
		<li><strong>q²</strong> = frequency of aa homozygotes</li>
	</ul>

	<h2>Interactive De Finetti Diagram</h2>

	<p>
		The De Finetti diagram provides a geometric representation of all possible genotype frequencies.
		The parabola represents all populations in Hardy-Weinberg equilibrium. <strong>Drag the point along the
		base</strong> to see how genotype frequencies change with allele frequency.
	</p>

	<div class="diagram">
		<div class="diagram-chart" bind:this={container}></div>

		<div class="freq-display">
			<div class="freq-item">
				<span class="freq-label">p (A)</span>
				<span class="freq-value">{p.toFixed(2)}</span>
			</div>
			<div class="freq-item">
				<span class="freq-label">q (a)</span>
				<span class="freq-value">{(1 - p).toFixed(2)}</span>
			</div>
			<div class="freq-divider"></div>
			<div class="freq-item aa">
				<span class="freq-label">AA (p²)</span>
				<span class="freq-value">{AA.toFixed(3)}</span>
			</div>
			<div class="freq-item het">
				<span class="freq-label">Aa (2pq)</span>
				<span class="freq-value">{Aa.toFixed(3)}</span>
			</div>
			<div class="freq-item aa-hom">
				<span class="freq-label">aa (q²)</span>
				<span class="freq-value">{aa.toFixed(3)}</span>
			</div>
		</div>

		<p class="diagram-caption">
			The HWE parabola shows maximum heterozygosity (2pq = 0.5) at p = q = 0.5
		</p>
	</div>

	<h2>Assumptions of Hardy-Weinberg</h2>

	<p>The equilibrium holds under these idealized conditions:</p>

	<ol>
		<li><strong>No mutation</strong> — allele frequencies are not altered by new mutations</li>
		<li><strong>Random mating</strong> — individuals pair by chance, not by genotype</li>
		<li><strong>No selection</strong> — all genotypes have equal fitness</li>
		<li><strong>Infinite population size</strong> — no genetic drift</li>
		<li><strong>No gene flow</strong> — no migration in or out of the population</li>
	</ol>

	<div class="note">
		In reality, no natural population perfectly meets these conditions. The value of HWE lies in its
		use as a <em>baseline</em> for detecting and measuring evolutionary forces.
	</div>

	<h2>Reaching Equilibrium</h2>

	<p>
		A remarkable property of HWE is that <strong>equilibrium is reached in a single generation</strong> of
		random mating, regardless of the initial genotype frequencies. This happens because:
	</p>

	<ol>
		<li>Allele frequencies (p and q) are determined by the previous generation</li>
		<li>Random mating produces all possible diploid combinations</li>
		<li>The resulting genotype frequencies are exactly p², 2pq, and q²</li>
	</ol>

	<h2>Applications</h2>

	<h3>Testing for HWE</h3>
	<p>
		The chi-square test compares observed genotype frequencies to expected HWE frequencies.
		Significant deviations suggest non-random mating, selection, or population structure.
	</p>

	<h3>Estimating Carrier Frequencies</h3>
	<p>
		For rare recessive diseases, if the disease frequency (q²) is known, we can estimate:
	</p>
	<ul>
		<li>The recessive allele frequency: q = √(disease frequency)</li>
		<li>The carrier frequency: 2pq ≈ 2q (when q is small)</li>
	</ul>

	<div class="equation">
		If q² = 0.0001 (1 in 10,000 affected)
		<br />
		Then q = 0.01 and carrier frequency ≈ 2%
		<span class="equation-label">Example: estimating carrier frequency</span>
	</div>

	<h3>Forensic Genetics</h3>
	<p>
		HWE is used to calculate genotype probabilities for DNA profiles. When combining probabilities
		across multiple independent loci, HWE provides the foundation for match probability calculations.
	</p>

	<h2>Historical Context</h2>

	<p>
		The Hardy-Weinberg principle resolved a major misconception in early genetics. Critics of Mendelian
		inheritance argued that dominant alleles should eventually "swamp" recessive ones. Hardy and Weinberg
		independently showed that, under neutral conditions, <em>both alleles persist indefinitely</em> at
		their original frequencies.
	</p>

	<p>
		This insight was crucial for the Modern Synthesis, bridging Mendelian genetics with Darwinian
		evolution and establishing population genetics as a quantitative discipline.
	</p>
</TheoryLayout>

<style>
	.diagram-chart {
		width: 100%;
		height: 350px;
	}

	.freq-display {
		display: flex;
		justify-content: center;
		gap: 1.5rem;
		margin-top: 1rem;
		padding: 0.75rem 1rem;
		background: var(--bg);
		border-radius: 4px;
		flex-wrap: wrap;
	}

	.freq-item {
		display: flex;
		flex-direction: column;
		align-items: center;
		gap: 0.25rem;
	}

	.freq-label {
		font-size: 0.7rem;
		color: var(--text-muted);
		text-transform: uppercase;
		letter-spacing: 0.03em;
	}

	.freq-value {
		font-family: var(--font-mono);
		font-size: 1rem;
		font-weight: 600;
		color: var(--text);
	}

	.freq-item.aa .freq-value {
		color: var(--viz-4);
	}

	.freq-item.het .freq-value {
		color: var(--viz-3);
	}

	.freq-item.aa-hom .freq-value {
		color: var(--viz-2);
	}

	.freq-divider {
		width: 1px;
		background: var(--border);
		align-self: stretch;
	}

	@media (max-width: 600px) {
		.diagram-chart {
			height: 280px;
		}

		.freq-display {
			gap: 1rem;
		}

		.freq-value {
			font-size: 0.9rem;
		}
	}
</style>
