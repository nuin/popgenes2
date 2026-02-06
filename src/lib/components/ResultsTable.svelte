<script lang="ts">
	let {
		headers,
		rows,
		caption = ''
	}: {
		headers: string[];
		rows: (string | number)[][];
		caption?: string;
	} = $props();
</script>

<div class="table-wrap">
	{#if caption}
		<div class="table-caption">{caption}</div>
	{/if}
	<table>
		<thead>
			<tr>
				{#each headers as h}
					<th>{h}</th>
				{/each}
			</tr>
		</thead>
		<tbody>
			{#each rows as row}
				<tr>
					{#each row as cell}
						<td>{typeof cell === 'number' ? cell.toFixed(6) : cell}</td>
					{/each}
				</tr>
			{/each}
		</tbody>
	</table>
</div>

<style>
	.table-wrap {
		width: 100%;
		height: 100%;
		overflow: auto;
		font-family: var(--font-mono);
		font-size: 0.8rem;
	}

	.table-caption {
		font-family: var(--font-sans);
		font-size: 0.75rem;
		font-weight: 500;
		color: var(--text-muted);
		text-transform: uppercase;
		letter-spacing: 0.05em;
		padding: 0.5rem 0;
	}

	table {
		width: 100%;
		border-collapse: collapse;
	}

	th {
		text-align: left;
		font-family: var(--font-sans);
		font-size: 0.65rem;
		font-weight: 600;
		color: var(--text-muted);
		text-transform: uppercase;
		letter-spacing: 0.05em;
		padding: 0.5rem 0.75rem;
		border-bottom: 1px solid var(--border);
		white-space: nowrap;
	}

	td {
		padding: 0.4rem 0.75rem;
		color: var(--text);
		border-bottom: 1px solid var(--border);
		transition: color 0.25s;
	}

	tr:hover td {
		background: var(--link-hover-bg);
	}
</style>
