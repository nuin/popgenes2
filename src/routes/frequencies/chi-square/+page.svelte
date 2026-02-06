<script lang="ts">
	import SimLayout from '$lib/components/SimLayout.svelte';
	import ParamInput from '$lib/components/ParamInput.svelte';
	import ResultsTable from '$lib/components/ResultsTable.svelte';
	import ResultsPanel from '$lib/components/ResultsPanel.svelte';
	import { computeChiSquare } from '$lib/sim/chi-square';
	import type { ChiSquareResult } from '$lib/sim/chi-square';

	let nAA = $state(100);
	let nAa = $state(50);
	let naa = $state(10);

	let result: ChiSquareResult | null = $state(null);

	function run() {
		result = computeChiSquare({ nAA, nAa, naa });
	}

	function reset() {
		nAA = 100;
		nAa = 50;
		naa = 10;
		result = null;
	}

	const fmt = (n: number) => n.toFixed(4);
</script>

<SimLayout title="Chi-Square HWE Test" onrun={run} onreset={reset}>
	{#snippet controls()}
		<ParamInput label="N(AA)" bind:value={nAA} min={0} />
		<ParamInput label="N(Aa)" bind:value={nAa} min={0} />
		<ParamInput label="N(aa)" bind:value={naa} min={0} />
	{/snippet}
	{#snippet chart()}
		{#if result}
			<div class="results-area">
				<ResultsPanel items={[
					{ label: 'p', value: result.p },
					{ label: 'q', value: result.q },
					{ label: 'N', value: result.total }
				]} />

				<ResultsTable
					headers={['Genotype', 'Observed', 'Obs. Freq', 'Exp. Freq', 'Exp. Count', 'χ²']}
					rows={[
						['AA', nAA, fmt(result.obsFreq[0]), fmt(result.expFreq[0]), fmt(result.expCount[0]), fmt(result.chiParts[0])],
						['Aa', nAa, fmt(result.obsFreq[1]), fmt(result.expFreq[1]), fmt(result.expCount[1]), fmt(result.chiParts[1])],
						['aa', naa, fmt(result.obsFreq[2]), fmt(result.expFreq[2]), fmt(result.expCount[2]), fmt(result.chiParts[2])]
					]}
				/>

				<ResultsPanel items={[
					{ label: 'χ² total', value: result.chiTotal },
					{ label: 'df', value: result.df },
					{ label: 'Critical (α=0.05)', value: result.critical },
					{ label: 'Verdict', value: result.significant ? 'Reject H₀ (not in HWE)' : 'Fail to reject H₀ (consistent with HWE)' }
				]} />
			</div>
		{:else}
			<div class="placeholder">Enter observed genotype counts and click Run</div>
		{/if}
	{/snippet}
</SimLayout>

<style>
	.results-area {
		padding: 1rem;
		display: flex;
		flex-direction: column;
		gap: 1.5rem;
		overflow-y: auto;
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
