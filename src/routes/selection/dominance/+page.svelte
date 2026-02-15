<script lang="ts">
	import SimLayout from '$lib/components/SimLayout.svelte';
	import ParamInput from '$lib/components/ParamInput.svelte';
	import Chart from '$lib/components/Chart.svelte';
	import {
		simulateDominance,
		simulateDominanceComparison,
		dominanceInfo,
		DOMINANCE_DEFAULTS
	} from '$lib/sim/dominance';
	import type { SimResult } from '$lib/sim/types';

	let s = $state(DOMINANCE_DEFAULTS.s);
	let h = $state(DOMINANCE_DEFAULTS.h);
	let initialFreq = $state(DOMINANCE_DEFAULTS.initialFreq);
	let generations = $state(DOMINANCE_DEFAULTS.generations);
	let compareMode = $state(false);

	let data: SimResult = $state([]);

	const info = $derived(dominanceInfo({ s, h, initialFreq, generations }));

	function run() {
		if (compareMode) {
			data = simulateDominanceComparison({ s, initialFreq, generations });
		} else {
			data = simulateDominance({ s, h, initialFreq, generations });
		}
	}

	function reset() {
		s = DOMINANCE_DEFAULTS.s;
		h = DOMINANCE_DEFAULTS.h;
		initialFreq = DOMINANCE_DEFAULTS.initialFreq;
		generations = DOMINANCE_DEFAULTS.generations;
		compareMode = false;
		data = [];
	}
</script>

<SimLayout title="Dominance & Selection" onrun={run} onreset={reset} helpKey="/selection/dominance">
	{#snippet controls()}
		<ParamInput label="s" bind:value={s} step={0.01} min={0} max={1} />
		<ParamInput label="h" bind:value={h} step={0.05} min={0} max={1} disabled={compareMode} />
		<ParamInput label="P(A)" bind:value={initialFreq} step={0.01} min={0.001} max={0.999} />
		<ParamInput label="Gen" bind:value={generations} min={10} max={2000} />

		<label class="compare-toggle">
			<input type="checkbox" bind:checked={compareMode} />
			<span>Compare h values</span>
		</label>

		<div class="info-panel">
			<div class="info-row">
				<span class="info-label">wAA</span>
				<span class="info-value">{info.wAA.toFixed(3)}</span>
			</div>
			<div class="info-row">
				<span class="info-label">wAa</span>
				<span class="info-value">{info.wAa.toFixed(3)}</span>
			</div>
			<div class="info-row">
				<span class="info-label">waa</span>
				<span class="info-value">{info.waa.toFixed(3)}</span>
			</div>
			<div class="info-type">{info.dominanceType}</div>
		</div>
	{/snippet}
	{#snippet chart()}
		<Chart
			{data}
			legendLabels={compareMode ? ['h=0', 'h=0.25', 'h=0.5', 'h=0.75', 'h=1'] : undefined}
		/>
	{/snippet}
</SimLayout>

<style>
	.compare-toggle {
		display: flex;
		align-items: center;
		gap: 0.5rem;
		font-size: 0.75rem;
		color: var(--text-muted);
		cursor: pointer;
		padding: 0.5rem 0;
	}

	.compare-toggle input {
		cursor: pointer;
	}

	.info-panel {
		margin-top: 0.75rem;
		padding: 0.75rem;
		background: var(--chart-bg);
		border: 1px solid var(--border);
		border-radius: 4px;
		font-size: 0.7rem;
	}

	.info-row {
		display: flex;
		justify-content: space-between;
		margin-bottom: 0.25rem;
	}

	.info-label {
		color: var(--text-muted);
	}

	.info-value {
		font-family: var(--font-mono, monospace);
		color: var(--text);
	}

	.info-type {
		margin-top: 0.5rem;
		padding-top: 0.5rem;
		border-top: 1px solid var(--border);
		color: var(--accent);
		font-size: 0.65rem;
	}
</style>
