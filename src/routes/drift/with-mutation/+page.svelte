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
	let mu = $state(0.0001);
	let nu = $state(0.00001);

	let data: SimResult = $state([]);

	function run() {
		data = simulateDrift({
			populations, populationSize, initialFreq, generations,
			mu, nu
		});
	}

	function reset() {
		populations = DRIFT_DEFAULTS.populations;
		populationSize = DRIFT_DEFAULTS.populationSize;
		initialFreq = DRIFT_DEFAULTS.initialFreq;
		generations = DRIFT_DEFAULTS.generations;
		mu = 0.0001;
		nu = 0.00001;
		data = [];
	}
</script>

<SimLayout title="Drift + Mutation" onrun={run} onreset={reset} helpKey="/drift/with-mutation">
	{#snippet controls()}
		<ParamInput label="Pop" bind:value={populations} min={1} />
		<ParamInput label="Ne" bind:value={populationSize} min={2} />
		<ParamInput label="P(A)" bind:value={initialFreq} step={0.01} min={0} max={1} />
		<ParamInput label="Gen" bind:value={generations} min={1} />
		<ParamInput label="μ" bind:value={mu} step={0.00001} min={0} max={1} />
		<ParamInput label="ν" bind:value={nu} step={0.00001} min={0} max={1} />
	{/snippet}
	{#snippet chart()}
		<Chart {data} />
	{/snippet}
</SimLayout>
