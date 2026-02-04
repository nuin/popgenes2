import type { SimResult } from './types';

export interface SelectionParams {
	wAA: number;
	wAa: number;
	waa: number;
	initialFreq: number;
	generations: number;
}

export const SELECTION_DEFAULTS: SelectionParams = {
	wAA: 1.0,
	wAa: 1.0,
	waa: 0.8,
	initialFreq: 0.01,
	generations: 200
};

export function simulateSelection(params: SelectionParams): SimResult {
	const { wAA, wAa, waa, initialFreq, generations } = params;
	const trajectory = [{ generation: 0, frequency: initialFreq }];
	let p = initialFreq;

	for (let g = 1; g <= generations; g++) {
		const q = 1 - p;
		const wBar = p * p * wAA + 2 * p * q * wAa + q * q * waa;

		if (wBar > 0) {
			p = (p * p * wAA + p * q * wAa) / wBar;
		}

		p = Math.max(0, Math.min(1, p));
		trajectory.push({ generation: g, frequency: p });

		if (p <= 0 || p >= 1) {
			for (let rest = g + 1; rest <= generations; rest++) {
				trajectory.push({ generation: rest, frequency: p });
			}
			break;
		}
	}

	// Compute equilibrium frequency if it exists (heterozygote case)
	const result: SimResult = [trajectory];

	// Add equilibrium line when overdominance or underdominance exists
	if (wAa !== wAA || wAa !== waa) {
		const pHat = (wAa - waa) / (2 * wAa - wAA - waa);
		if (pHat > 0 && pHat < 1) {
			const eqLine = [
				{ generation: 0, frequency: pHat },
				{ generation: generations, frequency: pHat }
			];
			result.push(eqLine);
		}
	}

	return result;
}
