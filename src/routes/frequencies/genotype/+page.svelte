<script lang="ts">
	import SimLayout from '$lib/components/SimLayout.svelte';
	import { generateGenotypeCurves } from '$lib/sim/genotype';
	import { renderCurveChart } from '$lib/charts/curveChart';
	import type { CurveData } from '$lib/charts/curveChart';

	let curves: CurveData[] = $state([]);
	let chartEl: HTMLDivElement;

	function run() {
		curves = generateGenotypeCurves();
	}

	function reset() {
		curves = [];
	}

	$effect(() => {
		if (chartEl && curves.length > 0) {
			renderCurveChart(chartEl, curves, {
				xLabel: 'p (frequency of A)',
				yLabel: 'Genotype Frequency'
			});
		}
	});
</script>

<SimLayout title="Genotype Frequencies" onrun={run} onreset={reset}>
	{#snippet controls()}
		<span style="font-size: 0.7rem; color: var(--text-muted);">
			Click Run to plot HWE curves (p², 2pq, q²)
		</span>
	{/snippet}
	{#snippet chart()}
		<div class="chart-wrap" bind:this={chartEl}></div>
	{/snippet}
</SimLayout>

<style>
	.chart-wrap {
		width: 100%;
		height: 100%;
	}
</style>
