<script lang="ts">
	import type { Snippet } from 'svelte';
	import { theme, toggleTheme } from '$lib/theme';

	let {
		title,
		subtitle = '',
		simLinks = [],
		children
	}: {
		title: string;
		subtitle?: string;
		simLinks?: { href: string; label: string }[];
		children: Snippet;
	} = $props();
</script>

<div class="theory-page">
	<header class="header">
		<div class="header-left">
			<a href="/theory" class="back">&larr; Theory</a>
			<div class="title-group">
				<h1>{title}</h1>
				{#if subtitle}
					<p class="subtitle">{subtitle}</p>
				{/if}
			</div>
		</div>
		<div class="header-right">
			{#if simLinks.length > 0}
				<div class="sim-links">
					<span class="sim-links-label">Try it:</span>
					{#each simLinks as link}
						<a href={link.href} class="sim-link">{link.label}</a>
					{/each}
				</div>
			{/if}
			<button class="btn-theme" onclick={toggleTheme} aria-label="Toggle theme">
				{$theme === 'dark' ? '☀' : '☾'}
			</button>
		</div>
	</header>

	<main class="content">
		<article class="article">
			{@render children()}
		</article>
	</main>
</div>

<style>
	.theory-page {
		min-height: 100vh;
		background: var(--bg);
		transition: background 0.25s;
	}

	.header {
		display: flex;
		align-items: flex-start;
		justify-content: space-between;
		padding: 1.5rem 2rem;
		border-bottom: 1px solid var(--border);
		position: sticky;
		top: 0;
		background: var(--bg);
		z-index: 100;
	}

	.header-left {
		display: flex;
		align-items: flex-start;
		gap: 2rem;
	}

	.header-right {
		display: flex;
		align-items: center;
		gap: 1.5rem;
	}

	.back {
		font-size: 0.75rem;
		color: var(--text-muted);
		text-decoration: none;
		transition: color 0.15s;
		padding-top: 0.25rem;
	}

	.back:hover {
		color: var(--text);
	}

	.title-group {
		display: flex;
		flex-direction: column;
		gap: 0.25rem;
	}

	h1 {
		font-size: 1.25rem;
		font-weight: 500;
		color: var(--text);
		margin: 0;
		letter-spacing: -0.02em;
	}

	.subtitle {
		font-size: 0.8rem;
		color: var(--text-muted);
		margin: 0;
	}

	.sim-links {
		display: flex;
		align-items: center;
		gap: 0.5rem;
	}

	.sim-links-label {
		font-size: 0.7rem;
		color: var(--text-muted);
		text-transform: uppercase;
		letter-spacing: 0.05em;
	}

	.sim-link {
		font-size: 0.75rem;
		color: var(--accent);
		text-decoration: none;
		padding: 0.25rem 0.5rem;
		border: 1px solid var(--accent);
		border-radius: 4px;
		transition: all 0.15s;
	}

	.sim-link:hover {
		background: var(--accent);
		color: var(--accent-text);
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

	.content {
		max-width: 900px;
		margin: 0 auto;
		padding: 2rem;
	}

	.article {
		color: var(--text);
		line-height: 1.7;
	}

	/* Article typography - applied to children */
	.article :global(h2) {
		font-size: 1.1rem;
		font-weight: 600;
		color: var(--text);
		margin: 2.5rem 0 1rem;
		padding-bottom: 0.5rem;
		border-bottom: 1px solid var(--border);
	}

	.article :global(h3) {
		font-size: 0.95rem;
		font-weight: 600;
		color: var(--text);
		margin: 2rem 0 0.75rem;
	}

	.article :global(p) {
		font-size: 0.9rem;
		margin: 0 0 1rem;
		color: var(--text);
	}

	.article :global(ul),
	.article :global(ol) {
		font-size: 0.9rem;
		margin: 0 0 1rem;
		padding-left: 1.5rem;
	}

	.article :global(li) {
		margin-bottom: 0.5rem;
	}

	.article :global(.equation) {
		display: block;
		text-align: center;
		font-family: var(--font-mono, 'SF Mono', monospace);
		font-size: 1rem;
		padding: 1.25rem;
		margin: 1.5rem 0;
		background: var(--chart-bg);
		border: 1px solid var(--border);
		border-radius: 6px;
		color: var(--text);
		overflow-x: auto;
	}

	.article :global(.equation-label) {
		display: block;
		font-size: 0.7rem;
		color: var(--text-muted);
		margin-top: 0.5rem;
		font-family: var(--font-sans);
	}

	.article :global(.note) {
		font-size: 0.85rem;
		padding: 1rem;
		margin: 1.5rem 0;
		background: rgba(59, 130, 246, 0.08);
		border-left: 3px solid var(--accent);
		border-radius: 0 4px 4px 0;
	}

	.article :global(.diagram) {
		margin: 2rem 0;
		padding: 1rem;
		background: var(--chart-bg);
		border: 1px solid var(--border);
		border-radius: 6px;
	}

	.article :global(.diagram-caption) {
		font-size: 0.75rem;
		color: var(--text-muted);
		text-align: center;
		margin-top: 0.75rem;
		font-style: italic;
	}

	.article :global(strong) {
		font-weight: 600;
		color: var(--text);
	}

	.article :global(em) {
		font-style: italic;
	}

	.article :global(code) {
		font-family: var(--font-mono);
		font-size: 0.85em;
		background: var(--chart-bg);
		padding: 0.15em 0.3em;
		border-radius: 3px;
	}

	.article :global(.var) {
		font-family: var(--font-mono);
		font-style: italic;
		color: var(--accent);
	}

	@media (max-width: 768px) {
		.header {
			flex-direction: column;
			gap: 1rem;
			padding: 1rem;
		}

		.header-left {
			flex-direction: column;
			gap: 0.5rem;
		}

		.content {
			padding: 1rem;
		}
	}
</style>
