<script lang="ts">
	import { browser } from '$app/environment';
	import { theme, toggleTheme } from '$lib/theme';
	import ParamInput from '$lib/components/ParamInput.svelte';
	import * as d3 from 'd3';

	// === Parameters ===
	let N = $state(500);           // Population size
	let s = $state(0.05);          // Selection coefficient
	let h = $state(0.5);           // Dominance (0.5 = additive)
	let initialP = $state(0.01);   // Initial frequency of beneficial allele
	let numLoci = $state(20);      // Number of linked neutral loci
	let recombRate = $state(0.01); // Recombination rate between adjacent loci

	// === State ===
	let running = $state(false);
	let generation = $state(0);
	let selectedFreq = $state<number[]>([]);        // Frequency of selected allele over time
	let neutralDiv = $state<number[][]>([]);        // Heterozygosity at each neutral locus over time
	let fixedGen = $state<number | null>(null);
	let abortController: AbortController | null = null;

	// === Containers ===
	let freqContainer: HTMLDivElement;
	let diversityContainer: HTMLDivElement;

	// === Simulation ===
	// Use a run ID to track which simulation is current
	let currentRunId = 0;

	async function runSimulation() {
		// Increment run ID to invalidate any previous simulation
		const runId = ++currentRunId;

		// Clear everything first
		if (freqContainer) d3.select(freqContainer).selectAll('*').remove();
		if (diversityContainer) d3.select(diversityContainer).selectAll('*').remove();

		// Reset all state with fresh arrays
		running = true;
		generation = 0;
		fixedGen = null;

		// Use LOCAL arrays during simulation to avoid reactive issues
		const localSelectedFreq: number[] = [initialP];
		const localNeutralDiv: number[][] = [];

		// Initialize neutral loci - all start polymorphic at 0.5
		const neutralFreqs: number[] = new Array(numLoci).fill(0.5);
		localNeutralDiv.push(neutralFreqs.map(p => 2 * p * (1 - p))); // Initial heterozygosity

		// Haplotype structure
		const linkedNeutral: number[] = neutralFreqs.map(() => Math.random() < 0.5 ? 1 : 0);

		let p = initialP;
		const maxGen = 1000;
		let localFixedGen: number | null = null;

		while (p > 0 && p < 1 && generation < maxGen) {
			// Check if this simulation was superseded by a new one
			if (runId !== currentRunId) {
				running = false;
				return;
			}

			generation++;

			// Selection on beneficial allele
			const q = 1 - p;
			const wAA = 1 + s;
			const wAa = 1 + h * s;
			const waa = 1;
			const wBar = p * p * wAA + 2 * p * q * wAa + q * q * waa;

			// New frequency after selection
			const pPrime = (p * p * wAA + p * q * wAa) / wBar;

			// Drift
			let count = 0;
			for (let i = 0; i < 2 * N; i++) {
				if (Math.random() < pPrime) count++;
			}
			p = count / (2 * N);

			localSelectedFreq.push(p);

			// Update neutral loci - hitchhiking effect
			const newNeutralFreqs: number[] = [];

			for (let locus = 0; locus < numLoci; locus++) {
				const distFromCenter = Math.abs(locus - numLoci / 2);
				const recombProb = 1 - Math.pow(1 - recombRate, distFromCenter);

				let neutralP = neutralFreqs[locus];

				// Hitchhiking effect
				const prevP = localSelectedFreq[localSelectedFreq.length - 2];
				const hitchhikeStrength = (1 - recombProb) * (p - prevP);
				if (linkedNeutral[locus] === 1) {
					neutralP += hitchhikeStrength * (1 - neutralP);
				} else {
					neutralP -= hitchhikeStrength * neutralP;
				}

				// Drift at neutral locus
				let neutralCount = 0;
				for (let i = 0; i < 2 * N; i++) {
					if (Math.random() < neutralP) neutralCount++;
				}
				neutralP = neutralCount / (2 * N);

				neutralP = Math.max(0, Math.min(1, neutralP));
				newNeutralFreqs.push(neutralP);
				neutralFreqs[locus] = neutralP;
			}

			localNeutralDiv.push(newNeutralFreqs.map(freq => 2 * freq * (1 - freq)));

			// Check for fixation
			if (p >= 0.999 && localFixedGen === null) {
				localFixedGen = generation;
			}

			// Render periodically - copy local arrays to state
			if (generation % 5 === 0 || p >= 1 || p <= 0) {
				selectedFreq = [...localSelectedFreq];
				neutralDiv = [...localNeutralDiv];
				fixedGen = localFixedGen;
				renderFreqChart();
				renderDiversityChart();
				await new Promise(r => setTimeout(r, 10));

				if (runId !== currentRunId) {
					running = false;
					return;
				}
			}
		}

		// Final update
		selectedFreq = [...localSelectedFreq];
		neutralDiv = [...localNeutralDiv];
		fixedGen = localFixedGen;
		running = false;
		renderFreqChart();
		renderDiversityChart();
	}

	function reset() {
		// Cancel any running simulation
		if (abortController) {
			abortController.abort();
			abortController = null;
		}
		running = false;
		generation = 0;
		fixedGen = null;
		selectedFreq = [];
		neutralDiv = [];
		if (freqContainer) d3.select(freqContainer).selectAll('*').remove();
		if (diversityContainer) d3.select(diversityContainer).selectAll('*').remove();
	}

	// === Render Frequency Chart ===
	function renderFreqChart() {
		if (!browser || !freqContainer || selectedFreq.length === 0) return;

		const colors = getColors();
		const rect = freqContainer.getBoundingClientRect();
		const w = rect.width;
		const h = rect.height;

		d3.select(freqContainer).selectAll('*').remove();

		const margin = { top: 20, right: 30, bottom: 40, left: 50 };
		const iw = w - margin.left - margin.right;
		const ih = h - margin.top - margin.bottom;

		const svg = d3.select(freqContainer)
			.append('svg')
			.attr('width', w)
			.attr('height', h);

		const g = svg.append('g')
			.attr('transform', `translate(${margin.left},${margin.top})`);

		// Scales - use data length for domain to ensure consistency
		const maxX = Math.max(selectedFreq.length - 1, 50);
		const x = d3.scaleLinear().domain([0, maxX]).range([0, iw]);
		const y = d3.scaleLinear().domain([0, 1]).range([ih, 0]);

		// Grid
		[0.25, 0.5, 0.75].forEach(v => {
			g.append('line')
				.attr('x1', 0).attr('x2', iw)
				.attr('y1', y(v)).attr('y2', y(v))
				.attr('stroke', colors.grid)
				.attr('stroke-dasharray', '3,5');
		});

		// Fixation line
		if (fixedGen !== null) {
			g.append('line')
				.attr('x1', x(fixedGen)).attr('x2', x(fixedGen))
				.attr('y1', 0).attr('y2', ih)
				.attr('stroke', colors.viz3)
				.attr('stroke-width', 2)
				.attr('stroke-dasharray', '4,4');

			g.append('text')
				.attr('x', x(fixedGen) + 5)
				.attr('y', 15)
				.attr('font-size', '9px')
				.attr('fill', colors.viz3)
				.text(`Fixed: gen ${fixedGen}`);
		}

		// Axes
		g.append('g')
			.attr('transform', `translate(0,${ih})`)
			.call(d3.axisBottom(x).ticks(8))
			.attr('color', colors.axis)
			.selectAll('text')
			.attr('fill', colors.label);

		g.append('g')
			.call(d3.axisLeft(y).ticks(5))
			.attr('color', colors.axis)
			.selectAll('text')
			.attr('fill', colors.label);

		// Labels
		svg.append('text')
			.attr('x', margin.left + iw / 2)
			.attr('y', h - 5)
			.attr('text-anchor', 'middle')
			.attr('font-size', '11px')
			.attr('fill', colors.label)
			.text('Generation');

		svg.append('text')
			.attr('transform', 'rotate(-90)')
			.attr('x', -(margin.top + ih / 2))
			.attr('y', 15)
			.attr('text-anchor', 'middle')
			.attr('font-size', '11px')
			.attr('fill', colors.label)
			.text('Beneficial Allele Frequency');

		// Frequency line
		const line = d3.line<number>()
			.x((_, i) => x(i))
			.y(d => y(d));

		g.append('path')
			.datum(selectedFreq)
			.attr('fill', 'none')
			.attr('stroke', colors.viz1)
			.attr('stroke-width', 2.5)
			.attr('d', line);

		// Current point
		const lastP = selectedFreq[selectedFreq.length - 1];
		g.append('circle')
			.attr('cx', x(selectedFreq.length - 1))
			.attr('cy', y(lastP))
			.attr('r', 5)
			.attr('fill', colors.viz1);

		// Stats
		g.append('text')
			.attr('x', 10)
			.attr('y', 15)
			.attr('font-size', '10px')
			.attr('fill', colors.text)
			.text(`p = ${lastP.toFixed(3)}, s = ${s}, gen = ${selectedFreq.length - 1}`);
	}

	// === Render Diversity Chart ===
	function renderDiversityChart() {
		if (!browser || !diversityContainer || neutralDiv.length === 0) return;

		const colors = getColors();
		const rect = diversityContainer.getBoundingClientRect();
		const w = rect.width;
		const h = rect.height;

		d3.select(diversityContainer).selectAll('*').remove();

		const margin = { top: 20, right: 30, bottom: 40, left: 50 };
		const iw = w - margin.left - margin.right;
		const ih = h - margin.top - margin.bottom;

		const svg = d3.select(diversityContainer)
			.append('svg')
			.attr('width', w)
			.attr('height', h);

		const g = svg.append('g')
			.attr('transform', `translate(${margin.left},${margin.top})`);

		// Get current diversity across loci
		const currentDiv = neutralDiv[neutralDiv.length - 1];
		const initialDiv = neutralDiv[0];

		// Scales
		const x = d3.scaleLinear().domain([0, numLoci - 1]).range([0, iw]);
		const y = d3.scaleLinear().domain([0, 0.5]).range([ih, 0]);

		// Grid
		g.append('line')
			.attr('x1', 0).attr('x2', iw)
			.attr('y1', y(0.25)).attr('y2', y(0.25))
			.attr('stroke', colors.grid)
			.attr('stroke-dasharray', '3,5');

		// Selected site marker
		const selectedPos = numLoci / 2;
		g.append('line')
			.attr('x1', x(selectedPos)).attr('x2', x(selectedPos))
			.attr('y1', 0).attr('y2', ih)
			.attr('stroke', colors.viz1)
			.attr('stroke-width', 2)
			.attr('stroke-dasharray', '4,4');

		g.append('text')
			.attr('x', x(selectedPos))
			.attr('y', -5)
			.attr('text-anchor', 'middle')
			.attr('font-size', '9px')
			.attr('fill', colors.viz1)
			.text('Selected site');

		// Axes
		g.append('g')
			.attr('transform', `translate(0,${ih})`)
			.call(d3.axisBottom(x).ticks(numLoci > 10 ? 10 : numLoci))
			.attr('color', colors.axis)
			.selectAll('text')
			.attr('fill', colors.label);

		g.append('g')
			.call(d3.axisLeft(y).ticks(5))
			.attr('color', colors.axis)
			.selectAll('text')
			.attr('fill', colors.label);

		// Labels
		svg.append('text')
			.attr('x', margin.left + iw / 2)
			.attr('y', h - 5)
			.attr('text-anchor', 'middle')
			.attr('font-size', '11px')
			.attr('fill', colors.label)
			.text('Genomic Position (neutral loci)');

		svg.append('text')
			.attr('transform', 'rotate(-90)')
			.attr('x', -(margin.top + ih / 2))
			.attr('y', 15)
			.attr('text-anchor', 'middle')
			.attr('font-size', '11px')
			.attr('fill', colors.label)
			.text('Heterozygosity (H)');

		// Initial diversity line
		const line = d3.line<number>()
			.x((_, i) => x(i))
			.y(d => y(d));

		g.append('path')
			.datum(initialDiv)
			.attr('fill', 'none')
			.attr('stroke', colors.muted)
			.attr('stroke-width', 1.5)
			.attr('stroke-dasharray', '4,4')
			.attr('d', line);

		// Current diversity - area plot
		const area = d3.area<number>()
			.x((_, i) => x(i))
			.y0(ih)
			.y1(d => y(d));

		g.append('path')
			.datum(currentDiv)
			.attr('fill', colors.viz2)
			.attr('fill-opacity', 0.3)
			.attr('d', area);

		g.append('path')
			.datum(currentDiv)
			.attr('fill', 'none')
			.attr('stroke', colors.viz2)
			.attr('stroke-width', 2)
			.attr('d', line);

		// Legend
		g.append('line')
			.attr('x1', iw - 100).attr('x2', iw - 80)
			.attr('y1', 15).attr('y2', 15)
			.attr('stroke', colors.muted)
			.attr('stroke-dasharray', '4,4');
		g.append('text')
			.attr('x', iw - 75).attr('y', 18)
			.attr('font-size', '9px')
			.attr('fill', colors.text)
			.text('Initial');

		g.append('line')
			.attr('x1', iw - 100).attr('x2', iw - 80)
			.attr('y1', 30).attr('y2', 30)
			.attr('stroke', colors.viz2)
			.attr('stroke-width', 2);
		g.append('text')
			.attr('x', iw - 75).attr('y', 33)
			.attr('font-size', '9px')
			.attr('fill', colors.text)
			.text('Current');
	}

	// === Colors ===
	function getColors() {
		if (!browser) {
			return {
				viz1: '#3b82f6', viz2: '#14b8a6', viz3: '#f97316',
				bg: '#1a1a2e', border: '#333', text: '#fff', muted: '#888',
				grid: '#333', axis: '#666', label: '#888'
			};
		}
		const style = getComputedStyle(document.body);
		return {
			viz1: style.getPropertyValue('--viz-1').trim() || '#3b82f6',
			viz2: style.getPropertyValue('--viz-2').trim() || '#14b8a6',
			viz3: style.getPropertyValue('--viz-3').trim() || '#f97316',
			bg: style.getPropertyValue('--chart-bg').trim() || '#1a1a2e',
			border: style.getPropertyValue('--border').trim() || '#333',
			text: style.getPropertyValue('--text').trim() || '#fff',
			muted: style.getPropertyValue('--text-muted').trim() || '#888',
			grid: style.getPropertyValue('--grid').trim() || '#333',
			axis: style.getPropertyValue('--axis').trim() || '#666',
			label: style.getPropertyValue('--label').trim() || '#888'
		};
	}

	// === Effects ===
	$effect(() => {
		void $theme;
		if (selectedFreq.length > 0) {
			renderFreqChart();
			renderDiversityChart();
		}
	});
