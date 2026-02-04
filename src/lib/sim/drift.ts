import { randomBinomial } from 'd3';
import type { SimResult } from './types';

export interface DriftParams {
	populations: number;
	populationSize: number;
	initialFreq: number;
	generations: number;
}

export const DRIFT_DEFAULTS: DriftParams = {
	populations: 10,
	populationSize: 20,
	initialFreq: 0.5,
	generations: 100
};

export function simulateDrift(params: DriftParams): SimResult {
	const { populations, populationSize, initialFreq, generations } = params;
	const results: SimResult = [];
	const numAlleles = 2 * populationSize;

	for (let i = 0; i < populations; i++) {
		const trajectory = [{ generation: 0, frequency: initialFreq }];
		let freq = initialFreq;

		for (let g = 1; g <= generations; g++) {
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
