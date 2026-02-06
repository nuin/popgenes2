<script lang="ts">
	import SimLayout from '$lib/components/SimLayout.svelte';
	import ParamInput from '$lib/components/ParamInput.svelte';
	import ResultsTable from '$lib/components/ResultsTable.svelte';
	import ResultsPanel from '$lib/components/ResultsPanel.svelte';
	import { computeWahlund, WAHLUND_DEFAULTS } from '$lib/sim/wahlund';
	import type { WahlundResult } from '$lib/sim/wahlund';

	let p1 = $state(WAHLUND_DEFAULTS.pops[0]);
	let p2 = $state(WAHLUND_DEFAULTS.pops[1]);
	let p3 = $state(WAHLUND_DEFAULTS.pops[2]);
	let p4 = $state(WAHLUND_DEFAULTS.pops[3]);
	let p5 = $state(WAHLUND_DEFAULTS.pops[4]);
	let f = $state(WAHLUND_DEFAULTS.f);

	const fmt = (n: number) => n.toFixed(4);

	let result: WahlundResult | null = $state(null);

	function run() {
		result = computeWahlund({ pops: [p1, p2, p3, p4, p5], f });
	}

	function reset() {
		p1 = WAHLUND_DEFAULTS.pops[0];
		p2 = WAHLUND_DEFAULTS.pops[1];
		p3 = WAHLUND_DEFAULTS.pops[2];
		p4 = WAHLUND_DEFAULTS.pops[3];
		p5 = WAHLUND_DEFAULTS.pops[4];
		f = WAHLUND_DEFAULTS.f;
		result = null;
	}
</script>

<SimLayout title="Wahlund Effect" onrun={run} onreset={reset}>
	{#snippet controls()}
		<ParamInput label="p₁" bind:value={p1} step={0.01} min={0} max={1} />
		<ParamInput label="p₂" bind:value={p2} step={0.01} min={0} max={1} />
		<ParamInput label="p₃" bind:value={p3} step={0.01} min={0} max={1} />
		<ParamInput label="p₄" bind:value={p4} step={0.01} min={0} max={1} />
		<ParamInput label="p₅" bind:value={p5} step={0.01} min={0} max={1} />
		<ParamInput label="f" bind:value={f} step={0.01} min={0} max={1} />
	{/snippet}
	{#snippet chart()}
		{#if result}
			<div class="results-area">
				<ResultsPanel items={[
					{ label: 'Mean p', value: fmt(result.avgP) },
					{ label: 'Var(p)', value: fmt(result.varP) }
				]} />

				<ResultsTable
					headers={['Pop', 'p', 'AA', 'Aa', 'aa']}
					rows={result.subpops.map(s => [
						s.label,
						fmt(s.p),
						fmt(s.freqAA),
						fmt(s.freqAa),
						fmt(s.freqaa)
					])}
				/>

				<ResultsTable
					headers={['', 'AA', 'Aa', 'aa']}
					rows={[
						['Observed (avg)', fmt(result.observedAA), fmt(result.observedAa), fmt(result.observedaa)],
						['Expected (HWE)', fmt(result.expectedAA), fmt(result.expectedAa), fmt(result.expectedaa)]
					]}
				/>

				<ResultsPanel items={[
					{ label: 'Fis', value: fmt(result.Fis) },
					{ label: 'Fst', value: fmt(result.Fst) },
					{ label: 'Fit', value: fmt(result.Fit) }
				]} />
			</div>
		{:else}
			<div class="placeholder">Enter subpopulation frequencies and click Run</div>
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
