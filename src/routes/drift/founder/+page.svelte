<script lang="ts">
	import { browser } from '$app/environment';
	import { theme, toggleTheme } from '$lib/theme';
	import ParamInput from '$lib/components/ParamInput.svelte';
	import * as d3 from 'd3';

	// === Parameters ===
	let sourceN = $state(500);       // Source population size
	let founderN = $state(10);       // Number of founders
	let generations = $state(50);    // Generations to simulate
	let initialP = $state(0.5);      // Initial allele frequency in source
	let numTrials = $state(5);       // Number of independent founding events

	// === State ===
	let running = $state(false);
	let results = $state<{ gen: number; trials: number[][] }[]>([]);
	let sourceStats = $state<{ p: number; AA: number; Aa: number; aa: number } | null>(null);

	// === Containers ===
	let chartContainer: HTMLDivElement;
	let comparisonContainer: HTMLDivElement;

	// === Simulation ===
	// Track current run to invalidate previous simulations
	let currentRunId = 0;

	function runSimulation() {
		// Increment run ID to invalidate any stale state
		const runId = ++currentRunId;

		// Clear everything FIRST before any computation
		if (chartContainer) d3.select(chartContainer).selectAll('*').remove();
		if (comparisonContainer) d3.select(comparisonContainer).selectAll('*').remove();

		// Reset reactive state
		running = true;
		results = [];
		sourceStats = null;

		// Generate source population genotypes based on HWE
		const p = initialP;
		const q = 1 - p;
		const probAA = p * p;
		const probAa = 2 * p * q;

		let sourceAA = 0, sourceAa = 0, sourceaa = 0;
		const sourceGenotypes: number[] = [];

		for (let i = 0; i < sourceN; i++) {
			const rand = Math.random();
			let genotype: number;
			if (rand < probAA) {
				genotype = 2;
				sourceAA++;
			} else if (rand < probAA + probAa) {
				genotype = 1;
				sourceAa++;
			} else {
				genotype = 0;
				sourceaa++;
			}
			sourceGenotypes.push(genotype);
		}

		const actualSourceP = (2 * sourceAA + sourceAa) / (2 * sourceN);

		// Run multiple founding events - use LOCAL arrays
		const allTrials: number[][] = [];

		for (let trial = 0; trial < numTrials; trial++) {
			// Sample founders from source
			const founders: number[] = [];
			for (let i = 0; i < founderN; i++) {
				const idx = Math.floor(Math.random() * sourceGenotypes.length);
				founders.push(sourceGenotypes[idx]);
			}

			// Calculate founder allele frequency
			const founderAA = founders.filter(g => g === 2).length;
			const founderAa = founders.filter(g => g === 1).length;
			let founderP = (2 * founderAA + founderAa) / (2 * founderN);

			const trajectory: number[] = [founderP];

			// Drift simulation for this founding population
			let currentP = founderP;
			const N = founderN; // Founder population stays small initially then grows

			for (let gen = 1; gen <= generations; gen++) {
				// Population grows over time (logistic growth)
				const effectiveN = Math.min(500, Math.floor(N * Math.pow(1.1, gen)));

				// Wright-Fisher sampling
				let aCount = 0;
				for (let i = 0; i < 2 * effectiveN; i++) {
					if (Math.random() < currentP) aCount++;
				}
				currentP = aCount / (2 * effectiveN);

				// Check for fixation
				if (currentP <= 0) currentP = 0;
				if (currentP >= 1) currentP = 1;

				trajectory.push(currentP);
			}

			allTrials.push(trajectory);
		}

		// Check if this run was superseded
		if (runId !== currentRunId) {
			running = false;
			return;
		}

		// Build results using LOCAL array first
		const localResults: { gen: number; trials: number[][] }[] = [];
		for (let gen = 0; gen <= generations; gen++) {
			localResults.push({
				gen,
				trials: allTrials.map(t => [t[gen]])
			});
		}

		// NOW assign to reactive state all at once
		// The $effect will handle rendering when results changes
		sourceStats = { p: actualSourceP, AA: sourceAA, Aa: sourceAa, aa: sourceaa };
		results = localResults;
		running = false;
	}

	function reset() {
		results = [];
		sourceStats = null;
		if (chartContainer) d3.select(chartContainer).selectAll('*').remove();
		if (comparisonContainer) d3.select(comparisonContainer).selectAll('*').remove();
	}

	// === Render Chart ===
	let isRendering = false;

	function renderChart() {
		if (!browser || !chartContainer || results.length === 0) return;
		if (isRendering) return; // Prevent re-entry
		isRendering = true;

		const colors = getColors();
		const rect = chartContainer.getBoundingClientRect();
		const w = rect.width;
		const h = rect.height;

		if (w < 10 || h < 10) {
			isRendering = false;
			return;
		}

		d3.select(chartContainer).selectAll('*').remove();

		const margin = { top: 20, right: 30, bottom: 45, left: 50 };
		const iw = w - margin.left - margin.right;
		const ih = h - margin.top - margin.bottom;

		const svg = d3.select(chartContainer)
			.append('svg')
			.attr('width', w)
			.attr('height', h);

		const g = svg.append('g')
			.attr('transform', `translate(${margin.left},${margin.top})`);

		// Scales - use data length for domain to ensure consistency
		const maxGen = results.length > 0 ? results.length - 1 : generations;
		const x = d3.scaleLinear().domain([0, maxGen]).range([0, iw]);
		const y = d3.scaleLinear().domain([0, 1]).range([ih, 0]);

		// Grid
		[0.25, 0.5, 0.75].forEach(v => {
			g.append('line')
				.attr('x1', 0).attr('x2', iw)
				.attr('y1', y(v)).attr('y2', y(v))
				.attr('stroke', colors.grid)
				.attr('stroke-dasharray', '3,5');
		});

		// Source frequency reference line
		if (sourceStats) {
			g.append('line')
				.attr('x1', 0).attr('x2', iw)
				.attr('y1', y(sourceStats.p)).attr('y2', y(sourceStats.p))
				.attr('stroke', colors.muted)
				.attr('stroke-width', 2)
				.attr('stroke-dasharray', '8,4');

			g.append('text')
				.attr('x', iw - 5)
				.attr('y', y(sourceStats.p) - 5)
				.attr('text-anchor', 'end')
				.attr('font-size', '9px')
				.attr('fill', colors.muted)
				.text(`Source p = ${sourceStats.p.toFixed(3)}`);
		}

		// Axes
		g.append('g')
			.attr('transform', `translate(0,${ih})`)
			.call(d3.axisBottom(x).ticks(10))
			.attr('color', colors.axis)
			.selectAll('text')
			.attr('fill', colors.label);

		g.append('g')
			.call(d3.axisLeft(y).ticks(5))
			.attr('color', colors.axis)
			.selectAll('text')
			.attr('fill', colors.label);

		// Axis labels
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
			.text('Allele Frequency (p)');

		// Draw trajectories
		const line = d3.line<number>()
			.x((_, i) => x(i))
			.y(d => y(d));

		const vizColors = [
			colors.viz1, colors.viz2, colors.viz3, colors.viz4,
			colors.viz5, colors.viz6, colors.viz7, colors.viz8
		];

		// Extract full trajectories
		const trajectories: number[][] = [];
		for (let t = 0; t < numTrials; t++) {
			trajectories.push(results.map(r => r.trials[t][0]));
		}

		trajectories.forEach((traj, i) => {
			g.append('path')
				.datum(traj)
				.attr('fill', 'none')
				.attr('stroke', vizColors[i % vizColors.length])
				.attr('stroke-width', 2)
				.attr('opacity', 0.8)
				.attr('d', line);

			// Starting point
			g.append('circle')
				.attr('cx', x(0))
				.attr('cy', y(traj[0]))
				.attr('r', 4)
				.attr('fill', vizColors[i % vizColors.length]);
		});

		// Legend
		g.append('text')
			.attr('x', 10)
			.attr('y', 15)
			.attr('font-size', '10px')
			.attr('fill', colors.text)
			.text(`${numTrials} independent founding events`);

		isRendering = false;
	}

	// === Render Comparison ===
	function renderComparison() {
		if (!browser || !comparisonContainer || !sourceStats || results.length === 0) return;

		const colors = getColors();
		const rect = comparisonContainer.getBoundingClientRect();
		const w = rect.width;
		const h = rect.height;

		d3.select(comparisonContainer).selectAll('*').remove();

		const svg = d3.select(comparisonContainer)
			.append('svg')
			.attr('width', w)
			.attr('height', h);

		const margin = { top: 20, bottom: 50, left: 30, right: 30 };
		const iw = w - margin.left - margin.right;
		const ih = h - margin.top - margin.bottom;

		const g = svg.append('g')
			.attr('transform', `translate(${margin.left},${margin.top})`);

		// Get final frequencies
		const finalFreqs = results[results.length - 1].trials.map(t => t[0]);
		const founderFreqs = results[0].trials.map(t => t[0]);

		// Bar chart comparing source, founder, and final frequencies
		const barWidth = iw / 4;
		const data = [
			{ label: 'Source', value: sourceStats.p, color: colors.muted },
			{ label: 'Founders\n(mean)', value: d3.mean(founderFreqs) || 0, color: colors.viz1 },
			{ label: 'Final\n(mean)', value: d3.mean(finalFreqs) || 0, color: colors.viz2 }
		];

		const y = d3.scaleLinear().domain([0, 1]).range([ih, 0]);

		data.forEach((d, i) => {
			const x = (i + 0.5) * (iw / 3);

			g.append('rect')
				.attr('x', x - barWidth / 2)
				.attr('y', y(d.value))
				.attr('width', barWidth)
				.attr('height', ih - y(d.value))
				.attr('fill', d.color)
				.attr('opacity', 0.8);

			g.append('text')
				.attr('x', x)
				.attr('y', ih + 15)
				.attr('text-anchor', 'middle')
				.attr('font-size', '10px')
				.attr('fill', colors.text)
				.text(d.label.split('\n')[0]);

			if (d.label.includes('\n')) {
				g.append('text')
					.attr('x', x)
					.attr('y', ih + 27)
					.attr('text-anchor', 'middle')
					.attr('font-size', '9px')
					.attr('fill', colors.muted)
					.text(d.label.split('\n')[1]);
			}

			g.append('text')
				.attr('x', x)
				.attr('y', y(d.value) - 5)
				.attr('text-anchor', 'middle')
				.attr('font-size', '11px')
				.attr('font-weight', '600')
				.attr('fill', colors.text)
				.text(d.value.toFixed(3));
		});

		// Variance info
		const variance = d3.variance(finalFreqs) || 0;
		g.append('text')
			.attr('x', iw / 2)
			.attr('y', 0)
			.attr('text-anchor', 'middle')
			.attr('font-size', '10px')
			.attr('fill', colors.muted)
			.text(`Final variance: ${variance.toFixed(4)}`);
	}

	// === Colors ===
	function getColors() {
		if (!browser) {
			return {
				viz1: '#3b82f6', viz2: '#14b8a6', viz3: '#f97316', viz4: '#8b5cf6',
				viz5: '#ec4899', viz6: '#06b6d4', viz7: '#84cc16', viz8: '#f43f5e',
				bg: '#1a1a2e', border: '#333', text: '#fff', muted: '#888',
				grid: '#333', axis: '#666', label: '#888'
			};
		}
		const style = getComputedStyle(document.body);
		return {
			viz1: style.getPropertyValue('--viz-1').trim() || '#3b82f6',
			viz2: style.getPropertyValue('--viz-2').trim() || '#14b8a6',
			viz3: style.getPropertyValue('--viz-3').trim() || '#f97316',
			viz4: style.getPropertyValue('--viz-4').trim() || '#8b5cf6',
			viz5: style.getPropertyValue('--viz-5').trim() || '#ec4899',
			viz6: style.getPropertyValue('--viz-6').trim() || '#06b6d4',
			viz7: style.getPropertyValue('--viz-7').trim() || '#84cc16',
			viz8: style.getPropertyValue('--viz-8').trim() || '#f43f5e',
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
		if (results.length > 0) {
			renderChart();
			renderComparison();
		}
	});

	let lastChartSize = { w: 0, h: 0 };
	$effect(() => {
		let resizeTimeout: ReturnType<typeof setTimeout> | null = null;
		const observer = new ResizeObserver((entries) => {
			if (results.length === 0) return;
			// Debounce and check if size actually changed
			if (resizeTimeout) clearTimeout(resizeTimeout);
			resizeTimeout = setTimeout(() => {
				const entry = entries[0];
				if (entry) {
					const { width, height } = entry.contentRect;
					if (Math.abs(width - lastChartSize.w) > 5 || Math.abs(height - lastChartSize.h) > 5) {
						lastChartSize = { w: width, h: height };
						renderChart();
						renderComparison();
					}
				}
			}, 100);
		});
		if (chartContainer) observer.observe(chartContainer);
		if (comparisonContainer) observer.observe(comparisonContainer);
		return () => {
			if (resizeTimeout) clearTimeout(resizeTimeout);
			observer.disconnect();
		};
	});
