<script lang="ts">
	import TheoryLayout from '$lib/components/TheoryLayout.svelte';
	import { theme } from '$lib/theme';
	import * as d3 from 'd3';

	// Interactive diagram state
	let container: HTMLDivElement;

	// Parameters
	let alpha = $state(0.3); // Degree of assortative mating (0 = random, 1 = complete)
	let p0 = $state(0.5); // Initial frequency of A

	// Calculate trajectory with assortative mating
	let trajectory = $derived(() => {
		const points = [];
		let pAA = p0 * p0;
		let pAa = 2 * p0 * (1 - p0);
		let paa = (1 - p0) * (1 - p0);
		const generations = 20;

		for (let t = 0; t <= generations; t++) {
			const p = pAA + pAa / 2;
			const H = pAa; // Heterozygosity
			points.push({ t, pAA, pAa, paa, H });

			// Under positive assortative mating, heterozygotes decrease
			// New genotype frequencies after one generation
			const newPAa = (1 - alpha) * 2 * p * (1 - p); // Random portion
			const newPAA = p * p + alpha * pAa / 4 + (1 - alpha) * p * p - p * p + pAA;
			const newPaa = (1 - p) * (1 - p) + alpha * pAa / 4;

			// Simplified model: H decreases by factor (1 - alpha/2)
			pAa = pAa * (1 - alpha / 2);
			pAA = p - pAa / 2;
			paa = (1 - p) - pAa / 2;
		}
		return points;
	});

	// Equilibrium heterozygosity (approaches 0 for positive assortative mating)
	let Heq = $derived(alpha === 1 ? 0 : 2 * p0 * (1 - p0) * Math.pow(1 - alpha / 2, 50));

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
		const x = d3.scaleLinear().domain([0, 20]).range([0, iw]);
		const y = d3.scaleLinear().domain([0, 1]).range([ih, 0]);

		// Grid
		[0.25, 0.5, 0.75].forEach(v => {
			g.append('line')
				.attr('x1', 0).attr('x2', iw)
				.attr('y1', y(v)).attr('y2', y(v))
				.attr('stroke', gridColor)
				.attr('stroke-dasharray', '3,5');
		});

		// HWE heterozygosity reference line
		const H0 = 2 * p0 * (1 - p0);
		g.append('line')
			.attr('x1', 0).attr('x2', iw)
			.attr('y1', y(H0)).attr('y2', y(H0))
			.attr('stroke', viz2)
			.attr('stroke-width', 1)
			.attr('stroke-dasharray', '6,4')
			.attr('opacity', 0.6);

		g.append('text')
			.attr('x', iw - 5)
			.attr('y', y(H0) - 6)
			.attr('text-anchor', 'end')
			.attr('font-size', '9px')
			.attr('fill', viz2)
			.text(`HWE H = ${H0.toFixed(3)}`);

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
			.text('Heterozygosity (H)');

		// Heterozygosity trajectory
		const line = d3.line<{ t: number; H: number }>()
			.x(d => x(d.t))
			.y(d => y(d.H));

		g.append('path')
			.datum(trajectory())
			.attr('fill', 'none')
			.attr('stroke', viz1)
			.attr('stroke-width', 2.5)
			.attr('d', line);

		// Legend
		g.append('line')
			.attr('x1', 10).attr('x2', 30)
			.attr('y1', 15).attr('y2', 15)
			.attr('stroke', viz1)
			.attr('stroke-width', 2);
		g.append('text')
			.attr('x', 35)
			.attr('y', 18)
			.attr('font-size', '9px')
			.attr('fill', textColor)
			.text('Observed H');

		g.append('line')
			.attr('x1', 10).attr('x2', 30)
			.attr('y1', 30).attr('y2', 30)
			.attr('stroke', viz2)
			.attr('stroke-width', 1)
			.attr('stroke-dasharray', '4,2');
		g.append('text')
			.attr('x', 35)
			.attr('y', 33)
			.attr('font-size', '9px')
			.attr('fill', textColor)
			.text('HWE expected');

		// Starting point
		g.append('circle')
			.attr('cx', x(0))
			.attr('cy', y(H0))
			.attr('r', 5)
			.attr('fill', viz1);
	}

	$effect(() => {
		void alpha;
		void p0;
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
	title="Mating Systems"
	subtitle="Non-random mating and its effects on genotype frequencies"
	simLinks={[
		{ href: '/mating/assortative', label: 'Assortative Mating' },
		{ href: '/mating/assortative-matrix', label: 'Assortative Matrix' }
	]}
>
	<h2>Non-Random Mating</h2>

	<p>
		The Hardy-Weinberg principle assumes <strong>random mating</strong> — individuals pair
		without regard to genotype. In nature, mating is often non-random, which affects genotype
		frequencies without changing allele frequencies.
	</p>

	<div class="note">
		<strong>Key insight:</strong> Non-random mating changes genotype frequencies but does NOT
		change allele frequencies (unless combined with selection).
	</div>

	<h2>Types of Non-Random Mating</h2>

	<h3>Assortative Mating</h3>
	<p>
		<strong>Positive assortative mating:</strong> Like pairs with like (similar phenotypes mate
		more often than expected by chance). This increases homozygosity.
	</p>

	<p>
		<strong>Negative assortative mating (disassortative):</strong> Unlike pairs with unlike
		(dissimilar phenotypes mate more often). This increases heterozygosity.
	</p>

	<h3>Inbreeding</h3>
	<p>
		Mating between relatives increases the probability that offspring receive identical alleles
		from a common ancestor. The <strong>inbreeding coefficient F</strong> measures this:
	</p>

	<div class="equation">
		F = (H<sub>exp</sub> - H<sub>obs</sub>) / H<sub>exp</sub>
		<span class="equation-label">Deviation from HWE heterozygosity</span>
	</div>

	<h2>Effects on Genotype Frequencies</h2>

	<p>
		Under inbreeding or positive assortative mating, genotype frequencies shift from HWE:
	</p>

	<div class="equation">
		P(AA) = p² + Fpq
		<span class="equation-label">Homozygote excess</span>
	</div>

	<div class="equation">
		P(Aa) = 2pq(1-F)
		<span class="equation-label">Heterozygote deficit</span>
	</div>

	<div class="equation">
		P(aa) = q² + Fpq
		<span class="equation-label">Homozygote excess</span>
	</div>

	<h2>Interactive: Assortative Mating Effects</h2>

	<p>
		Adjust the degree of positive assortative mating (α) to see how heterozygosity declines
		over generations. At α = 0, mating is random (HWE maintained). At α = 1, only like genotypes
		mate.
	</p>

	<div class="controls">
		<div class="control-group">
			<label for="alpha">Assortment (α)</label>
			<input id="alpha" type="range" min="0" max="1" step="0.05" bind:value={alpha} />
			<span class="control-value">{alpha.toFixed(2)}</span>
		</div>
		<div class="control-group">
			<label for="p0">Initial p</label>
			<input id="p0" type="range" min="0.1" max="0.9" step="0.05" bind:value={p0} />
			<span class="control-value">{p0.toFixed(2)}</span>
		</div>
	</div>

	<div class="diagram">
		<div class="diagram-chart" bind:this={container}></div>
		<p class="diagram-caption">
			Positive assortative mating reduces heterozygosity while preserving allele frequencies.
		</p>
	</div>

	<h2>Inbreeding Depression</h2>

	<p>
		Increased homozygosity from inbreeding often reduces fitness because:
	</p>

	<ul>
		<li><strong>Deleterious recessives:</strong> Recessive harmful alleles become exposed in homozygotes</li>
		<li><strong>Overdominance:</strong> If heterozygotes are fittest, homozygotes have lower fitness</li>
		<li><strong>Reduced variation:</strong> Less genetic diversity for response to environmental change</li>
	</ul>

	<p>
		This <strong>inbreeding depression</strong> is stronger for fitness-related traits and in
		populations that are normally outbreeding.
	</p>

	<h2>Selfing</h2>

	<p>
		Self-fertilization is the extreme of inbreeding (F approaches 1). After <span class="var">t</span>
		generations of selfing:
	</p>

	<div class="equation">
		H(t) = H₀ × (1/2)^t
		<span class="equation-label">Halving of heterozygosity each generation</span>
	</div>

	<p>
		Heterozygosity halves each generation under complete selfing. After 10 generations, only
		~0.1% of the original heterozygosity remains.
	</p>

	<h2>Outbreeding</h2>

	<p>
		When inbred populations cross, the F1 generation shows <strong>heterosis</strong> (hybrid vigor):
	</p>

	<ul>
		<li><strong>Dominance hypothesis:</strong> Heterozygotes mask deleterious recessives</li>
		<li><strong>Overdominance hypothesis:</strong> Heterozygotes are intrinsically superior</li>
	</ul>

	<p>
		However, crossing very divergent populations can cause <strong>outbreeding depression</strong>
		if locally adapted gene combinations are broken up.
	</p>

	<h2>Practical Implications</h2>

	<ul>
		<li><strong>Conservation:</strong> Small populations risk inbreeding depression</li>
		<li><strong>Agriculture:</strong> Inbred lines crossed for hybrid vigor</li>
		<li><strong>Human genetics:</strong> Consanguineous marriages increase recessive disease risk</li>
		<li><strong>Forensics:</strong> Population structure affects DNA match probabilities</li>
	</ul>

	<div class="note">
		The effective number of breeders and mating system determine how quickly genetic variation
		is lost. Managing mating patterns is crucial for conservation of endangered species.
	</div>
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
