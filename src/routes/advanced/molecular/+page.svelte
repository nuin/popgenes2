<script lang="ts">
	import SimLayout from '$lib/components/SimLayout.svelte';
	import ParamInput from '$lib/components/ParamInput.svelte';
	import ParamSelect from '$lib/components/ParamSelect.svelte';
	import ResultsTable from '$lib/components/ResultsTable.svelte';
	import ResultsPanel from '$lib/components/ResultsPanel.svelte';
	import { computeMolPopGen, MOLPOPGEN_DEFAULTS } from '$lib/sim/molpopgen';
	import {
		simulateCoalescent,
		expectedSFS,
		getModelDescription,
		COALESCENT_DEFAULTS,
		type DemographicModel
	} from '$lib/sim/coalescent';
	import { renderHistogramChart, type HistogramBar } from '$lib/charts/histogramChart';
	import type { MolPopGenResult } from '$lib/sim/molpopgen';
	import type { CoalescentResult } from '$lib/sim/coalescent';

	// Mode toggle
	let mode: 'calculator' | 'simulation' = $state('simulation');

	// Calculator params
	let n = $state(MOLPOPGEN_DEFAULTS.n);
	let S = $state(MOLPOPGEN_DEFAULTS.S);
	let L = $state(MOLPOPGEN_DEFAULTS.L);
	let kHat = $state(MOLPOPGEN_DEFAULTS.kHat);
	let calcResult: MolPopGenResult | null = $state(null);

	// Simulation params
	let simN = $state(COALESCENT_DEFAULTS.n);
	let theta = $state(COALESCENT_DEFAULTS.theta);
	let simL = $state(COALESCENT_DEFAULTS.L);
	let demoModel: DemographicModel = $state(COALESCENT_DEFAULTS.model);
	let growthRate = $state(COALESCENT_DEFAULTS.growthRate ?? 0.1);
	let bottleneckTime = $state(COALESCENT_DEFAULTS.bottleneckTime ?? 0.5);
	let bottleneckSize = $state(COALESCENT_DEFAULTS.bottleneckSize ?? 0.1);
	let simResult: CoalescentResult | null = $state(null);

	// Chart container
	let chartContainer: HTMLElement | null = $state(null);

	const modelOptions = [
		{ value: 'constant', label: 'Constant' },
		{ value: 'exponential', label: 'Growth' },
		{ value: 'bottleneck', label: 'Bottleneck' }
	];

	function run() {
		if (mode === 'calculator') {
			calcResult = computeMolPopGen({ n, S, L, kHat });
		} else {
			simResult = simulateCoalescent({
				n: simN,
				theta,
				L: simL,
				model: demoModel,
				growthRate,
				bottleneckTime,
				bottleneckSize
			});
		}
	}

	function reset() {
		if (mode === 'calculator') {
			n = MOLPOPGEN_DEFAULTS.n;
			S = MOLPOPGEN_DEFAULTS.S;
			L = MOLPOPGEN_DEFAULTS.L;
			kHat = MOLPOPGEN_DEFAULTS.kHat;
			calcResult = null;
		} else {
			simN = COALESCENT_DEFAULTS.n;
			theta = COALESCENT_DEFAULTS.theta;
			simL = COALESCENT_DEFAULTS.L;
			demoModel = COALESCENT_DEFAULTS.model;
			growthRate = COALESCENT_DEFAULTS.growthRate ?? 0.1;
			bottleneckTime = COALESCENT_DEFAULTS.bottleneckTime ?? 0.5;
			bottleneckSize = COALESCENT_DEFAULTS.bottleneckSize ?? 0.1;
			simResult = null;
		}
	}

	// Render SFS histogram when simulation result changes
	$effect(() => {
		if (chartContainer && simResult) {
			const sfs = simResult.sfs;
			const bars: HistogramBar[] = [];
			for (let i = 1; i < simN; i++) {
				bars.push({
					label: `${i}`,
					value: sfs[i] ?? 0
				});
			}

			const expected = expectedSFS(simN, theta);
			const overlayValues = bars.map((_, i) => expected[i + 1]);

			renderHistogramChart(chartContainer, bars, {
				xLabel: 'Derived Allele Count',
				yLabel: 'Number of Sites',
				overlayValues,
				overlayColor: '#22c55e'
			});
		}
	});
</script>

