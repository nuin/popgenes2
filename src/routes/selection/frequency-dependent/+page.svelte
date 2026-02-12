<script lang="ts">
	import SimLayout from '$lib/components/SimLayout.svelte';
	import ParamInput from '$lib/components/ParamInput.svelte';
	import DualChart from '$lib/components/DualChart.svelte';
	import CurveChart from '$lib/components/CurveChart.svelte';
	import { computeFreqDep, FREQDEP_DEFAULTS } from '$lib/sim/frequency-dependent';
	import type { CurveData } from '$lib/charts/curveChart';

	let s1 = $state(FREQDEP_DEFAULTS.s1);
	let s2 = $state(FREQDEP_DEFAULTS.s2);
	let s3 = $state(FREQDEP_DEFAULTS.s3);

	let deltaCurves: CurveData[] = $state([]);
	let fitnessCurves: CurveData[] = $state([]);

	function run() {
		const result = computeFreqDep({ s1, s2, s3 });
		deltaCurves = [result.deltaP];
		fitnessCurves = [result.wAA, result.wAa, result.waa, result.wBar];
	}

	function reset() {
		s1 = FREQDEP_DEFAULTS.s1;
		s2 = FREQDEP_DEFAULTS.s2;
		s3 = FREQDEP_DEFAULTS.s3;
		deltaCurves = [];
		fitnessCurves = [];
	}
</script>

<SimLayout title="Frequency-Dependent Selection" onrun={run} onreset={reset} helpKey="/selection/frequency-dependent">
	{#snippet controls()}
		<ParamInput label="s₁ (AA)" bind:value={s1} step={0.01} min={0} max={1} />
		<ParamInput label="s₂ (Aa)" bind:value={s2} step={0.01} min={0} max={1} />
		<ParamInput label="s₃ (aa)" bind:value={s3} step={0.01} min={0} max={1} />
	{/snippet}
	{#snippet chart()}
		<DualChart>
			{#snippet left()}
				<CurveChart curves={deltaCurves} options={{ xLabel: 'p', yLabel: 'Δp' }} />
			{/snippet}
			{#snippet right()}
				<CurveChart curves={fitnessCurves} options={{ xLabel: 'p', yLabel: 'Fitness' }} />
			{/snippet}
		</DualChart>
	{/snippet}
</SimLayout>
