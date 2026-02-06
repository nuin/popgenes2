import type { GenotypePoint } from '$lib/sim/definetti';

/**
 * Comprehensive assortative mating simulation.
 *
 * The VB.NET code defines 14 different mating restriction patterns,
 * each with 2 variants: "forbidden" (matings don't occur) vs "sterile"
 * (matings occur but produce no viable offspring). This gives 28 total formulas.
 *
 * The 3×3 mating matrix has positions:
 *   [0] AA×AA  [1] AA×Aa  [2] AA×aa
 *   [3] Aa×AA  [4] Aa×Aa  [5] Aa×aa
 *   [6] aa×AA  [7] aa×Aa  [8] aa×aa
 *
 * Due to symmetry, we track 6 unique mating types:
 *   DD = AA×AA (position 0)
 *   DH = AA×Aa (positions 1,3)
 *   DR = AA×aa (positions 2,6)
 *   HH = Aa×Aa (position 4)
 *   HR = Aa×aa (positions 5,7)
 *   RR = aa×aa (position 8)
 */

// ══════════════════════════════════════════════════════════════════════════════
// TYPES
// ══════════════════════════════════════════════════════════════════════════════

export type MatingVariant = 'forbidden' | 'sterile';

/** 14 mating patterns from VB.NET, numbered 1-14 */
export type ModelNumber = 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 | 10 | 11 | 12 | 13 | 14;

/** Which of the 6 mating types are allowed */
export interface MatingPattern {
	DD: boolean; // AA × AA
	DH: boolean; // AA × Aa
	DR: boolean; // AA × aa
	HH: boolean; // Aa × Aa
	HR: boolean; // Aa × aa
	RR: boolean; // aa × aa
}

export interface AssortativeParams {
	D: number; // initial freq(AA)
	H: number; // initial freq(Aa)
	generations: number;
	model: ModelNumber;
	variant: MatingVariant;
}

export const ASSORTATIVE_DEFAULTS: AssortativeParams = {
	D: 0.04,
	H: 0.32,
	generations: 20,
	model: 1,
	variant: 'forbidden'
};

export interface AssortativeTrajectory {
	points: GenotypePoint[];
	genD: number[];
	genH: number[];
	genR: number[];
}

// ══════════════════════════════════════════════════════════════════════════════
// MODEL DEFINITIONS
// ══════════════════════════════════════════════════════════════════════════════

/**
 * The 14 mating patterns from VB.NET AssortM.vb modelAssign().
 * true = mating allowed, false = mating forbidden/sterile
 */
export const MODEL_PATTERNS: Record<ModelNumber, MatingPattern> = {
	// Model 1: Positive with dominance (phenotype-based)
	// Allowed: DD, DH, HH, RR (A- mates with A-, aa mates with aa)
	1: { DD: true, DH: true, DR: false, HH: true, HR: false, RR: true },

	// Model 2: Positive without dominance (genotype-based, selfing)
	// Allowed: DD, HH, RR (each genotype mates only with same)
	2: { DD: true, DH: false, DR: false, HH: true, HR: false, RR: true },

	// Model 3: Negative (disassortative)
	// Allowed: DH, DR, HR (opposite phenotypes mate)
	3: { DD: false, DH: true, DR: true, HH: false, HR: true, RR: false },

	// Model 4: AA×AA and aa×aa forbidden
	4: { DD: false, DH: true, DR: true, HH: true, HR: true, RR: false },

	// Model 5: AA×AA and Aa×Aa forbidden
	5: { DD: false, DH: true, DR: true, HH: false, HR: true, RR: true },

	// Model 6: AA×AA, AA×Aa, Aa×Aa forbidden
	6: { DD: false, DH: false, DR: true, HH: false, HR: true, RR: true },

	// Model 7: Aa×Aa forbidden only
	7: { DD: true, DH: true, DR: true, HH: false, HR: true, RR: true },

	// Model 8: AA×AA forbidden only
	8: { DD: false, DH: true, DR: true, HH: true, HR: true, RR: true },

	// Model 9: AA×Aa and Aa×aa forbidden
	9: { DD: true, DH: false, DR: true, HH: true, HR: false, RR: true },

	// Model 10: AA×AA, AA×Aa, Aa×aa, aa×aa forbidden
	10: { DD: false, DH: false, DR: true, HH: true, HR: false, RR: false },

	// Model 11: AA×aa and Aa×Aa forbidden
	11: { DD: true, DH: true, DR: false, HH: false, HR: true, RR: true },

	// Model 12: AA×AA, AA×Aa, Aa×Aa, aa×aa forbidden (= negative)
	12: { DD: false, DH: false, DR: true, HH: false, HR: true, RR: false },

	// Model 13: AA×AA, AA×aa, Aa×Aa, aa×aa forbidden
	13: { DD: false, DH: true, DR: false, HH: false, HR: true, RR: false },

	// Model 14: Aa×aa and aa×aa forbidden
	14: { DD: true, DH: true, DR: true, HH: true, HR: false, RR: false }
};

