export interface ParabolaPoint {
	p: number;   // frequency of A (x-axis)
	het: number; // heterozygote frequency P(Aa) (y-axis)
}

export interface GenotypePoint {
	p: number;      // allele frequency of A (x-axis)
	het: number;    // observed P(Aa) (y-axis)
	hweHet: number; // expected P(Aa) under HWE = 2p(1-p)
}

/** Triangle vertices: bottom-left (aa), bottom-right (AA), apex (Aa) */
export const TRIANGLE = {
	aa: { x: 0, y: 0 },
	AA: { x: 1, y: 0 },
	Aa: { x: 0.5, y: 1 }
} as const;

export function generateHWEParabola(steps = 1000): ParabolaPoint[] {
	const pts: ParabolaPoint[] = [];
	for (let i = 0; i <= steps; i++) {
		const p = i / steps;
		pts.push({ p, het: 2 * p * (1 - p) });
	}
	return pts;
}

export function genotypeToPoint(d: number, h: number): GenotypePoint {
	const p = d + h / 2;
	return { p, het: h, hweHet: 2 * p * (1 - p) };
}

export function validateGenotypes(d: number, h: number): string | null {
	if (d < 0 || d > 1) return 'P(AA) must be between 0 and 1';
	if (h < 0 || h > 1) return 'P(Aa) must be between 0 and 1';
	if (d + h > 1) return 'P(AA) + P(Aa) cannot exceed 1';
	return null;
}
