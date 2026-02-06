import { randomBinomial } from 'd3';
import type { SimResult } from './types';

export interface DriftParams {
	populations: number;
	populationSize: number;
	initialFreq: number;
	generations: number;
	/** Fitness of AA genotype (optional — enables selection) */
	wAA?: number;
	/** Fitness of Aa genotype */
	wAa?: number;
	/** Fitness of aa genotype */
	waa?: number;
	/** Forward mutation rate A→a (optional — enables mutation) */
	mu?: number;
	/** Back mutation rate a→A */
	nu?: number;
}

export const DRIFT_DEFAULTS: DriftParams = {
	populations: 10,
	populationSize: 20,
	initialFreq: 0.5,
	generations: 100
};

/**
 * Apply deterministic selection to shift allele frequency.
 * Standard selection equation:
 *   p' = (p² wAA + p(1-p) wAa) / (p² wAA + 2p(1-p) wAa + (1-p)² waa)
 */
function applySelection(p: number, wAA: number, wAa: number, waa: number): number {
	const q = 1 - p;
	const meanFitness = p * p * wAA + 2 * p * q * wAa + q * q * waa;
	if (meanFitness === 0) return p;
	return (p * p * wAA + p * q * wAa) / meanFitness;
}

/**
 * Apply mutation: p' = p(1 - mu) + (1 - p) * nu
 */
function applyMutation(p: number, mu: number, nu: number): number {
	return p * (1 - mu) + (1 - p) * nu;
}

export function simulateDrift(params: DriftParams): SimResult {
	const {
		populations, populationSize, initialFreq, generations,
		wAA, wAa, waa, mu, nu
	} = params;

	const results: SimResult = [];
	const numAlleles = 2 * populationSize;

	const hasSelection = wAA !== undefined && wAa !== undefined && waa !== undefined;
	const hasMutation = mu !== undefined && nu !== undefined;

	for (let i = 0; i < populations; i++) {
		const trajectory = [{ generation: 0, frequency: initialFreq }];
		let freq = initialFreq;

		for (let g = 1; g <= generations; g++) {
			if (freq > 0 && freq < 1) {
				let p = freq;

				// Selection: deterministic shift before drift sampling
				if (hasSelection) {
					p = applySelection(p, wAA!, wAa!, waa!);
				}

				// Drift: binomial sampling
				const draw = randomBinomial(numAlleles, p)();
				p = draw / numAlleles;

				// Mutation: applied after drift
				if (hasMutation) {
					p = applyMutation(p, mu!, nu!);
				}

				freq = p;
			}
			trajectory.push({ generation: g, frequency: freq });
		}

		results.push(trajectory);
	}

	return results;
}
