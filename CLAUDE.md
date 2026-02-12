# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

PopGeneS2 is a web-based population genetics simulation suite (28 modules) for educational and research purposes. Rewritten from the original VB.NET desktop app (preserved in `PopGene.S/` for reference).

**Stack**: SvelteKit (Svelte 5 runes) + TypeScript (strict) + D3.js v7 + Vite

## Commands

```bash
npm run dev          # Start dev server with HMR
npm run build        # Production build
npm run preview      # Preview production build
npm run check        # Type-check with svelte-check
npm run check:watch  # Type-check in watch mode
npm run deploy       # Build and deploy to Cloudflare Pages
```

No test framework is currently configured.

## Architecture

### Three-Layer Separation

1. **Simulation logic** (`src/lib/sim/*.ts`) — Pure functions. No DOM, no Svelte. Accept typed params, return data. Each module exports a params interface, defaults constant, and simulation function.
2. **Chart rendering** (`src/lib/charts/*.ts`) — D3 functions taking a DOM element + data. Read theme colors from CSS custom properties at render time. Multiple specialized renderers exist (line, drift, De Finetti, curve, histogram).
3. **Route pages** (`src/routes/*/+page.svelte`) — Thin wrappers composing sim logic + components. Wire `$state` for params, call sim on Run, reset to defaults on Reset.

### Simulation Data Contract

```typescript
interface SimPoint { generation: number; frequency: number; }
type SimResult = SimPoint[][];   // array of trajectories
```

All simulation functions return `SimResult`. Some simulations include extra trajectories for equilibrium lines or reference curves.

### Pattern for Each Simulation Module

Every sim module in `src/lib/sim/` follows this structure:
- `FooParams` interface defining inputs
- `FOO_DEFAULTS` constant with sensible initial values
- `simulateFoo(params: FooParams): SimResult` pure function

### Route Page Pattern

Each route page follows a consistent pattern:
1. Declare `$state()` variables initialized from `*_DEFAULTS`
2. `run()` calls the simulation function with current state
3. `reset()` restores defaults and clears data
4. Render via `SimLayout` with `{#snippet controls()}` and `{#snippet chart()}`

### Component Hierarchy

- **SimLayout** — Master layout using Svelte 5 Snippets (`controls` and `chart` slots). Provides topbar with back link, title, inline controls, Run/Reset/Theme/Help buttons, and a full-bleed chart area. Accepts optional `helpKey` prop to enable the help panel.
- **HelpPanel** — Slide-out panel rendering structured help content (formulas as HTML, parameters, insights, references). Triggered by `?` button in SimLayout when `helpKey` is provided.
- **Chart** — Generic chart wrapper binding a div to `renderLineChart`. Auto-redraws on data/theme/resize.
- **DriftChart** — Specialized chart component with context-menu toggles (fixation markers, mean line, variance envelope, stats overlay).
- **DeFinettiChart**, **CurveChart**, **HistogramChart** — Specialized chart wrappers for non-line chart types.
- **DualChart** — Side-by-side panel layout (two Snippet slots: `left`/`right`).
- **ParamInput** — Labeled numeric input with `$bindable()` value.
- **ParamSelect** — Labeled dropdown select.
- **ResultsPanel** — Key-value display for computed results.
- **ResultsTable** — Tabular data display.

### Theming

CSS custom properties defined in `src/app.css` under `[data-theme="dark"]` and `[data-theme="light"]`. D3 chart renderers read these at render time via `getComputedStyle`. Theme state lives in `src/lib/theme.ts` (Svelte writable store). Eight visualization colors (`--viz-1` through `--viz-8`) cycle for multi-line charts.

### Svelte 5 Runes (not legacy syntax)

- `$state()` for reactive state
- `$derived()` for computed values
- `$effect()` for side effects (including chart redraws)
- `$props()` for component props with inline type annotations
- `$bindable()` for two-way binding (used in ParamInput)
- `{#snippet name()}` / `{@render name()}` for component composition (not legacy slots)

### Help System

`src/lib/help/` provides structured educational content for each simulation module:
- `types.ts` — `HelpContent` interface (title, category, description, formulas as HTML, parameters, insights, references)
- `content.ts` — Registry keyed by route path (e.g., `"/drift"`, `"/selection"`)
- `_drift.ts`, `_selection_mutation.ts`, `_mating_geneflow.ts`, `_linkage_freq_advanced.ts` — Content split by category

To add help for a module: create/add entries in the appropriate `_*.ts` file, keyed by the route path, then pass `helpKey="/route/path"` to `SimLayout`.

### Sim File Naming

Most sim files match their route name, but some don't:
- `htime.ts` → `/drift/heterozygosity`
- `fstats.ts` → `/gene-flow/f-statistics`
- `migration.ts` → `/gene-flow/continent-island` and `/gene-flow/island-island`
- `mating.ts` → `/mating/autosomal` and `/mating/x-linked`

### Import Aliases

`$lib` resolves to `src/lib/` (configured by SvelteKit). All internal imports use this alias.

### Module Categories (28 total)

- **Frequencies**: De Finetti, Genotype Frequencies, Chi-Square HWE
- **Drift**: Pure, +Selection, +Mutation, Combined, Markov Chain, Heterozygosity
- **Mating**: Autosomal, X-Linked, Assortative, Assortative Matrix
- **Mutation**: Two-Way, Irreversible, Neutral, Muller's Ratchet
- **Selection**: Natural Selection, Frequency-Dependent
- **Gene Flow**: Continent-Island, Island-Island, F-Statistics, Wahlund
- **Linkage**: Disequilibrium, Magnitude, Histogram
- **Advanced**: Molecular Pop Gen, QTL

## Deployment

**Domain**: popgenejs.bioinformat.org (Cloudflare Pages)

**Hosting**: Cloudflare Pages (static site via `@sveltejs/adapter-static`)

**Project name**: `popgenejs` (on Cloudflare account `bioinformat`)

### How It Works

The SvelteKit adapter-static prerenders all 28 routes into static HTML at build time. A `200.html` SPA fallback is generated for any routes that can't be prerendered. Cloudflare Pages serves the `build/` directory as static files.

Configuration files:
- `svelte.config.js` — adapter-static with `fallback: '200.html'`, output to `build/`
- `wrangler.toml` — Cloudflare Pages project name and build output directory

### Deploy

```bash
npm run deploy
```

This runs `npm run build` then `npx wrangler pages deploy build --project-name=popgenejs`.

### First-Time Setup

1. Authenticate wrangler: `npx wrangler login`
2. Create the Pages project (already done): `npx wrangler pages project create popgenejs --production-branch=master`
3. Deploy: `npm run deploy`
4. Add custom domain in Cloudflare dashboard: **Workers & Pages > popgenejs > Custom domains > Add `popgenejs.bioinformat.org`**

### Manual Deploy

```bash
npm run build
npx wrangler pages deploy build --project-name=popgenejs
```

## Reference: Original VB.NET Application

`PopGene.S/` contains the original desktop application. Key files for porting:
- `Drift.vb`, `Selection.vb`, `TwoMut.vb` — simulation algorithms
- `MainModule.vb` — parameter definitions

## Git

- Never include Claude references or co-authorship in commit messages
