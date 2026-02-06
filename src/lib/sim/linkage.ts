import type { SimResult } from './types';
import type { HistogramBar } from '$lib/charts/histogramChart';

// ── Linkage disequilibrium calculation ───────────────────────────────

export interface LinkageInput {
	nAB: number;
	nAb: number;
	naB: number;
	nab: number;
}

export interface LinkageResult {
	total: number;
	/** Gamete frequencies (observed) */
	obsFreq: [number, number, number, number];
	/** Allele frequencies: pA, pa, pB, pb */
	pA: number;
	pa: number;
	pB: number;
	pb: number;
	/** Expected gamete frequencies under linkage equilibrium */
	expFreq: [number, number, number, number];
	/** Expected gamete counts */
	expCount: [number, number, number, number];
	/** Disequilibrium coefficient D = f(AB)*f(ab) - f(Ab)*f(aB) */
	D: number;
	/** Chi-square = N * D² / (pA * pa * pB * pb) */
	chi: number;
	/** Histogram bars: observed and expected */
	histoBars: { observed: HistogramBar[]; expected: HistogramBar[] };
}

/**
 * Compute linkage disequilibrium from gamete counts.
 *
 * Gamete types: AB, Ab, aB, ab
 * D = g1*g4 - g2*g3 (using frequencies)
 * Chi-square = N * D² / (pA * pa * pB * pb), df = 1
 */
export function computeLinkage(input: LinkageInput): LinkageResult {
	const { nAB, nAb, naB, nab } = input;
	const total = nAB + nAb + naB + nab;

	const g1 = nAB / total;
	const g2 = nAb / total;
	const g3 = naB / total;
	const g4 = nab / total;

	const pA = g1 + g2;
	const pa = g3 + g4;
	const pB = g1 + g3;
	const pb = g2 + g4;

	const D = g1 * g4 - g2 * g3;

	const expFreq: [number, number, number, number] = [pA * pB, pA * pb, pa * pB, pa * pb];
	const expCount: [number, number, number, number] = [
		pA * pB * total,
		pA * pb * total,
		pa * pB * total,
		pa * pb * total
	];

	const denom = pA * pa * pB * pb;
	const chi = denom > 0 ? (total * D * D) / denom : 0;

	const labels = ['AB', 'Ab', 'aB', 'ab'];
	const obsFreqArr: [number, number, number, number] = [g1, g2, g3, g4];

	const histoBars = {
		observed: labels.map((label, i) => ({ label, value: obsFreqArr[i] })),
		expected: labels.map((label, i) => ({ label, value: expFreq[i] }))
	};

	return {
		total,
		obsFreq: obsFreqArr,
		pA,
		pa,
		pB,
		pb,
		expFreq,
		expCount,
		D,
		chi,
		histoBars
	};
}

// ── Magnitude of D decay ─────────────────────────────────────────────

export interface MagDParams {
	r: number;       // recombination rate
	D0: number;      // initial D
	generations: number;
}

export const MAGD_DEFAULTS: MagDParams = {
	r: 0.1,
	D0: 0.15,
	generations: 100
};

/**
 * Compute D decay over generations.
 * D(t) = (1 - r)^t * D₀
 *
 * Returns single series of D values over time.
 */
export function simulateMagD(params: MagDParams): SimResult {
	const { r, D0, generations } = params;

	const line = [];
	let dt = D0;

	for (let t = 0; t <= generations; t++) {
		line.push({ generation: t, frequency: dt });
		dt = (1 - r) * dt;
	}

	return [line];
}