</script>

<div class="sim">
	<div class="topbar">
		<div class="topbar-left">
			<a href="/" class="back">&larr; Modules</a>
			<span class="sim-title">Founder Effect</span>
			<span class="sim-subtitle">Genetic drift in colonizing populations</span>
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
				<h4>Source Population</h4>
				<ParamInput label="Size (N)" bind:value={sourceN} min={100} max={2000} step={100} />
				<ParamInput label="Initial p" bind:value={initialP} min={0.1} max={0.9} step={0.05} />
			</div>
			<div class="param-group">
				<h4>Founding Event</h4>
				<ParamInput label="Founders" bind:value={founderN} min={2} max={50} step={1} />
				<ParamInput label="Trials" bind:value={numTrials} min={1} max={8} step={1} />
			</div>
			<div class="param-group">
				<h4>Simulation</h4>
				<ParamInput label="Generations" bind:value={generations} min={10} max={200} step={10} />
			</div>
			<div class="button-group">
				<button class="btn btn-run" onclick={runSimulation}>
					{running ? 'Restart' : 'Colonize'}
				</button>
				<button class="btn btn-reset" onclick={reset}>
					Reset
				</button>
			</div>
		</div>

		<div class="charts-area">
			<div class="chart-container">
				<h3>Allele Frequency Trajectories</h3>
				<div class="chart" bind:this={chartContainer}></div>
			</div>
			<div class="comparison-container">
				<h3>Frequency Comparison</h3>
				<div class="comparison" bind:this={comparisonContainer}></div>
				{#if sourceStats}
					<div class="source-info">
						<span>Source: AA={sourceStats.AA}, Aa={sourceStats.Aa}, aa={sourceStats.aa}</span>
					</div>
				{/if}
			</div>
		</div>
	</main>

	<div class="info-panel">
		<p>
			<strong>Founder Effect:</strong> When a small group colonizes a new area, their allele
			frequencies may differ from the source population due to sampling. This genetic
			"bottleneck" at colonization creates divergent populations through drift alone.
		</p>
	</div>
</div>

<style>
	.sim {
		height: 100vh;
		display: flex;
		flex-direction: column;
		background: var(--bg);
		transition: background 0.25s;
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
		width: 200px;
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

	.chart-container, .comparison-container {
		background: var(--chart-bg);
		border: 1px solid var(--border);
		border-radius: 6px;
		padding: 0.75rem;
	}

	.chart-container {
		flex: 2;
		display: flex;
		flex-direction: column;
	}

	.comparison-container {
		flex: 1;
		display: flex;
		flex-direction: column;
	}

	.chart-container h3, .comparison-container h3 {
		font-size: 0.8rem;
		font-weight: 500;
		color: var(--text-muted);
		margin-bottom: 0.5rem;
	}

	.chart {
		flex: 1;
		min-height: 200px;
		overflow: hidden;
		position: relative;
	}

	.comparison {
		flex: 1;
		min-height: 120px;
		overflow: hidden;
		position: relative;
	}

	.source-info {
		font-size: 0.75rem;
		color: var(--text-muted);
		text-align: center;
		margin-top: 0.5rem;
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
			min-width: 150px;
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
