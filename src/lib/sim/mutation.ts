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
