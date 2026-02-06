<script lang="ts">
	let {
		items
	}: {
		items: { label: string; value: string | number }[];
	} = $props();
</script>

<div class="panel">
	{#each items as item}
		<div class="kv">
			<span class="kv-label">{item.label}</span>
			<span class="kv-value">
				{typeof item.value === 'number' ? item.value.toFixed(6) : item.value}
			</span>
		</div>
	{/each}
</div>

<style>
	.panel {
		display: flex;
		flex-wrap: wrap;
		gap: 1rem 2rem;
		padding: 0.75rem 0;
	}

	.kv {
		display: flex;
		align-items: baseline;
		gap: 0.5rem;
	}

	.kv-label {
		font-size: 0.65rem;
		color: var(--text-muted);
		text-transform: uppercase;
		letter-spacing: 0.05em;
		font-weight: 500;
		white-space: nowrap;
	}

	.kv-value {
		font-size: 0.85rem;
		font-family: var(--font-mono);
		color: var(--text);
		transition: color 0.25s;
	}
</style>
