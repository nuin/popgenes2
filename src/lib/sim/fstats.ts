import { randomBinomial } from 'd3';
import type { SimPoint, SimResult } from './types';

export interface FStatsParams {
	populations: number;
	populationSize: number;
	initialFreq: number;
	generations: number;
	migrationRate: number;
	inbreedingCoeff: number;
	plotLines: number;
}

export const FSTATS_DEFAULTS: FStatsParams = {
	populations: 20,
	populationSize: 50,
	initialFreq: 0.5,
	generations: 100,
	migrationRate: 0.01,
	inbreedingCoeff: 0.0,
	plotLines: 8
};

export interface FStatsResult {
	driftLines: SimResult;
	fis: SimPoint[];
	fst: SimPoint[];
	fit: SimPoint[];
}

/**
 * Simulate multiple populations drifting with migration,
 * computing Wright's F-statistics at each generation.
 *
 * From VB.NET FStats.vb:
 *   - Each population drifts independently via Wright-Fisher sampling
 *   - Migration: p_new = p*(1-m) + p_bar*m
 *   - Hi = avg observed heterozygosity (with inbreeding)
 *   - Hs = avg expected heterozygosity within subpops
 *   - Ht = expected heterozygosity from total allele freq
 *   - Fis = (Hs - Hi) / Hs
 *   - Fst = (Ht - Hs) / Ht
 *   - Fit = (Ht - Hi) / Ht
 */
export function simulateFStats(params: FStatsParams): FStatsResult {
	const {
		populations, populationSize, initialFreq,
		generations, migrationRate: m, inbreedingCoeff: f, plotLines
	} = params;

	const numAlleles = 2 * populationSize;

	// Track allele frequencies for all populations across generations
	const freqs: number[][] = [];
	for (let j = 0; j < populations; j++) {
		freqs.push([initialFreq]);
	}

	const fisLine: SimPoint[] = [{ generation: 0, frequency: 0 }];
	const fstLine: SimPoint[] = [{ generation: 0, frequency: 0 }];
	const fitLine: SimPoint[] = [{ generation: 0, frequency: 0 }];

	for (let g = 1; g <= generations; g++) {
		// 1. Drift each population
		const newFreqs: number[] = [];
		for (let j = 0; j < populations; j++) {
			const prevP = freqs[j][g - 1];
			let p = prevP;
			if (p > 0 && p < 1) {
				const draw = randomBinomial(numAlleles, p)();
				p = draw / numAlleles;
			}
			newFreqs.push(p);
		}

		// 2. Migration: p_new = p*(1-m) + p_bar*m
		const meanP = newFreqs.reduce((s, v) => s + v, 0) / populations;
		for (let j = 0; j < populations; j++) {
			newFreqs[j] = newFreqs[j] * (1 - m) + meanP * m;
			freqs[j].push(newFreqs[j]);
		}

		// 3. Compute heterozygosities
		let sumHi = 0;
		let sumHs = 0;
		let sumP = 0;

		for (let j = 0; j < populations; j++) {
			const pj = newFreqs[j];
			// Hi: observed heterozygosity with inbreeding
			const het = 2 * pj * (1 - pj) * (1 - f);
			sumHi += het;
			// Hs: expected heterozygosity within subpop
			sumHs += 2 * pj * (1 - pj);
			sumP += pj;
		}

		const Hi = sumHi / populations;
		const Hs = sumHs / populations;
		const pTotal = sumP / populations;
		const Ht = 2 * pTotal * (1 - pTotal);

		const fisVal = Hs > 0 ? (Hs - Hi) / Hs : 0;
		const fstVal = Ht > 0 ? (Ht - Hs) / Ht : 0;
		const fitVal = Ht > 0 ? (Ht - Hi) / Ht : 0;

		fisLine.push({ generation: g, frequency: fisVal });
		fstLine.push({ generation: g, frequency: fstVal });
		fitLine.push({ generation: g, frequency: fitVal });
	}

	// Select a subset of populations to plot
	const driftLines: SimResult = [];
	const step = Math.max(1, Math.floor(populations / plotLines));
	for (let j = 0; j < populations && driftLines.length < plotLines; j += step) {
		const line: SimPoint[] = [];
		for (let g = 0; g <= generations; g++) {
			line.push({ generation: g, frequency: freqs[j][g] });
		}
		driftLines.push(line);
	}

	return { driftLines, fis: fisLine, fst: fstLine, fit: fitLine };
}
