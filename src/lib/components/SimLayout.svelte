<script lang="ts">
	import type { Snippet } from 'svelte';
	import { theme, toggleTheme } from '$lib/theme';
	import HelpPanel from './HelpPanel.svelte';
	import { helpContent } from '$lib/help/content';
	import type { HelpContent } from '$lib/help/types';

	let {
		title,
		controls,
		onrun,
		onreset,
		chart,
		helpKey
	}: {
		title: string;
		controls: Snippet;
		onrun: () => void;
		onreset: () => void;
		chart: Snippet;
		helpKey?: string;
	} = $props();

	let helpOpen = $state(false);
	let helpData: HelpContent | null = $derived(helpKey ? helpContent[helpKey] ?? null : null);
</script>

<div class="sim">
	<div class="topbar">
		<div class="topbar-left">
			<a href="/" class="back">&larr; Modules</a>
			<span class="sim-title">{title}</span>
		</div>
		<div class="topbar-right">
			<div class="controls">
				{@render controls()}
			</div>
			<button class="btn-run" onclick={onrun}>Run</button>
			<button class="btn-reset" onclick={onreset}>Reset</button>
			{#if helpData}
				<button
					class="btn-help"
					onclick={() => (helpOpen = !helpOpen)}
					aria-label="Show help"
					aria-expanded={helpOpen}
				>?</button>
			{/if}
			<button class="btn-theme" onclick={toggleTheme} aria-label="Toggle theme">
				{$theme === 'dark' ? '☀' : '☾'}
			</button>
		</div>
	</div>
	<main class="chart-full">
		<div class="chart-wrap">
			{@render chart()}
		</div>
	</main>
	<HelpPanel content={helpData} bind:open={helpOpen} />
</div>

<style>
	.sim {
		height: 100vh;
		display: flex;
		flex-direction: column;
		background: var(--bg);
		transition: background 0.25s;
		position: relative;
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
		z-index: 200;
		position: relative;
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

	.back:hover {
		color: var(--text);
	}

	.sim-title {
		font-size: 0.8rem;
		font-weight: 500;
		color: var(--text);
		letter-spacing: -0.01em;
		transition: color 0.25s;
	}

	.controls {
		display: flex;
		align-items: center;
		gap: 1rem;
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

	.btn-run:hover {
		background: var(--accent-hover);
	}

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

	.btn-help {
		padding: 0.35rem 0.55rem;
		font-size: 0.8rem;
		font-weight: 600;
		font-family: var(--font-sans);
		background: transparent;
		color: var(--text-muted);
		border: 1px solid var(--border);
		border-radius: 4px;
		cursor: pointer;
		transition: all 0.15s;
		line-height: 1;
	}

	.btn-help:hover {
		color: var(--accent);
		border-color: var(--accent);
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
