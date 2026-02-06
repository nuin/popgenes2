<script lang="ts">
	import SimLayout from '$lib/components/SimLayout.svelte';
	import ParamInput from '$lib/components/ParamInput.svelte';
	import DriftChart from '$lib/components/DriftChart.svelte';
	import { simulateDrift, DRIFT_DEFAULTS } from '$lib/sim/drift';
	import type { SimResult } from '$lib/sim/types';

	let populations = $state(DRIFT_DEFAULTS.populations);
	let populationSize = $state(DRIFT_DEFAULTS.populationSize);
	let initialFreq = $state(DRIFT_DEFAULTS.initialFreq);
	let generations = $state(DRIFT_DEFAULTS.generations);

	let data: SimResult = $state([]);

	function run() {
		data = simulateDrift({ populations, populationSize, initialFreq, generations });
	}

	function reset() {
		populations = DRIFT_DEFAULTS.populations;
		populationSize = DRIFT_DEFAULTS.populationSize;
		initialFreq = DRIFT_DEFAULTS.initialFreq;
		generations = DRIFT_DEFAULTS.generations;
		data = [];
	}
</script>

<SimLayout title="Genetic Drift" onrun={run} onreset={reset}>
	{#snippet controls()}
		<ParamInput label="Pop" bind:value={populations} min={1} />
		<ParamInput label="Ne" bind:value={populationSize} min={2} />
		<ParamInput label="P(A)" bind:value={initialFreq} step={0.01} min={0} max={1} />
		<ParamInput label="Gen" bind:value={generations} min={1} />
	{/snippet}
	{#snippet chart()}
		<DriftChart {data} {initialFreq} {populationSize} />
	{/snippet}
</SimLayout>
