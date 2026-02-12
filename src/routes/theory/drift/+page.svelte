<script lang="ts">
	import TheoryLayout from '$lib/components/TheoryLayout.svelte';
	import { theme } from '$lib/theme';
	import * as d3 from 'd3';

	// Interactive diagram state
	let container: HTMLDivElement;
	let populationSize = $state(20);
	let generations = $state(50);
	let trajectories: number[][] = $state([]);

	// Theoretical variance at generation t
	let expectedVariance = $derived(() => {
		const p0 = 0.5;
		const q0 = 0.5;
		const result = [];
		for (let t = 0; t <= generations; t++) {
			const factor = 1 - Math.pow(1 - 1 / (2 * populationSize), t);
			result.push(p0 * q0 * factor);
		}
		return result;
	});

	function runSimulation() {
		const numPops = 8;
		const p0 = 0.5;
		const N = populationSize;
		const newTrajectories: number[][] = [];

		for (let pop = 0; pop < numPops; pop++) {
			const trajectory = [p0];
			let p = p0;

			for (let gen = 1; gen <= generations; gen++) {
				// Binomial sampling: number of A alleles in next generation
				const alleles = 2 * N;
				let countA = 0;
				for (let i = 0; i < alleles; i++) {
					if (Math.random() < p) countA++;
				}
				p = countA / alleles;
				trajectory.push(p);
			}
			newTrajectories.push(trajectory);
		}

		trajectories = newTrajectories;
	}

	function renderDiagram() {
		if (!container || trajectories.length === 0) return;

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

		const vizColors = [
			style.getPropertyValue('--viz-1').trim(),
			style.getPropertyValue('--viz-2').trim(),
			style.getPropertyValue('--viz-3').trim(),
			style.getPropertyValue('--viz-4').trim(),
			style.getPropertyValue('--viz-5').trim(),
			style.getPropertyValue('--viz-6').trim(),
			style.getPropertyValue('--viz-7').trim(),
			style.getPropertyValue('--viz-8').trim()
		];

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
		const x = d3.scaleLinear().domain([0, generations]).range([0, iw]);
		const y = d3.scaleLinear().domain([0, 1]).range([ih, 0]);

		// Grid
		[0.25, 0.5, 0.75].forEach(v => {
			g.append('line')
				.attr('x1', 0).attr('x2', iw)
				.attr('y1', y(v)).attr('y2', y(v))
				.attr('stroke', gridColor)
				.attr('stroke-dasharray', '3,5');
		});

		// Initial frequency line
		g.append('line')
			.attr('x1', 0).attr('x2', iw)
			.attr('y1', y(0.5)).attr('y2', y(0.5))
			.attr('stroke', labelColor)
			.attr('stroke-width', 1)
			.attr('stroke-dasharray', '5,5');

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
			.attr('y', h - 10)
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

		// Draw trajectories
		const line = d3.line<number>()
			.x((_, i) => x(i))
			.y(d => y(d));

		trajectories.forEach((traj, i) => {
			g.append('path')
				.datum(traj)
				.attr('fill', 'none')
				.attr('stroke', vizColors[i % vizColors.length])
				.attr('stroke-width', 1.5)
				.attr('opacity', 0.8)
				.attr('d', line);

			// Mark fixation/loss
			const final = traj[traj.length - 1];
			if (final >= 0.999 || final <= 0.001) {
				g.append('circle')
					.attr('cx', x(generations))
					.attr('cy', y(final >= 0.999 ? 1 : 0))
					.attr('r', 4)
					.attr('fill', vizColors[i % vizColors.length]);
			}
		});

		// Count fixations/losses
		let fixed = 0, lost = 0;
		trajectories.forEach(traj => {
			const final = traj[traj.length - 1];
			if (final >= 0.999) fixed++;
			else if (final <= 0.001) lost++;
		});

		// Stats box
		g.append('text')
			.attr('x', iw - 5)
			.attr('y', 15)
			.attr('text-anchor', 'end')
			.attr('font-size', '10px')
			.attr('fill', textColor)
			.text(`Fixed: ${fixed}  Lost: ${lost}  Polymorphic: ${trajectories.length - fixed - lost}`);
	}

	// Initial run
	$effect(() => {
		runSimulation();
	});

	$effect(() => {
		void trajectories;
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
	title="Genetic Drift"
	subtitle="Random changes in allele frequencies"
	simLinks={[
		{ href: '/drift', label: 'Pure Drift' },
		{ href: '/drift/markov', label: 'Markov Chain' }
	]}
>
	<h2>What is Genetic Drift?</h2>

	<p>
		Genetic drift is the random change in allele frequencies from one generation to the next due to
		<strong>chance events in reproduction</strong>. Unlike natural selection, drift is not driven by
		differences in fitness — it's the result of random sampling when gametes form the next generation.
	</p>

	<div class="note">
		<strong>Key insight:</strong> Drift is most powerful in small populations. In an infinite population,
		random fluctuations cancel out. In small populations, they can dramatically change allele frequencies.
	</div>

	<h2>The Wright-Fisher Model</h2>

	<p>
		The standard model of genetic drift, developed by Sewall Wright and R.A. Fisher, treats each generation
		as <strong>binomial sampling</strong> from the previous generation's allele frequencies.
	</p>

	<div class="equation">
		P(i → j) = C(2N, j) × p^j × (1-p)^(2N-j)
		<span class="equation-label">Transition probability: i alleles → j alleles</span>
	</div>

	<p>
		Where <span class="var">N</span> is the population size and <span class="var">p = i/2N</span>
		is the current allele frequency. This binomial sampling causes allele frequencies to fluctuate
		randomly each generation.
	</p>

	<h2>Interactive Simulation</h2>

	<p>
		Watch how drift affects multiple populations starting at the same allele frequency. Each colored line
		represents an independent population. <strong>Smaller populations show more dramatic fluctuations.</strong>
	</p>

	<div class="controls">
		<div class="control-group">
			<label for="popSize">Population Size (N)</label>
			<input
				id="popSize"
				type="range"
				min="5"
				max="100"
				bind:value={populationSize}
				onchange={() => runSimulation()}
			/>
			<span class="control-value">{populationSize}</span>
		</div>
		<div class="control-group">
			<label for="gens">Generations</label>
			<input
				id="gens"
				type="range"
				min="20"
				max="200"
				bind:value={generations}
				onchange={() => runSimulation()}
			/>
			<span class="control-value">{generations}</span>
		</div>
		<button class="btn-resim" onclick={() => runSimulation()}>
			Re-run
		</button>
	</div>

	<div class="diagram">
		<div class="diagram-chart" bind:this={container}></div>
		<p class="diagram-caption">
			8 populations with p₀ = 0.5. Triangles mark fixation (p=1) or loss (p=0).
		</p>
	</div>

	<h2>Key Properties of Drift</h2>

	<h3>Expected Frequency Unchanged</h3>
	<p>
		Despite random fluctuations, the <em>expected</em> allele frequency remains constant:
	</p>

	<div class="equation">
		E[p(t)] = p₀
		<span class="equation-label">Drift doesn't bias allele frequencies</span>
	</div>

	<h3>Variance Increases Over Time</h3>
	<p>
		While the mean stays constant, the variance in allele frequency across replicate populations grows:
	</p>

	<div class="equation">
		Var[p(t)] = p₀q₀[1 - (1 - 1/2N)^t]
		<span class="equation-label">Variance approaches p₀q₀ as t → ∞</span>
	</div>

	<h3>Fixation is Inevitable</h3>
	<p>
		Given enough time, drift will eventually fix one allele (p = 1) and lose the other (p = 0).
		The probability of fixation equals the initial frequency:
	</p>

	<div class="equation">
		P(fixation) = p₀
		<span class="equation-label">Probability of allele A eventually fixing</span>
	</div>

	<h2>Time to Fixation</h2>

	<p>
		How long does fixation take? On average, starting from frequency <span class="var">p</span>:
	</p>

	<div class="equation">
		t̄(fixation) ≈ 4N generations
		<span class="equation-label">Mean time to fixation (starting from p = 0.5)</span>
	</div>

	<p>
		This means larger populations maintain genetic variation longer. A population of 1000 individuals
		would take roughly 4000 generations to fix an allele by drift alone.
	</p>

	<h2>Heterozygosity Decline</h2>

	<p>
		Drift causes heterozygosity to decline over generations. Starting with expected heterozygosity
		H₀ = 2p₀q₀:
	</p>

	<div class="equation">
		H(t) = H₀(1 - 1/2N)^t
		<span class="equation-label">Deterministic heterozygosity decay</span>
	</div>

	<p>
		Each generation, heterozygosity decreases by a factor of 1/(2N). Small populations lose variation
		quickly; large populations retain it longer.
	</p>

	<h2>Effective Population Size</h2>

	<p>
		Real populations often don't match Wright-Fisher assumptions. The <strong>effective population size</strong>
		(Nₑ) is the size of an idealized population that would experience drift at the same rate.
	</p>

	<p>Nₑ is reduced by:</p>
	<ul>
		<li><strong>Unequal sex ratios:</strong> Nₑ = 4NₘNf / (Nₘ + Nf)</li>
		<li><strong>Variance in reproductive success:</strong> populations with unequal contribution</li>
		<li><strong>Population fluctuations:</strong> bottlenecks have lasting effects</li>
		<li><strong>Inbreeding:</strong> reduces the number of independent lineages</li>
	</ul>

	<div class="note">
		Effective population size is often much smaller than census population size. Humans have Nₑ ≈ 10,000
		despite a census size of billions — reflecting our recent population expansion and historical bottlenecks.
	</div>

	<h2>Drift vs. Selection</h2>

	<p>
		When is drift important relative to selection? The key parameter is the product <span class="var">Ns</span>,
		where <span class="var">s</span> is the selection coefficient:
	</p>

	<ul>
		<li><strong>|Ns| &lt;&lt; 1:</strong> Drift dominates — selection is effectively neutral</li>
		<li><strong>|Ns| ≈ 1:</strong> Both forces matter — complex dynamics</li>
		<li><strong>|Ns| &gt;&gt; 1:</strong> Selection dominates — drift is negligible</li>
	</ul>

	<p>
		In small populations, even moderately selected alleles can be lost by chance. In large populations,
		even tiny selective differences eventually determine outcomes.
	</p>
</TheoryLayout>

<style>
	.diagram-chart {
		width: 100%;
		height: 320px;
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
		font-size: 0.7rem;
		color: var(--text-muted);
		text-transform: uppercase;
		letter-spacing: 0.03em;
	}

	.control-group input[type="range"] {
		width: 120px;
	}

	.control-value {
		font-family: var(--font-mono);
		font-size: 0.85rem;
		color: var(--text);
		font-weight: 600;
	}

	.btn-resim {
		padding: 0.4rem 0.8rem;
		font-size: 0.75rem;
		font-weight: 500;
		background: var(--accent);
		color: var(--accent-text);
		border: none;
		border-radius: 4px;
		cursor: pointer;
		transition: opacity 0.15s;
	}

	.btn-resim:hover {
		opacity: 0.9;
	}

	@media (max-width: 600px) {
		.diagram-chart {
			height: 260px;
		}

		.controls {
			gap: 1rem;
		}

		.control-group input[type="range"] {
			width: 100px;
		}
	}
</style>
