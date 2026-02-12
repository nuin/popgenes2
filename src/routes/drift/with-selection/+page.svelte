<script lang="ts">
	import SimLayout from '$lib/components/SimLayout.svelte';
	import ParamInput from '$lib/components/ParamInput.svelte';
	import Chart from '$lib/components/Chart.svelte';
	import { simulateDrift, DRIFT_DEFAULTS } from '$lib/sim/drift';
	import type { SimResult } from '$lib/sim/types';

	let populations = $state(DRIFT_DEFAULTS.populations);
	let populationSize = $state(DRIFT_DEFAULTS.populationSize);
	let initialFreq = $state(DRIFT_DEFAULTS.initialFreq);
	let generations = $state(DRIFT_DEFAULTS.generations);
	let wAA = $state(1.0);
	let wAa = $state(1.0);
	let waa = $state(0.8);

	let data: SimResult = $state([]);

	function run() {
		data = simulateDrift({
			populations, populationSize, initialFreq, generations,
			wAA, wAa, waa
		});
	}

	function reset() {
		populations = DRIFT_DEFAULTS.populations;
		populationSize = DRIFT_DEFAULTS.populationSize;
		initialFreq = DRIFT_DEFAULTS.initialFreq;
		generations = DRIFT_DEFAULTS.generations;
		wAA = 1.0;
		wAa = 1.0;
		waa = 0.8;
		data = [];
	}
</script>

<SimLayout title="Drift + Selection" onrun={run} onreset={reset} helpKey="/drift/with-selection">
	{#snippet controls()}
		<ParamInput label="Pop" bind:value={populations} min={1} />
		<ParamInput label="Ne" bind:value={populationSize} min={2} />
		<ParamInput label="P(A)" bind:value={initialFreq} step={0.01} min={0} max={1} />
		<ParamInput label="Gen" bind:value={generations} min={1} />
		<ParamInput label="wAA" bind:value={wAA} step={0.01} min={0} max={1} />
		<ParamInput label="wAa" bind:value={wAa} step={0.01} min={0} max={1} />
		<ParamInput label="waa" bind:value={waa} step={0.01} min={0} max={1} />
	{/snippet}
	{#snippet chart()}
		<Chart {data} />
	{/snippet}
</SimLayout>