</script>

<div class="sim">
	<div class="topbar">
		<div class="topbar-left">
			<a href="/" class="back">&larr; Modules</a>
			<span class="sim-title">Selective Sweep</span>
			<span class="sim-subtitle">Positive selection and linked diversity loss</span>
		</div>
		<div class="topbar-right">
			<button class="btn-theme" onclick={toggleTheme} aria-label="Toggle theme">
				{$theme === 'dark' ? '☀' : '☾'}
			</button>
		</div>
	</div>

	<main class="main-area">
		<div class="controls-panel">
			<div class="param-group">
				<h4>Population</h4>
				<ParamInput label="Size (N)" bind:value={N} min={50} max={2000} step={50} />
			</div>
			<div class="param-group">
				<h4>Selection</h4>
				<ParamInput label="Coefficient (s)" bind:value={s} min={0.001} max={0.2} step={0.005} />
				<ParamInput label="Dominance (h)" bind:value={h} min={0} max={1} step={0.1} />
				<ParamInput label="Initial p" bind:value={initialP} min={0.001} max={0.1} step={0.001} />
			</div>
			<div class="param-group">
				<h4>Linkage</h4>
				<ParamInput label="Neutral loci" bind:value={numLoci} min={5} max={50} step={5} />
				<ParamInput label="Recomb rate" bind:value={recombRate} min={0.001} max={0.1} step={0.005} />
			</div>
			<div class="button-group">
				<button class="btn btn-run" onclick={runSimulation}>
					{running ? 'Restart' : 'Start Sweep'}
				</button>
				<button class="btn btn-reset" onclick={reset}>
					Reset
				</button>
			</div>
		</div>

		<div class="charts-area">
			<div class="chart-container">
				<h3>Beneficial Allele Frequency</h3>
				<div class="chart" bind:this={freqContainer}></div>
			</div>
			<div class="chart-container">
				<h3>Diversity at Linked Neutral Loci</h3>
				<div class="chart" bind:this={diversityContainer}></div>
			</div>
		</div>
	</main>

	<div class="info-panel">
		<p>
			<strong>Selective Sweep:</strong> When positive selection drives a beneficial allele to
			fixation, nearby neutral variants "hitchhike" along, reducing genetic diversity in a
			characteristic valley pattern centered on the selected site. Tighter linkage (lower
			recombination) creates wider valleys.
		</p>
	</div>
