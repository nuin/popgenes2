import { writable } from 'svelte/store';
import { browser } from '$app/environment';

export type Theme = 'dark' | 'light';

const initial: Theme = 'dark';

export const theme = writable<Theme>(initial);

export function toggleTheme() {
	theme.update((t) => {
		const next = t === 'dark' ? 'light' : 'dark';
		if (browser) {
			document.body.setAttribute('data-theme', next);
		}
		return next;
	});
}
