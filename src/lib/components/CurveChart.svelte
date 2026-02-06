<script lang="ts">
	import type { CurveData, CurveChartOptions } from '$lib/charts/curveChart';
	import { renderCurveChart } from '$lib/charts/curveChart';
	import { theme } from '$lib/theme';

	let {
		curves,
		options = {}
	}: {
		curves: CurveData[];
		options?: CurveChartOptions;
	} = $props();

	let container: HTMLDivElement;

	function draw() {
		if (container && curves.length > 0) {
			renderCurveChart(container, curves, options);
		}
	}

	$effect(() => {
		void curves;
		void $theme;
		draw();
	});

	$effect(() => {
		const observer = new ResizeObserver(() => draw());
		if (container) observer.observe(container);
		return () => observer.disconnect();
	});
</script>

<div class="chart" bind:this={container}></div>

<style>
	.chart {
		width: 100%;
		height: 100%;
	}
</style>
