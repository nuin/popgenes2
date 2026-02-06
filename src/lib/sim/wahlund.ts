export interface WahlundParams {
	pops: number[];  // allele frequencies for each subpopulation
	f: number;       // inbreeding coefficient
}

export const WAHLUND_DEFAULTS: WahlundParams = {
	pops: [0.1, 0.3, 0.5, 0.7, 0.9],
	f: 0.0
};

export interface PopGenotypes {
	label: string;
	p: number;
	freqAA: number;
	freqAa: number;
	freqaa: number;
}

export interface WahlundResult {
	subpops: PopGenotypes[];
	avgP: number;
	varP: number;
	expectedAA: number;
	expectedAa: number;
	expectedaa: number;
	observedAA: number;
	observedAa: number;
	observedaa: number;
	Fis: number;
	Fst: number;
	Fit: number;
}

/**
 * Compute the Wahlund effect: deficit of heterozygotes when
 * subpopulations with different allele frequencies are pooled.
 *
 * With inbreeding coefficient f:
 *   freq(AA) = p²(1-f) + pf
 *   freq(Aa) = 2p(1-p)(1-f)
 *   freq(aa) = (1-p)²(1-f) + (1-p)f
 *
 * Fst = Var(p) / (p_bar * (1 - p_bar))
 * Fit = 1 - (1 - Fst)(1 - Fis)
 */
export function computeWahlund(params: WahlundParams): WahlundResult {
	const { pops, f } = params;
	const n = pops.length;

	const subpops: PopGenotypes[] = pops.map((p, i) => {
		const q = 1 - p;
		return {
			label: `Pop ${i + 1}`,
			p,
			freqAA: p * p * (1 - f) + p * f,
			freqAa: 2 * p * q * (1 - f),
			freqaa: q * q * (1 - f) + q * f
		};
	});

	const avgP = pops.reduce((s, v) => s + v, 0) / n;
	const varP = pops.reduce((s, v) => s + (v - avgP) ** 2, 0) / n;

	// Expected under HWE from pooled p_bar
	const expectedAA = avgP * avgP;
	const expectedAa = 2 * avgP * (1 - avgP);
	const expectedaa = (1 - avgP) * (1 - avgP);

	// Observed = average of subpop genotype frequencies
	const observedAA = subpops.reduce((s, v) => s + v.freqAA, 0) / n;
	const observedAa = subpops.reduce((s, v) => s + v.freqAa, 0) / n;
	const observedaa = subpops.reduce((s, v) => s + v.freqaa, 0) / n;

	const Fis = f;
	const denom = avgP * (1 - avgP);
	const Fst = denom > 0 ? varP / denom : 0;
	const Fit = 1 - (1 - Fst) * (1 - Fis);

	return {
		subpops,
		avgP,
		varP,
		expectedAA,
		expectedAa,
		expectedaa,
		observedAA,
		observedAa,
		observedaa,
		Fis,
		Fst,
		Fit
	};
}
