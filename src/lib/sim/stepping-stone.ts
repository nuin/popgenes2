import type { SimResult } from './types';

export interface SteppingStoneParams {
	numPops: number; // number of populations in the linear chain
	m: number; // migration rate between adjacent populations
	initialFreqs: number[]; // initial frequency for each population
	generations: number;
}

export const STEPPING_STONE_DEFAULTS: SteppingStoneParams = {
	numPops: 5,
	m: 0.1,
	initialFreqs: [0.9, 0.7, 0.5, 0.3, 0.1], // gradient from left to right
	generations: 100
};

/**
 * 1D Stepping-Stone Model.
 *
 * Populations arranged in a line. Each population exchanges migrants
 * only with its immediate neighbors. Edge populations exchange with
 * one neighbor only.
 *
 * For each population i:
 *   p'[i] = (1 - m) * p[i] + (m/2) * p[i-1] + (m/2) * p[i+1]
 *
 * Edge populations:
 *   p'[0] = (1 - m/2) * p[0] + (m/2) * p[1]
 *   p'[n-1] = (m/2) * p[n-2] + (1 - m/2) * p[n-1]
 */
export function simulateSteppingStone(params: SteppingStoneParams): SimResult {
	const { numPops, m, initialFreqs, generations } = params;

	// Ensure we have enough initial frequencies
	const freqs = [...initialFreqs];
	while (freqs.length < numPops) {
		freqs.push(0.5);
	}

	// Initialize trajectories for each population
	const trajectories: { generation: number; frequency: number }[][] = [];
	for (let i = 0; i < numPops; i++) {
		trajectories.push([{ generation: 0, frequency: freqs[i] }]);
	}

	// Current frequencies
	let current = freqs.slice(0, numPops);

	for (let g = 1; g <= generations; g++) {
		const next: number[] = new Array(numPops);

		for (let i = 0; i < numPops; i++) {
			if (i === 0) {
				// Left edge: only one neighbor on right
				next[i] = (1 - m / 2) * current[i] + (m / 2) * current[i + 1];
			} else if (i === numPops - 1) {
				// Right edge: only one neighbor on left
				next[i] = (m / 2) * current[i - 1] + (1 - m / 2) * current[i];
			} else {
				// Interior: two neighbors
				next[i] =
					(1 - m) * current[i] + (m / 2) * current[i - 1] + (m / 2) * current[i + 1];
			}
			// Clamp to valid range
			next[i] = Math.max(0, Math.min(1, next[i]));
		}

		for (let i = 0; i < numPops; i++) {
			trajectories[i].push({ generation: g, frequency: next[i] });
		}

		current = next;
	}

	return trajectories;
}

/**
 * Generate gradient initial frequencies from left to right.
 */
export function generateGradient(numPops: number, pLeft: number, pRight: number): number[] {
	const freqs: number[] = [];
	for (let i = 0; i < numPops; i++) {
		const t = numPops > 1 ? i / (numPops - 1) : 0.5;
		freqs.push(pLeft * (1 - t) + pRight * t);
	}
	return freqs;
}

/**
 * Calculate equilibrium frequency (average) that system converges to.
 */
export function equilibriumFrequency(freqs: number[]): number {
	return freqs.reduce((sum, f) => sum + f, 0) / freqs.length;
}
