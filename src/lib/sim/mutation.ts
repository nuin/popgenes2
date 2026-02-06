import type { SimResult } from './types';

export interface MutationParams {
	mu: number;      // forward mutation rate (A -> a)
	nu: number;      // reverse mutation rate (a -> A)
	initialFreq: number;
	generations: number;
}

export const MUTATION_DEFAULTS: MutationParams = {
	mu: 0.001,
	nu: 0.0005,
	initialFreq: 0.5,
	generations: 5000
};

export interface IrreversibleMutationParams {
	mu: number;          // mutation rate A → a (one-way)
	initialFreq: number;
	generations: number;
}

export const IRREVERSIBLE_DEFAULTS: IrreversibleMutationParams = {
	mu: 0.001,
	initialFreq: 0.9,
	generations: 5000
};

/**
 * Irreversible mutation: p(t) = p(t-1) × (1 - μ)
 * Only A→a occurs; allele A decays exponentially.
 */
export function simulateIrreversibleMutation(params: IrreversibleMutationParams): SimResult {
	const { mu, initialFreq, generations } = params;
	const trajectory = [{ generation: 0, frequency: initialFreq }];
	let p = initialFreq;

	for (let g = 1; g <= generations; g++) {
		p = p * (1 - mu);
		trajectory.push({ generation: g, frequency: p });
	}

	return [trajectory];
}

export function simulateMutation(params: MutationParams): SimResult {
	const { mu, nu, initialFreq, generations } = params;
	const trajectory = [{ generation: 0, frequency: initialFreq }];
	let p = initialFreq;

	for (let g = 1; g <= generations; g++) {
		p = p * (1 - mu) + (1 - p) * nu;
		p = Math.max(0, Math.min(1, p));
		trajectory.push({ generation: g, frequency: p });
	}

	const result: SimResult = [trajectory];

	// Equilibrium line: p_hat = nu / (mu + nu)
	if (mu + nu > 0) {
		const pHat = nu / (mu + nu);
		result.push([
			{ generation: 0, frequency: pHat },
			{ generation: generations, frequency: pHat }
		]);
	}

	return result;
}
