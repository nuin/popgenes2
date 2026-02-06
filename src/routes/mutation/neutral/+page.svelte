<script lang="ts">
	import SimLayout from '$lib/components/SimLayout.svelte';
	import ParamInput from '$lib/components/ParamInput.svelte';
	import Chart from '$lib/components/Chart.svelte';
	import { simulateNeutral, NEUTRAL_DEFAULTS } from '$lib/sim/neutral';
	import type { SimResult } from '$lib/sim/types';

	let populationSize = $state(NEUTRAL_DEFAULTS.populationSize);
	let generations = $state(NEUTRAL_DEFAULTS.generations);
	let interval = $state(NEUTRAL_DEFAULTS.interval);

	let data: SimResult = $state([]);

	function run() {
		data = simulateNeutral({ populationSize, generations, interval });
	}

	function reset() {
		populationSize = NEUTRAL_DEFAULTS.populationSize;
		generations = NEUTRAL_DEFAULTS.generations;
		interval = NEUTRAL_DEFAULTS.interval;
		data = [];
	}
</script>

<SimLayout title="Neutral Mutations" onrun={run} onreset={reset}>
	{#snippet controls()}
		<ParamInput label="Ne" bind:value={populationSize} min={2} />
		<ParamInput label="Gen" bind:value={generations} min={1} />
		<ParamInput label="Interval" bind:value={interval} min={1} />
	{/snippet}
	{#snippet chart()}
		<Chart {data} />
	{/snippet}
</SimLayout>
