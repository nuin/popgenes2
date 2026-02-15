<script lang="ts">
	import SimLayout from '$lib/components/SimLayout.svelte';
	import ParamInput from '$lib/components/ParamInput.svelte';
	import Chart from '$lib/components/Chart.svelte';
	import {
		simulateSteppingStone,
		generateGradient,
		equilibriumFrequency,
		STEPPING_STONE_DEFAULTS
	} from '$lib/sim/stepping-stone';
	import type { SimResult } from '$lib/sim/types';

	let numPops = $state(STEPPING_STONE_DEFAULTS.numPops);
	let m = $state(STEPPING_STONE_DEFAULTS.m);
	let generations = $state(STEPPING_STONE_DEFAULTS.generations);
	let pLeft = $state(0.9);
	let pRight = $state(0.1);
	let initialFreqs = $state([...STEPPING_STONE_DEFAULTS.initialFreqs]);

	let data: SimResult = $state([]);
	let eqFreq = $state<number | null>(null);

	// Generate population labels for legend
	const legendLabels = $derived(
		Array.from({ length: numPops }, (_, i) => `Pop ${i + 1}`)
	);

	function applyGradient() {
		initialFreqs = generateGradient(numPops, pLeft, pRight);
	}

	function run() {
		// Ensure initialFreqs matches numPops
		while (initialFreqs.length < numPops) {
			initialFreqs.push(0.5);
		}
		initialFreqs = initialFreqs.slice(0, numPops);

		data = simulateSteppingStone({
			numPops,
			m,
			initialFreqs,
			generations
		});
		eqFreq = equilibriumFrequency(initialFreqs);
	}

	function reset() {
		numPops = STEPPING_STONE_DEFAULTS.numPops;
		m = STEPPING_STONE_DEFAULTS.m;
		generations = STEPPING_STONE_DEFAULTS.generations;
		pLeft = 0.9;
		pRight = 0.1;
		initialFreqs = [...STEPPING_STONE_DEFAULTS.initialFreqs];
		data = [];
		eqFreq = null;
	}

	// Update initialFreqs when numPops changes
	$effect(() => {
		if (initialFreqs.length !== numPops) {
			initialFreqs = generateGradient(numPops, pLeft, pRight);
		}
	});
</script>

<SimLayout title="Stepping-Stone Model" onrun={run} onreset={reset} helpKey="/gene-flow/stepping-stone">
	{#snippet controls()}
		<ParamInput label="Pops" bind:value={numPops} min={2} max={10} step={1} />
		<ParamInput label="m" bind:value={m} step={0.01} min={0} max={0.5} />
		<ParamInput label="Gen" bind:value={generations} min={10} max={500} />

		<div class="gradient-section">
			<div class="gradient-row">
				<ParamInput label="p(left)" bind:value={pLeft} step={0.1} min={0} max={1} />
				<ParamInput label="p(right)" bind:value={pRight} step={0.1} min={0} max={1} />
			</div>
			<button class="btn-gradient" onclick={applyGradient}>Apply Gradient</button>
		</div>

		<div class="freq-list">
			<span class="freq-label">Initial frequencies:</span>
			{#each initialFreqs.slice(0, numPops) as freq, i}
				<div class="freq-item">
					<span class="pop-num">{i + 1}</span>
					<input
						type="number"
						min="0"
						max="1"
						step="0.1"
						value={freq.toFixed(2)}
						onchange={(e) => {
							const val = parseFloat((e.target as HTMLInputElement).value);
							if (!isNaN(val)) {
								initialFreqs[i] = Math.max(0, Math.min(1, val));
							}
						}}
					/>
				</div>
			{/each}
		</div>

		{#if eqFreq !== null}
			<div class="eq-info">
				Equilibrium p = {eqFreq.toFixed(3)}
			</div>
		{/if}
	{/snippet}
	{#snippet chart()}
		<Chart {data} options={{ lineLabels: legendLabels }} />
	{/snippet}
</SimLayout>

<style>
	.gradient-section {
		margin-top: 0.5rem;
		padding: 0.5rem;
		background: var(--chart-bg);
		border: 1px solid var(--border);
		border-radius: 4px;
	}

	.gradient-row {
		display: flex;
		gap: 0.5rem;
	}

	.btn-gradient {
		width: 100%;
		margin-top: 0.5rem;
		padding: 0.4rem;
		font-size: 0.65rem;
		font-weight: 500;
		text-transform: uppercase;
		letter-spacing: 0.05em;
		color: var(--text-muted);
		background: transparent;
		border: 1px solid var(--border);
		border-radius: 3px;
		cursor: pointer;
		transition: all 0.15s;
	}

	.btn-gradient:hover {
		color: var(--text);
		border-color: var(--accent);
	}

	.freq-list {
		margin-top: 0.75rem;
		font-size: 0.7rem;
	}

	.freq-label {
		display: block;
		color: var(--text-muted);
		margin-bottom: 0.4rem;
	}

	.freq-item {
		display: flex;
		align-items: center;
		gap: 0.4rem;
		margin-bottom: 0.25rem;
	}

	.pop-num {
		width: 1.2rem;
		color: var(--text-muted);
		font-size: 0.65rem;
	}

	.freq-item input {
		width: 4rem;
		padding: 0.2rem 0.4rem;
		font-size: 0.7rem;
		font-family: var(--font-mono, monospace);
		color: var(--text);
		background: var(--bg);
		border: 1px solid var(--border);
		border-radius: 3px;
	}

	.freq-item input:focus {
		outline: none;
		border-color: var(--accent);
	}

	.eq-info {
		margin-top: 0.75rem;
		padding: 0.5rem;
		background: var(--chart-bg);
		border: 1px solid var(--border);
		border-radius: 4px;
		font-size: 0.7rem;
		color: var(--accent);
		text-align: center;
	}
</style>
