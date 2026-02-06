import type { HistogramBar } from '$lib/charts/histogramChart';

export interface MullerParams {
	N: number; // haploid population size
	loci: number; // number of mutable sites per genome
	mu: number; // mutation rate per genome per generation
	s: number; // selection coefficient per deleterious mutation
	generations: number;
}

export const MULLER_DEFAULTS: MullerParams = {
	N: 50,
	loci: 20,
	mu: 0.1,
	s: 0.02,
	generations: 300
};

export interface MullerSnapshot {
	generation: number;
	bars: HistogramBar[];
}

export interface MullerResult {
	snapshots: MullerSnapshot[];
}

/**
 * Muller's Ratchet simulation.
 *
 * Haploid population with N individuals, each carrying a genome of `loci` sites.
 * Each generation:
 *   1. Add ~N*μ new deleterious mutations at random positions
 *   2. Compute fitness = (1-s)^k for each individual (k = mutation count)
 *   3. Reproduce: fitness-weighted sampling to form next generation
 *
 * Returns 4 histogram snapshots at generations 0, T/3, 2T/3, T-1.
 */
export function simulateMuller(params: MullerParams): MullerResult {
	const { N, loci, mu, s, generations } = params;

	// Each individual is an array of 0/1 (mutated or not) at each locus
	let pop: number[][] = [];
	for (let i = 0; i < N; i++) {
		pop.push(new Array(loci).fill(0));
	}

	// Snapshot time points
	const snapGens = [
		0,
		Math.round(generations / 3),
		Math.round((2 * generations) / 3),
		generations - 1
	];
	const snapshots: MullerSnapshot[] = [];

	// Record generation 0
	snapshots.push(buildSnapshot(pop, 0));

	for (let g = 1; g < generations; g++) {
		// 1. Mutation: add ~N*mu new mutations
		const expectedMuts = N * mu;
		let numMuts: number;
		if (expectedMuts >= 1) {
			numMuts = Math.round(expectedMuts);
		} else {
			numMuts = Math.random() < expectedMuts ? 1 : 0;
		}

		for (let m = 0; m < numMuts; m++) {
			const ind = Math.floor(Math.random() * N);
			const loc = Math.floor(Math.random() * loci);
			pop[ind][loc] = 1; // mutation (even if already mutated)
		}

		// 2. Compute fitness for each individual
		const fitness: number[] = [];
		for (let i = 0; i < N; i++) {
			const k = pop[i].reduce((sum, v) => sum + v, 0);
			fitness[i] = Math.pow(1 - s, k);
		}

		// 3. Reproduce: fitness-weighted sampling
		const totalFitness = fitness.reduce((a, b) => a + b, 0);
		if (totalFitness <= 0) break; // population collapsed

		const cumFitness: number[] = [];
		let cum = 0;
		for (let i = 0; i < N; i++) {
			cum += fitness[i] / totalFitness;
			cumFitness[i] = cum;
		}

		const newPop: number[][] = [];
		for (let i = 0; i < N; i++) {
			const r = Math.random();
			let parent = 0;
			for (let j = 0; j < N; j++) {
				if (r <= cumFitness[j]) {
					parent = j;
					break;
				}
			}
			newPop.push([...pop[parent]]);
		}
		pop = newPop;

		// Record snapshots
		if (snapGens.includes(g)) {
			snapshots.push(buildSnapshot(pop, g));
		}
	}

	// Ensure we have 4 snapshots (fill if simulation ended early)
	while (snapshots.length < 4) {
		snapshots.push(buildSnapshot(pop, generations - 1));
	}

	return { snapshots: snapshots.slice(0, 4) };
}

function buildSnapshot(pop: number[][], generation: number): MullerSnapshot {
	const N = pop.length;
	const counts: Map<number, number> = new Map();

	for (let i = 0; i < N; i++) {
		const k = pop[i].reduce((sum, v) => sum + v, 0);
		counts.set(k, (counts.get(k) ?? 0) + 1);
	}

	const maxK = Math.max(...counts.keys(), 0);
	const bars: HistogramBar[] = [];
	for (let k = 0; k <= maxK; k++) {
		bars.push({
			label: k.toString(),
			value: counts.get(k) ?? 0
		});
	}

	return { generation, bars };
}