/** Human-readable description of each model */
export const MODEL_DESCRIPTIONS: Record<ModelNumber, string> = {
	1: 'Positive with dominance (A- × A-, aa × aa)',
	2: 'Positive without dominance (selfing)',
	3: 'Negative / disassortative (AA×AA, Aa×Aa, aa×aa forbidden)',
	4: 'AA×AA and aa×aa forbidden',
	5: 'AA×AA and Aa×Aa forbidden',
	6: 'AA×AA, AA×Aa, Aa×Aa forbidden',
	7: 'Aa×Aa forbidden only',
	8: 'AA×AA forbidden only',
	9: 'AA×Aa and Aa×aa forbidden',
	10: 'AA×AA, AA×Aa, Aa×aa, aa×aa forbidden',
	11: 'AA×aa and Aa×Aa forbidden',
	12: 'AA×AA, AA×Aa, Aa×Aa, aa×aa forbidden',
	13: 'AA×AA, AA×aa, Aa×Aa, aa×aa forbidden',
	14: 'Aa×aa and aa×aa forbidden'
};

// ══════════════════════════════════════════════════════════════════════════════
// PATTERN MATCHING
// ══════════════════════════════════════════════════════════════════════════════

/**
 * Given a mating pattern, find which model number it matches.
 * Returns null if no valid model matches.
 */
export function identifyModel(pattern: MatingPattern): ModelNumber | null {
	for (let m = 1; m <= 14; m++) {
		const mp = MODEL_PATTERNS[m as ModelNumber];
		if (
			mp.DD === pattern.DD &&
			mp.DH === pattern.DH &&
			mp.DR === pattern.DR &&
			mp.HH === pattern.HH &&
			mp.HR === pattern.HR &&
			mp.RR === pattern.RR
		) {
			return m as ModelNumber;
		}
	}
	return null;
}

/**
 * Convert a 9-element boolean array (3×3 matrix positions) to a MatingPattern.
 * Matrix positions:
 *   [0] AA×AA  [1] AA×Aa  [2] AA×aa
 *   [3] Aa×AA  [4] Aa×Aa  [5] Aa×aa
 *   [6] aa×AA  [7] aa×Aa  [8] aa×aa
 */
export function matrixToPattern(matrix: boolean[]): MatingPattern {
	return {
		DD: matrix[0],
		DH: matrix[1] || matrix[3],
		DR: matrix[2] || matrix[6],
		HH: matrix[4],
		HR: matrix[5] || matrix[7],
		RR: matrix[8]
	};
}

// ══════════════════════════════════════════════════════════════════════════════
// SIMULATION ENGINE
// ══════════════════════════════════════════════════════════════════════════════

/**
 * Main simulation function.
 * Dispatches to the appropriate formula based on model number and variant.
 */
