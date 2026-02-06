<script lang="ts">
	let {
		label,
		value = $bindable(),
		options
	}: {
		label: string;
		value: string;
		options: { value: string; label: string }[];
	} = $props();
</script>

<div class="control-item">
	<span class="control-label">{label}</span>
	<select class="control-select" bind:value>
		{#each options as opt}
			<option value={opt.value}>{opt.label}</option>
		{/each}
	</select>
</div>

<style>
	.control-item {
		display: flex;
		align-items: center;
		gap: 0.4rem;
	}

	.control-label {
		font-size: 0.65rem;
		color: var(--text-muted);
		text-transform: uppercase;
		letter-spacing: 0.05em;
		font-weight: 500;
		transition: color 0.25s;
		white-space: nowrap;
	}

	.control-select {
		padding: 0.3rem 0.4rem;
		font-size: 0.75rem;
		font-family: var(--font-sans);
		color: var(--input-text);
		background: var(--input-bg);
		border: 1px solid var(--input-border);
		border-radius: 4px;
		outline: none;
		cursor: pointer;
		transition: border-color 0.15s, background 0.25s, color 0.25s;
	}

	.control-select:focus {
		border-color: var(--border-focus);
	}
</style>
