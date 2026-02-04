# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

PopGeneS.js is a web-based population genetics simulation suite for educational and research purposes. Rewritten from the original VB.NET desktop app (preserved in `PopGene.S/` for reference).

## Technology Stack

- **Framework**: SvelteKit (Svelte 5 with runes)
- **Language**: TypeScript (strict mode)
- **Visualization**: D3.js v7
- **Build Tool**: Vite
- **Styling**: CSS custom properties (dark/light theme via `[data-theme]`)

## Commands

```bash
npm run dev       # Start dev server with HMR
npm run build     # Production build
npm run preview   # Preview production build
npm run check     # Type-check with svelte-check
```

No test framework is currently configured.

## Architecture

### SvelteKit File-Based Routing

```
src/
  routes/
    +page.svelte              # Landing page
    +layout.svelte            # Root layout (imports app.css)
    drift/+page.svelte        # Drift simulation
    selection/+page.svelte    # Selection simulation
    mutation/+page.svelte     # Mutation simulation
  lib/
    sim/                      # Pure simulation logic (no DOM, no Svelte)
      types.ts                # SimPoint, SimResult types
      drift.ts                # Wright-Fisher drift
      selection.ts            # Natural selection (delta-p)
      mutation.ts             # Two-way mutation
    components/               # Shared Svelte components
      Chart.svelte            # D3 chart mount (auto-redraws on data/theme/resize)
      ParamInput.svelte       # Labeled numeric input
      SimLayout.svelte        # Topbar + full-bleed chart layout
    charts/
      lineChart.ts            # D3 line chart renderer (reads CSS vars for theming)
    theme.ts                  # Dark/light theme store
  app.css                     # Design tokens (dark + light themes)
  app.html                    # HTML shell with Google Fonts
```

### Separation of Concerns

1. **Simulation logic** (`lib/sim/*.ts`) — Pure functions. No DOM, no Svelte. Accept params, return `SimResult` (array of `SimPoint[]` trajectories).
2. **Chart rendering** (`lib/charts/lineChart.ts`) — D3 function taking a DOM element + data. Reads theme colors from CSS custom properties.
3. **UI components** (`lib/components/*.svelte`) — Svelte 5 components using runes (`$state`, `$effect`, `$props`).
4. **Route pages** (`routes/*/+page.svelte`) — Thin wrappers composing sim logic + components.

### Simulation Data Contract

```typescript
interface SimPoint { generation: number; frequency: number; }
type SimResult = SimPoint[][];
```

### UI Pattern: Data-Forward

- Controls compressed into a topbar (inline inputs + Run/Reset buttons)
- Chart fills the entire remaining viewport
- Dark theme default, light theme via toggle
- Staggered line-draw animation via stroke-dashoffset

### Svelte 5 Runes

This project uses Svelte 5 runes, not legacy reactive declarations:
- `$state()` for reactive state
- `$derived()` for computed values
- `$effect()` for side effects
- `$props()` for component props
- `$bindable()` for two-way binding

## Reference: Original VB.NET Application

`PopGene.S/` contains the original desktop application. Key files for porting:
- `Drift.vb`, `Selection.vb`, `TwoMut.vb` — simulation algorithms
- `MainModule.vb` — parameter definitions

## Git

- Remove claude references from commit messages