export function simulateAssortative(params: AssortativeParams): AssortativeTrajectory {
	const { D, H, generations, model, variant } = params;

	// Select the appropriate formula function
	const formulaIndex = variant === 'forbidden' ? model * 2 - 1 : model * 2;
	const formula = FORMULAS[formulaIndex];

	if (!formula) {
		throw new Error(`Unknown model ${model} variant ${variant}`);
	}

	return runSimulation(D, H, generations, formula);
}

/**
 * Run the simulation with a given formula function.
 */
function runSimulation(
	D0: number,
	H0: number,
	generations: number,
	formula: (d: number, h: number) => [number, number]
): AssortativeTrajectory {
	let d = D0;
	let h = H0;

	const genD: number[] = [d];
	const genH: number[] = [h];
	const genR: number[] = [1 - d - h];
	const points: GenotypePoint[] = [];

	// Record initial point
	const p0 = d + h / 2;
	points.push({ p: p0, het: h, hweHet: 2 * p0 * (1 - p0) });

	for (let t = 0; t < generations; t++) {
		const [dn, hn] = formula(d, h);

		d = Math.max(0, Math.min(1, dn));
		h = Math.max(0, Math.min(1, hn));

		// Ensure d + h <= 1
		if (d + h > 1) {
			const scale = 1 / (d + h);
			d *= scale;
			h *= scale;
		}

		genD.push(d);
		genH.push(h);
		genR.push(Math.max(0, 1 - d - h));

		const p = d + h / 2;
		points.push({ p, het: h, hweHet: 2 * p * (1 - p) });
	}

	return { points, genD, genH, genR };
}

// ══════════════════════════════════════════════════════════════════════════════
// ALL 28 FORMULAS FROM VB.NET assort.vb
// ══════════════════════════════════════════════════════════════════════════════

type Formula = (d: number, h: number) => [number, number];

/**
 * Formula index = model * 2 - 1 for forbidden, model * 2 for sterile
 * So formulas[1] = ass01 (model 1 forbidden), formulas[2] = ass02 (model 1 sterile), etc.
 */
