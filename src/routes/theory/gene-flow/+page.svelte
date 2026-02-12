<script lang="ts">
	import TheoryLayout from '$lib/components/TheoryLayout.svelte';
	import { theme } from '$lib/theme';
	import * as d3 from 'd3';

	// Interactive diagram state
	let container: HTMLDivElement;

	// Parameters
	let m = $state(0.05); // Migration rate
	let pContinent = $state(0.8); // Continent allele frequency
	let pIsland0 = $state(0.2); // Initial island frequency

	// Calculate trajectory
	let trajectory = $derived(() => {
		const points = [];
		let p = pIsland0;
		const generations = 100;

		for (let t = 0; t <= generations; t++) {
			points.push({ t, p, pC: pContinent });
			// Change: dp = m(pC - p)
			const dp = m * (pContinent - p);
			p = p + dp;
		}
		return points;
	});

	// Equilibrium (equals continent frequency)
	let pEquilibrium = $derived(pContinent);

	// Half-life to equilibrium
	let halfLife = $derived(Math.log(2) / m);

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

		const margin = { top: 20, right: 30, bottom: 50, left: 50 };
		const iw = w - margin.left - margin.right;
		const ih = h - margin.top - margin.bottom;

		const svg = d3.select(container)
			.append('svg')
			.attr('width', w)
			.attr('height', h);

		const g = svg.append('g')
			.attr('transform', `translate(${margin.left},${margin.top})`);

		// Scales
		const x = d3.scaleLinear().domain([0, 100]).range([0, iw]);
		const y = d3.scaleLinear().domain([0, 1]).range([ih, 0]);

		// Grid
		[0.25, 0.5, 0.75].forEach(v => {
			g.append('line')
				.attr('x1', 0).attr('x2', iw)
				.attr('y1', y(v)).attr('y2', y(v))
				.attr('stroke', gridColor)
				.attr('stroke-dasharray', '3,5');
		});

		// Continent frequency line
		g.append('line')
			.attr('x1', 0).attr('x2', iw)
			.attr('y1', y(pContinent)).attr('y2', y(pContinent))
			.attr('stroke', viz2)
			.attr('stroke-width', 2)
			.attr('stroke-dasharray', '8,4');

		// Half-life marker
		if (halfLife <= 100) {
			const halfwayP = pIsland0 + (pContinent - pIsland0) / 2;
			g.append('line')
				.attr('x1', x(halfLife)).attr('x2', x(halfLife))
				.attr('y1', y(0)).attr('y2', y(1))
				.attr('stroke', viz3)
				.attr('stroke-width', 1)
				.attr('stroke-dasharray', '4,4')
				.attr('opacity', 0.6);

			g.append('text')
				.attr('x', x(halfLife))
				.attr('y', 12)
				.attr('text-anchor', 'middle')
				.attr('font-size', '9px')
				.attr('fill', viz3)
				.text(`t½ = ${halfLife.toFixed(1)}`);
		}

		// Axes
		g.append('g')
			.attr('transform', `translate(0,${ih})`)
			.call(d3.axisBottom(x).ticks(5))
			.attr('color', axisColor)
			.selectAll('text')
			.attr('fill', labelColor);

		g.append('g')
			.call(d3.axisLeft(y).ticks(5))
			.attr('color', axisColor)
			.selectAll('text')
			.attr('fill', labelColor);

		// Axis labels
		svg.append('text')
			.attr('x', margin.left + iw / 2)
			.attr('y', h - 8)
			.attr('text-anchor', 'middle')
			.attr('font-size', '11px')
			.attr('fill', labelColor)
			.text('Generation');

		svg.append('text')
			.attr('transform', 'rotate(-90)')
			.attr('x', -(margin.top + ih / 2))
			.attr('y', 15)
			.attr('text-anchor', 'middle')
			.attr('font-size', '11px')
			.attr('fill', labelColor)
			.text('Allele Frequency (p)');

		// Island trajectory
		const line = d3.line<{ t: number; p: number }>()
			.x(d => x(d.t))
			.y(d => y(d.p));

		g.append('path')
			.datum(trajectory())
			.attr('fill', 'none')
			.attr('stroke', viz1)
			.attr('stroke-width', 2.5)
			.attr('d', line);

		// Legend
		g.append('line')
			.attr('x1', iw - 100).attr('x2', iw - 80)
			.attr('y1', 15).attr('y2', 15)
			.attr('stroke', viz1)
			.attr('stroke-width', 2);
		g.append('text')
			.attr('x', iw - 75)
			.attr('y', 18)
			.attr('font-size', '9px')
			.attr('fill', textColor)
			.text('Island');

		g.append('line')
			.attr('x1', iw - 100).attr('x2', iw - 80)
			.attr('y1', 30).attr('y2', 30)
			.attr('stroke', viz2)
			.attr('stroke-width', 2)
			.attr('stroke-dasharray', '4,2');
		g.append('text')
			.attr('x', iw - 75)
			.attr('y', 33)
			.attr('font-size', '9px')
			.attr('fill', textColor)
			.text('Continent');

		// Starting point
		g.append('circle')
			.attr('cx', x(0))
			.attr('cy', y(pIsland0))
			.attr('r', 5)
			.attr('fill', viz1);
	}

	$effect(() => {
		void m;
		void pContinent;
		void pIsland0;
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
	title="Gene Flow & Population Structure"
	subtitle="Migration and its effects on genetic differentiation"
	simLinks={[
		{ href: '/gene-flow/continent-island', label: 'Continent-Island' },
		{ href: '/gene-flow/f-statistics', label: 'F-Statistics' }
	]}
>
	<h2>Gene Flow and Migration</h2>

	<p>
		<strong>Gene flow</strong> is the transfer of alleles between populations through migration.
		It is a homogenizing force — gene flow tends to make populations more similar to each other,
		counteracting the diversifying effects of drift and local selection.
	</p>

	<div class="note">
		<strong>Key insight:</strong> Gene flow reduces genetic differentiation between populations.
		Even a small amount of migration can prevent populations from diverging substantially.
	</div>

	<h2>Continent-Island Model</h2>

	<p>
		The simplest migration model assumes one-way gene flow from a large "continent" population to
		a small "island" population:
	</p>

	<div class="equation">
		p'(island) = (1-m)p + m×p_C
		<span class="equation-label">Island frequency after migration</span>
	</div>

	<p>
		Where <span class="var">m</span> is the fraction of the island replaced by migrants each generation,
		and <span class="var">p_C</span> is the continent allele frequency.
	</p>

	<p>The change in island frequency is:</p>

	<div class="equation">
		Δp = m(p_C - p)
		<span class="equation-label">Change due to migration</span>
	</div>

	<h2>Interactive Migration Dynamics</h2>

	<p>
		Adjust migration rate and population frequencies to see how the island population converges
		toward the continent frequency over time.
	</p>

	<div class="controls">
		<div class="control-group">
			<label for="mRate">Migration rate (m)</label>
			<input id="mRate" type="range" min="0.01" max="0.2" step="0.01" bind:value={m} />
			<span class="control-value">{m.toFixed(2)}</span>
		</div>
		<div class="control-group">
			<label for="pC">Continent p</label>
			<input id="pC" type="range" min="0" max="1" step="0.05" bind:value={pContinent} />
			<span class="control-value">{pContinent.toFixed(2)}</span>
		</div>
		<div class="control-group">
			<label for="p0">Initial island p</label>
			<input id="p0" type="range" min="0" max="1" step="0.05" bind:value={pIsland0} />
			<span class="control-value">{pIsland0.toFixed(2)}</span>
		</div>
	</div>

	<div class="diagram">
		<div class="diagram-chart" bind:this={container}></div>
		<p class="diagram-caption">
			Island population approaches continent frequency. Half-life = ln(2)/m generations.
		</p>
	</div>

	<h2>Rate of Convergence</h2>

	<p>
		Migration acts quickly compared to mutation but can be slower than selection. The deviation
		from equilibrium decays exponentially:
	</p>

	<div class="equation">
		p(t) - p_C = (p₀ - p_C)(1-m)^t
		<span class="equation-label">Exponential approach to equilibrium</span>
	</div>

	<div class="equation">
		t₁/₂ = ln(2) / m ≈ 0.693 / m
		<span class="equation-label">Half-life of differentiation</span>
	</div>

	<p>
		With m = 0.1 (10% migration), the half-life is only ~7 generations. Even with m = 0.01,
		differentiation halves every 70 generations.
	</p>

	<h2>Island Model</h2>

	<p>
		Wright's island model considers multiple populations exchanging migrants symmetrically.
		Each population receives a fraction <span class="var">m</span> of migrants from a common
		migrant pool with mean allele frequency <span class="var">p̄</span>.
	</p>

	<div class="equation">
		p'ᵢ = (1-m)pᵢ + m×p̄
		<span class="equation-label">Frequency in population i after migration</span>
	</div>

	<h2>F-Statistics</h2>

	<p>
		Wright's F-statistics quantify genetic structure at different levels:
	</p>

	<ul>
		<li><strong>F<sub>IS</sub></strong>: Inbreeding within subpopulations</li>
		<li><strong>F<sub>ST</sub></strong>: Differentiation among subpopulations</li>
		<li><strong>F<sub>IT</sub></strong>: Total inbreeding relative to the whole population</li>
	</ul>

	<div class="equation">
		F_ST = (H_T - H_S) / H_T
		<span class="equation-label">Genetic differentiation index</span>
	</div>

	<p>
		Where H<sub>T</sub> is the expected heterozygosity of the total population and H<sub>S</sub>
		is the mean heterozygosity within subpopulations.
	</p>

	<h2>Migration-Drift Equilibrium</h2>

	<p>
		In finite populations, migration counters drift. At equilibrium under the island model:
	</p>

	<div class="equation">
		F_ST ≈ 1 / (4Nm + 1)
		<span class="equation-label">Equilibrium F_ST (island model)</span>
	</div>

	<p>
		The product <span class="var">Nm</span> (effective number of migrants per generation) determines
		population structure:
	</p>

	<ul>
		<li><strong>Nm &gt;&gt; 1:</strong> Populations are essentially panmictic (F<sub>ST</sub> ≈ 0)</li>
		<li><strong>Nm ≈ 1:</strong> Moderate differentiation (F<sub>ST</sub> ≈ 0.2)</li>
		<li><strong>Nm &lt;&lt; 1:</strong> Strong differentiation (F<sub>ST</sub> approaches 1)</li>
	</ul>

	<div class="note">
		The famous "one migrant per generation" rule: If Nm ≥ 1, populations remain genetically cohesive.
		This is surprisingly little gene flow!
	</div>

	<h2>Wahlund Effect</h2>

	<p>
		When populations with different allele frequencies are pooled, the combined sample shows a
		<strong>deficiency of heterozygotes</strong> relative to Hardy-Weinberg expectations:
	</p>

	<div class="equation">
		H_observed &lt; 2p̄(1-p̄)
		<span class="equation-label">Heterozygote deficiency from population structure</span>
	</div>

	<p>
		This apparent "inbreeding" is purely a sampling artifact — each subpopulation may be in HWE,
		but the pooled sample is not.
	</p>

	<h2>Gene Flow and Local Adaptation</h2>

	<p>
		Gene flow can prevent local adaptation by swamping locally beneficial alleles with maladaptive
		immigrants. The balance depends on the ratio <span class="var">m/s</span>:
	</p>

	<ul>
		<li><strong>m &lt;&lt; s:</strong> Selection overcomes migration; local adaptation possible</li>
		<li><strong>m ≈ s:</strong> Balance between forces; polymorphism maintained</li>
		<li><strong>m &gt;&gt; s:</strong> Migration swamps selection; no local adaptation</li>
	</ul>

	<h2>Real-World Patterns</h2>

	<p>
		Natural populations show a range of gene flow patterns:
	</p>

	<ul>
		<li><strong>Isolation by distance:</strong> Nearby populations more similar than distant ones</li>
		<li><strong>Stepping-stone model:</strong> Migration only between adjacent populations</li>
		<li><strong>Source-sink dynamics:</strong> Asymmetric flow from productive to marginal habitats</li>
		<li><strong>Hybrid zones:</strong> Narrow regions of contact between differentiated populations</li>
	</ul>
</TheoryLayout>

<style>
	.diagram-chart {
		width: 100%;
		height: 280px;
	}

	.controls {
		display: flex;
		flex-wrap: wrap;
		gap: 1.5rem;
		align-items: flex-end;
		margin-bottom: 1rem;
		padding: 1rem;
		background: var(--chart-bg);
		border: 1px solid var(--border);
		border-radius: 6px;
	}

	.control-group {
		display: flex;
		flex-direction: column;
		gap: 0.4rem;
	}

	.control-group label {
		font-size: 0.75rem;
		color: var(--text-muted);
	}

	.control-group input[type="range"] {
		width: 100px;
	}

	.control-value {
		font-family: var(--font-mono);
		font-size: 0.85rem;
		color: var(--text);
		font-weight: 600;
	}

	@media (max-width: 600px) {
		.diagram-chart {
			height: 240px;
		}

		.control-group input[type="range"] {
			width: 80px;
		}
	}
</style>
