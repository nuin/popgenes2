import type { CurveData } from '$lib/charts/curveChart';

export interface FreqDepParams {
	s1: number; // selection coeff for AA
	s2: number; // selection coeff for Aa
	s3: number; // selection coeff for aa
}

export const FREQDEP_DEFAULTS: FreqDepParams = {
	s1: 0.3,
	s2: 0.1,
	s3: 0.3
};

export interface FreqDepResult {
	deltaP: CurveData;
	wAA: CurveData;
	wAa: CurveData;
	waa: CurveData;
	wBar: CurveData;
}

const STEPS = 100;

/**
 * Frequency-dependent selection.
 *
 * Fitness values depend on current allele frequency:
 *   w_AA = 1 - s1 * p²
 *   w_Aa = 1 - s2 * 2p(1-p)
 *   w_aa = 1 - s3 * (1-p)²
 *
 * Mean fitness: wbar = w_AA * p² + w_Aa * 2p(1-p) + w_aa * (1-p)²
 * New p: p' = (p² * w_AA + p(1-p) * w_Aa) / wbar
 * Delta p: p' - p
 */
export function computeFreqDep(params: FreqDepParams): FreqDepResult {
	const { s1, s2, s3 } = params;

	const deltaPPoints = [];
	const wAAPoints = [];
	const wAaPoints = [];
	const waaPoints = [];
	const wBarPoints = [];

	for (let i = 0; i <= STEPS; i++) {
		const p = i / STEPS;
		const q = 1 - p;

		const wAA = 1 - s1 * p * p;
		const wAa = 1 - s2 * 2 * p * q;
		const waa = 1 - s3 * q * q;

		const wbar = wAA * p * p + wAa * 2 * p * q + waa * q * q;

		let dp = 0;
		if (wbar > 0 && p > 0 && p < 1) {
			const pPrime = (p * p * wAA + p * q * wAa) / wbar;
			dp = pPrime - p;
		}

		deltaPPoints.push({ x: p, y: dp });
		wAAPoints.push({ x: p, y: wAA });
		wAaPoints.push({ x: p, y: wAa });
		waaPoints.push({ x: p, y: waa });
		wBarPoints.push({ x: p, y: wbar });
	}

	return {
		deltaP: { points: deltaPPoints, label: 'Δp' },
		wAA: { points: wAAPoints, label: 'wAA' },
		wAa: { points: wAaPoints, label: 'wAa' },
		waa: { points: waaPoints, label: 'waa' },
		wBar: { points: wBarPoints, label: 'w̄' }
	};
}
