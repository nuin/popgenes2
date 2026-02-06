import { randomBinomial } from 'd3';
import type { SimResult } from './types';

export interface NeutralParams {
	populationSize: number;
	generations: number;
	/** New mutation appears every `interval` generations */
	interval: number;
}

export const NEUTRAL_DEFAULTS: NeutralParams = {
	populationSize: 50,
	generations: 200,
	interval: 20
};

/**
 * Neutral mutations drifting in a finite population.
 * Every `interval` generations a new mutation appears at frequency 1/(2N).
 * Each mutation drifts independently via Wright-Fisher sampling.
 */
export function simulateNeutral(params: NeutralParams): SimResult {
	const { populationSize, generations, interval } = params;
	const results: SimResult = [];
	const numAlleles = 2 * populationSize;
	const initialFreq = 1 / numAlleles;

	const numMutations = Math.floor(generations / interval);

	for (let m = 0; m <= numMutations; m++) {
		const startGen = m * interval;
		const trajectory = [];

		// Pad with zero before the mutation appears
		for (let g = 0; g < startGen; g++) {
			trajectory.push({ generation: g, frequency: 0 });
		}

		let freq = initialFreq;
		trajectory.push({ generation: startGen, frequency: freq });

		for (let g = startGen + 1; g <= generations; g++) {
			if (freq > 0 && freq < 1) {
				const draw = randomBinomial(numAlleles, freq)();
				freq = draw / numAlleles;
			}
			trajectory.push({ generation: g, frequency: freq });
		}

		results.push(trajectory);
	}

	return results;
}
