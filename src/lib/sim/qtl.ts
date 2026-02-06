import type { SimResult, SimPoint } from './types';

export interface QTLParams {
	N: number; // diploid population size
	nQTL: number; // number of QTL loci
	generations: number;
	p: number; // initial allele frequency at each locus
	Ve: number; // environmental variance
	maxGenValue: number; // max genotypic value (all loci homozygous +)
	selStrength: number; // selection strength (0 = neutral, higher = stronger)
}

export const QTL_DEFAULTS: QTLParams = {
	N: 100,
	nQTL: 10,
	generations: 50,
	p: 0.5,
	Ve: 1.0,
	maxGenValue: 10.0,
	selStrength: 0.1
};

export interface QTLResult {
	alleleFreqs: SimResult; // one line per QTL locus
	means: SimResult; // [phenotypic mean, genotypic mean]
	variances: SimResult; // [VP, VG]
	heritability: SimResult; // [h² = VG/VP]
}

/**
 * QTL simulation with additive diploid model.
 *
 * N diploid individuals, each with nQTL loci.
 * Genotype at each locus: 0, 1, or 2 copies of the + allele.
 * Allelic effect α = maxGenValue / (2 * nQTL).
 * Genotypic value G = Σ(allele_count_i * α).
 * Phenotypic value P = G + ε, where ε ~ N(0, Ve).
 * Selection: fitness proportional to phenotype (shifted to be positive).
 * Reproduction: fitness-weighted random mating, Mendelian segregation.
 */
export function simulateQTL(params: QTLParams): QTLResult {
	const { N, nQTL, generations, p, Ve, maxGenValue, selStrength } = params;

	const alpha = maxGenValue / (2 * nQTL);

	// Initialize population: genotype[individual][locus] = 0, 1, or 2
	let pop: number[][] = [];
	for (let i = 0; i < N; i++) {
		const ind: number[] = [];
		for (let j = 0; j < nQTL; j++) {
			let count = 0;
			if (Math.random() < p) count++;
			if (Math.random() < p) count++;
			ind.push(count);
		}
		pop.push(ind);
	}

	// Storage for results
	const alleleFreqLines: SimPoint[][] = Array.from({ length: nQTL }, () => []);
	const pMeanLine: SimPoint[] = [];
	const gMeanLine: SimPoint[] = [];
	const vpLine: SimPoint[] = [];
	const vgLine: SimPoint[] = [];
	const h2Line: SimPoint[] = [];

	for (let g = 0; g <= generations; g++) {
		// Compute genotypic values
		const gValues: number[] = pop.map((ind) =>
			ind.reduce((sum, count) => sum + count * alpha, 0)
		);

		// Compute phenotypic values
		const pValues: number[] = gValues.map((gv) => gv + normalRandom(0, Math.sqrt(Ve)));

		// Record allele frequencies at each locus
		for (let locus = 0; locus < nQTL; locus++) {
			let totalAlleles = 0;
			for (let i = 0; i < N; i++) {
				totalAlleles += pop[i][locus];
			}
			const freq = totalAlleles / (2 * N);
			alleleFreqLines[locus].push({ generation: g, frequency: freq });
		}

		// Mean values
		const pMean = mean(pValues);
		const gMean = mean(gValues);
		pMeanLine.push({ generation: g, frequency: pMean });
		gMeanLine.push({ generation: g, frequency: gMean });

		// Variances
		const vp = variance(pValues);
		const vg = variance(gValues);
		vpLine.push({ generation: g, frequency: vp });
		vgLine.push({ generation: g, frequency: vg });

		// Heritability
		const h2 = vp > 0 ? vg / vp : 0;
		h2Line.push({ generation: g, frequency: Math.min(h2, 1) });

		// Stop if at last generation (no reproduction needed)
		if (g === generations) break;

		// Selection + Reproduction
		const fitness: number[] = [];
		if (selStrength > 0) {
			const pStd = Math.sqrt(vp) || 1;
			for (let i = 0; i < N; i++) {
				// Fitness proportional to phenotype, shifted to be positive
				const z = (pValues[i] - pMean) / pStd;
				fitness[i] = Math.max(0.01, 1 + selStrength * z);
			}
		} else {
			// Neutral: equal fitness
			for (let i = 0; i < N; i++) fitness[i] = 1;
		}

		// Build cumulative fitness for weighted sampling
		const totalFit = fitness.reduce((a, b) => a + b, 0);
		const cumFit: number[] = [];
		let cum = 0;
		for (let i = 0; i < N; i++) {
			cum += fitness[i] / totalFit;
			cumFit[i] = cum;
		}

		// Produce next generation through random mating
		const newPop: number[][] = [];
		for (let i = 0; i < N; i++) {
			const p1 = weightedSample(cumFit);
			const p2 = weightedSample(cumFit);

			const child: number[] = [];
			for (let locus = 0; locus < nQTL; locus++) {
				// Mendelian segregation: each parent donates one allele
				const allele1 = segregate(pop[p1][locus]);
				const allele2 = segregate(pop[p2][locus]);
				child.push(allele1 + allele2);
			}
			newPop.push(child);
		}
		pop = newPop;
	}

	return {
		alleleFreqs: alleleFreqLines,
		means: [pMeanLine, gMeanLine],
		variances: [vpLine, vgLine],
		heritability: [h2Line]
	};
}

/** Mendelian segregation: from genotype (0,1,2), donate 0 or 1 allele */
function segregate(genotype: number): number {
	if (genotype === 0) return 0;
	if (genotype === 2) return 1;
	// heterozygote: 50% chance
	return Math.random() < 0.5 ? 1 : 0;
}

/** Fitness-weighted sampling using cumulative distribution */
function weightedSample(cumFit: number[]): number {
	const r = Math.random();
	for (let i = 0; i < cumFit.length; i++) {
		if (r <= cumFit[i]) return i;
	}
	return cumFit.length - 1;
}

/** Box-Muller transform for normal random variate */
function normalRandom(mu: number, sigma: number): number {
	let u1 = Math.random();
	let u2 = Math.random();
	while (u1 === 0) u1 = Math.random();
	const z = Math.sqrt(-2 * Math.log(u1)) * Math.cos(2 * Math.PI * u2);
	return mu + sigma * z;
}

function mean(arr: number[]): number {
	return arr.reduce((a, b) => a + b, 0) / arr.length;
}

function variance(arr: number[]): number {
	const m = mean(arr);
	return arr.reduce((sum, v) => sum + (v - m) * (v - m), 0) / arr.length;
}
