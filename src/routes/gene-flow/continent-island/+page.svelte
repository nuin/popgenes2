<script lang="ts">
	import SimLayout from '$lib/components/SimLayout.svelte';
	import ParamInput from '$lib/components/ParamInput.svelte';
	import Chart from '$lib/components/Chart.svelte';
	import { simulateContIsland, CONT_ISLAND_DEFAULTS } from '$lib/sim/migration';
	import type { SimResult } from '$lib/sim/types';

	let pContinent = $state(CONT_ISLAND_DEFAULTS.pContinent);
	let pIsland = $state(CONT_ISLAND_DEFAULTS.pIsland);
	let m = $state(CONT_ISLAND_DEFAULTS.m);
	let generations = $state(CONT_ISLAND_DEFAULTS.generations);

	let data: SimResult = $state([]);

	function run() {
		data = simulateContIsland({ pContinent, pIsland, m, generations });
	}

	function reset() {
		pContinent = CONT_ISLAND_DEFAULTS.pContinent;
		pIsland = CONT_ISLAND_DEFAULTS.pIsland;
		m = CONT_ISLAND_DEFAULTS.m;
		generations = CONT_ISLAND_DEFAULTS.generations;
		data = [];
	}
</script>

<SimLayout title="Continent-Island Migration" onrun={run} onreset={reset} helpKey="/gene-flow/continent-island">
	{#snippet controls()}
		<ParamInput label="p(cont)" bind:value={pContinent} step={0.01} min={0} max={1} />
		<ParamInput label="p(isle)" bind:value={pIsland} step={0.01} min={0} max={1} />
		<ParamInput label="m" bind:value={m} step={0.001} min={0} max={1} />
		<ParamInput label="Gen" bind:value={generations} min={1} />
	{/snippet}
	{#snippet chart()}
		<Chart {data} />
	{/snippet}
</SimLayout>
