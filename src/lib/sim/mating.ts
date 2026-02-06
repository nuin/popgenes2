import type { GenotypePoint, ParabolaPoint } from '$lib/sim/definetti';
import type { SimPoint, SimResult } from '$lib/sim/types';

// ── Autosomal random mating ──────────────────────────────────────────

export interface AutosomalInput {
	nAA: number;
	nAa: number;
	naa: number;
}

export interface AutosomalResult {
	total: number;
	D: number;  // freq AA
	H: number;  // freq Aa
	R: number;  // freq aa
	p: number;  // allele freq A
	q: number;  // allele freq a
	observed: GenotypePoint;
	afterMating: GenotypePoint;
}

/**
 * Compute genotype frequencies from counts and show position
 * on the De Finetti triangle, both before and after one
 * generation of random mating (which restores HWE).
 */
export function computeAutosomal(input: AutosomalInput): AutosomalResult {
	const { nAA, nAa, naa } = input;
	const total = nAA + nAa + naa;

	const D = nAA / total;
	const H = nAa / total;
	const R = naa / total;
	const p = D + H / 2;
	const q = 1 - p;

	const observed: GenotypePoint = {
		p,
		het: H,
		hweHet: 2 * p * q
	};

	// After one generation of random mating → HWE
	const afterMating: GenotypePoint = {
		p,
		het: 2 * p * q,
		hweHet: 2 * p * q
	};

	return { total, D, H, R, p, q, observed, afterMating };
}

// ── X-linked locus convergence ───────────────────────────────────────

export interface XLinkedParams {
	pFemale: number;
	pMale: number;
	generations: number;
}

export const XLINKED_DEFAULTS: XLinkedParams = {
	pFemale: 0.7,
	pMale: 0.3,
	generations: 20
};

/**
 * Simulate X-linked allele frequency convergence.
 * Females: pf(t) = (pf(t-1) + pm(t-1)) / 2
 * Males:   pm(t) = pf(t-1)
 *
 * Returns two series: [female line, male line]
 */
export function simulateXLinked(params: XLinkedParams): SimResult {
	const { pFemale, pMale, generations } = params;

	const femaleLine: SimPoint[] = [];
	const maleLine: SimPoint[] = [];

	let pf = pFemale;
	let pm = pMale;

	femaleLine.push({ generation: 0, frequency: pf });
	maleLine.push({ generation: 0, frequency: pm });

	for (let t = 1; t <= generations; t++) {
		const newPf = (pf + pm) / 2;
		const newPm = pf;
		pf = newPf;
		pm = newPm;
		femaleLine.push({ generation: t, frequency: pf });
		maleLine.push({ generation: t, frequency: pm });
	}

	return [femaleLine, maleLine];
}
