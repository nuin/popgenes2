import type { HistogramBar } from '$lib/charts/histogramChart';

export interface MarkovParams {
	Ne: number;
	initialFreqIndex: number; // index into state space (0..2Ne)
	generations: number;
}

export const MARKOV_DEFAULTS: MarkovParams = {
	Ne: 10,
	initialFreqIndex: 10, // p = 0.5 for Ne=10 (state 10 out of 0..20)
	generations: 10
};

export interface MarkovResult {
	states: number;
	vector: number[];
	bars: HistogramBar[];
}

/**
 * Build the (2N+1) × (2N+1) Wright-Fisher transition matrix.
 *
 * State i means i copies of allele A out of 2N.
 * P(j | i) = C(2N, j) * p^j * (1-p)^(2N-j) where p = i/(2N).
 *
 * Uses binomial recursion for numerical stability.
 */
export function buildTransitionMatrix(Ne: number): number[][] {
	const states = 2 * Ne + 1;
	const matrix: number[][] = [];

	for (let i = 0; i < states; i++) {
		const row = new Array(states).fill(0);
		const p = i / (states - 1);
		const q = 1 - p;

		if (p === 0) {
			row[0] = 1;
		} else if (p === 1) {
			row[states - 1] = 1;
		} else {
			// First term: P(0|p) = q^(2N)
			row[0] = Math.pow(q, states - 1);
			// Binomial recursion: P(j|p) = P(j-1|p) * (2N-j+1)/j * p/q
			for (let j = 1; j < states; j++) {
				row[j] = row[j - 1] * ((states - j) / j) * (p / q);
			}
		}

		matrix.push(row);
	}

	return matrix;
}

/**
 * Multiply state vector by transition matrix for g generations.
 *
 * newVec[j] = Σ_i vec[i] * matrix[i][j]
 */
export function evolveMarkov(
	matrix: number[][],
	initialIndex: number,
	generations: number
): MarkovResult {
	const states = matrix.length;

	let vector = new Array(states).fill(0);
	vector[initialIndex] = 1;

	for (let g = 0; g < generations; g++) {
		const newVec = new Array(states).fill(0);
		for (let j = 0; j < states; j++) {
			for (let i = 0; i < states; i++) {
				newVec[j] += vector[i] * matrix[i][j];
			}
		}
		vector = newVec;
	}

	const bars: HistogramBar[] = vector.map((v, i) => ({
		label: i.toString(),
		value: v
	}));

	return { states, vector, bars };
}
