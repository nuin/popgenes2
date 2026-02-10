# PopGeneJS

A web-based population genetics simulation suite for teaching and research. Runs entirely in the browser — no server, no installation, no data uploaded.

**Live**: [popgenejs.bioinformat.org](https://popgenejs.bioinformat.org)

## Background

PopGeneJS is a rewrite of [PopGene.S](https://github.com/nuin/popgenes2/tree/master/PopGene.S), a Visual Basic .NET desktop application originally developed for population genetics education. The web version preserves the same models and pedagogical approach while making them accessible from any browser.

All simulations run client-side as pure TypeScript functions. Visualizations are rendered with D3.js and respond to theme changes and window resizes in real time.

## Simulation Modules

28 interactive modules across 8 categories:

### Allele & Genotype Frequencies
| Module | Description |
|--------|-------------|
| **De Finetti Parabola** | Plot genotype frequencies on a ternary diagram against the Hardy-Weinberg equilibrium parabola |
| **Genotype Frequencies** | Calculate expected genotype frequencies from allele frequencies under HWE |
| **Chi-Square HWE Test** | Test observed genotype counts against Hardy-Weinberg expectations |

### Genetic Drift
| Module | Description |
|--------|-------------|
| **Pure Drift** | Wright-Fisher model — binomial sampling of alleles across generations |
| **Drift + Selection** | Drift with deterministic selection (fitness coefficients wAA, wAa, waa) |
| **Drift + Mutation** | Drift with forward and reverse mutation pressure |
| **Drift + Selection + Mutation** | Combined model with all three evolutionary forces |
| **Markov Chain Drift** | Transition matrix approach showing absorption probabilities |
| **Heterozygosity Decline** | Track expected heterozygosity loss over generations (H_t = H_0 × (1 - 1/2N)^t) |

### Natural Selection
| Module | Description |
|--------|-------------|
| **Natural Selection** | Deterministic allele frequency change under selection with equilibrium lines for overdominance/underdominance |
| **Frequency-Dependent** | Selection where fitness depends on allele frequency in the population |

### Mutation
| Module | Description |
|--------|-------------|
| **Two-Way Mutation** | Reversible mutation (A↔a) with equilibrium frequency p̂ = ν/(μ+ν) |
| **Irreversible Mutation** | One-way mutation (A→a) showing exponential decay of the dominant allele |
| **Neutral Mutations** | Infinite-sites neutral mutation accumulation |
| **Muller's Ratchet** | Irreversible accumulation of deleterious mutations in finite asexual populations |

### Mating Models
| Module | Description |
|--------|-------------|
| **Autosomal Locus** | Genotype frequency changes under different mating systems |
| **X-Linked Locus** | Allele frequency dynamics for X-linked loci with sex-specific inheritance |
| **Assortative Mating** | Positive and negative assortative mating effects on genotype frequencies |
| **Assortative Matrix** | Full mating-type matrix showing all possible crosses and offspring frequencies |

### Gene Flow & Population Structure
| Module | Description |
|--------|-------------|
| **Continent-Island Model** | One-way migration from a large source to a smaller population |
| **Island-Island Model** | Symmetric migration between two populations |
| **F-Statistics** | Wright's F_ST, F_IS, and F_IT with drift and migration |
| **Wahlund Effect** | Heterozygote deficiency from population subdivision |

### Gametic Disequilibrium
| Module | Description |
|--------|-------------|
| **Linkage Disequilibrium** | Measure and visualize D, D', and r² between two loci |
| **Magnitude of D** | Maximum and minimum values of D given allele frequencies |
| **Linkage Histogram** | Distribution of D values across replicate populations |

### Advanced
| Module | Description |
|--------|-------------|
| **Molecular Pop Gen** | Summary statistics from sequence data: Watterson's θ, π, Tajima's D |
| **Quantitative Trait Loci** | Multi-locus trait evolution with environmental variance and stabilizing selection |

## Tech Stack

- **[SvelteKit](https://svelte.dev/docs/kit)** — Framework with file-based routing and static prerendering
- **[Svelte 5](https://svelte.dev/docs/svelte)** — Runes reactivity system (`$state`, `$derived`, `$effect`, `$props`)
- **[D3.js v7](https://d3js.org/)** — SVG chart rendering with animated line drawing
- **[TypeScript](https://www.typescriptlang.org/)** — Strict mode throughout
- **[Vite](https://vite.dev/)** — Build tool and dev server
- **[Cloudflare Pages](https://pages.cloudflare.com/)** — Static hosting

## Getting Started

```bash
# Install dependencies
npm install

# Start development server
npm run dev
```

Open [http://localhost:5173](http://localhost:5173).

## Scripts

| Command | Description |
|---------|-------------|
| `npm run dev` | Start dev server with hot module replacement |
| `npm run build` | Production build (static output to `build/`) |
| `npm run preview` | Preview the production build locally |
| `npm run check` | Run TypeScript type checking |
| `npm run check:watch` | Type checking in watch mode |
| `npm run deploy` | Build and deploy to Cloudflare Pages |

## Project Structure

```
src/
  lib/
    sim/          Pure simulation functions (no DOM, no Svelte)
    charts/       D3 chart renderers (line, drift, De Finetti, curve, histogram)
    components/   Shared Svelte 5 components
    theme.ts      Dark/light theme store
  routes/         SvelteKit file-based routing (one directory per module)
  app.css         Design tokens for dark and light themes
  app.html        HTML shell
PopGene.S/        Original VB.NET desktop application (reference)
```

### Architecture

The codebase follows a strict three-layer separation:

1. **Simulation layer** (`lib/sim/*.ts`) — Pure functions that accept parameter objects and return arrays of trajectories (`SimPoint[][]`). No DOM access, no framework imports. Each module exports a typed params interface, a defaults constant, and a simulation function.

2. **Visualization layer** (`lib/charts/*.ts`) — D3 rendering functions that take a DOM container and data. They read theme colors from CSS custom properties at render time, so charts automatically adapt to dark/light mode.

3. **UI layer** (`routes/*/+page.svelte`) — Thin page components that wire reactive state to simulation functions and chart components. All pages share the same `SimLayout` component which provides the topbar controls, Run/Reset buttons, and full-bleed chart area.

### Theming

Two themes (dark default, light toggle) defined entirely through CSS custom properties in `app.css`. Eight visualization colors (`--viz-1` through `--viz-8`) cycle for multi-series charts. D3 renderers read these at render time via `getComputedStyle`, so switching themes re-renders all charts without page reload.

## Deployment

The site is deployed as a static site on Cloudflare Pages:

```bash
npm run deploy
```

This builds the project and uploads the `build/` directory to the `popgenejs` Cloudflare Pages project. The custom domain `popgenejs.bioinformat.org` is configured in the Cloudflare dashboard.

## License

MIT
