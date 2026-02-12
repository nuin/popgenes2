<script lang="ts">
	import SimLayout from '$lib/components/SimLayout.svelte';
	import ParamInput from '$lib/components/ParamInput.svelte';
	import DualChart from '$lib/components/DualChart.svelte';
	import Chart from '$lib/components/Chart.svelte';
	import { simulateFStats, FSTATS_DEFAULTS } from '$lib/sim/fstats';
	import type { SimResult } from '$lib/sim/types';

	let populations = $state(FSTATS_DEFAULTS.populations);
	let populationSize = $state(FSTATS_DEFAULTS.populationSize);
	let initialFreq = $state(FSTATS_DEFAULTS.initialFreq);
	let generations = $state(FSTATS_DEFAULTS.generations);
	let migrationRate = $state(FSTATS_DEFAULTS.migrationRate);
	let inbreedingCoeff = $state(FSTATS_DEFAULTS.inbreedingCoeff);

	let driftData: SimResult = $state([]);
	let fData: SimResult = $state([]);

	function run() {
		const result = simulateFStats({
			populations,
			populationSize,
			initialFreq,
			generations,
			migrationRate,
			inbreedingCoeff,
			plotLines: 8
		});
		driftData = result.driftLines;
		fData = [result.fis, result.fst, result.fit];
	}

	function reset() {
		populations = FSTATS_DEFAULTS.populations;
		populationSize = FSTATS_DEFAULTS.populationSize;
		initialFreq = FSTATS_DEFAULTS.initialFreq;
		generations = FSTATS_DEFAULTS.generations;
		migrationRate = FSTATS_DEFAULTS.migrationRate;
		inbreedingCoeff = FSTATS_DEFAULTS.inbreedingCoeff;
		driftData = [];
		fData = [];
	}
</script>

<SimLayout title="F-Statistics" onrun={run} onreset={reset} helpKey="/gene-flow/f-statistics">
	{#snippet controls()}
		<ParamInput label="Pops" bind:value={populations} min={2} />
		<ParamInput label="Ne" bind:value={populationSize} min={2} />
		<ParamInput label="p₀" bind:value={initialFreq} step={0.01} min={0} max={1} />
		<ParamInput label="Gen" bind:value={generations} min={1} />
		<ParamInput label="m" bind:value={migrationRate} step={0.001} min={0} max={1} />
		<ParamInput label="f" bind:value={inbreedingCoeff} step={0.01} min={0} max={1} />
	{/snippet}
	{#snippet chart()}
		<DualChart>
			{#snippet left()}
				<Chart data={driftData} options={{ yLabel: 'Allele Frequency' }} />
			{/snippet}
			{#snippet right()}
				<Chart data={fData} options={{ yLabel: 'F', yDomain: [-0.5, 1] }} />
			{/snippet}
		</DualChart>
	{/snippet}
</SimLayout>
