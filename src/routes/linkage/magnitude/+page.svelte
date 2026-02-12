<script lang="ts">
	import SimLayout from '$lib/components/SimLayout.svelte';
	import ParamInput from '$lib/components/ParamInput.svelte';
	import Chart from '$lib/components/Chart.svelte';
	import { simulateMagD, MAGD_DEFAULTS } from '$lib/sim/linkage';
	import type { SimResult } from '$lib/sim/types';

	let r = $state(MAGD_DEFAULTS.r);
	let D0 = $state(MAGD_DEFAULTS.D0);
	let generations = $state(MAGD_DEFAULTS.generations);

	let data: SimResult = $state([]);

	function run() {
		data = simulateMagD({ r, D0, generations });
	}

	function reset() {
		r = MAGD_DEFAULTS.r;
		D0 = MAGD_DEFAULTS.D0;
		generations = MAGD_DEFAULTS.generations;
		data = [];
	}
</script>

<SimLayout title="Magnitude of D" onrun={run} onreset={reset} helpKey="/linkage/magnitude">
	{#snippet controls()}
		<ParamInput label="r" bind:value={r} step={0.01} min={0} max={0.5} />
		<ParamInput label="D₀" bind:value={D0} step={0.01} min={-0.25} max={0.25} />
		<ParamInput label="Gen" bind:value={generations} min={1} />
	{/snippet}
	{#snippet chart()}
		<Chart {data} options={{ yLabel: 'D' }} />
	{/snippet}
</SimLayout>
