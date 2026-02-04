# PopGeneS.js SvelteKit Rewrite — Design Document

## Overview

Rewrite PopGeneS.js from Ripple.js to SvelteKit + D3.js with a minimalist scientific UI. Start fresh — the current Ripple.js code is replaced entirely.

## Decisions

| Area | Choice |
|---|---|
| Framework | SvelteKit (file-based routing, SSR-capable) |
| Visualization | D3.js v7 |
| Styling | CSS custom properties, no framework |
| Typography | Inter (UI) + IBM Plex Mono (numbers) |
| Routing | Landing page + separate route per simulation |
| Initial scope | Drift, Selection, Mutation |

## Project Structure

```
src/
  routes/
    +page.svelte              # Landing page (categorized link list)
    +layout.svelte            # Shared layout (minimal)
    drift/+page.svelte        # Drift simulation
    selection/+page.svelte    # Selection simulation
    mutation/+page.svelte     # Mutation simulation
  lib/
    sim/                      # Pure simulation logic (no DOM, no Svelte)
      drift.ts
      selection.ts
      mutation.ts
    components/               # Shared Svelte components
      Chart.svelte            # D3 chart wrapper
      ParamInput.svelte       # Labeled number input
      SimLayout.svelte        # Topbar + full-bleed chart layout
    charts/                   # D3 rendering functions
      lineChart.ts
  app.css                     # Global styles + design tokens
static/
svelte.config.js
vite.config.ts
package.json
```

## Architecture

### Separation of Concerns

1. **Simulation logic** (`lib/sim/*.ts`) — Pure TypeScript functions. No DOM access, no framework imports. Accept params, return data arrays. Independently testable.

2. **Chart rendering** (`lib/charts/*.ts`) — D3 functions that take a DOM element + data and render SVG. Framework-agnostic.

3. **UI components** (`lib/components/*.svelte`) — Svelte components for layout and inputs. Compose sim logic + chart rendering.

4. **Route pages** (`routes/*/+page.svelte`) — Thin wrappers that use components.

### Simulation Data Contract

All simulations share the same output shape:

```typescript
interface SimPoint {
  generation: number;
  frequency: number;
}

// Each simulation returns an array of population trajectories
type SimResult = SimPoint[][];
```

### Drift

```typescript
interface DriftParams {
  populations: number;
  populationSize: number;
  initialFreq: number;
  generations: number;
}
function simulateDrift(params: DriftParams): SimResult
```

Uses `d3.randomBinomial()` for stochastic sampling.

### Selection

```typescript
interface SelectionParams {
  wAA: number;          // fitness of AA
  wAa: number;          // fitness of Aa
  waa: number;          // fitness of aa
  initialFreq: number;
  generations: number;
}
function simulateSelection(params: SelectionParams): SimResult
```

Deterministic delta-p recurrence. Returns single trajectory + equilibrium line.

### Mutation

```typescript
interface MutationParams {
  mu: number;           // forward mutation rate (A -> a)
  nu: number;           // reverse mutation rate (a -> A)
  initialFreq: number;
  generations: number;
}
function simulateMutation(params: MutationParams): SimResult
```

Deterministic equilibrium convergence.

## UI Design

**Style: Data-Forward** — chart dominates the viewport, controls compressed into a top bar. Dark/light theme toggle.

### Landing Page

Title + subtitle + plain categorized link list. No cards, no descriptions.

```
PopGeneS.js
Population genetics simulations

Drift
  Genetic Drift (Wright-Fisher)

Selection
  Natural Selection

Mutation
  Two-Way Mutation
```

### Simulation Page Layout

```
┌─────────────────────────────────────────────────────────┐
│  ← Modules   Genetic Drift   [Pop][Ne][P(A)][Gen] Run Reset │
├─────────────────────────────────────────────────────────┤
│                                                         │
│                       Chart                             │
│                    (fills viewport)                      │
│                                                         │
│                                                         │
└─────────────────────────────────────────────────────────┘
  topbar: flex row, all controls inline
  chart:  flex-grow, fills remaining height
```

Mobile: topbar wraps controls onto two rows, chart remains full-width below.

### Theming

Dark/light toggle via `[data-theme]` attribute on `<body>`. All colors use CSS custom properties.

**Dark theme (default):**
```css
--bg: #111;
--bg-surface: #0d0d0d;
--bg-control: #1a1a1a;
--border: #222;
--text: #ccc;
--text-muted: #555;
--accent: #4dabf7;
--accent-text: #111;
--axis: #444;
--grid: #1e1e1e;
--label: #666;
--line-opacity: 0.8;
```

**Light theme:**
```css
--bg: #fff;
--bg-surface: #fff;
--bg-control: #f6f6f6;
--border: #e5e5e5;
--text: #222;
--text-muted: #999;
--accent: #0066CC;
--accent-text: #fff;
--axis: #bbb;
--grid: #f0f0f0;
--label: #999;
--line-opacity: 0.6;
```

### Typography

```css
--font-sans: 'Inter', system-ui, sans-serif;
--font-mono: 'IBM Plex Mono', monospace;
```

### Chart Colors

8-color palette, adapted per theme for contrast:

**Dark:**
```
#4dabf7  #ff6b6b  #51cf66  #ffd43b  #cc5de8  #ff922b  #22b8cf  #e599f7
```

**Light:**
```
#0066CC  #E63946  #06A77D  #D4920B  #7B68EE  #E07020  #0E8A8A  #B05CE6
```

### Interaction

- Explicit "Run" button (no auto-run)
- "Reset" button restores default parameter values
- Chart clears and redraws on each run
- Staggered line-draw animation (stroke-dashoffset, 1200ms, 60ms delay between lines)
- Catmull-Rom curve interpolation for smooth lines

## Implementation Steps

### Step 1: Project scaffold

- Initialize SvelteKit project with TypeScript
- Set up Vite config
- Install D3.js
- Create `app.css` with design tokens
- Create shared layout (`+layout.svelte`)
- Create landing page with placeholder links

### Step 2: Shared components

- `SimLayout.svelte` — topbar controls + full-bleed chart layout
- `ParamInput.svelte` — labeled numeric input
- `Chart.svelte` — D3 mount point (binds DOM element, calls render function)
- `lineChart.ts` — reusable D3 line chart renderer

### Step 3: Drift simulation

- Port `simulateDrift()` to `lib/sim/drift.ts`
- Create `routes/drift/+page.svelte`
- Wire up params, run button, chart

### Step 4: Selection simulation

- Implement `simulateSelection()` in `lib/sim/selection.ts`
- Create `routes/selection/+page.svelte`
- Add equilibrium line overlay to chart

### Step 5: Mutation simulation

- Implement `simulateMutation()` in `lib/sim/mutation.ts`
- Create `routes/mutation/+page.svelte`

### Step 6: Polish

- Mobile responsive behavior
- Verify chart responsiveness on window resize
- Update CLAUDE.md for new stack

## Reference

Original VB.NET simulation algorithms are in `PopGene.S/`:
- `Drift.vb` — drift logic
- `Selection.vb` — selection models
- `TwoMut.vb` — two-way mutation
- `MainModule.vb` — parameter definitions
