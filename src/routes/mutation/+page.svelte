<script lang="ts">
	import SimLayout from '$lib/components/SimLayout.svelte';
	import ParamInput from '$lib/components/ParamInput.svelte';
	import Chart from '$lib/components/Chart.svelte';
	import { simulateMutation, MUTATION_DEFAULTS } from '$lib/sim/mutation';
	import type { SimResult } from '$lib/sim/types';

	let mu = $state(MUTATION_DEFAULTS.mu);
	let nu = $state(MUTATION_DEFAULTS.nu);
	let initialFreq = $state(MUTATION_DEFAULTS.initialFreq);
	let generations = $state(MUTATION_DEFAULTS.generations);

	let data: SimResult = $state([]);

	function run() {
		data = simulateMutation({ mu, nu, initialFreq, generations });
	}

	function reset() {
		mu = MUTATION_DEFAULTS.mu;
		nu = MUTATION_DEFAULTS.nu;
		initialFreq = MUTATION_DEFAULTS.initialFreq;
		generations = MUTATION_DEFAULTS.generations;
		data = [];
	}
</script>

<SimLayout title="Two-Way Mutation" onrun={run} onreset={reset} helpKey="/mutation">
	{#snippet controls()}
		<ParamInput label="μ" bind:value={mu} step={0.0001} min={0} max={1} />
		<ParamInput label="ν" bind:value={nu} step={0.0001} min={0} max={1} />
		<ParamInput label="P(A)" bind:value={initialFreq} step={0.01} min={0} max={1} />
		<ParamInput label="Gen" bind:value={generations} min={1} />
	{/snippet}
	{#snippet chart()}
		<Chart {data} />
	{/snippet}
</SimLayout>
