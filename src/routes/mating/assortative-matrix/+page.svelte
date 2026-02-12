<script lang="ts">
	import SimLayout from '$lib/components/SimLayout.svelte';
	import ParamInput from '$lib/components/ParamInput.svelte';
	import ParamSelect from '$lib/components/ParamSelect.svelte';
	import ResultsPanel from '$lib/components/ResultsPanel.svelte';
	import {
		computeMatingStep,
		identifyModel,
		matrixToPattern,
		simulateAssortative,
		MODEL_PATTERNS,
		MODEL_DESCRIPTIONS,
		ASSORTATIVE_DEFAULTS,
		type MatingVariant,
		type ModelNumber,
		type MatrixResult
	} from '$lib/sim/assortative';

	// Initial frequencies
	let D = $state(ASSORTATIVE_DEFAULTS.D);
	let H = $state(ASSORTATIVE_DEFAULTS.H);
	let generations = $state(ASSORTATIVE_DEFAULTS.generations);
	let variant: MatingVariant = $state('forbidden');

	// 3×3 matrix: true = allowed, false = forbidden
	// Layout: [0]=AA×AA, [1]=AA×Aa, [2]=AA×aa, [3]=Aa×AA, [4]=Aa×Aa, [5]=Aa×aa, [6]=aa×AA, [7]=aa×Aa, [8]=aa×aa
	let matrix = $state([true, true, false, true, true, false, false, false, true]);

	const variantOptions = [
		{ value: 'forbidden', label: 'Forbidden (matings don\'t occur)' },
		{ value: 'sterile', label: 'Sterile (matings occur, no offspring)' }
	];

	// Derived: which model matches current pattern
	const currentPattern = $derived(matrixToPattern(matrix));
	const matchedModel = $derived(identifyModel(currentPattern));

	let result: MatrixResult | null = $state(null);
	let trajectory: { genD: number[]; genH: number[]; genR: number[] } | null = $state(null);

	const fmt = (n: number) => n.toFixed(4);

	function toggleCell(index: number) {
		matrix[index] = !matrix[index];
		// Sync symmetric cells (AA×Aa ↔ Aa×AA, etc.)
		const symmetricPairs: [number, number][] = [
			[1, 3], // AA×Aa ↔ Aa×AA
			[2, 6], // AA×aa ↔ aa×AA
			[5, 7] // Aa×aa ↔ aa×Aa
		];
		for (const [a, b] of symmetricPairs) {
			if (index === a) matrix[b] = matrix[a];
			if (index === b) matrix[a] = matrix[b];
		}
		result = null; // Clear previous results when matrix changes
	}

	function loadModel(modelNum: ModelNumber) {
		const pattern = MODEL_PATTERNS[modelNum];
		matrix = [
			pattern.DD,
			pattern.DH,
			pattern.DR,
			pattern.DH,
			pattern.HH,
			pattern.HR,
			pattern.DR,
			pattern.HR,
			pattern.RR
		];
		result = null;
	}

	function run() {
		if (!matchedModel) {
			// No valid model matches - show error
			result = null;
			trajectory = null;
			return;
		}

		result = computeMatingStep(D, H, matchedModel, variant);
		const traj = simulateAssortative({
			D,
			H,
			generations,
			model: matchedModel,
			variant
		});
		trajectory = { genD: traj.genD, genH: traj.genH, genR: traj.genR };
	}

	function reset() {
		D = ASSORTATIVE_DEFAULTS.D;
		H = ASSORTATIVE_DEFAULTS.H;
		generations = ASSORTATIVE_DEFAULTS.generations;
		variant = 'forbidden';
		matrix = [true, true, false, true, true, false, false, false, true];
		result = null;
		trajectory = null;
	}
</script>

