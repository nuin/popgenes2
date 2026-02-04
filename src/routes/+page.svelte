<script lang="ts">
	import { theme, toggleTheme } from '$lib/theme';
</script>

<div class="landing">
	<div class="landing-inner">
		<div class="header-row">
			<div>
				<h1>PopGeneS.js</h1>
				<p class="subtitle">Population genetics simulations</p>
			</div>
			<button class="theme-toggle" onclick={toggleTheme} aria-label="Toggle theme">
				{$theme === 'dark' ? 'Light' : 'Dark'}
			</button>
		</div>

		<a href="/definetti" class="featured">
			<span class="featured-label">Featured</span>
			<span class="featured-title">De Finetti Parabola</span>
			<span class="featured-desc">Plot genotype frequencies against Hardy-Weinberg equilibrium curves</span>
		</a>

		<div class="cat">
			<div class="cat-title">Drift</div>
			<a href="/drift">Genetic Drift (Wright-Fisher)</a>
		</div>

		<div class="cat">
			<div class="cat-title">Selection</div>
			<a href="/selection">Natural Selection</a>
		</div>

		<div class="cat">
			<div class="cat-title">Mutation</div>
			<a href="/mutation">Two-Way Mutation</a>
		</div>
	</div>
</div>

<style>
	.landing {
		min-height: 100vh;
		display: flex;
		justify-content: center;
		padding: 5rem 2rem 4rem;
		background: var(--bg);
		transition: background 0.25s;
	}

	.landing-inner {
		max-width: 520px;
		width: 100%;
	}

	.header-row {
		display: flex;
		justify-content: space-between;
		align-items: flex-start;
		margin-bottom: 3.5rem;
	}

	h1 {
		font-size: 1.3rem;
		font-weight: 300;
		letter-spacing: 0.08em;
		text-transform: uppercase;
		margin-bottom: 0.25rem;
		color: var(--text);
	}

	.subtitle {
		font-size: 0.85rem;
		color: var(--text-muted);
		font-weight: 400;
	}

	.theme-toggle {
		padding: 0.3rem 0.7rem;
		font-family: var(--font-sans);
		font-size: 0.65rem;
		font-weight: 500;
		text-transform: uppercase;
		letter-spacing: 0.08em;
		color: var(--text-muted);
		background: transparent;
		border: 1px solid var(--border);
		border-radius: 4px;
		cursor: pointer;
		transition: color 0.15s, border-color 0.15s;
	}

	.theme-toggle:hover {
		color: var(--text);
		border-color: var(--text-muted);
	}

	.featured {
		display: block;
		padding: 1.25rem 1rem;
		margin-bottom: 2.5rem;
		border: 1px solid var(--border);
		border-radius: 6px;
		text-decoration: none;
		transition: border-color 0.15s, background 0.15s;
	}

	.featured:hover {
		border-color: var(--accent);
		background: var(--link-hover-bg);
	}

	.featured-label {
		display: block;
		font-size: 0.55rem;
		font-weight: 500;
		text-transform: uppercase;
		letter-spacing: 0.15em;
		color: var(--accent);
		margin-bottom: 0.5rem;
	}

	.featured-title {
		display: block;
		font-size: 1rem;
		font-weight: 500;
		color: var(--text);
		margin-bottom: 0.3rem;
	}

	.featured-desc {
		display: block;
		font-size: 0.8rem;
		color: var(--text-muted);
		line-height: 1.4;
	}

	.cat {
		margin-bottom: 2rem;
	}

	.cat-title {
		font-size: 0.6rem;
		font-weight: 500;
		text-transform: uppercase;
		letter-spacing: 0.15em;
		color: var(--text-muted);
		margin-bottom: 0.75rem;
	}

	.cat a {
		display: block;
		padding: 0.55rem 0.75rem;
		margin-bottom: 0.2rem;
		color: var(--text);
		text-decoration: none;
		font-size: 0.9rem;
		font-weight: 400;
		border-radius: 4px;
		transition: all 0.15s;
	}

	.cat a:hover {
		background: var(--link-hover-bg);
		color: var(--accent);
	}
</style>
