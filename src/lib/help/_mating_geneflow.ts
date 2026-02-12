import type { HelpContent } from './types';

export const matingGeneflowContent: Record<string, HelpContent> = {
	'/mating/autosomal': {
		title: 'Autosomal Locus',
		category: 'Mating',
		description:
			'Demonstrates how genotype counts at an autosomal locus relate to allele frequencies and Hardy-Weinberg equilibrium expectations. Given observed numbers of AA, Aa, and aa individuals, the module computes genotype frequencies, derives allele frequencies, and shows the position on a De Finetti diagram before and after one generation of random mating. One round of random mating restores HWE proportions, illustrating that deviations from HWE at a single locus are transient under Mendelian inheritance.',
		formulas: [
			{
				label: 'Allele frequency from genotype counts',
				html: '<var>p</var> = <var>D</var> + <span class="frac"><span class="frac-num"><var>H</var></span><span class="frac-den">2</span></span>, where <var>D</var> = freq(AA), <var>H</var> = freq(Aa)'
			},
			{
				label: 'HWE genotype frequencies',
				html: 'freq(AA) = <var>p</var><sup>2</sup>, freq(Aa) = 2<var>p</var><var>q</var>, freq(aa) = <var>q</var><sup>2</sup>'
			},
			{
				label: 'Genotype frequencies with inbreeding coefficient F',
				html: 'P(AA) = <var>p</var><sup>2</sup> + <var>F</var><var>p</var><var>q</var>, P(Aa) = 2<var>p</var><var>q</var>(1 &minus; <var>F</var>), P(aa) = <var>q</var><sup>2</sup> + <var>F</var><var>p</var><var>q</var>'
			}
		],
		parameters: [
			{
				name: 'N(AA)',
				description: 'Number of AA homozygotes in the observed sample'
			},
			{
				name: 'N(Aa)',
				description: 'Number of Aa heterozygotes in the observed sample'
			},
			{
				name: 'N(aa)',
				description: 'Number of aa homozygotes in the observed sample'
			}
		],
		insights: [
			'Inbreeding increases homozygosity at the expense of heterozygotes but does not change allele frequencies.',
			'The inbreeding coefficient F measures the departure from Hardy-Weinberg proportions and ranges from 0 (random mating) to 1 (complete inbreeding).',
			'A single generation of random mating restores Hardy-Weinberg equilibrium at a single autosomal locus, regardless of the initial genotype frequencies.',
			'Under full selfing (F approaching 1), heterozygosity is halved each generation and the population converges to entirely homozygous genotypes.',
			'The De Finetti diagram shows that any point on the HWE parabola corresponds to random mating, while points below the parabola indicate heterozygote deficiency (inbreeding).'
		],
		references: [
			{
				authors: 'Wright, S.',
				title: 'Coefficients of inbreeding and relationship',
				journal: 'The American Naturalist',
				year: 1922,
				doi: '10.1086/279872'
			},
			{
				authors: 'Hardy, G. H.',
				title: 'Mendelian proportions in a mixed population',
				journal: 'Science',
				year: 1908,
				doi: '10.1126/science.28.706.49'
			},
			{
				authors: 'Hedrick, P. W.',
				title: 'Genetics of Populations (4th ed.)',
				journal: 'Jones & Bartlett Publishers',
				year: 2011
			},
			{
				authors: 'Ceballos, F.C., Joshi, P.K., Clark, D.W., Ramsay, M. & Wilson, J.F.',
				title: 'Runs of homozygosity: windows into population history and trait architecture',
				journal: 'Nature Reviews Genetics',
				year: 2018,
				doi: '10.1038/nrg.2017.109'
			},
			{
				authors: 'Kardos, M., Taylor, H.R., Ellegren, H., Luikart, G. & Allendorf, F.W.',
				title: 'Genomics advances the study of inbreeding depression in the wild',
				journal: 'Evolutionary Applications',
				year: 2016,
				doi: '10.1111/eva.12414'
			}
		]
	},

	'/mating/x-linked': {
		title: 'X-Linked Locus Convergence',
		category: 'Mating',
		description:
			'Simulates allele frequency dynamics at an X-linked locus where males are hemizygous and females carry two copies. Because males receive their single X from their mother and females receive one X from each parent, allele frequencies oscillate between the sexes before converging to a weighted equilibrium. This oscillatory convergence is a distinctive signature of X-linkage and has no analogue at autosomal loci.',
		formulas: [
			{
				label: 'Female frequency update',
				html: '<var>p</var><sub>f</sub>(t+1) = <span class="frac"><span class="frac-num"><var>p</var><sub>m</sub>(t) + <var>p</var><sub>f</sub>(t)</span><span class="frac-den">2</span></span>'
			},
			{
				label: 'Male frequency update',
				html: '<var>p</var><sub>m</sub>(t+1) = <var>p</var><sub>f</sub>(t)'
			},
			{
				label: 'Equilibrium frequency',
				html: '<var>p&#x0302;</var> = <span class="frac"><span class="frac-num">2<var>p</var><sub>f</sub> + <var>p</var><sub>m</sub></span><span class="frac-den">3</span></span>'
			},
			{
				label: 'Convergence rate',
				html: 'Deviation decays as (&minus;<span class="frac"><span class="frac-num">1</span><span class="frac-den">2</span></span>)<sup><var>t</var></sup>'
			}
		],
		parameters: [
			{
				name: 'P(A) in females',
				description:
					'Initial frequency of allele A in females (pFemale). Default: 0.7'
			},
			{
				name: 'P(A) in males',
				description:
					'Initial frequency of allele A in males (pMale). Default: 0.3'
			},
			{
				name: 'Gen',
				description:
					'Number of generations to simulate. Default: 20'
			}
		],
		insights: [
			'X-linked allele frequencies oscillate between the sexes, with the amplitude of oscillation halving each generation.',
			'The equilibrium frequency is a weighted average: two-thirds female frequency plus one-third male frequency, because females carry two-thirds of all X chromosomes in the population.',
			'Convergence rate is (&minus;1/2)^t, meaning the sign alternates (overshoot/undershoot) and magnitude decays geometrically.',
			'Unlike autosomal loci, X-linked loci require multiple generations to reach equilibrium even under random mating.',
			'The male frequency in any generation equals the female frequency from the previous generation, creating the characteristic zigzag pattern.'
		],
		references: [
			{
				authors: 'Li, C. C.',
				title: 'First Course in Population Genetics',
				journal: 'Boxwood Press',
				year: 1976
			},
			{
				authors: 'Hedrick, P. W.',
				title: 'Genetics of Populations (4th ed.)',
				journal: 'Jones & Bartlett Publishers',
				year: 2011
			},
			{
				authors: 'Crow, J. F.',
				title: 'Basic Concepts in Population, Quantitative, and Evolutionary Genetics',
				journal: 'W. H. Freeman',
				year: 1986
			},
			{
				authors: 'Driscoll, R.M.H., Beaudry, F.E.G., Cosgrove, E.J., Bowman, R., Fitzpatrick, J.W., Schoech, S.J. & Chen, N.',
				title: 'Allele frequency dynamics under sex-biased demography and sex-specific inheritance in a pedigreed jay population',
				journal: 'Genetics',
				year: 2024,
				doi: '10.1093/genetics/iyae075'
			}
		]
	},

	'/mating/assortative': {
		title: 'Assortative Mating',
		category: 'Mating',
		description:
			'Simulates the effects of positive assortative mating, where individuals with similar phenotypes or genotypes preferentially mate with each other. Three classical models are available: positive assortative mating with dominance (phenotype-based, where A- mates with A- and aa mates with aa), positive without dominance (genotype-based selfing, where each genotype mates only with its own type), and negative assortative (disassortative) mating where unlike phenotypes preferentially mate. Results are displayed on a De Finetti triangle showing the trajectory of genotype frequencies across generations.',
		formulas: [
			{
				label: 'Positive with dominance (Model 1)',
				html: '<var>D</var>\' = <span class="frac"><span class="frac-num">(2<var>D</var> + <var>H</var>)<sup>2</sup></span><span class="frac-den">4(<var>D</var> + <var>H</var>)</span></span>, <var>H</var>\' = <span class="frac"><span class="frac-num"><var>H</var>(2<var>D</var> + <var>H</var>)</span><span class="frac-den">2(<var>D</var> + <var>H</var>)</span></span>'
			},
			{
				label: 'Positive without dominance / selfing (Model 2)',
				html: '<var>D</var>\' = <var>D</var> + <span class="frac"><span class="frac-num"><var>H</var></span><span class="frac-den">4</span></span>, <var>H</var>\' = <span class="frac"><span class="frac-num"><var>H</var></span><span class="frac-den">2</span></span>'
			},
			{
				label: 'Allele frequency conservation',
				html: '<var>p</var> = <var>D</var> + <span class="frac"><span class="frac-num"><var>H</var></span><span class="frac-den">2</span></span> (constant across generations)'
			}
		],
		parameters: [
			{
				name: 'D (AA)',
				description:
					'Initial frequency of the AA genotype. Default: 0.04'
			},
			{
				name: 'H (Aa)',
				description:
					'Initial frequency of the Aa genotype. Default: 0.32. The aa frequency R is computed as 1 - D - H.'
			},
			{
				name: 'Gen',
				description: 'Number of generations to simulate. Default: 20'
			},
			{
				name: 'Model',
				description:
					'Assortment model: "Positive (dominance)" groups A- phenotypes together; "Positive (no dom.)" is strict genotype selfing; "Negative" is disassortative mating.'
			}
		],
		insights: [
			'Positive assortative mating increases homozygosity without changing allele frequencies, producing effects similar to inbreeding.',
			'Unlike inbreeding, assortative mating only affects loci controlling the trait under assortment, not genome-wide loci.',
			'Under the selfing model (positive without dominance), heterozygosity is exactly halved each generation.',
			'Negative (disassortative) mating increases heterozygosity and can maintain polymorphism, playing a role in phenomena like self-incompatibility systems.',
			'Assortative mating for a trait can be an important mechanism contributing to reproductive isolation and speciation.'
		],
		references: [
			{
				authors: 'Wright, S.',
				title: 'Systems of mating. III. Assortative mating based on somatic resemblance',
				journal: 'Genetics',
				year: 1921,
				doi: '10.1093/genetics/6.2.144'
			},
			{
				authors: 'Crow, J. F. & Kimura, M.',
				title: 'An Introduction to Population Genetics Theory',
				journal: 'Harper & Row',
				year: 1970
			},
			{
				authors: 'Hedrick, P. W.',
				title: 'Genetics of Populations (4th ed.)',
				journal: 'Jones & Bartlett Publishers',
				year: 2011
			},
			{
				authors: 'Robinson, M.R., Kleinman, A., Graff, M. et al.',
				title: 'Genetic evidence of assortative mating in humans',
				journal: 'Nature Human Behaviour',
				year: 2017,
				doi: '10.1038/s41562-016-0016'
			},
			{
				authors: 'Yengo, L., Robinson, M.R., Keller, M.C. et al.',
				title: 'Imprint of assortative mating on the human genome',
				journal: 'Nature Human Behaviour',
				year: 2018,
				doi: '10.1038/s41562-018-0476-3'
			}
		]
	},

	'/mating/assortative-matrix': {
		title: 'Assortative Mating Matrix',
		category: 'Mating',
		description:
			'Provides the most general framework for modeling non-random mating through an explicit 3x3 mating type matrix. Each cell specifies whether a particular female-genotype x male-genotype mating is allowed or forbidden/sterile. The module includes 14 predefined mating restriction patterns from classical population genetics, each available in two variants: "forbidden" (matings simply do not occur and their frequencies are redistributed) and "sterile" (matings occur but produce no viable offspring). Mendelian segregation ratios are applied to allowed matings to compute next-generation genotype frequencies.',
		formulas: [
			{
				label: 'General next-generation frequency',
				html: 'Genotype frequencies in generation <var>t</var>+1 are computed from the mating type matrix multiplied by Mendelian segregation ratios for each cross.'
			},
			{
				label: 'Mating frequency (random component)',
				html: 'freq(<var>i</var> &times; <var>j</var>) = freq(<var>i</var>) &middot; freq(<var>j</var>) for allowed matings, redistributed among permitted crosses'
			},
			{
				label: 'Selfing model (Model 2, forbidden)',
				html: '<var>D</var>\' = <var>D</var> + <span class="frac"><span class="frac-num"><var>H</var></span><span class="frac-den">4</span></span>, <var>H</var>\' = <span class="frac"><span class="frac-num"><var>H</var></span><span class="frac-den">2</span></span>'
			}
		],
		parameters: [
			{
				name: 'D (AA)',
				description: 'Initial frequency of the AA genotype. Default: 0.04'
			},
			{
				name: 'H (Aa)',
				description:
					'Initial frequency of the Aa genotype. Default: 0.32. R (aa) is calculated as 1 - D - H.'
			},
			{
				name: 'Gen',
				description: 'Number of generations to simulate. Default: 20'
			},
			{
				name: 'Variant',
				description:
					'"Forbidden" means disallowed matings do not occur and frequencies redistribute to allowed types. "Sterile" means matings occur but produce no offspring, reducing effective population output.'
			},
			{
				name: 'Mating matrix',
				description:
					'A 3x3 grid of toggles (AA, Aa, aa for each sex) specifying which crosses are allowed. Symmetric cells are automatically linked (e.g., AA x Aa mirrors Aa x AA).'
			}
		],
		insights: [
			'The mating type matrix provides the most general framework for non-random mating, subsuming random mating, positive assortative, negative assortative, and partial selfing as special cases.',
			'The 14 predefined models cover the classical restriction patterns studied by Li (1976), ranging from complete positive assortment to complete disassortative mating.',
			'The distinction between "forbidden" and "sterile" variants matters: forbidden matings redistribute mating effort, while sterile matings waste it, potentially leading to different equilibria.',
			'Some mating restriction patterns lead to loss of one or more genotypes over time, while others maintain stable polymorphism.',
			'The matrix approach makes it straightforward to verify that each model satisfies the constraint that genotype frequencies must sum to 1.0 each generation.'
		],
		references: [
			{
				authors: 'Li, C. C.',
				title: 'First Course in Population Genetics',
				journal: 'Boxwood Press',
				year: 1976
			},
			{
				authors: 'Hedrick, P. W.',
				title: 'Genetics of Populations (4th ed.)',
				journal: 'Jones & Bartlett Publishers',
				year: 2011
			},
			{
				authors: 'Torvik, F.A., Eilertsen, E.M., McAdams, T.A. et al.',
				title: 'Modeling assortative mating and genetic similarities between partners, siblings, and in-laws',
				journal: 'Nature Communications',
				year: 2022,
				doi: '10.1038/s41467-022-28774-y'
			}
		]
	},

	'/gene-flow/continent-island': {
		title: 'Continent-Island Gene Flow',
		category: 'Gene Flow',
		description:
			'Models one-way migration from a large continental source population to a small island population. The continent is assumed to be so large that its allele frequency remains effectively constant regardless of emigration. Each generation, a fraction m of the island population is replaced by migrants from the continent. The island allele frequency converges asymptotically toward the continent frequency, with the rate of convergence determined by the migration rate.',
		formulas: [
			{
				label: 'Island frequency recursion',
				html: '<var>p</var><sub>island</sub>(t+1) = (1 &minus; <var>m</var>) &middot; <var>p</var><sub>island</sub>(t) + <var>m</var> &middot; <var>p</var><sub>continent</sub>'
			},
			{
				label: 'Closed-form solution',
				html: '<var>p</var><sub>island</sub>(t) = <var>p</var><sub>island</sub>(0) &middot; (1 &minus; <var>m</var>)<sup><var>t</var></sup> + <var>p</var><sub>continent</sub> &middot; [1 &minus; (1 &minus; <var>m</var>)<sup><var>t</var></sup>]'
			},
			{
				label: 'Equilibrium',
				html: '<var>p&#x0302;</var><sub>island</sub> = <var>p</var><sub>continent</sub>'
			}
		],
		parameters: [
			{
				name: 'P(A) continent',
				description:
					'Allele frequency of A on the continent (constant). Default: 0.8'
			},
			{
				name: 'P(A) island',
				description:
					'Initial allele frequency of A on the island. Default: 0.2'
			},
			{
				name: 'm',
				description:
					'Migration rate: the fraction of the island population replaced by continent migrants each generation. Default: 0.05'
			},
			{
				name: 'Gen',
				description: 'Number of generations to simulate. Default: 100'
			}
		],
		insights: [
			'Gene flow acts as a homogenizing force, pulling the island frequency toward the continental source.',
			'Even very small migration rates (m = 0.01) are sufficient to prevent complete genetic differentiation between populations.',
			'The island frequency decays exponentially toward the continent frequency at rate (1 - m)^t.',
			'The half-life of convergence is approximately ln(2) / m generations; for m = 0.05, it takes about 14 generations to halve the frequency difference.',
			'In the continent-island model, gene flow is one-directional: the continent is unaffected by the island, making this a good approximation for large mainland versus small peripheral populations.'
		],
		references: [
			{
				authors: 'Wright, S.',
				title: 'Evolution in Mendelian populations',
				journal: 'Genetics',
				year: 1931,
				doi: '10.1093/genetics/16.2.97'
			},
			{
				authors: 'Hartl, D. L. & Clark, A. G.',
				title: 'Principles of Population Genetics (4th ed.)',
				journal: 'Sinauer Associates',
				year: 2007
			},
			{
				authors: 'Hedrick, P. W.',
				title: 'Genetics of Populations (4th ed.)',
				journal: 'Jones & Bartlett Publishers',
				year: 2011
			},
			{
				authors: 'Petkova, D., Novembre, J. & Stephens, M.',
				title: 'Visualizing spatial population structure with estimated effective migration surfaces',
				journal: 'Nature Genetics',
				year: 2016,
				doi: '10.1038/ng.3464'
			},
			{
				authors: 'Marcus, J.H., Ha, W., Barber, R.F. & Novembre, J.',
				title: 'Fast and flexible estimation of effective migration surfaces',
				journal: 'eLife',
				year: 2021,
				doi: '10.7554/eLife.61927'
			}
		]
	},

	'/gene-flow/island-island': {
		title: 'Island-Island Gene Flow',
		category: 'Gene Flow',
		description:
			'Models bidirectional migration between two populations. Each generation, a fraction of each population is replaced by migrants from the other. Unlike the continent-island model, both populations change over time and converge toward a weighted equilibrium frequency. The model supports asymmetric migration rates (m1 and m2), where m1 is the rate of immigration into population 1 from population 2, and m2 is the rate into population 2 from population 1.',
		formulas: [
			{
				label: 'Population 1 recursion',
				html: '<var>p</var><sub>1</sub>(t+1) = (1 &minus; <var>m</var><sub>1</sub>) &middot; <var>p</var><sub>1</sub>(t) + <var>m</var><sub>1</sub> &middot; <var>p</var><sub>2</sub>(t)'
			},
			{
				label: 'Population 2 recursion',
				html: '<var>p</var><sub>2</sub>(t+1) = (1 &minus; <var>m</var><sub>2</sub>) &middot; <var>p</var><sub>2</sub>(t) + <var>m</var><sub>2</sub> &middot; <var>p</var><sub>1</sub>(t)'
			},
			{
				label: 'Equilibrium frequency',
				html: '<var>p&#x0302;</var> = <span class="frac"><span class="frac-num"><var>p</var><sub>1</sub> &middot; <var>m</var><sub>2</sub> + <var>p</var><sub>2</sub> &middot; <var>m</var><sub>1</sub></span><span class="frac-den"><var>m</var><sub>1</sub> + <var>m</var><sub>2</sub></span></span>'
			},
			{
				label: 'Symmetric case equilibrium',
				html: 'When <var>m</var><sub>1</sub> = <var>m</var><sub>2</sub>: <var>p&#x0302;</var> = <span class="frac"><span class="frac-num"><var>p</var><sub>1</sub> + <var>p</var><sub>2</sub></span><span class="frac-den">2</span></span>'
			}
		],
		parameters: [
			{
				name: 'P(A) pop 1',
				description:
					'Initial allele frequency of A in population 1. Default: 0.8'
			},
			{
				name: 'P(A) pop 2',
				description:
					'Initial allele frequency of A in population 2. Default: 0.2'
			},
			{
				name: 'm1',
				description:
					'Migration rate into population 1 (fraction replaced by migrants from population 2 each generation). Default: 0.05'
			},
			{
				name: 'm2',
				description:
					'Migration rate into population 2 (fraction replaced by migrants from population 1 each generation). Default: 0.05'
			},
			{
				name: 'Gen',
				description: 'Number of generations to simulate. Default: 100'
			}
		],
		insights: [
			'Both populations converge toward a weighted equilibrium determined by the ratio of migration rates.',
			'With symmetric migration (m1 = m2), the equilibrium is the simple arithmetic mean of the initial frequencies.',
			'The rate of convergence depends on the sum m1 + m2, making symmetric two-way migration converge faster than one-way migration at the same per-population rate.',
			'Asymmetric migration shifts the equilibrium toward the population that receives fewer migrants (or equivalently, toward the population that sends more).',
			'Unlike the continent-island model, both populations are dynamic: neither acts as an unchanging source.'
		],
		references: [
			{
				authors: 'Wright, S.',
				title: 'Evolution in Mendelian populations',
				journal: 'Genetics',
				year: 1931,
				doi: '10.1093/genetics/16.2.97'
			},
			{
				authors: 'Hartl, D. L. & Clark, A. G.',
				title: 'Principles of Population Genetics (4th ed.)',
				journal: 'Sinauer Associates',
				year: 2007
			},
			{
				authors: 'Arredondo, A., Mourato, B., Nguyen, K. et al.',
				title: 'Inferring number of populations and changes in connectivity under the n-island model',
				journal: 'Heredity',
				year: 2021,
				doi: '10.1038/s41437-021-00426-9'
			}
		]
	},

	'/gene-flow/f-statistics': {
		title: "F-Statistics (Wright's)",
		category: 'Gene Flow',
		description:
			"Simulates Wright's hierarchical F-statistics (F_IS, F_ST, F_IT) across multiple subpopulations experiencing genetic drift and migration. Multiple populations drift independently via Wright-Fisher sampling, with migration modeled as exchange with the population mean. The three F-statistics partition total deviation from Hardy-Weinberg into within-subpopulation (F_IS) and between-subpopulation (F_ST) components, linked by the identity (1 - F_IT) = (1 - F_IS)(1 - F_ST).",
		formulas: [
			{
				label: 'F_ST (fixation index)',
				html: '<var>F</var><sub>ST</sub> = <span class="frac"><span class="frac-num"><var>H</var><sub>T</sub> &minus; <var>H</var><sub>S</sub></span><span class="frac-den"><var>H</var><sub>T</sub></span></span>'
			},
			{
				label: 'F_IS (inbreeding within subpopulations)',
				html: '<var>F</var><sub>IS</sub> = <span class="frac"><span class="frac-num"><var>H</var><sub>S</sub> &minus; <var>H</var><sub>I</sub></span><span class="frac-den"><var>H</var><sub>S</sub></span></span>'
			},
			{
				label: 'F_IT (overall inbreeding)',
				html: '<var>F</var><sub>IT</sub> = <span class="frac"><span class="frac-num"><var>H</var><sub>T</sub> &minus; <var>H</var><sub>I</sub></span><span class="frac-den"><var>H</var><sub>T</sub></span></span>'
			},
			{
				label: 'Hierarchical identity',
				html: '(1 &minus; <var>F</var><sub>IT</sub>) = (1 &minus; <var>F</var><sub>IS</sub>)(1 &minus; <var>F</var><sub>ST</sub>)'
			},
			{
				label: 'Migration-drift equilibrium',
				html: '<var>F</var><sub>ST</sub> &asymp; <span class="frac"><span class="frac-num">1</span><span class="frac-den">4<var>N</var><var>m</var> + 1</span></span>'
			}
		],
		parameters: [
			{
				name: 'Populations',
				description:
					'Number of subpopulations to simulate. Default: 20'
			},
			{
				name: 'Population Size',
				description:
					'Diploid population size (N) of each subpopulation. Default: 50'
			},
			{
				name: 'Initial Freq',
				description:
					'Starting allele frequency in all populations. Default: 0.5'
			},
			{
				name: 'Gen',
				description: 'Number of generations to simulate. Default: 100'
			},
			{
				name: 'Migration Rate',
				description:
					'Fraction of each subpopulation replaced by migrants from the population mean each generation. Default: 0.01'
			},
			{
				name: 'Inbreeding Coeff',
				description:
					'Within-population inbreeding coefficient (F_IS), reducing observed heterozygosity below HWE expectations. Default: 0.0'
			},
			{
				name: 'Plot Lines',
				description:
					'Number of individual population drift trajectories to display. Default: 8'
			}
		],
		insights: [
			'F_ST measures the proportion of total genetic variance that is due to differences between subpopulations; values above 0.25 indicate very great differentiation.',
			'F_IS measures deviation from Hardy-Weinberg equilibrium within subpopulations, capturing effects of local inbreeding or assortative mating.',
			'The product rule (1 - F_IT) = (1 - F_IS)(1 - F_ST) provides an exact partitioning: total departure from HWE decomposes into within- and between-population components.',
			'Wright\'s rule of thumb: Nm = 1 migrant per generation is sufficient to keep F_ST below approximately 0.2, preventing strong differentiation.',
			'F_ST increases with drift (small N, many generations) and decreases with migration; the equilibrium F_ST approximation 1/(4Nm + 1) applies under the island model at migration-drift balance.'
		],
		references: [
			{
				authors: 'Wright, S.',
				title: 'The genetical structure of populations',
				journal: 'Annals of Eugenics',
				year: 1951,
				doi: '10.1111/j.1469-1809.1949.tb02451.x'
			},
			{
				authors: 'Nei, M.',
				title: 'Analysis of gene diversity in subdivided populations',
				journal: 'Proceedings of the National Academy of Sciences',
				year: 1973,
				doi: '10.1073/pnas.70.12.3321'
			},
			{
				authors: 'Weir, B. S. & Cockerham, C. C.',
				title: 'Estimating F-statistics for the analysis of population structure',
				journal: 'Evolution',
				year: 1984,
				doi: '10.1111/j.1558-5646.1984.tb05657.x'
			},
			{
				authors: 'Ochoa, A. & Storey, J.D.',
				title: 'Estimating FST and kinship for arbitrary population structures',
				journal: 'PLOS Genetics',
				year: 2021,
				doi: '10.1371/journal.pgen.1009241'
			},
			{
				authors: 'Goudet, J., Kay, T. & Weir, B.S.',
				title: 'How to estimate kinship',
				journal: 'Molecular Ecology',
				year: 2018,
				doi: '10.1111/mec.14833'
			}
		]
	},

	'/gene-flow/wahlund': {
		title: 'Wahlund Effect',
		category: 'Gene Flow',
		description:
			'Demonstrates the Wahlund effect: the apparent deficiency of heterozygotes that arises when genotype frequencies are pooled across subdivided populations with different allele frequencies. Even if each subpopulation is in perfect Hardy-Weinberg equilibrium, the pooled sample will show fewer heterozygotes and more homozygotes than expected from the overall mean allele frequency. The heterozygote deficit equals exactly twice the variance in allele frequencies among subpopulations.',
		formulas: [
			{
				label: 'Pooled heterozygosity',
				html: '<var>H</var><sub>pooled</sub> = 2<span class="overline"><var>p</var></span><span class="overline"><var>q</var></span> &minus; 2σ<sup>2</sup><sub><var>p</var></sub>'
			},
			{
				label: 'Heterozygote deficit',
				html: 'Deficit = 2σ<sup>2</sup><sub><var>p</var></sub>, where σ<sup>2</sup><sub><var>p</var></sub> is the variance of allele frequencies among subpopulations'
			},
			{
				label: 'F_ST from variance',
				html: '<var>F</var><sub>ST</sub> = <span class="frac"><span class="frac-num">σ<sup>2</sup><sub><var>p</var></sub></span><span class="frac-den"><span class="overline"><var>p</var></span>(1 &minus; <span class="overline"><var>p</var></span>)</span></span>'
			},
			{
				label: 'Genotype frequencies with inbreeding',
				html: 'freq(AA) = <var>p</var><sup>2</sup>(1 &minus; <var>F</var>) + <var>p</var><var>F</var>, freq(Aa) = 2<var>p</var>(1 &minus; <var>p</var>)(1 &minus; <var>F</var>), freq(aa) = (1 &minus; <var>p</var>)<sup>2</sup>(1 &minus; <var>F</var>) + (1 &minus; <var>p</var>)<var>F</var>'
			}
		],
		parameters: [
			{
				name: 'Subpopulation frequencies',
				description:
					'Allele frequency of A in each subpopulation. Default: [0.1, 0.3, 0.5, 0.7, 0.9]'
			},
			{
				name: 'F (inbreeding coefficient)',
				description:
					'Within-subpopulation inbreeding coefficient applied to each subpopulation before pooling. Default: 0.0'
			}
		],
		insights: [
			'Population subdivision always causes an apparent heterozygote deficiency when individuals are pooled, even when each subpopulation is in HWE.',
			'The magnitude of the heterozygote deficit equals exactly 2 times the variance in allele frequencies among subpopulations (2 * sigma^2_p).',
			'Mistaking a subdivided population for a single panmictic unit leads to a false rejection of Hardy-Weinberg equilibrium due to the apparent excess of homozygotes.',
			'The Wahlund effect provides a direct link between F_ST and observable genotype frequencies: F_ST equals the proportional reduction in heterozygosity due to subdivision.',
			'Adding within-population inbreeding (F > 0) compounds the heterozygote deficit beyond what population structure alone produces.'
		],
		references: [
			{
				authors: 'Wahlund, S.',
				title: 'Zusammensetzung von Populationen und Korrelationserscheinungen vom Standpunkt der Vererbungslehre aus betrachtet',
				journal: 'Hereditas',
				year: 1928,
				doi: '10.1111/j.1601-5223.1928.tb02483.x'
			},
			{
				authors: 'Hartl, D. L. & Clark, A. G.',
				title: 'Principles of Population Genetics (4th ed.)',
				journal: 'Sinauer Associates',
				year: 2007
			},
			{
				authors: 'Hedrick, P. W.',
				title: 'Genetics of Populations (4th ed.)',
				journal: 'Jones & Bartlett Publishers',
				year: 2011
			},
			{
				authors: 'Pearman, W.S., Urban, L. & Alexander, A.',
				title: 'Commonly used Hardy-Weinberg equilibrium filtering schemes impact population structure inferences using RADseq data',
				journal: 'Molecular Ecology Resources',
				year: 2022,
				doi: '10.1111/1755-0998.13646'
			}
		]
	}
};
