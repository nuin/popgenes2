import type { SimResult } from './types';

export interface DominanceParams {
	s: number; // selection coefficient against aa
	h: number; // dominance coefficient (0=recessive, 0.5=additive, 1=dominant)
	initialFreq: number;
	generations: number;
}

export const DOMINANCE_DEFAULTS: DominanceParams = {
	s: 0.1,
	h: 0.5,
	initialFreq: 0.01,
	generations: 500
};

/**
 * Simulate selection with dominance coefficient model.
 *
 * Fitness values:
 *   wAA = 1
 *   wAa = 1 - hs
 *   waa = 1 - s
 *
 * h = 0: A dominant (deleterious a is recessive)
 * h = 0.5: Codominance / additive
 * h = 1: A recessive (deleterious a is dominant)
 */
export function simulateDominance(params: DominanceParams): SimResult {
	const { s, h, initialFreq, generations } = params;

	const wAA = 1;
	const wAa = 1 - h * s;
	const waa = 1 - s;

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

		if (p <= 1e-9 || p >= 1 - 1e-9) {
			for (let rest = g + 1; rest <= generations; rest++) {
				trajectory.push({ generation: rest, frequency: p < 0.5 ? 0 : 1 });
			}
			break;
		}
	}

	return [trajectory];
}

/**
 * Simulate multiple h values to compare dominance effects.
 */
export function simulateDominanceComparison(params: Omit<DominanceParams, 'h'>): SimResult {
	const hValues = [0, 0.25, 0.5, 0.75, 1.0];
	return hValues.map((h) => {
		const result = simulateDominance({ ...params, h });
		return result[0];
	});
}

/**
 * Calculate time to fixation or loss approximation.
 */
export function dominanceInfo(params: DominanceParams): {
	wAA: number;
	wAa: number;
	waa: number;
	dominanceType: string;
} {
	const { s, h } = params;
	const wAA = 1;
	const wAa = 1 - h * s;
	const waa = 1 - s;

	let dominanceType: string;
	if (h === 0) {
		dominanceType = 'Complete dominance (A dominant)';
	} else if (h === 1) {
		dominanceType = 'Complete dominance (a dominant)';
	} else if (h === 0.5) {
		dominanceType = 'Codominance / Additive';
	} else if (h < 0.5) {
		dominanceType = 'Partial dominance (A partially dominant)';
	} else {
		dominanceType = 'Partial dominance (a partially dominant)';
	}

	return { wAA, wAa, waa, dominanceType };
}
