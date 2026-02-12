<script lang="ts">
	import SimLayout from '$lib/components/SimLayout.svelte';
	import ParamInput from '$lib/components/ParamInput.svelte';
	import ParamSelect from '$lib/components/ParamSelect.svelte';
	import DeFinettiChart from '$lib/components/DeFinettiChart.svelte';
	import { generateHWEParabola, type GenotypePoint } from '$lib/sim/definetti';
	import {
		simulateSimpleAssortative,
		SIMPLE_ASSORTATIVE_DEFAULTS,
		type SimpleAssortativeModel
	} from '$lib/sim/assortative';

	const parabola = generateHWEParabola();

	let D = $state(SIMPLE_ASSORTATIVE_DEFAULTS.D);
	let H = $state(SIMPLE_ASSORTATIVE_DEFAULTS.H);
	let generations = $state(SIMPLE_ASSORTATIVE_DEFAULTS.generations);
	let model: string = $state(SIMPLE_ASSORTATIVE_DEFAULTS.model);

	const modelOptions = [
		{ value: 'positive-dominant', label: 'Positive (dominance)' },
		{ value: 'positive-no-dominant', label: 'Positive (no dom.)' },
		{ value: 'negative', label: 'Negative' }
	];

	let points: GenotypePoint[] = $state([]);

	function run() {
		const result = simulateSimpleAssortative({
			D,
			H,
			generations,
			model: model as SimpleAssortativeModel
		});
		points = result.points;
	}

	function reset() {
		D = SIMPLE_ASSORTATIVE_DEFAULTS.D;
		H = SIMPLE_ASSORTATIVE_DEFAULTS.H;
		generations = SIMPLE_ASSORTATIVE_DEFAULTS.generations;
		model = SIMPLE_ASSORTATIVE_DEFAULTS.model;
		points = [];
	}
</script>

<SimLayout title="Assortative Mating" onrun={run} onreset={reset} helpKey="/mating/assortative">
	{#snippet controls()}
		<ParamInput label="D (AA)" bind:value={D} step={0.01} min={0} max={1} />
		<ParamInput label="H (Aa)" bind:value={H} step={0.01} min={0} max={1} />
		<ParamInput label="Gen" bind:value={generations} min={1} />
		<ParamSelect label="Model" bind:value={model} options={modelOptions} />
	{/snippet}
	{#snippet chart()}
		<DeFinettiChart {parabola} {points} />
	{/snippet}
</SimLayout>