const FORMULAS: Record<number, Formula> = {
	// ─────────────────────────────────────────────────────────────────────────
	// Model 1: Positive with dominance
	// ─────────────────────────────────────────────────────────────────────────

	// ass01: Positive with dominance, forbidden
	1: (d, h) => {
		if (d + h === 0) return [0, 0];
		const dn = ((2 * d + h) * (2 * d + h)) / (4 * (d + h));
		const hn = (h * (2 * d + h)) / (2 * (d + h));
		return [dn, hn];
	},

	// ass02: Positive with dominance, sterile (AA×aa, Aa×aa sterile)
	2: (d, h) => {
		const r = 1 - d - h;
		const denom = r * r + (d + h) * (d + h);
		if (denom === 0) return [0, 0];
		const dn = ((d + h / 2) * (d + h / 2)) / denom;
		const hn = ((d + h / 2) * h) / denom;
		return [dn, hn];
	},

	// ─────────────────────────────────────────────────────────────────────────
	// Model 2: Positive without dominance (selfing)
	// ─────────────────────────────────────────────────────────────────────────

	// ass03: Selfing, forbidden
	3: (d, h) => {
		const dn = d + h / 4;
		const hn = h / 2;
		return [dn, hn];
	},

	// ass04: Selfing, sterile
	4: (d, h) => {
		const dn = d + h / 4;
		const hn = h / 2;
		return [dn, hn];
	},

	// ─────────────────────────────────────────────────────────────────────────
	// Model 3: Negative (disassortative) - AA×AA, Aa×Aa, aa×aa forbidden
	// ─────────────────────────────────────────────────────────────────────────

	// ass05: Negative, forbidden
	5: (d, h) => {
		if (d === 0) return [0, 0.5];
		if (d + h === 1) return [0.5, 0.5];
		const dn = (d * h * (2 - d - h)) / (2 * (1 - d) * (1 - h));
		const hn = 0.5 + (d * (1 + h) * (1 - d - h)) / (2 * (1 - d) * (d + h));
		return [dn, hn];
	},

	// ass06: Negative, sterile
	6: (d, h) => {
		if (d === 0) return [0, 0.5];
		if (d + h === 1) return [0.5, 0.5];
		const denom = d * h + (d + h) * (1 - d - h);
		if (denom === 0) return [0, 0.5];
		const dn = (d * h) / (2 * denom);
		const hn = 0.5 + (d * (1 - d - h)) / (2 * denom);
		return [dn, hn];
	},

	// ─────────────────────────────────────────────────────────────────────────
	// Model 4: AA×AA and aa×aa forbidden
	// ─────────────────────────────────────────────────────────────────────────

	// ass07: forbidden
	7: (d, h) => {
		if (d <= 0 || h <= 0) return [d, h];
		const dn = (d * h * (2 - d)) / (2 * (1 - d)) + (h * h) / 4;
		const hn = 0.5 + (d * (1 + h) * (1 - d - h)) / (2 * (1 - d) * (d + h));
		return [dn, hn];
	},

	// ass08: sterile
	8: (d, h) => {
		const r = 1 - d - h;
		const denom = 1 - d * d - r * r;
		if (denom === 0) return [d, h];
		const dn = (4 * d * h + h * h) / (4 * denom);
		const hn = (2 * d * h + 4 * d * r + 2 * h * r + h * h) / (2 * denom);
		return [dn, hn];
	},

	// ─────────────────────────────────────────────────────────────────────────
	// Model 5: AA×AA and Aa×Aa forbidden
	// ─────────────────────────────────────────────────────────────────────────

	// ass09: forbidden
	9: (d, h) => {
		const r = 1 - d - h;
		if (d + h === 1) return [0.5, 0.5];
		const dn = (d * h * (2 - d - h)) / (2 * (1 - d - h + d * h));
		const hn = (1 - r * r) / 2 + (d * r * (2 - d)) / (2 * (1 - d));
		return [dn, hn];
	},

	// ass10: sterile
	10: (d, h) => {
		const r = 1 - d - h;
		if (d + h === 1) return [0.5, 0.5];
		const dn = (d * h * (2 - d - h)) / (2 * (1 - d - h + d * h));
		const hn = (1 - r * r) / 2 + (d * r * (2 - d)) / (2 * (1 - d));
		return [dn, hn];
	},

	// ─────────────────────────────────────────────────────────────────────────
	// Model 6: AA×AA, AA×Aa, Aa×Aa forbidden
	// ─────────────────────────────────────────────────────────────────────────

	// ass11: forbidden
	11: (d, h) => {
		const r = 1 - d - h;
		const dn = 0;
		const hn = (d + h / 2) * (2 - d - h);
		return [dn, hn];
	},

	// ass12: sterile
	12: (d, h) => {
		const dn = 0;
		const hn = (2 * d + h) / (1 + d + h);
		return [dn, hn];
	},

	// ─────────────────────────────────────────────────────────────────────────
	// Model 7: Aa×Aa forbidden only
	// ─────────────────────────────────────────────────────────────────────────

	// ass13: forbidden
	13: (d, h) => {
		const r = 1 - d - h;
		if (h === 1) return [0, 0];
		const dn = d * (d + h / 2 + h / (2 * (1 - h)));
		const hn = h + 2 * d * r - (h * h) / 2;
		return [dn, hn];
	},

	// ass14: sterile
	14: (d, h) => {
		const r = 1 - d - h;
		const denom = 1 - h * h;
		if (denom === 0) return [0, 0];
		const dn = (d * (d + h)) / denom;
		const hn = (d * h + (2 * d + h) * r) / denom;
		return [dn, hn];
	},

	// ─────────────────────────────────────────────────────────────────────────
	// Model 8: AA×AA forbidden only
	// ─────────────────────────────────────────────────────────────────────────

	// ass15: forbidden
	15: (d, h) => {
		const r = 1 - d - h;
		if (d === 1) return [0, 0];
		const dn = (h * (d / (1 - d) + d + h / 2)) / 2;
		const hn = (1 - r * r) / 2 + (d * (2 - d) * r) / (2 * (1 - d));
		return [dn, hn];
	},

	// ass16: sterile
	16: (d, h) => {
		const r = 1 - d - h;
		const denom = 1 - d * d;
		if (denom === 0) return [0, 0];
		const dn = (h * (4 * d + h)) / (4 * denom);
		const hn = ((2 * d + h) * (h + 2 * r)) / (2 * denom);
		return [dn, hn];
	},

	// ─────────────────────────────────────────────────────────────────────────
	// Model 9: AA×Aa and Aa×aa forbidden
	// ─────────────────────────────────────────────────────────────────────────

	// ass17: forbidden
	17: (d, h) => {
		const r = 1 - d - h;
		if (h === 1) return [0, 0];
		const dn = (d * d) / (1 - h) + h / 4;
		const hn = (2 * d * r) / (1 - h) + h / 2;
		return [dn, hn];
	},

	// ass18: sterile
	18: (d, h) => {
		const r = 1 - d - h;
		if (d > 0.9999999) return [1, 0];
		if (d + h < 0.00000001) return [0, 0];
		const denom = 1 - 2 * h * (1 - h);
		if (denom === 0) return [d, h];
		const dn = (4 * d * d + h * h) / (4 * denom);
		const hn = (4 * d * r + h * h) / (2 * denom);
		return [dn, hn];
	},

	// ─────────────────────────────────────────────────────────────────────────
	// Model 10: AA×AA, AA×Aa, Aa×aa, aa×aa forbidden
	// ─────────────────────────────────────────────────────────────────────────

	// ass19: forbidden
	19: (d, h) => {
		const dn = h / 4;
		const hn = 1 - h / 2;
		return [dn, hn];
	},

	// ass20: sterile
	20: (d, h) => {
		const r = 1 - d - h;
		const denom = h * h + 2 * d * r;
		if (denom === 0) return [0, 0];
		const dn = ((h * h) / 4) / denom;
		const hn = ((h * h) / 2 + 2 * d * r) / denom;
		return [dn, hn];
	},

	// ─────────────────────────────────────────────────────────────────────────
	// Model 11: AA×aa and Aa×Aa forbidden
	// ─────────────────────────────────────────────────────────────────────────

	// ass21: forbidden
	21: (d, h) => {
		const r = 1 - d - h;
		if (d + h === 0) return [0, 0];
		if (h === 1) return [0, 0];
		const dn = (d * (2 * d + h)) / (2 * (d + h)) + (d * h) / (2 * (1 - h));
		const hn = (h * (2 + d / (d + h) - h / (1 - d))) / 2;
		return [dn, hn];
	},

	// ass22: sterile
	22: (d, h) => {
		const r = 1 - d - h;
		const denom = 1 - 2 * d * r - h * h;
		if (denom === 0) return [d, h];
		const dn = (d * (1 - r)) / denom;
		const hn = (h * (1 - h)) / denom;
		return [dn, hn];
	},

	// ─────────────────────────────────────────────────────────────────────────
	// Model 12: AA×AA, AA×Aa, Aa×Aa, aa×aa forbidden (= negative alternative)
	// ─────────────────────────────────────────────────────────────────────────

	// ass23: forbidden
	23: (d, h) => {
		if (d + h === 0) return [0, 0];
		const dn = 0;
		const hn = (d + h / 2) / (d + h);
		return [dn, hn];
	},

	// ass24: sterile
	24: (d, h) => {
		if (d + h === 0) return [0, 0];
		const dn = 0;
		const hn = (d + h / 2) / (d + h);
		return [dn, hn];
	},

	// ─────────────────────────────────────────────────────────────────────────
	// Model 13: AA×AA, AA×aa, Aa×Aa, aa×aa forbidden
	// ─────────────────────────────────────────────────────────────────────────

	// ass25: forbidden
	25: (d, h) => {
		if (h === 1) return [0, 0];
		const dn = d / (2 * (1 - h));
		const hn = 0.5;
		return [dn, hn];
	},

	// ass26: sterile
	26: (d, h) => {
		if (h === 1) return [0, 0];
		const dn = d / (2 * (1 - h));
		const hn = 0.5;
		return [dn, hn];
	},

	// ─────────────────────────────────────────────────────────────────────────
	// Model 14: Aa×aa and aa×aa forbidden
	// ─────────────────────────────────────────────────────────────────────────

	// ass27: forbidden
	27: (d, h) => {
		const r = 1 - d - h;
		if (d + h === 0) return [0, 0];
		const p = d + h / 2;
		const dn = (d + h / (2 * (d + h))) * p;
		const hn = (1 + d) * (1 - p);
		return [dn, hn];
	},

	// ass28: sterile
	28: (d, h) => {
		const r = 1 - d - h;
		if (d + h === 0) return [0, 0];
		const denom = (d + h) * (d + h) + 2 * d * r;
		if (denom === 0) return [0, 0];
		const p = d + h / 2;
		const dn = (p * p) / denom;
		const hn = (p * h + 2 * d * r) / denom;
		return [dn, hn];
	}
};

