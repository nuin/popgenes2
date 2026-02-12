<script lang="ts">
	import TheoryLayout from '$lib/components/TheoryLayout.svelte';
	import { theme } from '$lib/theme';
	import * as d3 from 'd3';

	// Interactive diagram state
	let container: HTMLDivElement;

	// Mutation rates
	let mu = $state(0.0001); // A → a
	let nu = $state(0.00002); // a → A

	// Calculate equilibrium
	let pEquilibrium = $derived(nu / (mu + nu));

	// Generate trajectory
	let trajectory = $derived(() => {
		const points = [];
		let p = 0.9; // Start with high frequency of A
		const generations = 500;

		for (let t = 0; t <= generations; t++) {
			points.push({ t, p });
			// Change in p due to mutation: dp = -μp + ν(1-p)
			const dp = -mu * p + nu * (1 - p);
			p = Math.max(0, Math.min(1, p + dp));
		}
		return points;
	});

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
		const x = d3.scaleLinear().domain([0, 500]).range([0, iw]);
		const y = d3.scaleLinear().domain([0, 1]).range([ih, 0]);

		// Grid
		[0.25, 0.5, 0.75].forEach(v => {
			g.append('line')
				.attr('x1', 0).attr('x2', iw)
				.attr('y1', y(v)).attr('y2', y(v))
				.attr('stroke', gridColor)
				.attr('stroke-dasharray', '3,5');
		});

		// Equilibrium line
		g.append('line')
			.attr('x1', 0).attr('x2', iw)
			.attr('y1', y(pEquilibrium)).attr('y2', y(pEquilibrium))
			.attr('stroke', viz2)
			.attr('stroke-width', 2)
			.attr('stroke-dasharray', '8,4');

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
			.text('Frequency of A (p)');

		// Trajectory
		const line = d3.line<{ t: number; p: number }>()
			.x(d => x(d.t))
			.y(d => y(d.p));

		g.append('path')
			.datum(trajectory())
			.attr('fill', 'none')
			.attr('stroke', viz1)
			.attr('stroke-width', 2)
			.attr('d', line);

		// Equilibrium label
		g.append('text')
			.attr('x', iw - 5)
			.attr('y', y(pEquilibrium) - 8)
			.attr('text-anchor', 'end')
			.attr('font-size', '10px')
			.attr('fill', viz2)
			.text(`p̂ = ${pEquilibrium.toFixed(4)}`);

		// Starting point
		g.append('circle')
			.attr('cx', x(0))
			.attr('cy', y(0.9))
			.attr('r', 5)
			.attr('fill', viz1);
	}

	$effect(() => {
		void mu;
		void nu;
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
	title="Mutation"
	subtitle="The ultimate source of genetic variation"
	simLinks={[
		{ href: '/mutation', label: 'Two-Way Mutation' },
		{ href: '/mutation/irreversible', label: 'Irreversible' }
	]}
>
	<h2>Mutation as an Evolutionary Force</h2>

	<p>
		Mutation is the only source of <strong>new genetic variation</strong>. Without mutation, evolution
		would eventually stop as selection and drift fix alleles. However, mutation alone is a weak
		evolutionary force — it takes many generations to appreciably change allele frequencies.
	</p>

	<div class="note">
		<strong>Key insight:</strong> Mutation provides the raw material for evolution. Selection, drift,
		and gene flow then shape how that variation changes over time.
	</div>

	<h2>Mutation Rates</h2>

	<p>
		The <strong>mutation rate</strong> (μ) is the probability that an allele mutates per generation.
		For most genes, rates are on the order of 10⁻⁴ to 10⁻⁸ per generation.
	</p>

	<ul>
		<li><strong>Point mutations:</strong> ~10⁻⁸ per base pair per generation</li>
		<li><strong>Gene-level mutations:</strong> ~10⁻⁵ to 10⁻⁶ per gene per generation</li>
		<li><strong>Structural variants:</strong> Higher rates, more variable</li>
	</ul>

	<h2>Two-Way Mutation Model</h2>

	<p>
		In the simplest model, mutations occur in both directions:
	</p>

	<div class="equation">
		A →(μ) a  and  a →(ν) A
		<span class="equation-label">Forward (μ) and back (ν) mutation</span>
	</div>

	<p>
		The change in allele frequency per generation is:
	</p>

	<div class="equation">
		Δp = -μp + ν(1-p)
		<span class="equation-label">Change due to bidirectional mutation</span>
	</div>

	<p>
		At equilibrium (Δp = 0):
	</p>

	<div class="equation">
		p̂ = ν / (μ + ν)
		<span class="equation-label">Mutation equilibrium frequency</span>
	</div>

	<h2>Interactive Mutation Dynamics</h2>

	<p>
		Adjust mutation rates to see how allele frequencies change over time. Notice how slowly
		mutation changes frequencies compared to selection or drift.
	</p>

	<div class="controls">
		<div class="control-group">
			<label for="mu">μ (A→a)</label>
			<input id="mu" type="range" min="0.00001" max="0.001" step="0.00001" bind:value={mu} />
			<span class="control-value">{mu.toFixed(5)}</span>
		</div>
		<div class="control-group">
			<label for="nu">ν (a→A)</label>
			<input id="nu" type="range" min="0.00001" max="0.001" step="0.00001" bind:value={nu} />
			<span class="control-value">{nu.toFixed(5)}</span>
		</div>
		<div class="control-group eq-display">
			<span class="eq-label">Equilibrium p̂</span>
			<span class="eq-value">{pEquilibrium.toFixed(4)}</span>
		</div>
	</div>

	<div class="diagram">
		<div class="diagram-chart" bind:this={container}></div>
		<p class="diagram-caption">
			Starting from p = 0.9, the population slowly approaches mutation equilibrium.
		</p>
	</div>

	<h2>Time Scale of Mutation</h2>

	<p>
		Mutation is slow! The half-life for approaching equilibrium is:
	</p>

	<div class="equation">
		t₁/₂ ≈ 0.693 / (μ + ν)
		<span class="equation-label">Half-life of approach to equilibrium</span>
	</div>

	<p>
		With typical mutation rates (μ ≈ 10⁻⁵), this means tens of thousands of generations — far longer
		than most evolutionary changes we observe.
	</p>

	<h2>Irreversible Mutation</h2>

	<p>
		When back mutation is negligible (ν ≈ 0), the model simplifies:
	</p>

	<div class="equation">
		p(t) = p₀ × e^(-μt)
		<span class="equation-label">Exponential decay under irreversible mutation</span>
	</div>

	<p>
		The favored allele A declines exponentially toward loss. This applies when one allele mutates
		to many possible forms but the reverse is unlikely.
	</p>

	<h2>Mutation-Selection Balance</h2>

	<p>
		In reality, most mutations are deleterious. Selection removes them, but mutation keeps
		introducing them, creating a dynamic equilibrium:
	</p>

	<div class="equation">
		q̂ ≈ μ/s (for recessive mutations)
		<span class="equation-label">Equilibrium frequency of deleterious allele</span>
	</div>

	<div class="equation">
		q̂ ≈ μ/(hs) (for partially dominant mutations)
		<span class="equation-label">When deleterious effects are partially dominant</span>
	</div>

	<p>
		This explains the <strong>genetic load</strong> — populations carry many slightly deleterious
		alleles at low frequencies.
	</p>

	<h2>Neutral Mutations</h2>

	<p>
		Most mutations that persist are <strong>neutral</strong> — they have no effect on fitness.
		Neutral theory (Kimura, 1968) shows that:
	</p>

	<ul>
		<li>Rate of neutral substitution equals the mutation rate: k = μ</li>
		<li>Most variation within populations is selectively neutral</li>
		<li>Drift, not selection, determines the fate of neutral alleles</li>
	</ul>

	<div class="equation">
		k = μ (substitution rate = mutation rate)
		<span class="equation-label">Neutral theory prediction</span>
	</div>

	<div class="note">
		The molecular clock arises from neutral theory: if substitutions occur at rate μ, sequence
		divergence between species reflects time since their common ancestor.
	</div>

	<h2>Mutation in Finite Populations</h2>

	<p>
		In real populations, new mutations start at frequency 1/(2N). Their fate depends on selection:
	</p>

	<ul>
		<li><strong>Neutral:</strong> Probability of fixation = 1/(2N)</li>
		<li><strong>Beneficial (s &gt; 0):</strong> Probability ≈ 2s (when Ns &gt;&gt; 1)</li>
		<li><strong>Deleterious:</strong> Usually lost quickly</li>
	</ul>

	<p>
		The expected number of new mutations entering a population per generation is:
	</p>

	<div class="equation">
		2Nμ (new mutations per generation)
		<span class="equation-label">Input of new variation</span>
	</div>

	<h2>Types of Mutations</h2>

	<h3>Point Mutations</h3>
	<ul>
		<li><strong>Synonymous:</strong> No amino acid change (usually neutral)</li>
		<li><strong>Nonsynonymous:</strong> Amino acid change (variable effects)</li>
		<li><strong>Nonsense:</strong> Creates stop codon (usually deleterious)</li>
	</ul>

	<h3>Structural Mutations</h3>
	<ul>
		<li><strong>Deletions/Insertions:</strong> Remove or add DNA</li>
		<li><strong>Duplications:</strong> Can create new gene copies</li>
		<li><strong>Inversions:</strong> Reverse segment orientation</li>
		<li><strong>Translocations:</strong> Move segments between chromosomes</li>
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
		width: 120px;
	}

	.control-value {
		font-family: var(--font-mono);
		font-size: 0.8rem;
		color: var(--text);
		font-weight: 600;
	}

	.eq-display {
		padding: 0.5rem 1rem;
		background: var(--bg);
		border-radius: 4px;
	}

	.eq-label {
		font-size: 0.7rem;
		color: var(--text-muted);
		display: block;
	}

	.eq-value {
		font-family: var(--font-mono);
		font-size: 1rem;
		color: var(--viz-2);
		font-weight: 600;
	}

	@media (max-width: 600px) {
		.diagram-chart {
			height: 240px;
		}

		.control-group input[type="range"] {
			width: 100px;
		}
	}
</style>
