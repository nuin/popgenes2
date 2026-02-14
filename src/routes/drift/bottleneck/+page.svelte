<script lang="ts">
	import { browser } from '$app/environment';
	import { theme, toggleTheme } from '$lib/theme';
	import ParamInput from '$lib/components/ParamInput.svelte';
	import * as d3 from 'd3';

	// === Parameters ===
	let initialN = $state(100);
	let bottleneckN = $state(10);
	let initialP = $state(0.5);
	let recoveryN = $state(100);

	// === Simulation State ===
	type Phase = 'setup' | 'initialized' | 'bottlenecked' | 'recovering' | 'complete';
	let phase = $state<Phase>('setup');

	// === Population ===
	interface Individual {
		id: number;
		genotype: number; // 0=aa, 1=Aa, 2=AA
		x: number;
		y: number;
		vx: number;
		vy: number;
		alive: boolean;
		opacity: number;
		radius: number;
		survivor: boolean;
	}

	let population = $state<Individual[]>([]);
	let nextId = $state(0);

	// === History for funnel ===
	interface Snapshot {
		n: number;
		p: number;
		AA: number;
		Aa: number;
		aa: number;
		H: number;
	}

	let beforeState = $state<Snapshot | null>(null);
	let bottleneckState = $state<Snapshot | null>(null);
	let afterState = $state<Snapshot | null>(null);

	// === Containers ===
	let arenaContainer: HTMLDivElement;
	let funnelContainer: HTMLDivElement;
	let simulation: d3.Simulation<Individual, undefined> | null = null;

	// === Derived stats ===
	let currentStats = $derived(() => {
		const alive = population.filter(p => p.alive);
		const n = alive.length;
		if (n === 0) return { n: 0, p: 0.5, AA: 0, Aa: 0, aa: 0, H: 0 };

		const AA = alive.filter(p => p.genotype === 2).length;
		const Aa = alive.filter(p => p.genotype === 1).length;
		const aa = alive.filter(p => p.genotype === 0).length;
		const p = (2 * AA + Aa) / (2 * n);
		const H = Aa / n;

		return { n, p, AA, Aa, aa, H };
	});

	// === Colors ===
	function getColors() {
		if (!browser) {
			return {
				AA: '#3b82f6', Aa: '#14b8a6', aa: '#f97316',
				bg: '#1a1a2e', border: '#333', text: '#fff', muted: '#888'
			};
		}
		const style = getComputedStyle(document.body);
		return {
			AA: style.getPropertyValue('--viz-1').trim() || '#3b82f6',
			Aa: style.getPropertyValue('--viz-2').trim() || '#14b8a6',
			aa: style.getPropertyValue('--viz-3').trim() || '#f97316',
			bg: style.getPropertyValue('--chart-bg').trim() || '#1a1a2e',
			border: style.getPropertyValue('--border').trim() || '#333',
			text: style.getPropertyValue('--text').trim() || '#fff',
			muted: style.getPropertyValue('--text-muted').trim() || '#888'
		};
	}

	function genotypeColor(genotype: number, colors: ReturnType<typeof getColors>) {
		if (genotype === 2) return colors.AA;
		if (genotype === 1) return colors.Aa;
		return colors.aa;
	}

	// === Initialize Population ===
	function initialize() {
		if (simulation) {
			simulation.stop();
			simulation = null;
		}

		const rect = arenaContainer?.getBoundingClientRect();
		const w = rect?.width || 600;
		const h = rect?.height || 350;

		population = [];
		nextId = 0;

		// Generate individuals based on HWE
		const p = initialP;
		const q = 1 - p;
		const probAA = p * p;
		const probAa = 2 * p * q;

		for (let i = 0; i < initialN; i++) {
			const rand = Math.random();
			let genotype: number;
			if (rand < probAA) genotype = 2;
			else if (rand < probAA + probAa) genotype = 1;
			else genotype = 0;

			population.push({
				id: nextId++,
				genotype,
				x: w / 2 + (Math.random() - 0.5) * w * 0.8,
				y: h / 2 + (Math.random() - 0.5) * h * 0.8,
				vx: 0,
				vy: 0,
				alive: true,
				opacity: 1,
				radius: 6,
				survivor: false
			});
		}

		// Take snapshot
		const stats = currentStats();
		beforeState = { ...stats };
		bottleneckState = null;
		afterState = null;

		phase = 'initialized';
		renderArena();
		renderFunnel();
		startSimulation();
	}

	// === D3 Force Simulation ===
	function startSimulation() {
		const rect = arenaContainer?.getBoundingClientRect();
		const w = rect?.width || 600;
		const h = rect?.height || 350;

		simulation = d3.forceSimulation(population)
			.force('charge', d3.forceManyBody().strength(-2))
			.force('center', d3.forceCenter(w / 2, h / 2).strength(0.02))
			.force('collision', d3.forceCollide<Individual>().radius(d => d.radius + 2))
			.force('x', d3.forceX(w / 2).strength(0.01))
			.force('y', d3.forceY(h / 2).strength(0.01))
			.alphaDecay(0.01)
			.on('tick', () => {
				// Boundary containment
				population.forEach(p => {
					p.x = Math.max(p.radius, Math.min(w - p.radius, p.x));
					p.y = Math.max(p.radius, Math.min(h - p.radius, p.y));
				});
				renderArena();
			});
	}

	// === Render Arena ===
	function renderArena() {
		if (!browser || !arenaContainer) return;

		const colors = getColors();
		const rect = arenaContainer.getBoundingClientRect();
		const w = rect.width;
		const h = rect.height;

		let svg = d3.select(arenaContainer).select('svg');
		if (svg.empty()) {
			svg = d3.select(arenaContainer)
				.append('svg')
				.attr('width', w)
				.attr('height', h);
		}

		const circles = svg.selectAll<SVGCircleElement, Individual>('circle')
			.data(population, d => d.id);

		circles.enter()
			.append('circle')
			.attr('cx', d => d.x)
			.attr('cy', d => d.y)
			.attr('r', 0)
			.attr('fill', d => genotypeColor(d.genotype, colors))
			.attr('opacity', 0)
			.attr('stroke', d => d.survivor ? '#fff' : 'none')
			.attr('stroke-width', d => d.survivor ? 2 : 0)
			.transition()
			.duration(300)
			.attr('r', d => d.radius)
			.attr('opacity', d => d.opacity);

		circles
			.attr('cx', d => d.x)
			.attr('cy', d => d.y)
			.attr('r', d => d.radius)
			.attr('fill', d => genotypeColor(d.genotype, colors))
			.attr('opacity', d => d.opacity)
			.attr('stroke', d => d.survivor ? '#fff' : 'none')
			.attr('stroke-width', d => d.survivor ? 2 : 0);

		circles.exit().remove();
	}

	// === Bottleneck Event ===
	async function triggerBottleneck() {
		if (phase !== 'initialized') return;
		phase = 'bottlenecked';

		const alive = population.filter(p => p.alive);
		const shuffled = [...alive].sort(() => Math.random() - 0.5);
		const survivors = shuffled.slice(0, bottleneckN);
		const survivorIds = new Set(survivors.map(s => s.id));

		// Mark survivors
		population.forEach(p => {
			if (survivorIds.has(p.id)) {
				p.survivor = true;
			}
		});

		// Animate non-survivors dying
		const deathDuration = 1500;
		const startTime = Date.now();

		await new Promise<void>(resolve => {
			const animate = () => {
				const elapsed = Date.now() - startTime;
				const progress = Math.min(1, elapsed / deathDuration);
				const eased = d3.easeCubicIn(progress);

				population.forEach(p => {
					if (!survivorIds.has(p.id)) {
						p.opacity = 1 - eased;
						p.radius = 6 * (1 - eased);
						p.y += eased * 2; // Drift downward
					}
				});

				// Pulse survivors
				if (progress < 0.5) {
					const pulse = Math.sin(progress * Math.PI * 4) * 0.3 + 1;
					population.forEach(p => {
						if (p.survivor) {
							p.radius = 6 * pulse;
						}
					});
				} else {
					population.forEach(p => {
						if (p.survivor) p.radius = 6;
					});
				}

				renderArena();

				if (progress < 1) {
					requestAnimationFrame(animate);
				} else {
					// Remove dead individuals
					population = population.filter(p => survivorIds.has(p.id));
					population.forEach(p => p.alive = true);

					// Update simulation
					if (simulation) {
						simulation.nodes(population);
						simulation.alpha(0.3).restart();
					}

					// Take snapshot
					const stats = currentStats();
					bottleneckState = { ...stats };
					renderFunnel();
					resolve();
				}
			};
			animate();
		});
	}

	// === Recovery ===
	async function triggerRecovery() {
		if (phase !== 'bottlenecked') return;
		phase = 'recovering';

		const rect = arenaContainer?.getBoundingClientRect();
		const w = rect?.width || 600;
		const h = rect?.height || 350;

		const generationDelay = 150;
		const targetN = recoveryN;

		// IMPORTANT: Capture survivor allele frequency ONCE at start of recovery
		// This is the founder frequency that should be maintained (with drift)
		const survivors = population.filter(ind => ind.alive);
		const survivorN = survivors.length;
		const survivorAA = survivors.filter(ind => ind.genotype === 2).length;
		const survivorAa = survivors.filter(ind => ind.genotype === 1).length;
		const founderP = (2 * survivorAA + survivorAa) / (2 * survivorN);

		console.log(`Recovery starting with founder p = ${founderP.toFixed(3)} from ${survivorN} survivors`);

		while (population.length < targetN) {
			// Get current population for parent selection
			const alive = population.filter(ind => ind.alive);
			const n = alive.length;

			// Add new individuals (reproduction based on FOUNDER frequency, not current)
			// This simulates rapid expansion where founder effect dominates
			const toAdd = Math.min(Math.ceil(n * 0.3), targetN - population.length);

			for (let i = 0; i < toAdd; i++) {
				// Sample alleles from founder frequency (bottleneck survivors)
				// Small drift variance per generation
				const driftP = founderP + (Math.random() - 0.5) * 0.02; // tiny drift
				const allele1 = Math.random() < driftP ? 1 : 0;
				const allele2 = Math.random() < driftP ? 1 : 0;
				const genotype = allele1 + allele2;

				// Spawn near a random parent
				const parent = alive[Math.floor(Math.random() * alive.length)];

				population.push({
					id: nextId++,
					genotype,
					x: parent.x + (Math.random() - 0.5) * 30,
					y: parent.y + (Math.random() - 0.5) * 30,
					vx: 0,
					vy: 0,
					alive: true,
					opacity: 1,
					radius: 0, // Start small, animate in
					survivor: false
				});
			}

			// Animate new particles growing
			const newOnes = population.filter(p => p.radius === 0);
			newOnes.forEach(p => p.radius = 6);

			// Update simulation
			if (simulation) {
				simulation.nodes(population);
				simulation.alpha(0.2).restart();
			}

			renderArena();
			renderFunnel();

			await new Promise(r => setTimeout(r, generationDelay));
		}

		// Final snapshot
		const stats = currentStats();
		afterState = { ...stats };
		phase = 'complete';

		console.log(`Recovery complete: final p = ${stats.p.toFixed(3)} (founder was ${founderP.toFixed(3)}, original was ${initialP.toFixed(3)})`);

		renderFunnel();
	}

	// === Reset ===
	function reset() {
		if (simulation) {
			simulation.stop();
			simulation = null;
		}
		population = [];
		beforeState = null;
		bottleneckState = null;
		afterState = null;
		phase = 'setup';

		if (arenaContainer) {
			d3.select(arenaContainer).selectAll('*').remove();
		}
		renderFunnel();
	}

	// === Render Funnel ===
	function renderFunnel() {
		if (!browser || !funnelContainer) return;

		const colors = getColors();
		const rect = funnelContainer.getBoundingClientRect();
		const w = rect.width;
		const h = rect.height;

		d3.select(funnelContainer).selectAll('*').remove();

		const svg = d3.select(funnelContainer)
			.append('svg')
			.attr('width', w)
			.attr('height', h);

		const margin = { top: 30, bottom: 40, left: 40, right: 40 };
		const iw = w - margin.left - margin.right;
		const ih = h - margin.top - margin.bottom;

		const g = svg.append('g')
			.attr('transform', `translate(${margin.left},${margin.top})`);

		// Three columns
		const colWidth = iw / 3;
		const maxBarHeight = ih - 20;
		const maxN = Math.max(initialN, recoveryN);

		const phases = [
			{ label: 'Before', state: beforeState, x: colWidth * 0.5 },
			{ label: 'Bottleneck', state: bottleneckState, x: colWidth * 1.5 },
			{ label: 'After', state: afterState || (phase === 'recovering' ? currentStats() : null), x: colWidth * 2.5 }
		];

		// Draw funnel lines connecting phases
		if (beforeState && bottleneckState) {
			const beforeH = (beforeState.n / maxN) * maxBarHeight;
			const bottleH = (bottleneckState.n / maxN) * maxBarHeight;
			const beforeX = colWidth * 0.5;
			const bottleX = colWidth * 1.5;
			const barWidth = 40;

			// Left funnel wall
			g.append('line')
				.attr('x1', beforeX - barWidth/2)
				.attr('y1', ih - beforeH)
				.attr('x2', bottleX - barWidth/2)
				.attr('y2', ih - bottleH)
				.attr('stroke', colors.muted)
				.attr('stroke-width', 2)
				.attr('opacity', 0.5);

			// Right funnel wall
			g.append('line')
				.attr('x1', beforeX + barWidth/2)
				.attr('y1', ih - beforeH)
				.attr('x2', bottleX + barWidth/2)
				.attr('y2', ih - bottleH)
				.attr('stroke', colors.muted)
				.attr('stroke-width', 2)
				.attr('opacity', 0.5);
		}

		if (bottleneckState && (afterState || phase === 'recovering')) {
			const bottleH = (bottleneckState.n / maxN) * maxBarHeight;
			const afterS = afterState || currentStats();
			const afterH = (afterS.n / maxN) * maxBarHeight;
			const bottleX = colWidth * 1.5;
			const afterX = colWidth * 2.5;
			const barWidth = 40;

			// Left funnel wall
			g.append('line')
				.attr('x1', bottleX - barWidth/2)
				.attr('y1', ih - bottleH)
				.attr('x2', afterX - barWidth/2)
				.attr('y2', ih - afterH)
				.attr('stroke', colors.muted)
				.attr('stroke-width', 2)
				.attr('opacity', 0.5);

			// Right funnel wall
			g.append('line')
				.attr('x1', bottleX + barWidth/2)
				.attr('y1', ih - bottleH)
				.attr('x2', afterX + barWidth/2)
				.attr('y2', ih - afterH)
				.attr('stroke', colors.muted)
				.attr('stroke-width', 2)
				.attr('opacity', 0.5);
		}

		// Draw bars for each phase
		phases.forEach(({ label, state, x }) => {
			if (!state) {
				// Placeholder
				g.append('text')
					.attr('x', x)
					.attr('y', ih + 20)
					.attr('text-anchor', 'middle')
					.attr('fill', colors.muted)
					.attr('font-size', '11px')
					.text(label);
				return;
			}

			const barHeight = (state.n / maxN) * maxBarHeight;
			const barWidth = 40;

			// Stacked bar: aa at bottom, Aa middle, AA top
			const aaH = (state.aa / state.n) * barHeight;
			const AaH = (state.Aa / state.n) * barHeight;
			const AAH = (state.AA / state.n) * barHeight;

			let yOffset = ih;

			// aa segment
			g.append('rect')
				.attr('x', x - barWidth/2)
				.attr('y', yOffset - aaH)
				.attr('width', barWidth)
				.attr('height', aaH)
				.attr('fill', colors.aa);
			yOffset -= aaH;

			// Aa segment
			g.append('rect')
				.attr('x', x - barWidth/2)
				.attr('y', yOffset - AaH)
				.attr('width', barWidth)
				.attr('height', AaH)
				.attr('fill', colors.Aa);
			yOffset -= AaH;

			// AA segment
			g.append('rect')
				.attr('x', x - barWidth/2)
				.attr('y', yOffset - AAH)
				.attr('width', barWidth)
				.attr('height', AAH)
				.attr('fill', colors.AA);

			// Label
			g.append('text')
				.attr('x', x)
				.attr('y', ih + 20)
				.attr('text-anchor', 'middle')
				.attr('fill', colors.text)
				.attr('font-size', '11px')
				.text(label);

			// N count
			g.append('text')
				.attr('x', x)
				.attr('y', ih - barHeight - 8)
				.attr('text-anchor', 'middle')
				.attr('fill', colors.text)
				.attr('font-size', '10px')
				.attr('font-weight', '600')
				.text(`N=${state.n}`);

			// p value
			g.append('text')
				.attr('x', x)
				.attr('y', ih + 32)
				.attr('text-anchor', 'middle')
				.attr('fill', colors.muted)
				.attr('font-size', '9px')
				.text(`p=${state.p.toFixed(3)}`);
		});

		// Legend
		const legendY = 0;
		const legendItems = [
			{ label: 'AA', color: colors.AA },
			{ label: 'Aa', color: colors.Aa },
			{ label: 'aa', color: colors.aa }
		];

		legendItems.forEach((item, i) => {
			const lx = iw - 80 + i * 30;
			g.append('rect')
				.attr('x', lx)
				.attr('y', legendY)
				.attr('width', 10)
				.attr('height', 10)
				.attr('fill', item.color);
			g.append('text')
				.attr('x', lx + 12)
				.attr('y', legendY + 9)
				.attr('fill', colors.text)
				.attr('font-size', '9px')
				.text(item.label);
		});
	}

	// === Effects ===
	$effect(() => {
		void $theme;
		renderArena();
		renderFunnel();
	});

	$effect(() => {
		const observer = new ResizeObserver(() => {
			renderFunnel();
		});
		if (funnelContainer) observer.observe(funnelContainer);
		return () => observer.disconnect();
	});