// ══════════════════════════════════════════════════════════════════════════════
// SIMPLIFIED INTERFACE FOR DE FINETTI PAGE
// ══════════════════════════════════════════════════════════════════════════════

export type SimpleAssortativeModel = 'positive-dominant' | 'positive-no-dominant' | 'negative';

export interface SimpleAssortativeParams {
	D: number;
	H: number;
	generations: number;
	model: SimpleAssortativeModel;
}

export const SIMPLE_ASSORTATIVE_DEFAULTS: SimpleAssortativeParams = {
	D: 0.04,
	H: 0.32,
	generations: 20,
	model: 'positive-dominant'
};

/**
 * Simplified simulation for the De Finetti page with just 3 classical models.
 */
export function simulateSimpleAssortative(params: SimpleAssortativeParams): AssortativeTrajectory {
	const modelMap: Record<SimpleAssortativeModel, ModelNumber> = {
		'positive-dominant': 1,
		'positive-no-dominant': 2,
		negative: 3
	};

	return simulateAssortative({
		D: params.D,
		H: params.H,
		generations: params.generations,
		model: modelMap[params.model],
		variant: 'forbidden'
	});
}

// ══════════════════════════════════════════════════════════════════════════════
// MATRIX RESULT FOR DISPLAY
// ══════════════════════════════════════════════════════════════════════════════