</div>

<style>
	.sim {
		height: 100vh;
		display: flex;
		flex-direction: column;
		background: var(--bg);
	}

	.topbar {
		display: flex;
		align-items: center;
		justify-content: space-between;
		padding: 0.6rem 1.5rem;
		background: var(--bg);
		border-bottom: 1px solid var(--border);
		flex-shrink: 0;
	}

	.topbar-left {
		display: flex;
		align-items: center;
		gap: 1.5rem;
	}

	.topbar-right {
		display: flex;
		align-items: center;
		gap: 1rem;
	}

	.back {
		font-size: 0.75rem;
		color: var(--text-muted);
		text-decoration: none;
	}

	.back:hover {
		color: var(--text);
	}

	.sim-title {
		font-size: 0.8rem;
		font-weight: 500;
		color: var(--text);
	}

	.sim-subtitle {
		font-size: 0.7rem;
		color: var(--text-muted);
	}

	.btn-theme {
		padding: 0.35rem 0.5rem;
		font-size: 0.85rem;
		background: transparent;
		color: var(--text-muted);
		border: 1px solid var(--border);
		border-radius: 4px;
		cursor: pointer;
	}

	.btn-theme:hover {
		color: var(--text);
		border-color: var(--text-muted);
	}

	.main-area {
		flex: 1;
		display: flex;
		padding: 0.75rem;
		gap: 0.75rem;
		min-height: 0;
		overflow: auto;
	}

	.controls-panel {
		width: 180px;
		flex-shrink: 0;
		display: flex;
		flex-direction: column;
		gap: 1rem;
		padding: 1rem;
		background: var(--chart-bg);
		border: 1px solid var(--border);
		border-radius: 6px;
	}

	.param-group h4 {
		font-size: 0.7rem;
		font-weight: 600;
		text-transform: uppercase;
		letter-spacing: 0.05em;
		color: var(--text-muted);
		margin-bottom: 0.5rem;
	}

	.button-group {
		display: flex;
		flex-direction: column;
		gap: 0.5rem;
		margin-top: auto;
	}

	.btn {
		padding: 0.6rem 1rem;
		font-size: 0.8rem;
		font-weight: 600;
		border: none;
		border-radius: 6px;
		cursor: pointer;
		transition: all 0.2s;
	}

	.btn:disabled {
		opacity: 0.5;
		cursor: not-allowed;
	}

	.btn-run {
		background: var(--viz-1);
		color: white;
	}

	.btn-run:hover:not(:disabled) {
		filter: brightness(1.1);
	}

	.btn-reset {
		background: var(--border);
		color: var(--text);
	}

	.btn-reset:hover:not(:disabled) {
		background: var(--text-muted);
	}

	.charts-area {
		flex: 1;
		display: flex;
		flex-direction: column;
		gap: 0.75rem;
		min-width: 0;
	}

	.chart-container {
		flex: 1;
		background: var(--chart-bg);
		border: 1px solid var(--border);
		border-radius: 6px;
		padding: 0.75rem;
		display: flex;
		flex-direction: column;
	}

	.chart-container h3 {
		font-size: 0.8rem;
		font-weight: 500;
		color: var(--text-muted);
		margin-bottom: 0.5rem;
	}

	.chart {
		flex: 1;
		min-height: 150px;
	}

	.info-panel {
		padding: 0.75rem 1.5rem;
		background: var(--chart-bg);
		border-top: 1px solid var(--border);
		font-size: 0.8rem;
		color: var(--text-muted);
	}

	.info-panel p {
		margin: 0;
		line-height: 1.5;
	}

	.info-panel strong {
		color: var(--text);
	}

	@media (max-width: 768px) {
		.main-area {
			flex-direction: column;
		}

		.controls-panel {
			width: 100%;
			flex-direction: row;
			flex-wrap: wrap;
		}

		.param-group {
			flex: 1;
			min-width: 140px;
		}

		.button-group {
			flex-direction: row;
			width: 100%;
		}

		.btn {
			flex: 1;
		}

		.sim-subtitle {
			display: none;
		}
	}
</style>