</script>

<div class="sim">
	<div class="topbar">
		<div class="topbar-left">
			<a href="/" class="back">&larr; Modules</a>
			<span class="sim-title">Bottleneck Effect</span>
			<span class="sim-subtitle">Population crash and genetic diversity loss</span>
		</div>
		<div class="topbar-right">
			<div class="controls">
				<ParamInput label="Initial N" bind:value={initialN} min={20} max={300} step={10} />
				<ParamInput label="Survivors" bind:value={bottleneckN} min={2} max={50} step={1} />
				<ParamInput label="Initial p" bind:value={initialP} min={0.1} max={0.9} step={0.05} />
				<ParamInput label="Recovery N" bind:value={recoveryN} min={20} max={300} step={10} />
			</div>
			<button class="btn-theme" onclick={toggleTheme} aria-label="Toggle theme">
				{$theme === 'dark' ? '&#9788;' : '&#9790;'}
			</button>
		</div>
	</div>

	<main class="main-area">
		<div class="simulation-content">
			<div class="action-buttons">
				<button
					class="btn btn-init"
					onclick={initialize}
					disabled={phase !== 'setup' && phase !== 'complete'}
				>
					Initialize
				</button>
				<button
					class="btn btn-bottleneck"
					onclick={triggerBottleneck}
					disabled={phase !== 'initialized'}
				>
					Bottleneck!
				</button>
				<button
					class="btn btn-recover"
					onclick={triggerRecovery}
					disabled={phase !== 'bottlenecked'}
				>
					Recover
				</button>
				<button
					class="btn btn-reset"
					onclick={reset}
					disabled={phase === 'setup'}
				>
					Reset
				</button>
			</div>

			<div class="stats-bar">
				<span class="stat">
					<span class="stat-label">Phase:</span>
					<span class="stat-value phase-{phase}">{phase}</span>
				</span>
				<span class="stat">
					<span class="stat-label">N:</span>
					<span class="stat-value">{currentStats().n}</span>
				</span>
				<span class="stat">
					<span class="stat-label">p(A):</span>
					<span class="stat-value">{currentStats().p.toFixed(3)}</span>
				</span>
				<span class="stat">
					<span class="stat-label">H:</span>
					<span class="stat-value">{currentStats().H.toFixed(3)}</span>
				</span>
			</div>

			<div class="arena" bind:this={arenaContainer}></div>

			<div class="funnel-section">
				<h3>Population Timeline</h3>
				<div class="funnel" bind:this={funnelContainer}></div>
			</div>
		</div>
	</main>
