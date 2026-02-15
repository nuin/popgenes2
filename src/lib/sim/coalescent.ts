/**
 * Coalescent Simulation Engine
 *
 * Simulates DNA sequences under coalescent models with different
 * demographic scenarios. Generates genealogies backwards in time,
 * adds mutations following the Jukes-Cantor model, and produces
 * sequences with computable summary statistics.
 */

export type DemographicModel = 'constant' | 'exponential' | 'bottleneck';

export interface CoalescentParams {
	n: number; // number of sequences (sample size)
	theta: number; // 4Nμ (mutation rate parameter)
	L: number; // sequence length
	model: DemographicModel; // demographic model
	growthRate?: number; // for exponential model (r > 0 = expansion, r < 0 = decline)
	bottleneckTime?: number; // time of bottleneck (in 2N generations)
	bottleneckSize?: number; // relative pop size during bottleneck (0-1)
}

export const COALESCENT_DEFAULTS: CoalescentParams = {
	n: 10,
	theta: 5,
	L: 500,
	model: 'constant',
	growthRate: 0.1,
	bottleneckTime: 0.5,
	bottleneckSize: 0.1
};

export interface CoalescentNode {
	id: number;
	time: number;
	children: number[];
	parent: number | null;
	branchLength: number; // time to parent
}

export interface Mutation {
	position: number; // site in sequence
	node: number; // node where mutation occurred
	time: number; // time of mutation
	ancestral: string;
	derived: string;
}

export interface CoalescentResult {
	sequences: string[];
	ancestralSequence: string;
	mutations: Mutation[];
	tree: CoalescentNode[];
	sfs: number[]; // Site Frequency Spectrum
	S: number; // segregating sites
	kHat: number; // average pairwise differences
	pi: number; // nucleotide diversity per site
	thetaW: number; // Watterson's theta
	tajimaD: number; // Tajima's D
	tmrca: number; // time to most recent common ancestor
	totalTreeLength: number;
}

const NUCLEOTIDES = ['A', 'C', 'G', 'T'];

/**
 * Generate random ancestral sequence.
 */
function generateAncestralSequence(L: number): string {
	const seq: string[] = [];
	for (let i = 0; i < L; i++) {
		seq.push(NUCLEOTIDES[Math.floor(Math.random() * 4)]);
	}
	return seq.join('');
}

/**
 * Get effective population size at time t for different demographic models.
 * Returns N(t)/N(0) ratio.
 */
function getPopSizeRatio(t: number, params: CoalescentParams): number {
	switch (params.model) {
		case 'exponential':
			// N(t) = N(0) * exp(-r * t) going backwards
			// Higher r = stronger growth = smaller ancestral pop
			return Math.exp(-(params.growthRate ?? 0.1) * t);

		case 'bottleneck':
			// Population was smaller before bottleneckTime
			const bTime = params.bottleneckTime ?? 0.5;
			const bSize = params.bottleneckSize ?? 0.1;
			if (t > bTime) {
				return bSize;
			}
			return 1;

		case 'constant':
		default:
			return 1;
	}
}

/**
 * Simulate coalescent genealogy with demographic model.
 * Time is scaled in units of 2N generations.
 */
function simulateGenealogy(n: number, params: CoalescentParams): CoalescentNode[] {
	const nodes: CoalescentNode[] = [];

	// Create leaf nodes (samples at time 0)
	for (let i = 0; i < n; i++) {
		nodes.push({
			id: i,
			time: 0,
			children: [],
			parent: null,
			branchLength: 0
		});
	}

	// Track active lineages
	let activeLineages = [...Array(n).keys()];
	let currentTime = 0;
	let nextId = n;

	// Coalesce until single ancestor
	while (activeLineages.length > 1) {
		const k = activeLineages.length;

		// Base coalescence rate
		const baseRate = (k * (k - 1)) / 2;

		// Adjust rate by population size (smaller pop = faster coalescence)
		const popRatio = getPopSizeRatio(currentTime, params);
		const adjustedRate = baseRate / popRatio;

		// Time to next coalescence ~ Exp(adjustedRate)
		const waitTime = -Math.log(Math.random()) / adjustedRate;
		currentTime += waitTime;

		// Pick two random lineages to coalesce
		const i1 = Math.floor(Math.random() * k);
		let i2 = Math.floor(Math.random() * (k - 1));
		if (i2 >= i1) i2++;

		const lineage1 = activeLineages[i1];
		const lineage2 = activeLineages[i2];

		// Create parent node
		const parent: CoalescentNode = {
			id: nextId,
			time: currentTime,
			children: [lineage1, lineage2],
			parent: null,
			branchLength: 0
		};

		// Update children's parent and branch lengths
		nodes[lineage1].parent = nextId;
		nodes[lineage1].branchLength = currentTime - nodes[lineage1].time;
		nodes[lineage2].parent = nextId;
		nodes[lineage2].branchLength = currentTime - nodes[lineage2].time;

		nodes.push(parent);

		// Update active lineages
		activeLineages = activeLineages.filter((_, idx) => idx !== i1 && idx !== i2);
		activeLineages.push(nextId);
		nextId++;
	}

	return nodes;
}

