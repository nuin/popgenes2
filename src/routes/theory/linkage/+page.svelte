<script lang="ts">
	import TheoryLayout from '$lib/components/TheoryLayout.svelte';
	import { theme } from '$lib/theme';
	import * as d3 from 'd3';

	// Interactive diagram state
	let container: HTMLDivElement;

	// Parameters
	let r = $state(0.1); // Recombination rate
	let D0 = $state(0.2); // Initial D

	// Calculate D decay
	let trajectory = $derived(() => {
		const points = [];
		const generations = 50;

		for (let t = 0; t <= generations; t++) {
			const D = D0 * Math.pow(1 - r, t);
			points.push({ t, D });
		}
		return points;
	});

	// Half-life
	let halfLife = $derived(Math.log(2) / Math.log(1 / (1 - r)));

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
		const x = d3.scaleLinear().domain([0, 50]).range([0, iw]);
		const y = d3.scaleLinear().domain([0, D0 * 1.1]).range([ih, 0]);

		// Grid
		g.append('line')
			.attr('x1', 0).attr('x2', iw)
			.attr('y1', y(D0 / 2)).attr('y2', y(D0 / 2))
			.attr('stroke', gridColor)
			.attr('stroke-dasharray', '3,5');

		// Equilibrium line (D = 0)
		g.append('line')
			.attr('x1', 0).attr('x2', iw)
			.attr('y1', y(0)).attr('y2', y(0))
			.attr('stroke', viz2)
			.attr('stroke-width', 1);

		// Half-life marker
		if (halfLife <= 50) {
			g.append('line')
				.attr('x1', x(halfLife)).attr('x2', x(halfLife))
				.attr('y1', y(0)).attr('y2', y(D0))
				.attr('stroke', viz3)
				.attr('stroke-width', 1)
				.attr('stroke-dasharray', '4,4')
				.attr('opacity', 0.7);

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
			.text('Linkage Disequilibrium (D)');

		// D decay curve
		const line = d3.line<{ t: number; D: number }>()
			.x(d => x(d.t))
			.y(d => y(d.D));

		g.append('path')
			.datum(trajectory())
			.attr('fill', 'none')
			.attr('stroke', viz1)
			.attr('stroke-width', 2.5)
			.attr('d', line);

		// Starting point
		g.append('circle')
			.attr('cx', x(0))
			.attr('cy', y(D0))
			.attr('r', 5)
			.attr('fill', viz1);

		// D₀ label
		g.append('text')
			.attr('x', x(0) + 8)
			.attr('y', y(D0) + 4)
			.attr('font-size', '10px')
			.attr('fill', textColor)
			.text(`D₀ = ${D0.toFixed(2)}`);
	}

	$effect(() => {
		void r;
		void D0;
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
	title="Linkage Disequilibrium"
	subtitle="Non-random association of alleles at different loci"
	simLinks={[
		{ href: '/linkage/disequilibrium', label: 'Gamete Frequencies' },
		{ href: '/linkage/magnitude', label: 'D Decay' }
	]}
>
	<h2>What is Linkage Disequilibrium?</h2>

	<p>
		<strong>Linkage disequilibrium</strong> (LD) occurs when alleles at different loci are associated
		non-randomly. If knowing the allele at one locus tells you something about the allele at another
		locus, those loci are in LD.
	</p>

	<div class="note">
		<strong>Key insight:</strong> Despite the name, linkage disequilibrium doesn't require physical
		linkage. Any non-random association creates LD, though it decays faster for unlinked loci.
	</div>

	<h2>Gamete Frequencies</h2>

	<p>
		Consider two biallelic loci: A/a and B/b. There are four possible gamete types:
	</p>

	<div class="gamete-table">
		<div class="gamete-row header">
			<span>Gamete</span>
			<span>Frequency</span>
			<span>Expected (equilibrium)</span>
		</div>
		<div class="gamete-row">
			<span class="gamete">AB</span>
			<span>x₁₁</span>
			<span>p_A × p_B</span>
		</div>
		<div class="gamete-row">
			<span class="gamete">Ab</span>
			<span>x₁₂</span>
			<span>p_A × q_B</span>
		</div>
		<div class="gamete-row">
			<span class="gamete">aB</span>
			<span>x₂₁</span>
			<span>q_A × p_B</span>
		</div>
		<div class="gamete-row">
			<span class="gamete">ab</span>
			<span>x₂₂</span>
			<span>q_A × q_B</span>
		</div>
	</div>

	<p>
		At <strong>linkage equilibrium</strong>, gamete frequencies equal the products of allele frequencies.
		Any deviation from this is disequilibrium.
	</p>

	<h2>Measuring LD: The D Statistic</h2>

	<p>
		The coefficient of linkage disequilibrium, <span class="var">D</span>, measures the departure
		from equilibrium:
	</p>

	<div class="equation">
		D = x₁₁ × x₂₂ - x₁₂ × x₂₁
		<span class="equation-label">Coefficient of linkage disequilibrium</span>
	</div>

	<p>Equivalently:</p>

	<div class="equation">
		D = x₁₁ - p_A × p_B
		<span class="equation-label">Deviation of AB gamete from expectation</span>
	</div>

	<ul>
		<li><strong>D = 0:</strong> Linkage equilibrium (random association)</li>
		<li><strong>D &gt; 0:</strong> Coupling phase excess (AB and ab more common)</li>
		<li><strong>D &lt; 0:</strong> Repulsion phase excess (Ab and aB more common)</li>
	</ul>

	<h2>Decay of LD</h2>

	<p>
		Recombination breaks down LD over time. With recombination rate <span class="var">r</span>
		between loci:
	</p>

	<div class="equation">
		D(t) = D₀ × (1-r)^t
		<span class="equation-label">Exponential decay of LD</span>
	</div>

	<p>
		The half-life of LD is:
	</p>

	<div class="equation">
		t₁/₂ = ln(2) / ln(1/(1-r)) ≈ 0.693/r
		<span class="equation-label">Half-life of linkage disequilibrium</span>
	</div>

	<h2>Interactive LD Decay</h2>

	<p>
		Adjust the recombination rate to see how quickly LD decays. Tightly linked loci (low r)
		maintain LD much longer than loosely linked or unlinked loci.
	</p>

	<div class="controls">
		<div class="control-group">
			<label for="recomb">Recombination rate (r)</label>
			<input id="recomb" type="range" min="0.01" max="0.5" step="0.01" bind:value={r} />
			<span class="control-value">{r.toFixed(2)}</span>
		</div>
		<div class="control-group">
			<label for="d0">Initial D</label>
			<input id="d0" type="range" min="0.05" max="0.25" step="0.01" bind:value={D0} />
			<span class="control-value">{D0.toFixed(2)}</span>
		</div>
		<div class="control-group info">
			<span class="info-label">Half-life</span>
			<span class="info-value">{halfLife.toFixed(1)} gen</span>
		</div>
	</div>

	<div class="diagram">
		<div class="diagram-chart" bind:this={container}></div>
		<p class="diagram-caption">
			LD decays exponentially toward zero. Free recombination (r = 0.5) gives fastest decay.
		</p>
	</div>

	<h2>Normalized Measures</h2>

	<p>
		Because D depends on allele frequencies, normalized measures are often used:
	</p>

	<h3>D' (D-prime)</h3>
	<div class="equation">
		D' = D / D_max
		<span class="equation-label">Ranges from -1 to +1</span>
	</div>
	<p>
		Where D<sub>max</sub> is the maximum possible D given the allele frequencies.
		|D'| = 1 indicates no recombination has occurred between these alleles.
	</p>

	<h3>r² (Correlation)</h3>
	<div class="equation">
		r² = D² / (p_A × q_A × p_B × q_B)
		<span class="equation-label">Squared correlation coefficient</span>
	</div>
	<p>
		Ranges from 0 to 1. Used extensively in GWAS for determining tagging power of SNPs.
	</p>

	<h2>Sources of LD</h2>

	<h3>Population Processes</h3>
	<ul>
		<li><strong>Genetic drift:</strong> Random associations accumulate in finite populations</li>
		<li><strong>Population admixture:</strong> Mixing populations with different allele frequencies</li>
		<li><strong>Population bottlenecks:</strong> Founder effects create LD from sampling</li>
		<li><strong>Selection:</strong> Hitchhiking of linked variants with selected allele</li>
	</ul>

	<h3>Genomic Factors</h3>
	<ul>
		<li><strong>Physical linkage:</strong> Nearby loci have low recombination rates</li>
		<li><strong>Chromosomal inversions:</strong> Suppress recombination in heterozygotes</li>
		<li><strong>Epistatic selection:</strong> Favorable allele combinations maintained</li>
	</ul>

	<div class="note">
		New mutations arise in complete LD with all other variants on the same chromosome.
		This LD erodes over time through recombination, creating a "molecular clock" for
		estimating mutation age.
	</div>

	<h2>LD in Population Genetics</h2>

	<h3>Genetic Mapping</h3>
	<p>
		LD is the basis of association mapping. Disease-causing variants are identified through their
		LD with nearby marker loci — we don't need to genotype the causal variant itself if we can
		detect a linked marker.
	</p>

	<h3>Haplotype Structure</h3>
	<p>
		Regions of high LD form <strong>haplotype blocks</strong> — sets of alleles that are inherited
		together. Block boundaries occur where recombination is common.
	</p>

	<h3>Selective Sweeps</h3>
	<p>
		When positive selection rapidly increases an allele's frequency, linked variants "hitchhike"
		along, creating extended regions of high LD. Detecting such patterns helps identify recent
		selection.
	</p>

	<h2>LD and Effective Population Size</h2>

	<p>
		The expected LD in a population reflects its history. At equilibrium between drift (creating LD)
		and recombination (breaking it down):
	</p>

	<div class="equation">
		E[r²] ≈ 1 / (4N_e × r + 1)
		<span class="equation-label">Expected LD under drift-recombination balance</span>
	</div>

	<p>
		This relationship allows estimation of effective population size from LD patterns, particularly
		useful for inferring historical population sizes.
	</p>
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
		font-size: 0.85rem;
		color: var(--text);
		font-weight: 600;
	}

	.control-group.info {
		padding: 0.5rem 1rem;
		background: var(--bg);
		border-radius: 4px;
	}

	.info-label {
		font-size: 0.7rem;
		color: var(--text-muted);
	}

	.info-value {
		font-family: var(--font-mono);
		font-size: 1rem;
		color: var(--viz-3);
		font-weight: 600;
	}

	.gamete-table {
		background: var(--chart-bg);
		border: 1px solid var(--border);
		border-radius: 6px;
		margin: 1.5rem 0;
		overflow: hidden;
	}

	.gamete-row {
		display: grid;
		grid-template-columns: 1fr 1fr 2fr;
		padding: 0.6rem 1rem;
		font-size: 0.85rem;
		border-bottom: 1px solid var(--border);
	}

	.gamete-row:last-child {
		border-bottom: none;
	}

	.gamete-row.header {
		background: var(--bg);
		font-weight: 600;
		font-size: 0.75rem;
		text-transform: uppercase;
		color: var(--text-muted);
		letter-spacing: 0.03em;
	}

	.gamete {
		font-family: var(--font-mono);
		font-weight: 600;
		color: var(--accent);
	}

	@media (max-width: 600px) {
		.diagram-chart {
			height: 240px;
		}

		.control-group input[type="range"] {
			width: 100px;
		}

		.gamete-row {
			font-size: 0.8rem;
			padding: 0.5rem 0.75rem;
		}
	}
</style>
