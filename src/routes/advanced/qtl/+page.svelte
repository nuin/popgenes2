<script lang="ts">
	import SimLayout from '$lib/components/SimLayout.svelte';
	import ParamInput from '$lib/components/ParamInput.svelte';
	import Chart from '$lib/components/Chart.svelte';
	import { simulateQTL, QTL_DEFAULTS } from '$lib/sim/qtl';
	import type { QTLResult } from '$lib/sim/qtl';
	import type { SimResult } from '$lib/sim/types';

	let N = $state(QTL_DEFAULTS.N);
	let nQTL = $state(QTL_DEFAULTS.nQTL);
	let generations = $state(QTL_DEFAULTS.generations);
	let p = $state(QTL_DEFAULTS.p);
	let Ve = $state(QTL_DEFAULTS.Ve);
	let maxGenValue = $state(QTL_DEFAULTS.maxGenValue);
	let selStrength = $state(QTL_DEFAULTS.selStrength);

	let alleleFreqs: SimResult = $state([]);
	let means: SimResult = $state([]);
	let variances: SimResult = $state([]);
	let heritability: SimResult = $state([]);

	function run() {
		const result = simulateQTL({ N, nQTL, generations, p, Ve, maxGenValue, selStrength });
		alleleFreqs = result.alleleFreqs;
		means = result.means;
		variances = result.variances;
		heritability = result.heritability;
	}

	function reset() {
		N = QTL_DEFAULTS.N;
		nQTL = QTL_DEFAULTS.nQTL;
		generations = QTL_DEFAULTS.generations;
		p = QTL_DEFAULTS.p;
		Ve = QTL_DEFAULTS.Ve;
		maxGenValue = QTL_DEFAULTS.maxGenValue;
		selStrength = QTL_DEFAULTS.selStrength;
		alleleFreqs = [];
		means = [];
		variances = [];
		heritability = [];
	}
</script>

<SimLayout title="Quantitative Trait Loci" onrun={run} onreset={reset} helpKey="/advanced/qtl">
	{#snippet controls()}
		<ParamInput label="N" bind:value={N} min={10} max={500} />
		<ParamInput label="QTL" bind:value={nQTL} min={2} max={20} />
		<ParamInput label="Gen" bind:value={generations} min={5} max={200} />
		<ParamInput label="p₀" bind:value={p} step={0.1} min={0.1} max={0.9} />
		<ParamInput label="Ve" bind:value={Ve} step={0.1} min={0} max={10} />
		<ParamInput label="Sel" bind:value={selStrength} step={0.01} min={0} max={1} />
	{/snippet}
	{#snippet chart()}
		{#if alleleFreqs.length > 0}
			<div class="grid-2x2">
				<div class="grid-cell">
					<div class="cell-label">Allele Frequencies at QTLs</div>
					<div class="cell-chart">
						<Chart data={alleleFreqs} options={{ yLabel: 'Freq (+)' }} />
					</div>
				</div>
				<div class="grid-cell">
					<div class="cell-label">Mean Values</div>
					<div class="cell-chart">
						<Chart data={means} options={{ yLabel: 'Mean', lineLabels: ['Phenotypic', 'Genotypic'] }} />
					</div>
				</div>
				<div class="grid-cell">
					<div class="cell-label">Variance Components</div>
					<div class="cell-chart">
						<Chart data={variances} options={{ yLabel: 'Variance', lineLabels: ['VP', 'VG'] }} />
					</div>
				</div>
				<div class="grid-cell">
					<div class="cell-label">Heritability</div>
					<div class="cell-chart">
						<Chart data={heritability} options={{ yLabel: 'h²', lineLabels: ['h² = VG/VP'] }} />
					</div>
				</div>
			</div>
		{:else}
			<div class="placeholder">Run simulation to see QTL dynamics</div>
		{/if}
	{/snippet}
</SimLayout>

<style>
	.grid-2x2 {
		display: grid;
		grid-template-columns: 1fr 1fr;
		grid-template-rows: 1fr 1fr;
		gap: 0.5rem;
		width: 100%;
		height: 100%;
	}

	.grid-cell {
		display: flex;
		flex-direction: column;
		min-height: 0;
	}

	.cell-label {
		font-size: 0.6rem;
		font-weight: 600;
		color: var(--text-muted);
		text-transform: uppercase;
		letter-spacing: 0.05em;
		padding: 0.15rem 0;
		flex-shrink: 0;
	}

	.cell-chart {
		flex: 1;
		min-height: 0;
	}

	.placeholder {
		display: flex;
		align-items: center;
		justify-content: center;
		height: 100%;
		color: var(--text-muted);
		font-size: 0.8rem;
	}

	@media (max-width: 768px) {
		.grid-2x2 {
			grid-template-columns: 1fr;
			grid-template-rows: repeat(4, 1fr);
		}
	}
</style>
