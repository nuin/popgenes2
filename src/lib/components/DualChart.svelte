<script lang="ts">
	import type { Snippet } from 'svelte';

	let {
		left,
		right
	}: {
		left: Snippet;
		right: Snippet;
	} = $props();
</script>

<div class="dual">
	<div class="panel">
		{@render left()}
	</div>
	<div class="panel">
		{@render right()}
	</div>
</div>

<style>
	.dual {
		display: flex;
		gap: 0.75rem;
		width: 100%;
		height: 100%;
		min-height: 0;
	}

	.panel {
		flex: 1;
		min-width: 0;
		min-height: 0;
	}

	@media (max-width: 768px) {
		.dual {
			flex-direction: column;
		}
	}
</style>
