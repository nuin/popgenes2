<script lang="ts">
	import { theme, toggleTheme } from '$lib/theme';
</script>

<div class="landing">
	<div class="landing-inner">
		<div class="header-row">
			<div>
				<h1>PopGeneJS</h1>
				<p class="subtitle">Population Genetics Simulations</p>
			</div>
			<button class="theme-toggle" onclick={toggleTheme} aria-label="Toggle theme">
				{$theme === 'dark' ? 'Light' : 'Dark'}
			</button>
		</div>

		<a href="/definetti" class="featured">
			<span class="featured-label">Featured</span>
			<span class="featured-title">De Finetti Parabola</span>
			<span class="featured-desc">Plot genotype frequencies against Hardy-Weinberg equilibrium curves on a ternary diagram</span>
		</a>

		<div class="grid">
			<div class="cat">
				<div class="cat-header">
					<span class="cat-title">Allele &amp; Genotype Frequencies</span>
					<span class="cat-count">3</span>
				</div>
				<a href="/definetti">De Finetti Parabola</a>
				<a href="/frequencies/genotype">Genotype Frequencies</a>
				<a href="/frequencies/chi-square">Chi-Square HWE Test</a>
			</div>

			<div class="cat">
				<div class="cat-header">
					<span class="cat-title">Genetic Drift</span>
					<span class="cat-count">6</span>
				</div>
				<a href="/drift">Pure Drift</a>
				<a href="/drift/with-selection">Drift + Selection</a>
				<a href="/drift/with-mutation">Drift + Mutation</a>
				<a href="/drift/combined">Drift + Selection + Mutation</a>
				<a href="/drift/markov">Markov Chain Drift</a>
				<a href="/drift/heterozygosity">Heterozygosity Decline</a>
			</div>

			<div class="cat">
				<div class="cat-header">
					<span class="cat-title">Mating Models</span>
					<span class="cat-count">4</span>
				</div>
				<a href="/mating/autosomal">Autosomal Locus</a>
				<a href="/mating/x-linked">X-Linked Locus</a>
				<a href="/mating/assortative">Assortative Mating</a>
				<a href="/mating/assortative-matrix">Assortative Matrix</a>
			</div>

			<div class="cat">
				<div class="cat-header">
					<span class="cat-title">Mutation</span>
					<span class="cat-count">4</span>
				</div>
				<a href="/mutation">Two-Way Mutation</a>
				<a href="/mutation/irreversible">Irreversible Mutation</a>
				<a href="/mutation/neutral">Neutral Mutations</a>
				<a href="/mutation/muller">Muller's Ratchet</a>
			</div>

			<div class="cat">
				<div class="cat-header">
					<span class="cat-title">Natural Selection</span>
					<span class="cat-count">2</span>
				</div>
				<a href="/selection">Natural Selection</a>
				<a href="/selection/frequency-dependent">Frequency-Dependent</a>
			</div>

			<div class="cat">
				<div class="cat-header">
					<span class="cat-title">Gene Flow &amp; Structure</span>
					<span class="cat-count">4</span>
				</div>
				<a href="/gene-flow/continent-island">Continent-Island Model</a>
				<a href="/gene-flow/island-island">Island-Island Model</a>
				<a href="/gene-flow/f-statistics">F-Statistics</a>
				<a href="/gene-flow/wahlund">Wahlund Effect</a>
			</div>

			<div class="cat">
				<div class="cat-header">
					<span class="cat-title">Gametic Disequilibrium</span>
					<span class="cat-count">3</span>
				</div>
				<a href="/linkage/disequilibrium">Linkage Disequilibrium</a>
				<a href="/linkage/magnitude">Magnitude of D</a>
				<a href="/linkage/histogram">Linkage Histogram</a>
			</div>

			<div class="cat">
				<div class="cat-header">
					<span class="cat-title">Advanced</span>
					<span class="cat-count">2</span>
				</div>
				<a href="/advanced/molecular">Molecular Pop Gen</a>
				<a href="/advanced/qtl">Quantitative Trait Loci</a>
			</div>
		</div>

		<div class="footer">
			<span class="footer-text">28 modules &middot; SvelteKit + D3.js</span>
		</div>
	</div>
</div>

<style>
	.landing {
		min-height: 100vh;
		display: flex;
		justify-content: center;
		padding: 4rem 2rem 3rem;
		background: var(--bg);
		transition: background 0.25s;
	}

	.landing-inner {
		max-width: 680px;
		width: 100%;
	}

	.header-row {
		display: flex;
		justify-content: space-between;
		align-items: flex-start;
		margin-bottom: 2.5rem;
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
		margin-bottom: 2rem;
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

	.grid {
		display: grid;
		grid-template-columns: 1fr 1fr;
		gap: 0.5rem 2.5rem;
	}

	.cat {
		margin-bottom: 1.5rem;
	}

	.cat-header {
		display: flex;
		align-items: center;
		gap: 0.5rem;
		margin-bottom: 0.5rem;
	}

	.cat-title {
		font-size: 0.6rem;
		font-weight: 500;
		text-transform: uppercase;
		letter-spacing: 0.15em;
		color: var(--text-muted);
	}

	.cat-count {
		font-size: 0.55rem;
		font-weight: 600;
		color: var(--accent);
		background: var(--link-hover-bg);
		padding: 0.1rem 0.4rem;
		border-radius: 8px;
	}

	.cat a {
		display: block;
		padding: 0.4rem 0.6rem;
		margin-bottom: 0.1rem;
		color: var(--text);
		text-decoration: none;
		font-size: 0.82rem;
		font-weight: 400;
		border-radius: 4px;
		transition: all 0.15s;
	}

	.cat a:hover {
		background: var(--link-hover-bg);
		color: var(--accent);
	}

	.footer {
		margin-top: 2rem;
		padding-top: 1.5rem;
		border-top: 1px solid var(--border);
		text-align: center;
	}

	.footer-text {
		font-size: 0.7rem;
		color: var(--text-muted);
		letter-spacing: 0.03em;
	}

	@media (max-width: 600px) {
		.grid {
			grid-template-columns: 1fr;
		}

		.landing {
			padding: 2rem 1rem;
		}
	}
</style>
