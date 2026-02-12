<script lang="ts">
	import SimLayout from '$lib/components/SimLayout.svelte';
	import ParamInput from '$lib/components/ParamInput.svelte';
	import DualChart from '$lib/components/DualChart.svelte';
	import HistogramChart from '$lib/components/HistogramChart.svelte';
	import ResultsPanel from '$lib/components/ResultsPanel.svelte';
	import { computeLinkage } from '$lib/sim/linkage';
	import type { LinkageResult } from '$lib/sim/linkage';
	import type { HistogramBar } from '$lib/charts/histogramChart';

	let nAB = $state(230);
	let nAb = $state(270);
	let naB = $state(120);
	let nab = $state(380);

	const fmt = (n: number) => n.toFixed(4);

	let result: LinkageResult | null = $state(null);
	let obsBars: HistogramBar[] = $state([]);
	let expBars: HistogramBar[] = $state([]);

	function run() {
		result = computeLinkage({ nAB, nAb, naB, nab });
		obsBars = result.histoBars.observed;
		expBars = result.histoBars.expected;
	}

	function reset() {
		nAB = 230;
		nAb = 270;
		naB = 120;
		nab = 380;
		result = null;
		obsBars = [];
		expBars = [];
	}
</script>

<SimLayout title="Linkage Histogram" onrun={run} onreset={reset} helpKey="/linkage/histogram">
	{#snippet controls()}
		<ParamInput label="nAB" bind:value={nAB} min={0} />
		<ParamInput label="nAb" bind:value={nAb} min={0} />
		<ParamInput label="naB" bind:value={naB} min={0} />
		<ParamInput label="nab" bind:value={nab} min={0} />
	{/snippet}
	{#snippet chart()}
		{#if result}
			<div class="histo-layout">
				<ResultsPanel items={[
					{ label: 'D', value: fmt(result.D) },
					{ label: 'Chi²', value: fmt(result.chi) }
				]} />
				<DualChart>
					{#snippet left()}
						<div class="chart-label">Observed</div>
						<HistogramChart bars={obsBars} options={{ yLabel: 'Frequency', xLabel: 'Gamete' }} />
					{/snippet}
					{#snippet right()}
						<div class="chart-label">Expected</div>
						<HistogramChart bars={expBars} options={{ yLabel: 'Frequency', xLabel: 'Gamete' }} />
					{/snippet}
				</DualChart>
			</div>
		{:else}
			<div class="placeholder">Enter gamete counts and click Run</div>
		{/if}
	{/snippet}
</SimLayout>

<style>
	.histo-layout {
		display: flex;
		flex-direction: column;
		height: 100%;
		gap: 0.5rem;
		padding: 0.5rem;
	}

	.chart-label {
		font-family: var(--font-sans);
		font-size: 0.7rem;
		font-weight: 600;
		color: var(--text-muted);
		text-transform: uppercase;
		letter-spacing: 0.05em;
		text-align: center;
		padding-bottom: 0.25rem;
	}

	.placeholder {
		display: flex;
		align-items: center;
		justify-content: center;
		height: 100%;
		color: var(--text-muted);
		font-size: 0.8rem;
	}
</style>
