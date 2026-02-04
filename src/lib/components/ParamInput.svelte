<script lang="ts">
	let {
		label,
		value = $bindable(),
		step = 1,
		min,
		max
	}: {
		label: string;
		value: number;
		step?: number;
		min?: number;
		max?: number;
	} = $props();
</script>

<div class="control-item">
	<span class="control-label">{label}</span>
	<input
		type="number"
		class="control-input"
		bind:value
		{step}
		{min}
		{max}
	/>
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

	.control-input {
		width: 60px;
		padding: 0.3rem 0.4rem;
		font-size: 0.8rem;
		font-family: var(--font-mono);
		color: var(--input-text);
		background: var(--input-bg);
		border: 1px solid var(--input-border);
		border-radius: 4px;
		outline: none;
		text-align: center;
		transition: border-color 0.15s, background 0.25s, color 0.25s;
	}

	.control-input:focus {
		border-color: var(--border-focus);
	}
</style>
