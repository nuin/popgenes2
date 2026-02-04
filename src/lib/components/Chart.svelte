<script lang="ts">
	import type { SimResult } from '$lib/sim/types';
	import type { ChartOptions } from '$lib/charts/lineChart';
	import { renderLineChart } from '$lib/charts/lineChart';
	import { theme } from '$lib/theme';

	let { data, options = {} }: { data: SimResult; options?: ChartOptions } = $props();

	let container: HTMLDivElement;

	function draw() {
		if (container && data.length > 0) {
			renderLineChart(container, data, options);
		}
	}

	$effect(() => {
		// Re-render when data or theme changes
		void data;
		void $theme;
		draw();
	});

	$effect(() => {
		// Handle resize
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