<SimLayout title="Molecular Population Genetics" onrun={run} onreset={reset} helpKey="/advanced/molecular">
	{#snippet controls()}
		<div class="mode-toggle">
			<button
				class="mode-btn"
				class:active={mode === 'simulation'}
				onclick={() => { mode = 'simulation'; simResult = null; calcResult = null; }}
			>Sim</button>
			<button
				class="mode-btn"
				class:active={mode === 'calculator'}
				onclick={() => { mode = 'calculator'; calcResult = null; simResult = null; }}
			>Calc</button>
		</div>

		{#if mode === 'calculator'}
			<ParamInput label="n" bind:value={n} min={2} max={200} />
			<ParamInput label="S" bind:value={S} min={0} max={1000} />
			<ParamInput label="L" bind:value={L} min={10} max={10000} />
			<ParamInput label="k" bind:value={kHat} step={0.1} min={0} max={500} />
		{:else}
			<ParamInput label="n" bind:value={simN} min={2} max={50} />
			<ParamInput label="θ" bind:value={theta} step={0.5} min={0.1} max={50} />
			<ParamInput label="L" bind:value={simL} min={100} max={5000} />
			<ParamSelect label="Model" bind:value={demoModel} options={modelOptions} />
			{#if demoModel === 'exponential'}
				<ParamInput label="r" bind:value={growthRate} step={0.05} min={-2} max={2} />
			{:else if demoModel === 'bottleneck'}
				<ParamInput label="t" bind:value={bottleneckTime} step={0.1} min={0.1} max={2} />
				<ParamInput label="Nb" bind:value={bottleneckSize} step={0.05} min={0.01} max={0.5} />
			{/if}
		{/if}
	{/snippet}
	{#snippet chart()}
		{#if mode === 'calculator'}
			{#if calcResult}
				<div class="results-layout">
					<ResultsPanel
						items={[
							{ label: "θ_W", value: calcResult.thetaW },
							{ label: 'θ_W/site', value: calcResult.thetaWPerSite },
							{ label: 'π', value: calcResult.pi },
							{ label: 'π total', value: calcResult.piTotal },
							{ label: "Tajima's D", value: calcResult.tajimaD }
						]}
					/>
					<ResultsTable
						caption="Summary Statistics"
						headers={['Statistic', 'Value', 'Description']}
						rows={[
							['n', calcResult.sampleSize, 'Sample size'],
							['L', calcResult.alignmentLength, 'Alignment length'],
							['S', calcResult.segregatingSites, 'Segregating sites'],
							['a₁', calcResult.a1, 'Harmonic number'],
							['θ_W', calcResult.thetaW, "Watterson's estimator"],
							['π', calcResult.pi, 'Nucleotide diversity/site'],
							["Tajima's D", calcResult.tajimaD, '(π - θ_W) / SE']
						]}
					/>
					<div class="interpretation">
						{#if calcResult.tajimaD > 2}
							<span class="tag tag-pos">D &gt; 2: Balancing selection / contraction</span>
						{:else if calcResult.tajimaD < -2}
							<span class="tag tag-neg">D &lt; -2: Purifying selection / expansion</span>
						{:else}
							<span class="tag tag-neu">-2 &lt; D &lt; 2: Neutral</span>
						{/if}
					</div>
				</div>
			{:else}
				<div class="placeholder">Enter parameters and run to compute statistics</div>
			{/if}
		{:else}
			{#if simResult}
				<div class="sim-layout">
					<div class="model-info">
						<span class="model-label">Model:</span>
						<span class="model-name">{getModelDescription({ n: simN, theta, L: simL, model: demoModel, growthRate, bottleneckTime, bottleneckSize })}</span>
					</div>
					<div class="sim-stats">
						<ResultsPanel
							items={[
								{ label: 'S', value: simResult.S },
								{ label: 'k', value: simResult.kHat },
								{ label: 'π', value: simResult.pi },
								{ label: "θ_W", value: simResult.thetaW },
								{ label: "D", value: simResult.tajimaD },
								{ label: 'TMRCA', value: simResult.tmrca }
							]}
						/>
						<div class="interpretation">
							{#if simResult.tajimaD > 2}
								<span class="tag tag-pos">D &gt; 2: Excess intermediate</span>
							{:else if simResult.tajimaD < -2}
								<span class="tag tag-neg">D &lt; -2: Excess rare</span>
							{:else}
								<span class="tag tag-neu">Neutral range</span>
							{/if}
						</div>
					</div>
					<div class="sfs-section">
						<h4>Site Frequency Spectrum</h4>
						<div class="legend">
							<span class="legend-bar">■ Observed</span>
							<span class="legend-line">--- Expected</span>
						</div>
						<div class="chart-container" bind:this={chartContainer}></div>
					</div>
					<div class="seq-preview">
						<h4>Sequences ({simResult.sequences.length}) - {simResult.mutations.length} mutations</h4>
						<div class="seq-scroll">
							<div class="seq-row ancestral">
								<span class="seq-num">Anc</span>
								<span class="seq-text">{simResult.ancestralSequence.slice(0, 60)}...</span>
							</div>
							{#each simResult.sequences.slice(0, 6) as seq, i}
								<div class="seq-row">
									<span class="seq-num">{i + 1}</span>
									<span class="seq-text">{seq.slice(0, 60)}...</span>
								</div>
							{/each}
							{#if simResult.sequences.length > 6}
								<div class="seq-more">+ {simResult.sequences.length - 6} more</div>
							{/if}
						</div>
					</div>
				</div>
			{:else}
				<div class="placeholder">
					<div class="placeholder-content">
						<span class="placeholder-title">Coalescent Simulation</span>
						<span class="placeholder-desc">Simulates DNA under Kingman's coalescent</span>
						<ul class="placeholder-list">
							<li><strong>Constant:</strong> Standard neutral</li>
							<li><strong>Growth:</strong> Expanding population</li>
							<li><strong>Bottleneck:</strong> Past reduction</li>
						</ul>
					</div>
				</div>
			{/if}
		{/if}
	{/snippet}
</SimLayout>

<style>
	.mode-toggle {
		display: flex;
		border: 1px solid var(--border);
		border-radius: 4px;
		overflow: hidden;
	}

	.mode-btn {
		padding: 0.3rem 0.5rem;
		font-size: 0.65rem;
		font-weight: 500;
		text-transform: uppercase;
		letter-spacing: 0.03em;
		color: var(--text-muted);
		background: transparent;
		border: none;
		cursor: pointer;
		transition: all 0.15s;
	}

	.mode-btn:hover {
		color: var(--text);
	}

	.mode-btn.active {
		background: var(--accent);
		color: var(--bg);
	}

	.results-layout {
		display: flex;
		flex-direction: column;
		gap: 1rem;
		height: 100%;
		overflow: auto;
	}

	.sim-layout {
		display: flex;
		flex-direction: column;
		gap: 0.75rem;
		height: 100%;
		overflow: auto;
	}

	.model-info {
		display: flex;
		align-items: center;
		gap: 0.5rem;
		padding: 0.4rem 0.6rem;
		background: var(--chart-bg);
		border: 1px solid var(--border);
		border-radius: 4px;
		font-size: 0.7rem;
	}

	.model-label {
		color: var(--text-muted);
		text-transform: uppercase;
		font-size: 0.6rem;
	}

	.model-name {
		color: var(--accent);
		font-weight: 500;
	}

	.sim-stats {
		display: flex;
		flex-direction: column;
		gap: 0.5rem;
	}

	.sfs-section {
		flex: 1;
		min-height: 160px;
		display: flex;
		flex-direction: column;
	}

	.sfs-section h4 {
		font-size: 0.65rem;
		font-weight: 500;
		text-transform: uppercase;
		letter-spacing: 0.1em;
		color: var(--text-muted);
		margin: 0 0 0.4rem 0;
	}

	.legend {
		display: flex;
		gap: 1rem;
		margin-bottom: 0.4rem;
		font-size: 0.6rem;
		color: var(--text-muted);
	}

	.legend-bar { color: var(--viz-1, #3b82f6); }
	.legend-line { color: #22c55e; }

	.chart-container {
		flex: 1;
		min-height: 140px;
	}

	.seq-preview {
		border-top: 1px solid var(--border);
		padding-top: 0.5rem;
	}

	.seq-preview h4 {
		font-size: 0.65rem;
		font-weight: 500;
		text-transform: uppercase;
		letter-spacing: 0.1em;
		color: var(--text-muted);
		margin: 0 0 0.4rem 0;
	}

	.seq-scroll {
		max-height: 90px;
		overflow-y: auto;
		font-family: var(--font-mono, monospace);
		font-size: 0.55rem;
		background: var(--chart-bg);
		border: 1px solid var(--border);
		border-radius: 4px;
		padding: 0.4rem;
	}

	.seq-row {
		display: flex;
		gap: 0.4rem;
		line-height: 1.3;
	}

	.seq-row.ancestral {
		color: var(--accent);
		border-bottom: 1px solid var(--border);
		padding-bottom: 0.2rem;
		margin-bottom: 0.2rem;
	}

	.seq-num {
		color: var(--text-muted);
		min-width: 1.5rem;
		text-align: right;
	}

	.seq-text {
		color: var(--text);
		word-break: break-all;
	}

	.seq-more {
		margin-top: 0.2rem;
		color: var(--text-muted);
		font-style: italic;
	}

	.interpretation { padding: 0.4rem 0; }

	.tag {
		font-size: 0.65rem;
		font-weight: 500;
		padding: 0.25rem 0.6rem;
		border-radius: 4px;
	}

	.tag-pos {
		background: rgba(59, 130, 246, 0.1);
		color: var(--viz-1, #3b82f6);
	}

	.tag-neg {
		background: rgba(239, 68, 68, 0.1);
		color: var(--viz-2, #ef4444);
	}

	.tag-neu {
		background: rgba(34, 197, 94, 0.1);
		color: var(--viz-3, #22c55e);
	}

	.placeholder {
		display: flex;
		align-items: center;
		justify-content: center;
		height: 100%;
		color: var(--text-muted);
	}

	.placeholder-content {
		display: flex;
		flex-direction: column;
		align-items: center;
		gap: 0.5rem;
		text-align: center;
	}

	.placeholder-title {
		font-size: 0.9rem;
		font-weight: 600;
		color: var(--text);
	}

	.placeholder-desc {
		font-size: 0.7rem;
	}

	.placeholder-list {
		text-align: left;
		font-size: 0.65rem;
		padding-left: 1.2rem;
		margin: 0;
	}

	.placeholder-list li { margin-bottom: 0.2rem; }
</style>
