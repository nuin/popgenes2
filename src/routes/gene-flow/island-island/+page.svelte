<script lang="ts">
	import SimLayout from '$lib/components/SimLayout.svelte';
	import ParamInput from '$lib/components/ParamInput.svelte';
	import Chart from '$lib/components/Chart.svelte';
	import { simulateIslandIsland, ISLAND_ISLAND_DEFAULTS } from '$lib/sim/migration';
	import type { SimResult } from '$lib/sim/types';

	let p1 = $state(ISLAND_ISLAND_DEFAULTS.p1);
	let p2 = $state(ISLAND_ISLAND_DEFAULTS.p2);
	let m1 = $state(ISLAND_ISLAND_DEFAULTS.m1);
	let m2 = $state(ISLAND_ISLAND_DEFAULTS.m2);
	let generations = $state(ISLAND_ISLAND_DEFAULTS.generations);

	let data: SimResult = $state([]);

	function run() {
		data = simulateIslandIsland({ p1, p2, m1, m2, generations });
	}

	function reset() {
		p1 = ISLAND_ISLAND_DEFAULTS.p1;
		p2 = ISLAND_ISLAND_DEFAULTS.p2;
		m1 = ISLAND_ISLAND_DEFAULTS.m1;
		m2 = ISLAND_ISLAND_DEFAULTS.m2;
		generations = ISLAND_ISLAND_DEFAULTS.generations;
		data = [];
	}
</script>

<SimLayout title="Island-Island Migration" onrun={run} onreset={reset} helpKey="/gene-flow/island-island">
	{#snippet controls()}
		<ParamInput label="p₁" bind:value={p1} step={0.01} min={0} max={1} />
		<ParamInput label="p₂" bind:value={p2} step={0.01} min={0} max={1} />
		<ParamInput label="m₁" bind:value={m1} step={0.001} min={0} max={1} />
		<ParamInput label="m₂" bind:value={m2} step={0.001} min={0} max={1} />
		<ParamInput label="Gen" bind:value={generations} min={1} />
	{/snippet}
	{#snippet chart()}
		<Chart {data} />
	{/snippet}
</SimLayout>