export interface MatingCell {
	female: string; // genotype label
	male: string; // genotype label
	frequency: number;
	allowed: boolean;
}

export interface MatrixResult {
	cells: MatingCell[];
	nextD: number;
	nextH: number;
	nextR: number;
	p: number;
}

/**
 * Compute one generation step and return the mating matrix for display.
 */
export function computeMatingStep(
	D: number,
	H: number,
	model: ModelNumber,
	variant: MatingVariant
): MatrixResult {
	const R = Math.max(0, 1 - D - H);
	const p = D + H / 2;
	const pattern = MODEL_PATTERNS[model];

	const genotypes = ['AA', 'Aa', 'aa'];
	const freqs = [D, H, R];

	// Build 3×3 matrix
	const cells: MatingCell[] = [];
	const allowedMap = [
		[pattern.DD, pattern.DH, pattern.DR],
		[pattern.DH, pattern.HH, pattern.HR],
		[pattern.DR, pattern.HR, pattern.RR]
	];

	for (let i = 0; i < 3; i++) {
		for (let j = 0; j < 3; j++) {
			cells.push({
				female: genotypes[i],
				male: genotypes[j],
				frequency: freqs[i] * freqs[j],
				allowed: allowedMap[i][j]
			});
		}
	}

	// Compute next generation
	const formulaIndex = variant === 'forbidden' ? model * 2 - 1 : model * 2;
	const formula = FORMULAS[formulaIndex];
	const [nextD, nextH] = formula(D, H);

	return {
		cells,
		nextD: Math.max(0, nextD),
		nextH: Math.max(0, nextH),
		nextR: Math.max(0, 1 - nextD - nextH),
		p
	};
}
