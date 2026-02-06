import type { SimResult, SimPoint } from './types';

export interface HtimeParams {
	Ne: number;
	p: number;
	generations: number;
	nDrift: number; // number of stochastic overlay populations (0 = none)
}

export const HTIME_DEFAULTS: HtimeParams = {
	Ne: 50,
	p: 0.5,
	generations: 100,
	nDrift: 4
};

/**
 * Heterozygosity decline over time.
 *
 * Deterministic: H(t) = H(t-1) * (1 - 1/(2*Ne))
 * Stochastic: Wright-Fisher drift → H = 2p(1-p) at each generation
 *
 * Returns first line = deterministic, rest = stochastic drift curves.
 */
export function simulateHtime(params: HtimeParams): SimResult {
	const { Ne, p, generations, nDrift } = params;
	const lines: SimResult = [];

	// Deterministic curve
	const det: SimPoint[] = [];
	let H = 2 * p * (1 - p);
	const factor = 1 - 1 / (2 * Ne);

	for (let t = 0; t <= generations; t++) {
		det.push({ generation: t, frequency: H });
		H = H * factor;
	}
	lines.push(det);

	// Stochastic overlay curves
	for (let d = 0; d < nDrift; d++) {
		const line: SimPoint[] = [];
		let pDrift = p;

		for (let t = 0; t <= generations; t++) {
			const hDrift = 2 * pDrift * (1 - pDrift);
			line.push({ generation: t, frequency: hDrift });

			// Wright-Fisher drift for next generation
			let successes = 0;
			for (let k = 0; k < Ne; k++) {
				if (Math.random() < pDrift) successes++;
			}
			pDrift = successes / Ne;
		}
		lines.push(line);
	}

	return lines;
}
