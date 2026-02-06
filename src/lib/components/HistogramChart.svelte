<script lang="ts">
	import type { HistogramBar, HistogramOptions } from '$lib/charts/histogramChart';
	import { renderHistogramChart } from '$lib/charts/histogramChart';
	import { theme } from '$lib/theme';

	let {
		bars,
		options = {}
	}: {
		bars: HistogramBar[];
		options?: HistogramOptions;
	} = $props();

	let container: HTMLDivElement;

	function draw() {
		if (container && bars.length > 0) {
			renderHistogramChart(container, bars, options);
		}
	}

	$effect(() => {
		void bars;
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
