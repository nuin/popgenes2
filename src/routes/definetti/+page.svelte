<script lang="ts">
	import DeFinettiChart from '$lib/components/DeFinettiChart.svelte';
	import ParamInput from '$lib/components/ParamInput.svelte';
	import { theme, toggleTheme } from '$lib/theme';
	import {
		generateHWEParabola,
		genotypeToPoint,
		validateGenotypes,
		type GenotypePoint
	} from '$lib/sim/definetti';

	const parabola = generateHWEParabola();

	let pAA = $state(0.25);
	let pAa = $state(0.5);
	let paa = $derived(Math.max(0, +(1 - pAA - pAa).toFixed(6)));
	let pAllele = $derived(+(pAA + pAa / 2).toFixed(6));
	let qAllele = $derived(+(1 - pAllele).toFixed(6));

	let points: GenotypePoint[] = $state([]);
	let error = $state('');

	function plot() {
		const err = validateGenotypes(pAA, pAa);
		if (err) {
			error = err;
			return;
		}
		error = '';
		points = [...points, genotypeToPoint(pAA, pAa)];
	}

	function clear() {
		points = [];
		pAA = 0.25;
		pAa = 0.5;
		error = '';
	}
</script>

<div class="sim">
	<div class="topbar">
		<div class="topbar-left">
			<a href="/" class="back">&larr; Modules</a>
			<span class="sim-title">De Finetti Parabola</span>
		</div>
		<div class="topbar-right">
			<div class="controls">
				<ParamInput label="P(AA)" bind:value={pAA} step={0.01} min={0} max={1} />
				<ParamInput label="P(Aa)" bind:value={pAa} step={0.01} min={0} max={1} />
				<div class="readonly-item">
					<span class="control-label">P(aa)</span>
					<span class="readonly-value">{paa.toFixed(4)}</span>
				</div>
				<div class="sep"></div>
				<div class="readonly-item">
					<span class="control-label">p</span>
					<span class="readonly-value">{pAllele.toFixed(4)}</span>
				</div>
				<div class="readonly-item">
					<span class="control-label">q</span>
					<span class="readonly-value">{qAllele.toFixed(4)}</span>
				</div>
			</div>
			<button class="btn-run" onclick={plot}>Plot</button>
			<button class="btn-reset" onclick={clear}>Clear</button>
			<button class="btn-theme" onclick={toggleTheme} aria-label="Toggle theme">
				{$theme === 'dark' ? '&#9788;' : '&#9790;'}
			</button>
		</div>
	</div>
	{#if error}
		<div class="error-bar">{error}</div>
	{/if}
	<main class="chart-full">
		<div class="chart-wrap">
			<DeFinettiChart {parabola} {points} />
		</div>
	</main>
</div>

<style>
	.sim {
		height: 100vh;
		display: flex;
		flex-direction: column;
		background: var(--bg);
		transition: background 0.25s;
	}

	.topbar {
		display: flex;
		align-items: center;
		justify-content: space-between;
		padding: 0.6rem 1.5rem;
		background: var(--bg);
		border-bottom: 1px solid var(--border);
		flex-shrink: 0;
		transition: background 0.25s, border-color 0.25s;
	}

	.topbar-left {
		display: flex;
		align-items: center;
		gap: 1.5rem;
	}

	.topbar-right {
		display: flex;
		align-items: center;
		gap: 1rem;
	}

	.back {
		font-size: 0.75rem;
		color: var(--text-muted);
		text-decoration: none;
		transition: color 0.15s;
	}

	.back:hover { color: var(--text); }

	.sim-title {
		font-size: 0.8rem;
		font-weight: 500;
		color: var(--text);
		letter-spacing: -0.01em;
	}

	.controls {
		display: flex;
		align-items: center;
		gap: 1rem;
	}

	.readonly-item {
		display: flex;
		align-items: center;
		gap: 0.4rem;
	}

	.control-label {
		font-size: 0.65rem;
		color: var(--text-muted);
		text-transform: uppercase;
		letter-spacing: 0.05em;
		font-weight: 500;
		white-space: nowrap;
	}

	.readonly-value {
		font-size: 0.8rem;
		font-family: var(--font-mono);
		color: var(--text-dim);
		min-width: 50px;
		text-align: center;
	}

	.sep {
		width: 1px;
		height: 20px;
		background: var(--border);
	}

	.btn-run {
		padding: 0.35rem 1rem;
		font-size: 0.75rem;
		font-weight: 500;
		font-family: var(--font-sans);
		background: var(--accent);
		color: var(--accent-text);
		border: none;
		border-radius: 4px;
		cursor: pointer;
		transition: background 0.15s;
	}

	.btn-run:hover { background: var(--accent-hover); }

	.btn-reset {
		padding: 0.35rem 0.75rem;
		font-size: 0.7rem;
		font-weight: 500;
		font-family: var(--font-sans);
		background: transparent;
		color: var(--text-muted);
		border: 1px solid var(--border);
		border-radius: 4px;
		cursor: pointer;
		transition: all 0.15s;
	}

	.btn-reset:hover {
		color: var(--text);
		border-color: var(--text-muted);
	}

	.btn-theme {
		padding: 0.35rem 0.5rem;
		font-size: 0.85rem;
		background: transparent;
		color: var(--text-muted);
		border: 1px solid var(--border);
		border-radius: 4px;
		cursor: pointer;
		transition: all 0.15s;
		line-height: 1;
	}

	.btn-theme:hover {
		color: var(--text);
		border-color: var(--text-muted);
	}

	.error-bar {
		padding: 0.4rem 1.5rem;
		font-size: 0.75rem;
		color: var(--viz-2);
		background: transparent;
		border-bottom: 1px solid var(--border);
	}

	.chart-full {
		flex: 1;
		padding: 0.75rem;
		display: flex;
		min-height: 0;
	}

	.chart-wrap {
		flex: 1;
		background: var(--chart-bg);
		border: 1px solid var(--border);
		border-radius: 6px;
		padding: 0.75rem;
		transition: background 0.25s, border-color 0.25s;
	}

	@media (max-width: 768px) {
		.topbar {
			flex-wrap: wrap;
			gap: 0.5rem;
		}

		.topbar-right {
			flex-wrap: wrap;
		}
	}
</style>
