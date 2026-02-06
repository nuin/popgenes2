<script lang="ts">
	import SimLayout from '$lib/components/SimLayout.svelte';
	import ParamInput from '$lib/components/ParamInput.svelte';
	import HistogramChart from '$lib/components/HistogramChart.svelte';
	import { buildTransitionMatrix, evolveMarkov, MARKOV_DEFAULTS } from '$lib/sim/markov';
	import type { MarkovResult } from '$lib/sim/markov';
	import type { HistogramBar } from '$lib/charts/histogramChart';

	let Ne = $state(MARKOV_DEFAULTS.Ne);
	let initialFreqIndex = $state(MARKOV_DEFAULTS.initialFreqIndex);
	let generations = $state(MARKOV_DEFAULTS.generations);

	let bars: HistogramBar[] = $state([]);
	let stateCount = $derived(2 * Ne + 1);

	function run() {
		const idx = Math.min(initialFreqIndex, stateCount - 1);
		const matrix = buildTransitionMatrix(Ne);
		const result = evolveMarkov(matrix, idx, generations);
		bars = result.bars;
	}

	function reset() {
		Ne = MARKOV_DEFAULTS.Ne;
		initialFreqIndex = MARKOV_DEFAULTS.initialFreqIndex;
		generations = MARKOV_DEFAULTS.generations;
		bars = [];
	}
</script>

<SimLayout title="Markov Chain Drift" onrun={run} onreset={reset}>
	{#snippet controls()}
		<ParamInput label="Ne" bind:value={Ne} min={2} max={50} />
		<ParamInput label="State" bind:value={initialFreqIndex} min={0} max={stateCount - 1} />
		<ParamInput label="Gen" bind:value={generations} min={1} max={2000} />
	{/snippet}
	{#snippet chart()}
		<HistogramChart {bars} options={{ xLabel: 'State (allele copies)', yLabel: 'Probability' }} />
	{/snippet}
</SimLayout>
