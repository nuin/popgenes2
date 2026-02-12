import type { HelpContent } from './types';

export const selectionMutationContent: Record<string, HelpContent> = {
	'/selection': {
		title: 'Natural Selection',
		category: 'Selection',
		description:
			'Deterministic model of allele frequency change under natural selection. Three genotype fitness values (wAA, wAa, waa) determine how the frequency of allele A changes over generations. The model tracks the classic recursion where each generation\'s allele frequency is weighted by genotype fitnesses and normalized by mean population fitness.',
		formulas: [
			{
				label: 'Genotype frequencies after selection',
				html: '<var>p</var><sup>2</sup><var>w</var><sub>AA</sub>, 2<var>pq</var><var>w</var><sub>Aa</sub>, <var>q</var><sup>2</sup><var>w</var><sub>aa</sub>'
			},
			{
				label: 'Mean fitness',
				html: '<span class="overline"><var>w</var></span> = <var>p</var><sup>2</sup><var>w</var><sub>AA</sub> + 2<var>pq</var><var>w</var><sub>Aa</sub> + <var>q</var><sup>2</sup><var>w</var><sub>aa</sub>'
			},
			{
				label: 'Allele frequency next generation',
				html: '<var>p</var>\u2032 = <span class="frac"><span class="frac-num"><var>p</var><sup>2</sup><var>w</var><sub>AA</sub> + <var>pq</var><var>w</var><sub>Aa</sub></span><span class="frac-den"><span class="overline"><var>w</var></span></span></span>'
			},
			{
				label: 'Equilibrium frequency (when overdominance)',
				html: '<var>\u0070\u0302</var> = <span class="frac"><span class="frac-num"><var>w</var><sub>Aa</sub> \u2212 <var>w</var><sub>aa</sub></span><span class="frac-den">2<var>w</var><sub>Aa</sub> \u2212 <var>w</var><sub>AA</sub> \u2212 <var>w</var><sub>aa</sub></span></span>'
			}
		],
		parameters: [
			{
				name: 'wAA',
				description: 'Fitness of the AA homozygote. A value of 1.0 represents maximum fitness; values below 1.0 indicate a selective disadvantage.'
			},
			{
				name: 'wAa',
				description: 'Fitness of the Aa heterozygote. When this exceeds both homozygote fitnesses, heterozygote advantage (overdominance) maintains a stable polymorphism.'
			},
			{
				name: 'waa',
				description: 'Fitness of the aa homozygote. Setting this below wAA models directional selection favoring allele A.'
			},
			{
				name: 'P(A)',
				description: 'Initial frequency of allele A in the population (0 to 1).'
			},
			{
				name: 'Gen',
				description: 'Number of generations to simulate.'
			}
		],
		insights: [
			'The dominance relationship between alleles strongly affects the rate of allele frequency change. With complete dominance, selection is most effective at intermediate frequencies.',
			'Heterozygote advantage (wAa > wAA and wAa > waa) maintains a stable polymorphism at an equilibrium frequency that depends only on the fitness values, not the starting frequency.',
			'Selection against rare recessives becomes dramatically less effective at low frequencies because most copies of the recessive allele are hidden in heterozygotes, shielded from selection.',
			'When the heterozygote is less fit than both homozygotes (underdominance), an unstable equilibrium exists and the outcome depends on whether the initial frequency is above or below it.'
		],
		references: [
			{
				authors: 'Fisher, R.A.',
				title: 'The Genetical Theory of Natural Selection',
				year: 1930
			},
			{
				authors: 'Haldane, J.B.S.',
				title: 'A mathematical theory of natural and artificial selection',
				journal: 'Transactions of the Cambridge Philosophical Society',
				year: 1924
			},
			{
				authors: 'Hartl, D.L. & Clark, A.G.',
				title: 'Principles of Population Genetics',
				year: 2007
			},
			{
				authors: 'Johnson, O.L., Tobler, R., Schmidt, J.M. & Huber, C.D.',
				title: 'Population genetic simulation: benchmarking frameworks for non-standard models of natural selection',
				journal: 'Molecular Ecology Resources',
				year: 2024,
				doi: '10.1111/1755-0998.13930'
			},
			{
				authors: 'Charlesworth, B. & Jensen, J.D.',
				title: 'Effects of selection at linked sites on patterns of genetic variability',
				journal: 'Annual Review of Ecology, Evolution, and Systematics',
				year: 2021,
				doi: '10.1146/annurev-ecolsys-010621-044528'
			}
		]
	},

	'/selection/frequency-dependent': {
		title: 'Frequency-Dependent Selection',
		category: 'Selection',
		description:
			'A model where genotype fitnesses are not constant but depend on current allele frequencies. This creates dynamic fitness landscapes where the selective advantage of a genotype changes as it becomes more or less common in the population. The simulation plots both the change in allele frequency (\u0394p) and the fitness functions across the full range of p.',
		formulas: [
			{
				label: 'Frequency-dependent fitness of AA',
				html: '<var>w</var><sub>AA</sub> = 1 \u2212 <var>s</var><sub>1</sub> \u00b7 <var>p</var><sup>2</sup>'
			},
			{
				label: 'Frequency-dependent fitness of Aa',
				html: '<var>w</var><sub>Aa</sub> = 1 \u2212 <var>s</var><sub>2</sub> \u00b7 2<var>pq</var>'
			},
			{
				label: 'Frequency-dependent fitness of aa',
				html: '<var>w</var><sub>aa</sub> = 1 \u2212 <var>s</var><sub>3</sub> \u00b7 <var>q</var><sup>2</sup>'
			},
			{
				label: 'Mean fitness',
				html: '<span class="overline"><var>w</var></span> = <var>p</var><sup>2</sup><var>w</var><sub>AA</sub> + 2<var>pq</var><var>w</var><sub>Aa</sub> + <var>q</var><sup>2</sup><var>w</var><sub>aa</sub>'
			},
			{
				label: 'Allele frequency change',
				html: '\u0394<var>p</var> = <span class="frac"><span class="frac-num"><var>p</var><sup>2</sup><var>w</var><sub>AA</sub> + <var>pq</var><var>w</var><sub>Aa</sub></span><span class="frac-den"><span class="overline"><var>w</var></span></span></span> \u2212 <var>p</var>'
			}
		],
		parameters: [
			{
				name: 's\u2081 (AA)',
				description: 'Selection coefficient for the AA genotype. Controls how strongly AA fitness decreases as allele A becomes common. Higher values mean stronger negative frequency dependence for AA.'
			},
			{
				name: 's\u2082 (Aa)',
				description: 'Selection coefficient for the Aa heterozygote. Controls how the heterozygote fitness varies with genotype frequency.'
			},
			{
				name: 's\u2083 (aa)',
				description: 'Selection coefficient for the aa genotype. Controls how strongly aa fitness decreases as allele a becomes common.'
			}
		],
		insights: [
			'Negative frequency dependence (rare allele advantage) is a powerful mechanism for maintaining genetic polymorphism. When a genotype becomes rare, its fitness increases, preventing its loss.',
			'Positive frequency dependence, where common genotypes have higher fitness, drives the population toward fixation of whichever allele is initially more frequent.',
			'Frequency-dependent selection is central to host-parasite coevolution (Red Queen hypothesis), where parasites adapt to the most common host genotype, giving rare genotypes a selective advantage.',
			'The \u0394p plot reveals equilibrium points where it crosses zero. Stable equilibria occur where the curve crosses from positive to negative (with increasing p).'
		],
		references: [
			{
				authors: 'Kojima, K.',
				title: 'Is there a constant fitness value for a given genotype? No!',
				journal: 'Evolution',
				year: 1971,
				doi: '10.1111/j.1558-5646.1971.tb01881.x'
			},
			{
				authors: 'Clarke, B. & O\'Donald, P.',
				title: 'Frequency-dependent selection',
				journal: 'Heredity',
				year: 1964,
				doi: '10.1038/hdy.1964.25'
			},
			{
				authors: 'Ayala, F.J. & Campbell, C.A.',
				title: 'Frequency-dependent selection',
				journal: 'Annual Review of Ecology and Systematics',
				year: 1974,
				doi: '10.1146/annurev.es.05.110174.000555'
			},
			{
				authors: 'Gomez-Llano, M., Bassar, R.D., Svensson, E.I., Tye, S.P. & Siepielski, A.M.',
				title: 'Meta-analytical evidence for frequency-dependent selection across the tree of life',
				journal: 'Ecology Letters',
				year: 2024,
				doi: '10.1111/ele.14477'
			},
			{
				authors: 'Svensson, E.I. & Connallon, T.',
				title: 'How frequency-dependent selection affects population fitness, maladaptation and evolutionary rescue',
				journal: 'Evolutionary Applications',
				year: 2019,
				doi: '10.1111/eva.12714'
			}
		]
	},

	'/mutation': {
		title: 'Two-Way Mutation',
		category: 'Mutation',
		description:
			'Bidirectional mutation model where allele A mutates to allele a at rate \u03bc (forward mutation) and allele a mutates back to A at rate \u03bd (reverse mutation). Over time the allele frequency converges to an equilibrium determined solely by the ratio of the two mutation rates. This module illustrates mutation as an evolutionary force in the absence of selection, drift, or gene flow.',
		formulas: [
			{
				label: 'Recurrence relation',
				html: '<var>p</var><sub>t+1</sub> = <var>p</var>(1 \u2212 \u03bc) + (1 \u2212 <var>p</var>)\u03bd'
			},
			{
				label: 'Equilibrium frequency',
				html: '<var>\u0070\u0302</var> = <span class="frac"><span class="frac-num">\u03bd</span><span class="frac-den">\u03bc + \u03bd</span></span>'
			}
		],
		parameters: [
			{
				name: '\u03bc',
				description: 'Forward mutation rate (A \u2192 a). Typical values range from 10\u207b\u2074 to 10\u207b\u2076 per generation per locus.'
			},
			{
				name: '\u03bd',
				description: 'Reverse (back) mutation rate (a \u2192 A). Often lower than the forward rate in biological systems.'
			},
			{
				name: 'P(A)',
				description: 'Initial frequency of allele A in the population (0 to 1).'
			},
			{
				name: 'Gen',
				description: 'Number of generations to simulate. Because mutation rates are small, many thousands of generations may be needed to approach equilibrium.'
			}
		],
		insights: [
			'Mutation alone is a very weak evolutionary force for changing allele frequencies. Even at relatively high mutation rates, convergence to equilibrium takes thousands of generations.',
			'The equilibrium frequency depends only on the ratio of the two mutation rates (\u03bd/(\u03bc + \u03bd)), not on the initial allele frequency. All starting frequencies converge to the same equilibrium.',
			'Mutation provides the raw material for evolution by introducing new genetic variation, but other forces (selection, drift) are typically far more important for determining allele frequency dynamics.',
			'The approach to equilibrium is approximately exponential with rate (\u03bc + \u03bd) per generation.'
		],
		references: [
			{
				authors: 'Haldane, J.B.S.',
				title: 'A mathematical theory of natural and artificial selection, Part V: Selection and mutation',
				journal: 'Proceedings of the Cambridge Philosophical Society',
				year: 1927,
				doi: '10.1017/S0305004100015644'
			},
			{
				authors: 'Crow, J.F. & Kimura, M.',
				title: 'An Introduction to Population Genetics Theory',
				year: 1970
			},
			{
				authors: 'Lynch, M., Ackerman, M.S., Gout, J.-F., Long, H., Sung, W., Thomas, W.K. & Foster, P.L.',
				title: 'Genetic drift, selection and the evolution of the mutation rate',
				journal: 'Nature Reviews Genetics',
				year: 2016,
				doi: '10.1038/nrg.2016.104'
			},
			{
				authors: 'Lynch, M.',
				title: 'The divergence of mutation rates and spectra across the Tree of Life',
				journal: 'EMBO Reports',
				year: 2023,
				doi: '10.15252/embr.202357561'
			}
		]
	},

	'/mutation/irreversible': {
		title: 'Irreversible Mutation',
		category: 'Mutation',
		description:
			'One-way mutation model where allele A mutates to allele a at rate \u03bc but no back mutation occurs. Without reverse mutation, the frequency of allele A decays exponentially toward zero. This is a useful approximation when forward mutation greatly exceeds reverse mutation, and demonstrates that without opposing forces, mutation pressure alone will eventually eliminate an allele.',
		formulas: [
			{
				label: 'Frequency decay',
				html: '<var>p</var>(<var>t</var>) = <var>p</var><sub>0</sub>(1 \u2212 \u03bc)<sup><var>t</var></sup>'
			},
			{
				label: 'Per-generation recurrence',
				html: '<var>p</var><sub>t+1</sub> = <var>p</var><sub>t</sub>(1 \u2212 \u03bc)'
			},
			{
				label: 'Half-life (generations to halve frequency)',
				html: '<var>t</var><sub>1/2</sub> = <span class="frac"><span class="frac-num">ln 2</span><span class="frac-den">\u03bc</span></span>'
			}
		],
		parameters: [
			{
				name: 'P(A)',
				description: 'Initial frequency of allele A (0 to 1). The simulation tracks the exponential decay of this frequency over time.'
			},
			{
				name: '\u03bc',
				description: 'Mutation rate from A to a per generation. Higher values produce faster decay of allele A.'
			},
			{
				name: 'Gen',
				description: 'Number of generations to simulate.'
			}
		],
		insights: [
			'Without back mutation or other counterbalancing forces, the allele undergoing mutation will inevitably be lost from the population. The decay is purely exponential.',
			'The rate of allele loss is directly proportional to the mutation rate. At \u03bc = 0.001, it takes approximately 693 generations to halve the allele frequency.',
			'This model serves as a good approximation for situations where forward mutation is much more frequent than reverse mutation, which is common for loss-of-function mutations.',
			'In real populations, selection, drift, and back mutation all interact with irreversible mutation, so pure exponential decay is rarely observed over long periods.'
		],
		references: [
			{
				authors: 'Haldane, J.B.S.',
				title: 'A mathematical theory of natural and artificial selection, Part V: Selection and mutation',
				journal: 'Proceedings of the Cambridge Philosophical Society',
				year: 1927,
				doi: '10.1017/S0305004100015644'
			},
			{
				authors: 'Crow, J.F. & Kimura, M.',
				title: 'An Introduction to Population Genetics Theory',
				year: 1970
			},
			{
				authors: 'Lynch, M., Ackerman, M.S., Gout, J.-F., Long, H., Sung, W., Thomas, W.K. & Foster, P.L.',
				title: 'Genetic drift, selection and the evolution of the mutation rate',
				journal: 'Nature Reviews Genetics',
				year: 2016,
				doi: '10.1038/nrg.2016.104'
			}
		]
	},

	'/mutation/neutral': {
		title: 'Neutral Mutations',
		category: 'Mutation',
		description:
			'Simulates the fate of neutral mutations arising in a finite population, illustrating key principles of Kimura\'s neutral theory of molecular evolution. New mutations appear at regular intervals, each starting at a frequency of 1/(2N), and drift randomly through the population via Wright-Fisher sampling. Most neutral mutations are lost quickly, but occasionally one drifts to fixation.',
		formulas: [
			{
				label: 'Initial frequency of a new mutation',
				html: '<var>p</var><sub>0</sub> = <span class="frac"><span class="frac-num">1</span><span class="frac-den">2<var>N</var><sub>e</sub></span></span>'
			},
			{
				label: 'Probability of fixation (neutral)',
				html: 'Pr(fix) = <span class="frac"><span class="frac-num">1</span><span class="frac-den">2<var>N</var><sub>e</sub></span></span>'
			},
			{
				label: 'Substitution rate (neutral)',
				html: '<var>k</var> = 2<var>N</var><sub>e</sub>\u03bc \u00b7 <span class="frac"><span class="frac-num">1</span><span class="frac-den">2<var>N</var><sub>e</sub></span></span> = \u03bc'
			},
			{
				label: 'Expected heterozygosity',
				html: '<var>H</var> = <span class="frac"><span class="frac-num">\u03b8</span><span class="frac-den">1 + \u03b8</span></span>, where \u03b8 = 4<var>N</var><sub>e</sub>\u03bc'
			}
		],
		parameters: [
			{
				name: 'Ne',
				description: 'Effective population size. Determines the strength of genetic drift and the initial frequency (1/(2Ne)) of each new mutation.'
			},
			{
				name: 'Gen',
				description: 'Number of generations to simulate.'
			},
			{
				name: 'Interval',
				description: 'Number of generations between the appearance of successive new neutral mutations.'
			}
		],
		insights: [
			'For neutral alleles, the rate of molecular evolution (substitution rate) equals the mutation rate, regardless of population size. This elegant result underpins the molecular clock.',
			'The parameter \u03b8 = 4N\u2091\u03bc is the fundamental quantity in neutral theory, governing expected heterozygosity, the number of segregating sites, and the site frequency spectrum.',
			'Most new neutral mutations are lost within a few generations due to drift. The probability that any single neutral mutation eventually fixes is 1/(2N\u2091), which is very small in large populations.',
			'The time to fixation for a neutral mutation that does fix is approximately 4N\u2091 generations on average, which can be very long in large populations.'
		],
		references: [
			{
				authors: 'Kimura, M.',
				title: 'Evolutionary rate at the molecular level',
				journal: 'Nature',
				year: 1968,
				doi: '10.1038/217624a0'
			},
			{
				authors: 'Kimura, M.',
				title: 'The Neutral Theory of Molecular Evolution',
				year: 1983
			},
			{
				authors: 'King, J.L. & Jukes, T.H.',
				title: 'Non-Darwinian evolution',
				journal: 'Science',
				year: 1969,
				doi: '10.1126/science.164.3881.788'
			},
			{
				authors: 'Galtier, N.',
				title: 'Half a century of controversy: the neutralist/selectionist debate in molecular evolution',
				journal: 'Genome Biology and Evolution',
				year: 2024,
				doi: '10.1093/gbe/evae003'
			},
			{
				authors: 'de Jong, G.',
				title: 'Moderating the neutralist\u2013selectionist debate: exactly which propositions are we debating, and which arguments are valid?',
				journal: 'Biological Reviews',
				year: 2024,
				doi: '10.1111/brv.13010'
			}
		]
	},

	'/mutation/muller': {
		title: "Muller's Ratchet",
		category: 'Mutation',
		description:
			'Simulates the irreversible accumulation of deleterious mutations in a finite asexual population. Each individual carries a genome with multiple loci that can acquire deleterious mutations. Without recombination, the least-loaded class (individuals with the fewest mutations) can be lost by drift and never recovered, causing the ratchet to "click." The simulation displays histograms of mutation counts across the population at four time points.',
		formulas: [
			{
				label: 'Individual fitness',
				html: '<var>w</var> = (1 \u2212 <var>s</var>)<sup><var>k</var></sup>, where <var>k</var> = number of deleterious mutations'
			},
			{
				label: 'Expected size of the least-loaded class',
				html: '<var>n</var><sub>0</sub> = <var>N</var> \u00b7 <var>e</var><sup>\u2212<var>U</var>/<var>s</var></sup>'
			},
			{
				label: 'Ratchet clicks when',
				html: '<var>n</var><sub>0</sub> \u2248 0, i.e., <var>N</var> \u00b7 <var>e</var><sup>\u2212<var>U</var>/<var>s</var></sup> \u226a 1'
			}
		],
		parameters: [
			{
				name: 'N',
				description: 'Haploid population size. Smaller populations are more vulnerable to the ratchet because the least-loaded class is more easily lost by drift.'
			},
			{
				name: 'Loci',
				description: 'Number of mutable sites per genome. More loci increase the potential for mutation accumulation.'
			},
			{
				name: '\u03bc',
				description: 'Genomic mutation rate (U) per genome per generation. Controls how many new deleterious mutations are introduced each generation across the population.'
			},
			{
				name: 's',
				description: 'Selection coefficient per deleterious mutation. Each mutation reduces fitness multiplicatively by a factor of (1 \u2212 s).'
			},
			{
				name: 'Gen',
				description: 'Number of generations to simulate. The four histogram snapshots are taken at generations 0, T/3, 2T/3, and T\u22121.'
			}
		],
		insights: [
			'Sexual reproduction (recombination) is the primary defense against Muller\'s ratchet. By shuffling mutations between genomes, recombination can recreate low-mutation genotypes that drift has eliminated.',
			'Small asexual populations are most vulnerable to the ratchet. The critical factor is whether n\u2080 = N\u00b7e^(\u2212U/s) is large enough to resist stochastic loss.',
			'The ratchet provides one of the most compelling evolutionary explanations for the maintenance of sexual reproduction despite its twofold cost.',
			'Over time, the mutation distribution shifts rightward (toward more mutations per genome) as the least-loaded class is repeatedly lost and cannot be regenerated without recombination.'
		],
		references: [
			{
				authors: 'Muller, H.J.',
				title: 'The relation of recombination to mutational advance',
				journal: 'Mutation Research',
				year: 1964,
				doi: '10.1016/0027-5107(64)90047-8'
			},
			{
				authors: 'Haigh, J.',
				title: 'The accumulation of deleterious genes in a population \u2014 Muller\'s ratchet',
				journal: 'Theoretical Population Biology',
				year: 1978,
				doi: '10.1016/0040-5809(78)90027-8'
			},
			{
				authors: 'Felsenstein, J.',
				title: 'The evolutionary advantage of recombination',
				journal: 'Genetics',
				year: 1974,
				doi: '10.1093/genetics/78.2.737'
			},
			{
				authors: 'Govindaraju, D.R., Innan, H. & Veitia, R.A.',
				title: 'The Muller\'s ratchet and aging',
				journal: 'Trends in Genetics',
				year: 2020,
				doi: '10.1016/j.tig.2020.02.004'
			},
			{
				authors: 'Lansch-Justen, L., Cusseddu, D., Schmitz, M.A. & Bank, C.',
				title: 'The extinction time under mutational meltdown driven by high mutation rates',
				journal: 'Ecology and Evolution',
				year: 2022,
				doi: '10.1002/ece3.9046'
			}
		]
	}
};
