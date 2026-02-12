<script lang="ts">
	import SimLayout from '$lib/components/SimLayout.svelte';
	import ParamInput from '$lib/components/ParamInput.svelte';
	import ResultsTable from '$lib/components/ResultsTable.svelte';
	import ResultsPanel from '$lib/components/ResultsPanel.svelte';
	import { computeLinkage } from '$lib/sim/linkage';
	import type { LinkageResult } from '$lib/sim/linkage';

	let nAB = $state(230);
	let nAb = $state(270);
	let naB = $state(120);
	let nab = $state(380);

	const fmt = (n: number) => n.toFixed(4);

	let result: LinkageResult | null = $state(null);

	function run() {
		result = computeLinkage({ nAB, nAb, naB, nab });
	}

	function reset() {
		nAB = 230;
		nAb = 270;
		naB = 120;
		nab = 380;
		result = null;
	}
</script>

<SimLayout title="Linkage Disequilibrium" onrun={run} onreset={reset} helpKey="/linkage/disequilibrium">
	{#snippet controls()}
		<ParamInput label="nAB" bind:value={nAB} min={0} />
		<ParamInput label="nAb" bind:value={nAb} min={0} />
		<ParamInput label="naB" bind:value={naB} min={0} />
		<ParamInput label="nab" bind:value={nab} min={0} />
	{/snippet}
	{#snippet chart()}
		{#if result}
			<div class="results-area">
				<ResultsPanel items={[
					{ label: 'Total', value: result.total.toString() },
					{ label: 'D', value: fmt(result.D) },
					{ label: 'Chi²', value: fmt(result.chi) }
				]} />

				<ResultsTable
					caption="Allele Frequencies"
					headers={['Allele', 'Frequency']}
					rows={[
						['pA', fmt(result.pA)],
						['pa', fmt(result.pa)],
						['pB', fmt(result.pB)],
						['pb', fmt(result.pb)]
					]}
				/>

				<ResultsTable
					caption="Gamete Frequencies"
					headers={['Gamete', 'Observed', 'Expected']}
					rows={[
						['AB', fmt(result.obsFreq[0]), fmt(result.expFreq[0])],
						['Ab', fmt(result.obsFreq[1]), fmt(result.expFreq[1])],
						['aB', fmt(result.obsFreq[2]), fmt(result.expFreq[2])],
						['ab', fmt(result.obsFreq[3]), fmt(result.expFreq[3])]
					]}
				/>

				<ResultsTable
					caption="Expected Counts"
					headers={['Gamete', 'Observed', 'Expected']}
					rows={[
						['AB', nAB.toString(), fmt(result.expCount[0])],
						['Ab', nAb.toString(), fmt(result.expCount[1])],
						['aB', naB.toString(), fmt(result.expCount[2])],
						['ab', nab.toString(), fmt(result.expCount[3])]
					]}
				/>
			</div>
		{:else}
			<div class="placeholder">Enter gamete counts and click Run</div>
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
