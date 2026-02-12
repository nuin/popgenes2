<script lang="ts">
	import TheoryLayout from '$lib/components/TheoryLayout.svelte';
	import { theme } from '$lib/theme';
	import * as d3 from 'd3';

	// Interactive diagram state
	let container: HTMLDivElement;

	// Selection coefficients (expressed as w = 1 - s)
	let wAA = $state(1.0);
	let wAa = $state(1.0);
	let waa = $state(0.8);

	// Derived values
	let h = $derived((wAA - wAa) / (wAA - waa)); // dominance coefficient
	let s = $derived(1 - waa / wAA); // selection coefficient

	// Calculate delta p for range of p values
	let deltaPCurve = $derived(() => {
		const points = [];
		for (let p = 0; p <= 1; p += 0.01) {
			const q = 1 - p;
			const wBar = p * p * wAA + 2 * p * q * wAa + q * q * waa;
			const deltaP = (p * q * (p * (wAA - wAa) + q * (wAa - waa))) / wBar;
			points.push({ p, deltaP });
		}
		return points;
	});

	// Find equilibrium (if any)
	let equilibrium = $derived(() => {
		if (wAa > wAA && wAa > waa) {
			// Heterozygote advantage: stable equilibrium
			const pHat = (wAa - waa) / (2 * wAa - wAA - waa);
			if (pHat > 0 && pHat < 1) return { p: pHat, stable: true };
		} else if (wAa < wAA && wAa < waa) {
			// Heterozygote disadvantage: unstable equilibrium
			const pHat = (wAa - waa) / (2 * wAa - wAA - waa);
			if (pHat > 0 && pHat < 1) return { p: pHat, stable: false };
		}
		return null;
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
		const viz3 = style.getPropertyValue('--viz-3').trim();

		const margin = { top: 20, right: 30, bottom: 50, left: 60 };
		const iw = w - margin.left - margin.right;
		const ih = h - margin.top - margin.bottom;

		const svg = d3.select(container)
			.append('svg')
			.attr('width', w)
			.attr('height', h);

		const g = svg.append('g')
			.attr('transform', `translate(${margin.left},${margin.top})`);

		// Find y range
		const minDelta = Math.min(...deltaPCurve().map(d => d.deltaP));
		const maxDelta = Math.max(...deltaPCurve().map(d => d.deltaP));
		const yPadding = Math.max(0.01, (maxDelta - minDelta) * 0.1);

		// Scales
		const x = d3.scaleLinear().domain([0, 1]).range([0, iw]);
		const y = d3.scaleLinear()
			.domain([Math.min(minDelta - yPadding, -0.01), Math.max(maxDelta + yPadding, 0.01)])
			.range([ih, 0]);

		// Zero line (equilibrium boundary)
		g.append('line')
			.attr('x1', 0).attr('x2', iw)
			.attr('y1', y(0)).attr('y2', y(0))
			.attr('stroke', axisColor)
			.attr('stroke-width', 1)
			.attr('stroke-dasharray', '5,5');

		// Grid
		g.append('line')
			.attr('x1', x(0.5)).attr('x2', x(0.5))
			.attr('y1', 0).attr('y2', ih)
			.attr('stroke', gridColor)
			.attr('stroke-dasharray', '3,5');

		// Axes
		g.append('g')
			.attr('transform', `translate(0,${ih})`)
			.call(d3.axisBottom(x).ticks(5))
			.attr('color', axisColor)
			.selectAll('text')
			.attr('fill', labelColor);

		g.append('g')
			.call(d3.axisLeft(y).ticks(5).tickFormat(d3.format('.3f')))
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
			.text('Allele Frequency (p)');

		svg.append('text')
			.attr('transform', 'rotate(-90)')
			.attr('x', -(margin.top + ih / 2))
			.attr('y', 15)
			.attr('text-anchor', 'middle')
			.attr('font-size', '11px')
			.attr('fill', labelColor)
			.text('Δp (change in frequency)');

		// Delta p curve
		const line = d3.line<{ p: number; deltaP: number }>()
			.x(d => x(d.p))
			.y(d => y(d.deltaP));

		g.append('path')
			.datum(deltaPCurve())
			.attr('fill', 'none')
			.attr('stroke', viz1)
			.attr('stroke-width', 2.5)
			.attr('d', line);

		// Mark equilibrium points
		// p = 0 (loss)
		g.append('circle')
			.attr('cx', x(0))
			.attr('cy', y(0))
			.attr('r', 6)
			.attr('fill', wAA > wAa ? viz3 : viz2)
			.attr('stroke', 'white')
			.attr('stroke-width', 1.5);

		// p = 1 (fixation)
		g.append('circle')
			.attr('cx', x(1))
			.attr('cy', y(0))
			.attr('r', 6)
			.attr('fill', wAA > wAa ? viz2 : viz3)
			.attr('stroke', 'white')
			.attr('stroke-width', 1.5);

		// Interior equilibrium (if exists)
		const eq = equilibrium();
		if (eq) {
			g.append('circle')
				.attr('cx', x(eq.p))
				.attr('cy', y(0))
				.attr('r', 8)
				.attr('fill', eq.stable ? viz2 : viz3)
				.attr('stroke', 'white')
				.attr('stroke-width', 2);

			g.append('text')
				.attr('x', x(eq.p))
				.attr('y', y(0) - 14)
				.attr('text-anchor', 'middle')
				.attr('font-size', '10px')
				.attr('fill', textColor)
				.text(`p̂ = ${eq.p.toFixed(3)} (${eq.stable ? 'stable' : 'unstable'})`);
		}

		// Legend
		g.append('circle').attr('cx', iw - 80).attr('cy', 10).attr('r', 5).attr('fill', viz2);
		g.append('text')
			.attr('x', iw - 70)
			.attr('y', 14)
			.attr('font-size', '9px')
			.attr('fill', textColor)
			.text('Stable');

		g.append('circle').attr('cx', iw - 80).attr('cy', 26).attr('r', 5).attr('fill', viz3);
		g.append('text')
			.attr('x', iw - 70)
			.attr('y', 30)
			.attr('font-size', '9px')
			.attr('fill', textColor)
			.text('Unstable');

		// Direction arrows
		const arrowPoints = [0.2, 0.5, 0.8].filter(p => {
			if (eq && Math.abs(p - eq.p) < 0.1) return false;
			return true;
		});

		arrowPoints.forEach(p => {
			const deltaP = deltaPCurve().find(d => Math.abs(d.p - p) < 0.01)?.deltaP || 0;
			if (Math.abs(deltaP) > 0.001) {
				const direction = deltaP > 0 ? 1 : -1;
				const arrowX = x(p);
				const arrowY = y(deltaP / 2);

				g.append('path')
					.attr('d', `M ${arrowX} ${arrowY} l ${direction * 8} -4 l 0 8 z`)
					.attr('fill', viz1)
					.attr('opacity', 0.6);
			}
		});
	}

	$effect(() => {
		void wAA;
		void wAa;
		void waa;
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
	title="Natural Selection"
	subtitle="Differential fitness and allele frequency change"
	simLinks={[
		{ href: '/selection', label: 'Selection Sim' },
		{ href: '/selection/frequency-dependent', label: 'Freq-Dependent' }
	]}
>
	<h2>The Principle</h2>

	<p>
		Natural selection is the process by which individuals with certain heritable traits tend to
		<strong>survive and reproduce more successfully</strong> than others. At the genetic level, this
		translates to changes in allele frequencies over generations.
	</p>

	<div class="note">
		<strong>Key insight:</strong> Selection acts on phenotypes but changes genotype frequencies.
		The connection between phenotype and genotype (dominance, epistasis) shapes how selection
		operates on alleles.
	</div>

	<h2>Fitness and Selection</h2>

	<p>
		<strong>Fitness</strong> (w) measures the relative reproductive success of a genotype. By convention,
		we set the highest fitness to 1 and express others relative to it.
	</p>

	<div class="equation">
		w_AA = 1,  w_Aa = 1-hs,  w_aa = 1-s
		<span class="equation-label">Standard parameterization with dominance</span>
	</div>

	<p>Where:</p>
	<ul>
		<li><strong>s</strong> = selection coefficient (reduction in fitness of aa)</li>
		<li><strong>h</strong> = dominance coefficient (0 = recessive, 0.5 = codominant, 1 = dominant)</li>
	</ul>

	<h2>Change in Allele Frequency</h2>

	<p>
		The change in allele frequency per generation depends on current frequencies and fitness values:
	</p>

	<div class="equation">
		Δp = pq[p(w_AA - w_Aa) + q(w_Aa - w_aa)] / w̄
		<span class="equation-label">General selection equation</span>
	</div>

	<p>
		Where <span class="var">w̄ = p²w_AA + 2pqw_Aa + q²w_aa</span> is the mean population fitness.
	</p>

	<h2>Interactive Selection Dynamics</h2>

	<p>
		Adjust the fitness values below to see how selection changes allele frequencies. The curve shows
		Δp for each frequency p. <strong>Where the curve crosses zero, populations are at equilibrium.</strong>
	</p>

	<div class="controls">
		<div class="control-group">
			<label for="wAA">w<sub>AA</sub></label>
			<input id="wAA" type="range" min="0.5" max="1.0" step="0.05" bind:value={wAA} />
			<span class="control-value">{wAA.toFixed(2)}</span>
		</div>
		<div class="control-group">
			<label for="wAa">w<sub>Aa</sub></label>
			<input id="wAa" type="range" min="0.5" max="1.2" step="0.05" bind:value={wAa} />
			<span class="control-value">{wAa.toFixed(2)}</span>
		</div>
		<div class="control-group">
			<label for="waa">w<sub>aa</sub></label>
			<input id="waa" type="range" min="0.5" max="1.0" step="0.05" bind:value={waa} />
			<span class="control-value">{waa.toFixed(2)}</span>
		</div>
	</div>

	<div class="diagram">
		<div class="diagram-chart" bind:this={container}></div>
		<p class="diagram-caption">
			Δp curve showing direction and magnitude of selection. Arrows indicate direction of change.
		</p>
	</div>

	<h2>Selection Regimes</h2>

	<h3>Directional Selection</h3>
	<p>
		When one allele has consistently higher fitness, selection drives it toward fixation.
		Try setting w<sub>AA</sub> = 1.0, w<sub>Aa</sub> = 0.9, w<sub>aa</sub> = 0.8 to see directional
		selection favoring A.
	</p>

	<h3>Balancing Selection</h3>
	<p>
		When heterozygotes have the highest fitness (<strong>overdominance</strong>), both alleles are
		maintained at a stable equilibrium. Try w<sub>AA</sub> = 0.9, w<sub>Aa</sub> = 1.0, w<sub>aa</sub> = 0.8.
	</p>

	<div class="equation">
		p̂ = (w_Aa - w_aa) / (2w_Aa - w_AA - w_aa)
		<span class="equation-label">Equilibrium frequency under overdominance</span>
	</div>

	<h3>Disruptive Selection</h3>
	<p>
		When heterozygotes have the <em>lowest</em> fitness (<strong>underdominance</strong>), the
		equilibrium is unstable — populations evolve away from it toward fixation or loss.
	</p>

	<h2>Rate of Selection</h2>

	<p>
		How fast does selection work? The time to change frequency depends on dominance:
	</p>

	<ul>
		<li><strong>Dominant advantageous:</strong> Fast initial spread, slow to fix (rare recessives hard to remove)</li>
		<li><strong>Recessive advantageous:</strong> Slow initial spread (hides in heterozygotes), fast final fixation</li>
		<li><strong>Additive:</strong> Relatively constant rate throughout</li>
	</ul>

	<div class="equation">
		t ≈ (1/s) × ln(p/q) for additive selection
		<span class="equation-label">Approximate time to change frequency</span>
	</div>

	<h2>Selection and Drift</h2>

	<p>
		In finite populations, selection competes with drift. The key parameter is <span class="var">Ns</span>:
	</p>

	<ul>
		<li><strong>Ns &gt;&gt; 1:</strong> Selection dominates; advantageous alleles likely fix</li>
		<li><strong>Ns ≈ 1:</strong> Both forces matter; outcomes are probabilistic</li>
		<li><strong>Ns &lt;&lt; 1:</strong> Drift dominates; alleles behave as if neutral</li>
	</ul>

	<p>
		The probability of fixation for a new mutation with selective advantage <span class="var">s</span>
		in a population of size <span class="var">N</span>:
	</p>

	<div class="equation">
		P(fix) ≈ 2s (for Ns &gt;&gt; 1)
		<span class="equation-label">Probability of fixation for beneficial mutation</span>
	</div>

	<div class="note">
		Even strongly advantageous mutations are often lost by drift when rare. A mutation with 10%
		advantage has only about 20% chance of eventual fixation.
	</div>

	<h2>Mutation-Selection Balance</h2>

	<p>
		Deleterious alleles persist in populations due to the balance between mutation (introducing them)
		and selection (removing them):
	</p>

	<div class="equation">
		q̂ ≈ μ/s (recessive) or q̂ ≈ μ/hs (partially dominant)
		<span class="equation-label">Equilibrium frequency of deleterious allele</span>
	</div>

	<p>
		This explains why many genetic diseases persist at low frequencies — they're continuously
		replenished by mutation even as selection removes them.
	</p>
</TheoryLayout>

<style>
	.diagram-chart {
		width: 100%;
		height: 300px;
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
			height: 260px;
		}

		.control-group input[type="range"] {
			width: 80px;
		}
	}
</style>
