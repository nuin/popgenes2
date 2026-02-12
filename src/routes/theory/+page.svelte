<script lang="ts">
	import { theme, toggleTheme } from '$lib/theme';

	const topics = [
		{
			title: 'Hardy-Weinberg Equilibrium',
			description: 'The foundation of population genetics: genotype frequencies in an ideal population',
			href: '/theory/hardy-weinberg',
			simulations: ['De Finetti', 'Chi-Square Test']
		},
		{
			title: 'Genetic Drift',
			description: 'Random changes in allele frequencies due to finite population size',
			href: '/theory/drift',
			simulations: ['Pure Drift', 'Markov Chain', 'Heterozygosity']
		},
		{
			title: 'Natural Selection',
			description: 'How differential fitness shapes allele frequencies over generations',
			href: '/theory/selection',
			simulations: ['Natural Selection', 'Frequency-Dependent']
		},
		{
			title: 'Mutation',
			description: 'The ultimate source of genetic variation and its population-level effects',
			href: '/theory/mutation',
			simulations: ['Two-Way Mutation', 'Irreversible', 'Neutral']
		},
		{
			title: 'Gene Flow & Population Structure',
			description: 'Migration between populations and its effects on genetic differentiation',
			href: '/theory/gene-flow',
			simulations: ['Continent-Island', 'F-Statistics', 'Wahlund']
		},
		{
			title: 'Linkage Disequilibrium',
			description: 'Non-random association of alleles at different loci',
			href: '/theory/linkage',
			simulations: ['Disequilibrium', 'Magnitude of D']
		},
		{
			title: 'Mating Systems',
			description: 'How non-random mating affects genotype frequencies',
			href: '/theory/mating',
			simulations: ['Assortative Mating', 'Assortative Matrix']
		}
	];
</script>

<div class="theory-index">
	<header class="header">
		<div class="header-left">
			<a href="/" class="back">&larr; Home</a>
			<div class="title-group">
				<h1>Population Genetics Theory</h1>
				<p class="subtitle">Mathematical foundations and biological concepts</p>
			</div>
		</div>
		<button class="btn-theme" onclick={toggleTheme} aria-label="Toggle theme">
			{$theme === 'dark' ? '☀' : '☾'}
		</button>
	</header>

	<main class="content">
		<div class="intro">
			<p>
				Population genetics describes how genetic variation changes within and between populations over time.
				These theory pages explain the mathematical models underlying each simulation, with interactive
				diagrams and links to hands-on experimentation.
			</p>
		</div>

		<div class="topics-grid">
			{#each topics as topic}
				<a href={topic.href} class="topic-card">
					<h2>{topic.title}</h2>
					<p>{topic.description}</p>
					<div class="topic-sims">
						{#each topic.simulations as sim}
							<span class="sim-tag">{sim}</span>
						{/each}
					</div>
				</a>
			{/each}
		</div>
	</main>
</div>

<style>
	.theory-index {
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
	}

	.header-left {
		display: flex;
		align-items: flex-start;
		gap: 2rem;
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
		max-width: 1000px;
		margin: 0 auto;
		padding: 2rem;
	}

	.intro {
		margin-bottom: 2.5rem;
	}

	.intro p {
		font-size: 0.95rem;
		color: var(--text-muted);
		line-height: 1.6;
		max-width: 700px;
	}

	.topics-grid {
		display: grid;
		grid-template-columns: repeat(auto-fill, minmax(300px, 1fr));
		gap: 1.25rem;
	}

	.topic-card {
		display: block;
		padding: 1.5rem;
		background: var(--chart-bg);
		border: 1px solid var(--border);
		border-radius: 8px;
		text-decoration: none;
		transition: all 0.2s;
	}

	.topic-card:hover {
		border-color: var(--accent);
		transform: translateY(-2px);
		box-shadow: 0 4px 12px rgba(0, 0, 0, 0.1);
	}

	.topic-card h2 {
		font-size: 1rem;
		font-weight: 600;
		color: var(--text);
		margin: 0 0 0.5rem;
	}

	.topic-card p {
		font-size: 0.8rem;
		color: var(--text-muted);
		margin: 0 0 1rem;
		line-height: 1.5;
	}

	.topic-sims {
		display: flex;
		flex-wrap: wrap;
		gap: 0.4rem;
	}

	.sim-tag {
		font-size: 0.65rem;
		color: var(--accent);
		background: rgba(59, 130, 246, 0.1);
		padding: 0.2rem 0.5rem;
		border-radius: 3px;
		text-transform: uppercase;
		letter-spacing: 0.03em;
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

		.topics-grid {
			grid-template-columns: 1fr;
		}
	}
</style>