<SimLayout title="Assortative Mating Matrix" onrun={run} onreset={reset} helpKey="/mating/assortative-matrix">
	{#snippet controls()}
		<ParamInput label="D (AA)" bind:value={D} step={0.01} min={0} max={1} />
		<ParamInput label="H (Aa)" bind:value={H} step={0.01} min={0} max={1} />
		<ParamInput label="Gen" bind:value={generations} min={1} max={100} />
		<ParamSelect label="Variant" bind:value={variant} options={variantOptions} />
	{/snippet}
	{#snippet chart()}
		<div class="matrix-layout">
			<div class="left-panel">
				<div class="section">
					<div class="section-title">Select Allowed Matings</div>
					<div class="mating-grid">
						<div class="grid-header corner">♀ \ ♂</div>
						<div class="grid-header">AA</div>
						<div class="grid-header">Aa</div>
						<div class="grid-header">aa</div>

						<div class="grid-row-label">AA</div>
						{#each [0, 1, 2] as i}
							<button
								class="grid-cell"
								class:allowed={matrix[i]}
								class:forbidden={!matrix[i]}
								onclick={() => toggleCell(i)}
							>
								{matrix[i] ? '✓' : '✗'}
							</button>
						{/each}

						<div class="grid-row-label">Aa</div>
						{#each [3, 4, 5] as i}
							<button
								class="grid-cell"
								class:allowed={matrix[i]}
								class:forbidden={!matrix[i]}
								onclick={() => toggleCell(i)}
							>
								{matrix[i] ? '✓' : '✗'}
							</button>
						{/each}

						<div class="grid-row-label">aa</div>
						{#each [6, 7, 8] as i}
							<button
								class="grid-cell"
								class:allowed={matrix[i]}
								class:forbidden={!matrix[i]}
								onclick={() => toggleCell(i)}
							>
								{matrix[i] ? '✓' : '✗'}
							</button>
						{/each}
					</div>
				</div>

				<div class="section">
					<div class="section-title">Model Detection</div>
					{#if matchedModel}
						<div class="model-match">
							<span class="model-num">Model {matchedModel}</span>
							<span class="model-desc">{MODEL_DESCRIPTIONS[matchedModel]}</span>
						</div>
					{:else}
						<div class="model-no-match">
							No predefined model matches this pattern.
							<br />Select a preset below or adjust the matrix.
						</div>
					{/if}
				</div>

				<div class="section">
					<div class="section-title">Load Preset Model</div>
					<div class="preset-grid">
						{#each Array.from({ length: 14 }, (_, i) => (i + 1) as ModelNumber) as m}
							<button
								class="preset-btn"
								class:active={matchedModel === m}
								onclick={() => loadModel(m)}
								title={MODEL_DESCRIPTIONS[m]}
							>
								{m}
							</button>
						{/each}
					</div>
				</div>
			</div>

			<div class="right-panel">
				{#if result}
					<div class="section">
						<div class="section-title">Current State</div>
						<ResultsPanel
							items={[
								{ label: 'p (allele A)', value: fmt(result.p) },
								{ label: 'D (AA)', value: fmt(D) },
								{ label: 'H (Aa)', value: fmt(H) },
								{ label: 'R (aa)', value: fmt(Math.max(0, 1 - D - H)) }
							]}
						/>
					</div>

					<div class="section">
						<div class="section-title">Mating Frequencies</div>
						<div class="freq-grid">
							<div class="freq-header corner">♀ \ ♂</div>
							<div class="freq-header">AA</div>
							<div class="freq-header">Aa</div>
							<div class="freq-header">aa</div>

							{#each ['AA', 'Aa', 'aa'] as rowLabel, rowIdx}
								<div class="freq-row-label">{rowLabel}</div>
								{#each [0, 1, 2] as colIdx}
									{@const cellIdx = rowIdx * 3 + colIdx}
									{@const cell = result.cells[cellIdx]}
									<div class="freq-cell" class:forbidden-freq={!cell.allowed}>
										{cell.allowed ? fmt(cell.frequency) : '—'}
									</div>
								{/each}
							{/each}
						</div>
					</div>

					<div class="section">
						<div class="section-title">Next Generation</div>
						<ResultsPanel
							items={[
								{ label: 'D\' (AA)', value: fmt(result.nextD) },
								{ label: 'H\' (Aa)', value: fmt(result.nextH) },
								{ label: 'R\' (aa)', value: fmt(result.nextR) }
							]}
						/>
					</div>

					{#if trajectory}
						<div class="section">
							<div class="section-title">Trajectory ({generations} generations)</div>
							<div class="trajectory-table">
								<div class="traj-header">Gen</div>
								<div class="traj-header">D</div>
								<div class="traj-header">H</div>
								<div class="traj-header">R</div>
								{#each trajectory.genD.slice(0, Math.min(10, generations + 1)) as _, i}
									<div class="traj-cell">{i}</div>
									<div class="traj-cell">{fmt(trajectory.genD[i])}</div>
									<div class="traj-cell">{fmt(trajectory.genH[i])}</div>
									<div class="traj-cell">{fmt(trajectory.genR[i])}</div>
								{/each}
								{#if generations > 9}
									<div class="traj-cell">...</div>
									<div class="traj-cell">...</div>
									<div class="traj-cell">...</div>
									<div class="traj-cell">...</div>
									<div class="traj-cell">{generations}</div>
									<div class="traj-cell">{fmt(trajectory.genD[generations])}</div>
									<div class="traj-cell">{fmt(trajectory.genH[generations])}</div>
									<div class="traj-cell">{fmt(trajectory.genR[generations])}</div>
								{/if}
							</div>
						</div>
					{/if}
				{:else if !matchedModel}
					<div class="placeholder error">
						Invalid mating pattern. Please select a valid combination or load a preset model.
					</div>
				{:else}
					<div class="placeholder">Click Run to compute mating frequencies</div>
				{/if}
			</div>
		</div>
	{/snippet}
</SimLayout>

<style>
	.matrix-layout {
		display: grid;
		grid-template-columns: 1fr 1fr;
		gap: 1.5rem;
		height: 100%;
		overflow: auto;
		padding: 0.5rem;
	}

	.left-panel,
	.right-panel {
		display: flex;
		flex-direction: column;
		gap: 1rem;
	}

	.section {
		display: flex;
		flex-direction: column;
		gap: 0.5rem;
	}

	.section-title {
		font-size: 0.65rem;
		font-weight: 600;
		color: var(--text-muted);
		text-transform: uppercase;
		letter-spacing: 0.05em;
	}

	/* Mating selection grid */
	.mating-grid {
		display: grid;
		grid-template-columns: 2.5rem repeat(3, 2.5rem);
		gap: 2px;
	}

	.grid-header,
	.grid-row-label {
		display: flex;
		align-items: center;
		justify-content: center;
		font-size: 0.7rem;
		font-weight: 600;
		color: var(--text-muted);
		height: 2.5rem;
	}

	.corner {
		font-size: 0.6rem;
	}

	.grid-cell {
		width: 2.5rem;
		height: 2.5rem;
		border: 1px solid var(--border);
		border-radius: 4px;
		font-size: 0.9rem;
		font-weight: 600;
		cursor: pointer;
		transition: all 0.15s;
		background: var(--bg);
	}

	.grid-cell.allowed {
		background: rgba(34, 197, 94, 0.15);
		color: var(--viz-3, #22c55e);
		border-color: var(--viz-3, #22c55e);
	}

	.grid-cell.forbidden {
		background: rgba(239, 68, 68, 0.15);
		color: var(--viz-2, #ef4444);
		border-color: var(--viz-2, #ef4444);
	}

	.grid-cell:hover {
		transform: scale(1.05);
	}

	/* Model detection */
	.model-match {
		display: flex;
		flex-direction: column;
		gap: 0.25rem;
		padding: 0.5rem;
		background: rgba(59, 130, 246, 0.1);
		border-radius: 4px;
	}

	.model-num {
		font-size: 0.85rem;
		font-weight: 600;
		color: var(--viz-1, #3b82f6);
	}

	.model-desc {
		font-size: 0.7rem;
		color: var(--text-muted);
	}

	.model-no-match {
		font-size: 0.75rem;
		color: var(--viz-2, #ef4444);
		padding: 0.5rem;
		background: rgba(239, 68, 68, 0.1);
		border-radius: 4px;
		line-height: 1.4;
	}

	/* Preset buttons */
	.preset-grid {
		display: grid;
		grid-template-columns: repeat(7, 1fr);
		gap: 4px;
	}

	.preset-btn {
		padding: 0.4rem;
		font-size: 0.7rem;
		font-weight: 600;
		border: 1px solid var(--border);
		border-radius: 4px;
		background: var(--bg);
		color: var(--text);
		cursor: pointer;
		transition: all 0.15s;
	}

	.preset-btn:hover {
		border-color: var(--accent);
		color: var(--accent);
	}

	.preset-btn.active {
		background: var(--accent);
		color: var(--bg);
		border-color: var(--accent);
	}

	/* Frequency display grid */
	.freq-grid {
		display: grid;
		grid-template-columns: 2rem repeat(3, 1fr);
		gap: 2px;
	}

	.freq-header,
	.freq-row-label {
		display: flex;
		align-items: center;
		justify-content: center;
		font-size: 0.65rem;
		font-weight: 600;
		color: var(--text-muted);
		padding: 0.3rem;
	}

	.freq-cell {
		display: flex;
		align-items: center;
		justify-content: center;
		font-size: 0.7rem;
		font-family: var(--font-mono, monospace);
		padding: 0.4rem;
		background: var(--link-hover-bg);
		border-radius: 2px;
	}

	.freq-cell.forbidden-freq {
		color: var(--text-muted);
		background: transparent;
	}

	/* Trajectory table */
	.trajectory-table {
		display: grid;
		grid-template-columns: 2rem repeat(3, 1fr);
		gap: 1px;
		font-size: 0.65rem;
		max-height: 200px;
		overflow-y: auto;
	}

	.traj-header {
		font-weight: 600;
		color: var(--text-muted);
		padding: 0.25rem;
		text-align: center;
		position: sticky;
		top: 0;
		background: var(--bg);
	}

	.traj-cell {
		padding: 0.2rem;
		text-align: center;
		font-family: var(--font-mono, monospace);
	}

	.placeholder {
		display: flex;
		align-items: center;
		justify-content: center;
		height: 100%;
		color: var(--text-muted);
		font-size: 0.8rem;
		text-align: center;
	}

	.placeholder.error {
		color: var(--viz-2, #ef4444);
	}

	@media (max-width: 768px) {
		.matrix-layout {
			grid-template-columns: 1fr;
		}
	}
</style>
