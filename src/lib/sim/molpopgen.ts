/**
 * Molecular Population Genetics Calculator
 *
 * Computes standard summary statistics from sequence data parameters.
 * Replaces the VB.NET FASTA-based MolPopGen module with a parameter-based
 * calculator suitable for web use.
 */

export interface MolPopGenParams {
	n: number; // number of sequences sampled
	S: number; // number of segregating (polymorphic) sites
	L: number; // total alignment length (sites)
	kHat: number; // average number of pairwise differences
}

export const MOLPOPGEN_DEFAULTS: MolPopGenParams = {
	n: 10,
	S: 12,
	L: 500,
	kHat: 3.5
};

export interface MolPopGenResult {
	thetaW: number; // Watterson's theta
	pi: number; // nucleotide diversity (per site)
	piTotal: number; // total pairwise differences (kHat)
	thetaWPerSite: number; // theta_W per site
	tajimaD: number; // Tajima's D statistic
	a1: number; // harmonic number
	a2: number; // sum of 1/i^2
	segregatingSites: number;
	sampleSize: number;
	alignmentLength: number;
}

/**
 * Compute Watterson's theta, nucleotide diversity, and Tajima's D.
 *
 * θ_W = S / a₁  where a₁ = Σ(1/i) for i=1..n-1
 * π = k̂ (average pairwise differences)
 * D = (π - θ_W) / √(Var(π - θ_W))
 *
 * Tajima's D variance formula uses coefficients from Tajima (1989).
 */
export function computeMolPopGen(params: MolPopGenParams): MolPopGenResult {
	const { n, S, L, kHat } = params;

	// Harmonic numbers
	let a1 = 0;
	let a2 = 0;
	for (let i = 1; i < n; i++) {
		a1 += 1 / i;
		a2 += 1 / (i * i);
	}

	// Watterson's theta
	const thetaW = S / a1;
	const thetaWPerSite = thetaW / L;

	// Nucleotide diversity
	const piTotal = kHat;
	const pi = kHat / L;

	// Tajima's D coefficients (Tajima 1989)
	const b1 = (n + 1) / (3 * (n - 1));
	const b2 = (2 * (n * n + n + 3)) / (9 * n * (n - 1));
	const c1 = b1 - 1 / a1;
	const c2 = b2 - (n + 2) / (a1 * n) + a2 / (a1 * a1);
	const e1 = c1 / a1;
	const e2 = c2 / (a1 * a1 + a2);

	// Tajima's D
	let tajimaD = 0;
	const denominator = Math.sqrt(e1 * S + e2 * S * (S - 1));
	if (denominator > 0 && S > 0) {
		tajimaD = (kHat - S / a1) / denominator;
	}

	return {
		thetaW,
		pi,
		piTotal,
		thetaWPerSite,
		tajimaD,
		a1,
		a2,
		segregatingSites: S,
		sampleSize: n,
		alignmentLength: L
	};
}