/**
 * Calculate total tree length (sum of all branch lengths).
 */
function totalTreeLength(nodes: CoalescentNode[]): number {
	return nodes.reduce((sum, node) => sum + node.branchLength, 0);
}

/**
 * Jukes-Cantor mutation: mutate to a DIFFERENT nucleotide.
 */
function mutate(base: string): string {
	const others = NUCLEOTIDES.filter((n) => n !== base);
	return others[Math.floor(Math.random() * 3)];
}

/**
 * Add mutations to genealogy using Poisson process with Jukes-Cantor model.
 * Number of mutations ~ Poisson(theta/2 * totalLength)
 */
function addMutations(
	nodes: CoalescentNode[],
	theta: number,
	L: number,
	ancestralSequence: string
): Mutation[] {
	const treeLength = totalTreeLength(nodes);
	const expectedMutations = (theta / 2) * treeLength;
	const numMutations = poissonRandom(expectedMutations);

	const mutations: Mutation[] = [];

	for (let i = 0; i < numMutations; i++) {
		// Pick random position on tree (proportional to branch length)
		let targetLength = Math.random() * treeLength;
		let accum = 0;
		let targetNode: CoalescentNode | null = null;
		let mutationTime = 0;

		for (const node of nodes) {
			if (node.branchLength > 0) {
				if (accum + node.branchLength > targetLength) {
					targetNode = node;
					// Time of mutation within this branch
					const fractionUp = (targetLength - accum) / node.branchLength;
					mutationTime = node.time + fractionUp * node.branchLength;
					break;
				}
				accum += node.branchLength;
			}
		}

		if (targetNode) {
			const position = Math.floor(Math.random() * L);
			const ancestral = ancestralSequence[position];
			const derived = mutate(ancestral);

			mutations.push({
				position,
				node: targetNode.id,
				time: mutationTime,
				ancestral,
				derived
			});
		}
	}

	return mutations;
}

/**
 * Generate Poisson random number using inverse transform.
 */
function poissonRandom(lambda: number): number {
	if (lambda <= 0) return 0;
	if (lambda > 500) {
		// For large lambda, use normal approximation
		const u1 = Math.random();
		const u2 = Math.random();
		const z = Math.sqrt(-2 * Math.log(u1)) * Math.cos(2 * Math.PI * u2);
		return Math.max(0, Math.round(lambda + Math.sqrt(lambda) * z));
	}
	const L = Math.exp(-lambda);
	let k = 0;
	let p = 1;
	do {
		k++;
		p *= Math.random();
	} while (p > L);
	return k - 1;
}

/**
 * Find all leaf descendants of a node.
 */
function findLeafDescendants(nodeId: number, nodes: CoalescentNode[], n: number): number[] {
	if (nodeId < n) {
		// This is a leaf
		return [nodeId];
	}

	const node = nodes[nodeId];
	const descendants: number[] = [];
	for (const childId of node.children) {
		descendants.push(...findLeafDescendants(childId, nodes, n));
	}
	return descendants;
}

/**
 * Generate sequences from genealogy and mutations.
 * Starts with ancestral sequence and applies mutations to descendants.
 */
function generateSequences(
	n: number,
	L: number,
	nodes: CoalescentNode[],
	mutations: Mutation[],
	ancestralSequence: string
): string[] {
	// Initialize all sequences with ancestral sequence
	const sequences: string[][] = Array.from({ length: n }, () => ancestralSequence.split(''));

	// Apply each mutation to descendants
	for (const mut of mutations) {
		const descendants = findLeafDescendants(mut.node, nodes, n);
		for (const leafId of descendants) {
			sequences[leafId][mut.position] = mut.derived;
		}
	}

	return sequences.map((seq) => seq.join(''));
}

/**
 * Compute Site Frequency Spectrum from sequences.
 * SFS[i] = number of sites where derived allele appears in exactly i sequences
 */
