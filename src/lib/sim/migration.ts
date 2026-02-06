import type { SimResult } from './types';

// ── Continent-Island model ───────────────────────────────────────────

export interface ContIslandParams {
	pContinent: number;
	pIsland: number;
	m: number;
	generations: number;
}

export const CONT_ISLAND_DEFAULTS: ContIslandParams = {
	pContinent: 0.8,
	pIsland: 0.2,
	m: 0.05,
	generations: 100
};

/**
 * Continent-Island migration model.
 * Continent frequency is constant; island converges toward it.
 *   p_island(t) = p_island(0) * (1-m)^t + p_continent * (1 - (1-m)^t)
 *
 * Returns [continent line, island line].
 */
export function simulateContIsland(params: ContIslandParams): SimResult {
	const { pContinent, pIsland, m, generations } = params;

	const contLine = [];
	const isleLine = [];

	for (let t = 0; t <= generations; t++) {
		contLine.push({ generation: t, frequency: pContinent });
		const pI = pIsland * (1 - m) ** t + pContinent * (1 - (1 - m) ** t);
		isleLine.push({ generation: t, frequency: pI });
	}

	return [contLine, isleLine];
}

// ── Island-Island model ──────────────────────────────────────────────

export interface IslandIslandParams {
	p1: number;
	p2: number;
	m1: number;
	m2: number;
	generations: number;
}

export const ISLAND_ISLAND_DEFAULTS: IslandIslandParams = {
	p1: 0.8,
	p2: 0.2,
	m1: 0.05,
	m2: 0.05,
	generations: 100
};

/**
 * Island-Island migration model.
 * Both populations converge toward a weighted equilibrium.
 *   p_bar = (p1*m2 + p2*m1) / (m1 + m2)
 *   p1(t) = p_bar + (1-m1)^t * (p1_0 - p_bar)
 *   p2(t) = p_bar + (1-m2)^t * (p2_0 - p_bar)
 *
 * Returns [island1 line, island2 line].
 */
export function simulateIslandIsland(params: IslandIslandParams): SimResult {
	const { p1, p2, m1, m2, generations } = params;

	const mSum = m1 + m2;
	const pBar = mSum > 0 ? (p1 * m2 + p2 * m1) / mSum : (p1 + p2) / 2;

	const line1 = [];
	const line2 = [];

	for (let t = 0; t <= generations; t++) {
		line1.push({ generation: t, frequency: pBar + (1 - m1) ** t * (p1 - pBar) });
		line2.push({ generation: t, frequency: pBar + (1 - m2) ** t * (p2 - pBar) });
	}

	return [line1, line2];
}
