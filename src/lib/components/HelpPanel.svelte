<script lang="ts">
	import type { HelpContent } from '$lib/help/types';

	let {
		content,
		open = $bindable(false)
	}: {
		content: HelpContent | null;
		open: boolean;
	} = $props();

	let panelEl: HTMLElement | undefined = $state();

	function close() {
		open = false;
	}

	function onkeydown(e: KeyboardEvent) {
		if (e.key === 'Escape') close();
	}

	$effect(() => {
		if (open && panelEl) {
			const btn = panelEl.querySelector<HTMLElement>('.help-close');
			btn?.focus();
		}
	});
</script>

<svelte:window {onkeydown} />

{#if open && content}
	<button class="help-backdrop" onclick={close} aria-label="Close help panel" tabindex="-1"></button>
	<aside
		class="help-panel"
		class:help-panel-open={open}
		aria-label="Help panel"
		bind:this={panelEl}
	>
		<div class="help-header">
			<span class="help-category">{content.category}</span>
			<button class="help-close" onclick={close} aria-label="Close help">&times;</button>
		</div>

		<div class="help-body">
			<h2 class="help-title">{content.title}</h2>
			<p class="help-desc">{content.description}</p>

			{#if content.formulas.length > 0}
				<h3 class="help-section">Mathematical Model</h3>
				{#each content.formulas as formula}
					<div class="formula-block">
						{#if formula.label}
							<span class="formula-label">{formula.label}</span>
						{/if}
						<div class="formula-expr">{@html formula.html}</div>
					</div>
				{/each}
			{/if}

			{#if content.parameters.length > 0}
				<h3 class="help-section">Parameters</h3>
				<dl class="help-params">
					{#each content.parameters as param}
						<dt>{param.name}</dt>
						<dd>{param.description}</dd>
					{/each}
				</dl>
			{/if}

			{#if content.insights.length > 0}
				<h3 class="help-section">Key Insights</h3>
				<ul class="help-insights">
					{#each content.insights as insight}
						<li>{insight}</li>
					{/each}
				</ul>
			{/if}

			{#if content.references.length > 0}
				<h3 class="help-section">References</h3>
				<ol class="help-refs">
					{#each content.references as ref}
						<li>
							<span class="ref-authors">{ref.authors}</span>
							({ref.year}).
							<em>{ref.title}</em>.
							{#if ref.journal}{ref.journal}.{/if}
							{#if ref.doi}
								<a href="https://doi.org/{ref.doi}" target="_blank" rel="noopener">{ref.doi}</a>
							{/if}
						</li>
					{/each}
				</ol>
			{/if}
		</div>
	</aside>
{/if}

<style>
	.help-backdrop {
		position: absolute;
		inset: 0;
		z-index: 100;
		background: rgba(0, 0, 0, 0.4);
		border: none;
		cursor: default;
	}

	.help-panel {
		position: absolute;
		top: 0;
		right: 0;
		bottom: 0;
		width: 420px;
		max-width: 100%;
		z-index: 101;
		background: var(--bg-surface);
		border-left: 1px solid var(--border);
		overflow-y: auto;
		transform: translateX(100%);
		transition: transform 0.3s ease;
	}

	.help-panel-open {
		transform: translateX(0);
	}

	.help-header {
		display: flex;
		align-items: center;
		justify-content: space-between;
		padding: 1rem 1.25rem;
		border-bottom: 1px solid var(--border);
		position: sticky;
		top: 0;
		background: var(--bg-surface);
		z-index: 1;
	}

	.help-category {
		font-size: 0.65rem;
		font-weight: 600;
		text-transform: uppercase;
		letter-spacing: 0.08em;
		color: var(--accent);
		background: color-mix(in srgb, var(--accent) 12%, transparent);
		padding: 0.2rem 0.5rem;
		border-radius: 3px;
	}

	.help-close {
		background: none;
		border: none;
		font-size: 1.4rem;
		line-height: 1;
		color: var(--text-muted);
		cursor: pointer;
		padding: 0.2rem 0.4rem;
		border-radius: 3px;
		transition: color 0.15s;
	}

	.help-close:hover {
		color: var(--text);
	}

	.help-body {
		padding: 1.25rem;
	}

	.help-title {
		font-size: 1.1rem;
		font-weight: 600;
		color: var(--text);
		margin-bottom: 0.75rem;
		line-height: 1.3;
	}

	.help-desc {
		font-size: 0.82rem;
		line-height: 1.6;
		color: var(--text);
		margin-bottom: 1.5rem;
		opacity: 0.85;
	}

	.help-section {
		font-size: 0.72rem;
		font-weight: 600;
		text-transform: uppercase;
		letter-spacing: 0.06em;
		color: var(--text-muted);
		margin-top: 1.5rem;
		margin-bottom: 0.75rem;
		padding-bottom: 0.35rem;
		border-bottom: 1px solid var(--border);
	}

	.formula-block {
		background: var(--bg-control);
		border: 1px solid var(--border);
		border-radius: 5px;
		padding: 0.75rem 1rem;
		margin-bottom: 0.5rem;
	}

	.formula-label {
		display: block;
		font-size: 0.65rem;
		font-weight: 500;
		color: var(--text-muted);
		text-transform: uppercase;
		letter-spacing: 0.04em;
		margin-bottom: 0.4rem;
	}

	.formula-expr {
		font-family: var(--font-mono);
		font-size: 0.85rem;
		color: var(--text);
		line-height: 1.8;
	}

	.formula-expr :global(var) {
		font-style: italic;
		font-family: 'Georgia', 'Times New Roman', serif;
	}

	.formula-expr :global(.frac) {
		display: inline-flex;
		flex-direction: column;
		align-items: center;
		vertical-align: middle;
		margin: 0 0.15em;
	}

	.formula-expr :global(.frac-num) {
		border-bottom: 1px solid var(--text-muted);
		padding: 0 0.3em 0.15em;
		font-size: 0.85em;
		line-height: 1.2;
	}

	.formula-expr :global(.frac-den) {
		padding: 0.15em 0.3em 0;
		font-size: 0.85em;
		line-height: 1.2;
	}

	.formula-expr :global(.overline) {
		text-decoration: overline;
	}

	.help-params {
		display: grid;
		grid-template-columns: auto 1fr;
		gap: 0.35rem 0.75rem;
		font-size: 0.8rem;
	}

	.help-params dt {
		font-family: var(--font-mono);
		font-weight: 500;
		color: var(--accent);
		font-size: 0.78rem;
	}

	.help-params dd {
		color: var(--text);
		opacity: 0.85;
		line-height: 1.5;
	}

	.help-insights {
		list-style: none;
		padding: 0;
	}

	.help-insights li {
		font-size: 0.8rem;
		line-height: 1.55;
		color: var(--text);
		opacity: 0.85;
		padding: 0.35rem 0;
		padding-left: 1rem;
		position: relative;
	}

	.help-insights li::before {
		content: '—';
		position: absolute;
		left: 0;
		color: var(--text-muted);
	}

	.help-refs {
		padding-left: 1.25rem;
	}

	.help-refs li {
		font-size: 0.75rem;
		line-height: 1.55;
		color: var(--text);
		opacity: 0.8;
		margin-bottom: 0.6rem;
	}

	.ref-authors {
		font-weight: 500;
	}

	.help-refs a {
		color: var(--accent);
		font-size: 0.7rem;
		word-break: break-all;
	}

	.help-refs a:hover {
		text-decoration: underline;
	}

	@media (max-width: 768px) {
		.help-panel {
			width: 100%;
		}
	}
</style>