function computeSFS(sequences: string[], L: number): number[] {
	const n = sequences.length;
	const sfs: number[] = Array(n + 1).fill(0);

	for (let site = 0; site < L; site++) {
		// Count allele frequencies at this site
		const alleleCount: { [key: string]: number } = {};
		for (const seq of sequences) {
			const allele = seq[site];
			alleleCount[allele] = (alleleCount[allele] || 0) + 1;
		}

		// If polymorphic, add to SFS
		const alleles = Object.keys(alleleCount);
		if (alleles.length > 1) {
			// Use minor allele frequency for folded SFS
			const counts = Object.values(alleleCount);
			const minorCount = Math.min(...counts);
			sfs[minorCount]++;
		}
	}

	return sfs;
}

/**
 * Count segregating sites.
 */
function countSegregatingSites(sequences: string[], L: number): number {
	let S = 0;
	for (let site = 0; site < L; site++) {
		const alleles = new Set(sequences.map((seq) => seq[site]));
		if (alleles.size > 1) S++;
	}
	return S;
}

/**
 * Compute average pairwise differences (k̂).
 */
function computePairwiseDifferences(sequences: string[], L: number): number {
	const n = sequences.length;
	let totalDiffs = 0;
	let pairs = 0;

	for (let i = 0; i < n; i++) {
		for (let j = i + 1; j < n; j++) {
			let diffs = 0;
			for (let site = 0; site < L; site++) {
				if (sequences[i][site] !== sequences[j][site]) {
					diffs++;
				}
			}
			totalDiffs += diffs;
			pairs++;
		}
	}

	return pairs > 0 ? totalDiffs / pairs : 0;
}

/**
 * Compute Tajima's D from sequences.
 */
function computeTajimaD(n: number, S: number, kHat: number): number {
	if (S === 0) return 0;

	// Harmonic numbers
	let a1 = 0;
	let a2 = 0;
	for (let i = 1; i < n; i++) {
		a1 += 1 / i;
		a2 += 1 / (i * i);
	}

	// Tajima's D coefficients
	const b1 = (n + 1) / (3 * (n - 1));
	const b2 = (2 * (n * n + n + 3)) / (9 * n * (n - 1));
	const c1 = b1 - 1 / a1;
	const c2 = b2 - (n + 2) / (a1 * n) + a2 / (a1 * a1);
	const e1 = c1 / a1;
	const e2 = c2 / (a1 * a1 + a2);

	const denominator = Math.sqrt(e1 * S + e2 * S * (S - 1));
	if (denominator === 0) return 0;

	return (kHat - S / a1) / denominator;
}

/**
 * Main coalescent simulation function.
 */
export function simulateCoalescent(params: CoalescentParams): CoalescentResult {
	const { n, theta, L } = params;

	// Generate random ancestral sequence
	const ancestralSequence = generateAncestralSequence(L);

	// Generate genealogy with demographic model
	const tree = simulateGenealogy(n, params);

	// Find TMRCA (time of most recent common ancestor)
	const tmrca = Math.max(...tree.map((node) => node.time));

	// Total tree length
	const treeLengthTotal = totalTreeLength(tree);

	// Add mutations with Jukes-Cantor model
	const mutations = addMutations(tree, theta, L, ancestralSequence);

	// Generate sequences from ancestral + mutations
	const sequences = generateSequences(n, L, tree, mutations, ancestralSequence);

	// Compute statistics
	const sfs = computeSFS(sequences, L);
	const S = countSegregatingSites(sequences, L);
	const kHat = computePairwiseDifferences(sequences, L);
	const pi = kHat / L;

	// Watterson's theta
	let a1 = 0;
	for (let i = 1; i < n; i++) {
		a1 += 1 / i;
	}
	const thetaW = S / a1;

	// Tajima's D
	const tajimaD = computeTajimaD(n, S, kHat);

	return {
		sequences,
		ancestralSequence,
		mutations,
		tree,
		sfs,
		S,
		kHat,
		pi,
		thetaW,
		tajimaD,
		tmrca,
		totalTreeLength: treeLengthTotal
	};
}

/**
 * Generate expected SFS under neutral constant-size model.
 * E[SFS[i]] = theta / i for i = 1, ..., n-1
 */
export function expectedSFS(n: number, theta: number): number[] {
	const expected: number[] = Array(n + 1).fill(0);
	for (let i = 1; i < n; i++) {
		expected[i] = theta / i;
	}
	return expected;
}

/**
 * Get demographic model description.
 */
export function getModelDescription(params: CoalescentParams): string {
	switch (params.model) {
		case 'exponential':
			const r = params.growthRate ?? 0.1;
			return r > 0
				? `Exponential growth (r=${r.toFixed(2)})`
				: `Exponential decline (r=${r.toFixed(2)})`;
		case 'bottleneck':
			return `Bottleneck at t=${params.bottleneckTime} (size=${params.bottleneckSize})`;
		case 'constant':
		default:
			return 'Constant population size';
	}
}