</div>

<style>
	.sim {
		height: 100vh;
		display: flex;
		flex-direction: column;
		background: var(--bg);
		transition: background 0.25s;
	}

	.topbar {
		display: flex;
		align-items: center;
		justify-content: space-between;
		padding: 0.6rem 1.5rem;
		background: var(--bg);
		border-bottom: 1px solid var(--border);
		flex-shrink: 0;
		transition: background 0.25s, border-color 0.25s;
		flex-wrap: wrap;
		gap: 0.75rem;
	}

	.topbar-left {
		display: flex;
		align-items: center;
		gap: 1.5rem;
	}

	.topbar-right {
		display: flex;
		align-items: center;
		gap: 1rem;
		flex-wrap: wrap;
	}

	.back {
		font-size: 0.75rem;
		color: var(--text-muted);
		text-decoration: none;
		transition: color 0.15s;
	}

	.back:hover {
		color: var(--text);
	}

	.sim-title {
		font-size: 0.8rem;
		font-weight: 500;
		color: var(--text);
		letter-spacing: -0.01em;
	}

	.sim-subtitle {
		font-size: 0.7rem;
		color: var(--text-muted);
	}

	.controls {
		display: flex;
		align-items: center;
		gap: 1rem;
		flex-wrap: wrap;
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

	.main-area {
		flex: 1;
		padding: 0.75rem;
		display: flex;
		min-height: 0;
		overflow: auto;
	}

	.simulation-content {
		flex: 1;
		display: flex;
		flex-direction: column;
		gap: 0.75rem;
		background: var(--chart-bg);
		border: 1px solid var(--border);
		border-radius: 6px;
		padding: 0.75rem;
	}

	.action-buttons {
		display: flex;
		gap: 0.75rem;
		flex-wrap: wrap;
	}

	.btn {
		padding: 0.6rem 1.2rem;
		font-size: 0.85rem;
		font-weight: 600;
		border: none;
		border-radius: 6px;
		cursor: pointer;
		transition: all 0.2s;
	}

	.btn:disabled {
		opacity: 0.4;
		cursor: not-allowed;
	}

	.btn-init {
		background: var(--viz-1);
		color: white;
	}

	.btn-init:hover:not(:disabled) {
		filter: brightness(1.1);
	}

	.btn-bottleneck {
		background: var(--viz-3);
		color: white;
	}

	.btn-bottleneck:hover:not(:disabled) {
		filter: brightness(1.1);
		transform: scale(1.02);
	}

	.btn-recover {
		background: var(--viz-2);
		color: white;
	}

	.btn-recover:hover:not(:disabled) {
		filter: brightness(1.1);
	}

	.btn-reset {
		background: var(--border);
		color: var(--text);
	}

	.btn-reset:hover:not(:disabled) {
		background: var(--text-muted);
	}

	.stats-bar {
		display: flex;
		gap: 1.5rem;
		padding: 0.6rem 1rem;
		background: var(--bg);
		border: 1px solid var(--border);
		border-radius: 6px;
		flex-wrap: wrap;
	}

	.stat {
		display: flex;
		gap: 0.4rem;
		align-items: center;
	}

	.stat-label {
		font-size: 0.75rem;
		color: var(--text-muted);
	}

	.stat-value {
		font-family: var(--font-mono);
		font-size: 0.85rem;
		font-weight: 600;
		color: var(--text);
	}

	.phase-setup { color: var(--text-muted); }
	.phase-initialized { color: var(--viz-1); }
	.phase-bottlenecked { color: var(--viz-3); }
	.phase-recovering { color: var(--viz-2); }
	.phase-complete { color: var(--accent); }

	.arena {
		flex: 1;
		min-height: 300px;
		background: var(--bg);
		border: 1px solid var(--border);
		border-radius: 8px;
		overflow: hidden;
	}

	.funnel-section {
		background: var(--bg);
		border: 1px solid var(--border);
		border-radius: 8px;
		padding: 1rem;
	}

	.funnel-section h3 {
		font-size: 0.85rem;
		font-weight: 500;
		color: var(--text-muted);
		margin: 0 0 0.5rem;
	}

	.funnel {
		height: 180px;
	}

	@media (max-width: 768px) {
		.topbar-left {
			flex-wrap: wrap;
			gap: 0.5rem;
		}

		.sim-subtitle {
			display: none;
		}

		.arena {
			min-height: 250px;
		}

		.funnel {
			height: 150px;
		}

		.action-buttons {
			justify-content: center;
		}

		.stats-bar {
			justify-content: center;
		}
	}
</style>
