<script lang="ts">
	import SimLayout from '$lib/components/SimLayout.svelte';
	import ParamInput from '$lib/components/ParamInput.svelte';
	import HistogramChart from '$lib/components/HistogramChart.svelte';
	import { simulateMuller, MULLER_DEFAULTS } from '$lib/sim/muller';
	import type { MullerSnapshot } from '$lib/sim/muller';

	let N = $state(MULLER_DEFAULTS.N);
	let loci = $state(MULLER_DEFAULTS.loci);
	let mu = $state(MULLER_DEFAULTS.mu);
	let s = $state(MULLER_DEFAULTS.s);
	let generations = $state(MULLER_DEFAULTS.generations);

	let snapshots: MullerSnapshot[] = $state([]);

	function run() {
		const result = simulateMuller({ N, loci, mu, s, generations });
		snapshots = result.snapshots;
	}

	function reset() {
		N = MULLER_DEFAULTS.N;
		loci = MULLER_DEFAULTS.loci;
		mu = MULLER_DEFAULTS.mu;
		s = MULLER_DEFAULTS.s;
		generations = MULLER_DEFAULTS.generations;
		snapshots = [];
	}
</script>

<SimLayout title="Muller's Ratchet" onrun={run} onreset={reset} helpKey="/mutation/muller">
	{#snippet controls()}
		<ParamInput label="N" bind:value={N} min={10} max={200} />
		<ParamInput label="Loci" bind:value={loci} min={5} max={50} />
		<ParamInput label="μ" bind:value={mu} step={0.01} min={0.01} max={1} />
		<ParamInput label="s" bind:value={s} step={0.01} min={0.001} max={0.5} />
		<ParamInput label="Gen" bind:value={generations} min={10} max={1000} />
	{/snippet}
	{#snippet chart()}
		{#if snapshots.length === 4}
			<div class="grid-2x2">
				{#each snapshots as snap}
					<div class="grid-cell">
						<div class="cell-label">Gen {snap.generation}</div>
						<div class="cell-chart">
							<HistogramChart
								bars={snap.bars}
								options={{ xLabel: 'Mutations per genome', yLabel: 'Individuals' }}
							/>
						</div>
					</div>
				{/each}
			</div>
		{:else}
			<div class="placeholder">Run simulation to see mutation accumulation over time</div>
		{/if}
	{/snippet}
</SimLayout>

<style>
	.grid-2x2 {
		display: grid;
		grid-template-columns: 1fr 1fr;
		grid-template-rows: 1fr 1fr;
		gap: 0.5rem;
		width: 100%;
		height: 100%;
	}

	.grid-cell {
		display: flex;
		flex-direction: column;
		min-height: 0;
	}

	.cell-label {
		font-size: 0.65rem;
		font-weight: 600;
		color: var(--text-muted);
		text-transform: uppercase;
		letter-spacing: 0.05em;
		padding: 0.25rem 0;
		flex-shrink: 0;
	}

	.cell-chart {
		flex: 1;
		min-height: 0;
	}

	.placeholder {
		display: flex;
		align-items: center;
		justify-content: center;
		height: 100%;
		color: var(--text-muted);
		font-size: 0.8rem;
	}

	@media (max-width: 768px) {
		.grid-2x2 {
			grid-template-columns: 1fr;
			grid-template-rows: repeat(4, 1fr);
		}
	}
</style>
