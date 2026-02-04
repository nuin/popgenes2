<script lang="ts">
	import type { ParabolaPoint, GenotypePoint } from '$lib/sim/definetti';
	import { renderDeFinettiChart } from '$lib/charts/definettiChart';
	import { theme } from '$lib/theme';

	let { parabola, points }: { parabola: ParabolaPoint[]; points: GenotypePoint[] } = $props();

	let container: HTMLDivElement;

	function draw() {
		if (container) {
			renderDeFinettiChart(container, parabola, points);
		}
	}

	$effect(() => {
		void parabola;
		void points;
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
