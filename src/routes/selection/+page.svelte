<script lang="ts">
	import SimLayout from '$lib/components/SimLayout.svelte';
	import ParamInput from '$lib/components/ParamInput.svelte';
	import Chart from '$lib/components/Chart.svelte';
	import { simulateSelection, SELECTION_DEFAULTS } from '$lib/sim/selection';
	import type { SimResult } from '$lib/sim/types';

	let wAA = $state(SELECTION_DEFAULTS.wAA);
	let wAa = $state(SELECTION_DEFAULTS.wAa);
	let waa = $state(SELECTION_DEFAULTS.waa);
	let initialFreq = $state(SELECTION_DEFAULTS.initialFreq);
	let generations = $state(SELECTION_DEFAULTS.generations);

	let data: SimResult = $state([]);

	function run() {
		data = simulateSelection({ wAA, wAa, waa, initialFreq, generations });
	}

	function reset() {
		wAA = SELECTION_DEFAULTS.wAA;
		wAa = SELECTION_DEFAULTS.wAa;
		waa = SELECTION_DEFAULTS.waa;
		initialFreq = SELECTION_DEFAULTS.initialFreq;
		generations = SELECTION_DEFAULTS.generations;
		data = [];
	}
</script>

<SimLayout title="Natural Selection" onrun={run} onreset={reset} helpKey="/selection">
	{#snippet controls()}
		<ParamInput label="wAA" bind:value={wAA} step={0.01} min={0} max={2} />
		<ParamInput label="wAa" bind:value={wAa} step={0.01} min={0} max={2} />
		<ParamInput label="waa" bind:value={waa} step={0.01} min={0} max={2} />
		<ParamInput label="P(A)" bind:value={initialFreq} step={0.01} min={0} max={1} />
		<ParamInput label="Gen" bind:value={generations} min={1} />
	{/snippet}
	{#snippet chart()}
		<Chart {data} />
	{/snippet}
</SimLayout>
