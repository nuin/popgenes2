<script lang="ts">
	import type { SimResult } from '$lib/sim/types';
	import { renderDriftChart, type DriftChartOptions } from '$lib/charts/driftChart';
	import { theme } from '$lib/theme';

	let {
		data,
		initialFreq = 0.5,
		populationSize = 100
	}: {
		data: SimResult;
		initialFreq?: number;
		populationSize?: number;
	} = $props();

	let container: HTMLDivElement;

	// Toggle states
	let showFixationMarkers = $state(true);
	let showMeanLine = $state(true);
	let showVarianceEnvelope = $state(false);
	let showSummaryStats = $state(true);
	let showInitialLine = $state(true);
	let thinLines = $state(true);

	// Context menu state
	let menuVisible = $state(false);
	let menuX = $state(0);
	let menuY = $state(0);

	function draw() {
		if (container && data.length > 0) {
			const options: DriftChartOptions = {
				initialFreq,
				populationSize,
				showFixationMarkers,
				showMeanLine,
				showVarianceEnvelope,
				showSummaryStats,
				showInitialLine,
				thinLines
			};
			renderDriftChart(container, data, options, handleContextMenu);
		}
	}

	function handleContextMenu(event: MouseEvent) {
		menuX = event.clientX;
		menuY = event.clientY;
		menuVisible = true;
	}

	function closeMenu() {
		menuVisible = false;
	}

	function toggleOption(option: string) {
		switch (option) {
			case 'fixation':
				showFixationMarkers = !showFixationMarkers;
				break;
			case 'mean':
				showMeanLine = !showMeanLine;
				break;
			case 'variance':
				showVarianceEnvelope = !showVarianceEnvelope;
				break;
			case 'stats':
				showSummaryStats = !showSummaryStats;
				break;
			case 'initial':
				showInitialLine = !showInitialLine;
				break;
			case 'thin':
				thinLines = !thinLines;
				break;
		}
		closeMenu();
	}

	$effect(() => {
		// Re-render when data, theme, or options change
		void data;
		void $theme;
		void showFixationMarkers;
		void showMeanLine;
		void showVarianceEnvelope;
		void showSummaryStats;
		void showInitialLine;
		void thinLines;
		draw();
	});

	$effect(() => {
		// Handle resize
		const observer = new ResizeObserver(() => draw());
		if (container) observer.observe(container);
		return () => observer.disconnect();
	});

	// Close menu on click outside
	function handleWindowClick(event: MouseEvent) {
		if (menuVisible) {
			closeMenu();
		}
	}
</script>

<svelte:window onclick={handleWindowClick} />

<div class="drift-chart-wrapper">
	<div class="chart" bind:this={container}></div>

	{#if menuVisible}
		<div
			class="context-menu"
			style="left: {menuX}px; top: {menuY}px;"
			onclick={(e) => e.stopPropagation()}
			onkeydown={(e) => e.key === 'Escape' && closeMenu()}
			role="menu"
			tabindex="-1"
		>
			<div class="menu-title">Display Options</div>
			<button
				class="menu-item"
				class:active={showFixationMarkers}
				onclick={() => toggleOption('fixation')}
			>
				<span class="check">{showFixationMarkers ? '✓' : ''}</span>
				Fixation Markers
			</button>
			<button
				class="menu-item"
				class:active={showMeanLine}
				onclick={() => toggleOption('mean')}
			>
				<span class="check">{showMeanLine ? '✓' : ''}</span>
				Mean Trajectory
			</button>
			<button
				class="menu-item"
				class:active={showVarianceEnvelope}
				onclick={() => toggleOption('variance')}
			>
				<span class="check">{showVarianceEnvelope ? '✓' : ''}</span>
				Variance Envelope
			</button>
			<button
				class="menu-item"
				class:active={showSummaryStats}
				onclick={() => toggleOption('stats')}
			>
				<span class="check">{showSummaryStats ? '✓' : ''}</span>
				Summary Stats
			</button>
			<div class="menu-divider"></div>
			<button
				class="menu-item"
				class:active={showInitialLine}
				onclick={() => toggleOption('initial')}
			>
				<span class="check">{showInitialLine ? '✓' : ''}</span>
				Initial Frequency Line
			</button>
			<button
				class="menu-item"
				class:active={thinLines}
				onclick={() => toggleOption('thin')}
			>
				<span class="check">{thinLines ? '✓' : ''}</span>
				Thin Lines
			</button>
		</div>
	{/if}
</div>

<style>
	.drift-chart-wrapper {
		width: 100%;
		height: 100%;
		position: relative;
	}

	.chart {
		width: 100%;
		height: 100%;
	}

	.context-menu {
		position: fixed;
		background: var(--bg);
		border: 1px solid var(--border);
		border-radius: 6px;
		box-shadow: 0 4px 12px rgba(0, 0, 0, 0.15);
		min-width: 180px;
		padding: 4px 0;
		z-index: 1000;
	}

	.menu-title {
		padding: 6px 12px;
		font-size: 0.65rem;
		font-weight: 600;
		color: var(--text-muted);
		text-transform: uppercase;
		letter-spacing: 0.05em;
		border-bottom: 1px solid var(--border);
		margin-bottom: 4px;
	}

	.menu-item {
		display: flex;
		align-items: center;
		width: 100%;
		padding: 6px 12px;
		font-family: var(--font-sans);
		font-size: 0.8rem;
		color: var(--text);
		background: none;
		border: none;
		cursor: pointer;
		text-align: left;
		transition: background 0.1s;
	}

	.menu-item:hover {
		background: var(--link-hover-bg);
	}

	.menu-item .check {
		width: 16px;
		margin-right: 8px;
		color: var(--accent);
		font-weight: 600;
	}

	.menu-divider {
		height: 1px;
		background: var(--border);
		margin: 4px 0;
	}
</style>
