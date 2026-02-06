<script lang="ts">
	import SimLayout from '$lib/components/SimLayout.svelte';
	import ParamInput from '$lib/components/ParamInput.svelte';
	import ResultsTable from '$lib/components/ResultsTable.svelte';
	import ResultsPanel from '$lib/components/ResultsPanel.svelte';
	import { computeMolPopGen, MOLPOPGEN_DEFAULTS } from '$lib/sim/molpopgen';
	import type { MolPopGenResult } from '$lib/sim/molpopgen';

	let n = $state(MOLPOPGEN_DEFAULTS.n);
	let S = $state(MOLPOPGEN_DEFAULTS.S);
	let L = $state(MOLPOPGEN_DEFAULTS.L);
	let kHat = $state(MOLPOPGEN_DEFAULTS.kHat);

	let result: MolPopGenResult | null = $state(null);

	function run() {
		result = computeMolPopGen({ n, S, L, kHat });
	}

	function reset() {
		n = MOLPOPGEN_DEFAULTS.n;
		S = MOLPOPGEN_DEFAULTS.S;
		L = MOLPOPGEN_DEFAULTS.L;
		kHat = MOLPOPGEN_DEFAULTS.kHat;
		result = null;
	}
</script>

<SimLayout title="Molecular Population Genetics" onrun={run} onreset={reset}>
	{#snippet controls()}
		<ParamInput label="n (seqs)" bind:value={n} min={2} max={200} />
		<ParamInput label="S (sites)" bind:value={S} min={0} max={1000} />
		<ParamInput label="L (length)" bind:value={L} min={10} max={10000} />
		<ParamInput label="k̂ (diffs)" bind:value={kHat} step={0.1} min={0} max={500} />
	{/snippet}
	{#snippet chart()}
		{#if result}
			<div class="results-layout">
				<ResultsPanel
					items={[
						{ label: "Watterson's θ_W", value: result.thetaW },
						{ label: 'θ_W per site', value: result.thetaWPerSite },
						{ label: 'π (per site)', value: result.pi },
						{ label: 'π (total)', value: result.piTotal },
						{ label: "Tajima's D", value: result.tajimaD }
					]}
				/>
				<ResultsTable
					caption="Summary Statistics"
					headers={['Statistic', 'Value', 'Description']}
					rows={[
						['n', result.sampleSize, 'Sample size (sequences)'],
						['L', result.alignmentLength, 'Alignment length (sites)'],
						['S', result.segregatingSites, 'Segregating sites'],
						['a₁', result.a1, 'Harmonic number Σ(1/i)'],
						['a₂', result.a2, 'Σ(1/i²)'],
						['θ_W', result.thetaW, "Watterson's estimator (S/a₁)"],
						['θ_W/site', result.thetaWPerSite, 'θ_W per nucleotide site'],
						['π', result.pi, 'Nucleotide diversity per site'],
						['k̂', result.piTotal, 'Average pairwise differences'],
						["Tajima's D", result.tajimaD, '(π - θ_W) / SE']
					]}
				/>
				<div class="interpretation">
					{#if result.tajimaD > 2}
						<span class="tag tag-pos">D &gt; 2: Suggests balancing selection or population contraction</span>
					{:else if result.tajimaD < -2}
						<span class="tag tag-neg">D &lt; -2: Suggests purifying selection or population expansion</span>
					{:else}
						<span class="tag tag-neu">-2 &lt; D &lt; 2: Consistent with neutral evolution</span>
					{/if}
				</div>
			</div>
		{:else}
			<div class="placeholder">Enter parameters and run to compute molecular statistics</div>
		{/if}
	{/snippet}
</SimLayout>

<style>
	.results-layout {
		display: flex;
		flex-direction: column;
		gap: 1rem;
		height: 100%;
		overflow: auto;
	}

	.interpretation {
		padding: 0.5rem 0;
	}

	.tag {
		font-size: 0.75rem;
		font-weight: 500;
		padding: 0.3rem 0.75rem;
		border-radius: 4px;
	}

	.tag-pos {
		background: rgba(59, 130, 246, 0.1);
		color: var(--viz-1, #3b82f6);
	}

	.tag-neg {
		background: rgba(239, 68, 68, 0.1);
		color: var(--viz-2, #ef4444);
	}

	.tag-neu {
		background: rgba(34, 197, 94, 0.1);
		color: var(--viz-3, #22c55e);
	}

	.placeholder {
		display: flex;
		align-items: center;
		justify-content: center;
		height: 100%;
		color: var(--text-muted);
		font-size: 0.8rem;
	}
</style>
