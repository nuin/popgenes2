<script lang="ts">
	import SimLayout from '$lib/components/SimLayout.svelte';
	import ParamInput from '$lib/components/ParamInput.svelte';
	import Chart from '$lib/components/Chart.svelte';
	import { simulateHtime, HTIME_DEFAULTS } from '$lib/sim/htime';
	import type { SimResult } from '$lib/sim/types';

	let Ne = $state(HTIME_DEFAULTS.Ne);
	let p = $state(HTIME_DEFAULTS.p);
	let generations = $state(HTIME_DEFAULTS.generations);
	let nDrift = $state(HTIME_DEFAULTS.nDrift);

	let data: SimResult = $state([]);

	function run() {
		data = simulateHtime({ Ne, p, generations, nDrift });
	}

	function reset() {
		Ne = HTIME_DEFAULTS.Ne;
		p = HTIME_DEFAULTS.p;
		generations = HTIME_DEFAULTS.generations;
		nDrift = HTIME_DEFAULTS.nDrift;
		data = [];
	}
</script>

<SimLayout title="Heterozygosity Decline" onrun={run} onreset={reset}>
	{#snippet controls()}
		<ParamInput label="Ne" bind:value={Ne} min={2} />
		<ParamInput label="p" bind:value={p} step={0.01} min={0.01} max={0.5} />
		<ParamInput label="Gen" bind:value={generations} min={1} />
		<ParamInput label="Drift" bind:value={nDrift} min={0} max={8} />
	{/snippet}
	{#snippet chart()}
		<Chart {data} options={{ yLabel: 'H' }} />
	{/snippet}
</SimLayout>
