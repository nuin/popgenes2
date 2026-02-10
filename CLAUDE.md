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

- **SimLayout** — Master layout using Svelte 5 Snippets (`controls` and `chart` slots). Provides topbar with back link, title, inline controls, Run/Reset/Theme buttons, and a full-bleed chart area.
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

### Module Categories (28 total)

- **Frequencies**: De Finetti, Genotype Frequencies, Chi-Square HWE
- **Drift**: Pure, +Selection, +Mutation, Combined, Markov Chain, Heterozygosity
- **Mating**: Autosomal, X-Linked, Assortative, Assortative Matrix
- **Mutation**: Two-Way, Irreversible, Neutral, Muller's Ratchet
- **Selection**: Natural Selection, Frequency-Dependent
- **Gene Flow**: Continent-Island, Island-Island, F-Statistics, Wahlund
- **Linkage**: Disequilibrium, Magnitude, Histogram
- **Advanced**: Molecular Pop Gen, QTL

## Reference: Original VB.NET Application

`PopGene.S/` contains the original desktop application. Key files for porting:
- `Drift.vb`, `Selection.vb`, `TwoMut.vb` — simulation algorithms
- `MainModule.vb` — parameter definitions

## Git

- Remove claude references from commit messages
