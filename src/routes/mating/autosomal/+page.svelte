<script lang="ts">
	import SimLayout from '$lib/components/SimLayout.svelte';
	import ParamInput from '$lib/components/ParamInput.svelte';
	import ResultsPanel from '$lib/components/ResultsPanel.svelte';
	import DeFinettiChart from '$lib/components/DeFinettiChart.svelte';
	import { generateHWEParabola, type GenotypePoint } from '$lib/sim/definetti';
	import { computeAutosomal } from '$lib/sim/mating';

	const parabola = generateHWEParabola();

	let nAA = $state(50);
	let nAa = $state(40);
	let naa = $state(10);

	let points: GenotypePoint[] = $state([]);
	let info: { label: string; value: string | number }[] = $state([]);

	function run() {
		const r = computeAutosomal({ nAA, nAa, naa });
		points = [r.observed, r.afterMating];
		info = [
			{ label: 'p', value: r.p.toFixed(4) },
			{ label: 'q', value: r.q.toFixed(4) },
			{ label: 'D (AA)', value: r.D.toFixed(4) },
			{ label: 'H (Aa)', value: r.H.toFixed(4) },
			{ label: 'R (aa)', value: (1 - r.D - r.H).toFixed(4) }
		];
	}

	function reset() {
		nAA = 50;
		nAa = 40;
		naa = 10;
		points = [];
		info = [];
	}
</script>

<SimLayout title="Autosomal Locus" onrun={run} onreset={reset}>
	{#snippet controls()}
		<ParamInput label="N(AA)" bind:value={nAA} min={0} />
		<ParamInput label="N(Aa)" bind:value={nAa} min={0} />
		<ParamInput label="N(aa)" bind:value={naa} min={0} />
	{/snippet}
	{#snippet chart()}
		<div class="layout">
			<div class="chart-area">
				<DeFinettiChart {parabola} {points} />
			</div>
			{#if info.length > 0}
				<div class="info-panel">
					<ResultsPanel items={info} />
					<div class="legend">
						<div class="legend-item">
							<span class="dot observed"></span> Observed
						</div>
						<div class="legend-item">
							<span class="dot hwe"></span> HWE Expected
						</div>
					</div>
				</div>
			{/if}
		</div>
	{/snippet}
</SimLayout>

<style>
	.layout {
		display: flex;
		height: 100%;
		gap: 1rem;
	}

	.chart-area {
		flex: 1;
		min-width: 0;
	}

	.info-panel {
		width: 180px;
		flex-shrink: 0;
		display: flex;
		flex-direction: column;
		gap: 1rem;
		padding-top: 1rem;
	}

	.legend {
		display: flex;
		flex-direction: column;
		gap: 0.5rem;
		padding: 0.75rem;
	}

	.legend-item {
		display: flex;
		align-items: center;
		gap: 0.5rem;
		font-size: 0.7rem;
		color: var(--text-muted);
	}

	.dot {
		width: 8px;
		height: 8px;
		border-radius: 50%;
	}

	.dot.observed { background: var(--viz-2); }
	.dot.hwe { background: var(--viz-1); }
</style>
