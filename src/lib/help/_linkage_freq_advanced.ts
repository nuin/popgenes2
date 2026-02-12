import type { HelpContent } from './types';

export const linkageFreqAdvancedContent: Record<string, HelpContent> = {
	'/linkage/disequilibrium': {
		title: 'Linkage Disequilibrium',
		category: 'Linkage',
		description:
			'Computes linkage disequilibrium (LD) between two loci from observed gamete counts. LD measures the non-random association of alleles at different loci: when alleles co-occur on the same gamete more (or less) often than expected by chance, the loci are in linkage disequilibrium. This module calculates D, the disequilibrium coefficient, and tests its significance with a chi-square statistic.',
		formulas: [
			{
				label: 'Disequilibrium coefficient',
				html: '<var>D</var> = <var>f</var><sub>AB</sub> \u00b7 <var>f</var><sub>ab</sub> \u2212 <var>f</var><sub>Ab</sub> \u00b7 <var>f</var><sub>aB</sub>'
			},
			{
				label: 'Equivalently',
				html: '<var>D</var> = <var>f</var><sub>AB</sub> \u2212 <var>p</var><sub>A</sub> \u00b7 <var>p</var><sub>B</sub>'
			},
			{
				label: 'Decay over generations',
				html: '<var>D</var>(<var>t</var>) = <var>D</var><sub>0</sub>(1 \u2212 <var>r</var>)<sup><var>t</var></sup>'
			},
			{
				label: 'Chi-square test',
				html: '\u03c7\u00b2 = <span class="frac"><span class="frac-num"><var>N</var> \u00b7 <var>D</var>\u00b2</span><span class="frac-den"><var>p</var><sub>A</sub> \u00b7 <var>p</var><sub>a</sub> \u00b7 <var>p</var><sub>B</sub> \u00b7 <var>p</var><sub>b</sub></span></span>, df = 1'
			}
		],
		parameters: [
			{
				name: 'nAB',
				description: 'Observed count of AB gametes (haplotype carrying alleles A and B)'
			},
			{
				name: 'nAb',
				description: 'Observed count of Ab gametes (haplotype carrying alleles A and b)'
			},
			{
				name: 'naB',
				description: 'Observed count of aB gametes (haplotype carrying alleles a and B)'
			},
			{
				name: 'nab',
				description: 'Observed count of ab gametes (haplotype carrying alleles a and b)'
			}
		],
		insights: [
			'LD decays exponentially over generations at a rate proportional to the recombination rate r between the two loci.',
			'Complete decay of LD requires free recombination (r = 0.5); even so, the half-life is only about 1.4 generations, making LD short-lived unless actively maintained.',
			'Physical proximity of loci on the same chromosome reduces recombination and slows LD decay, which is why tightly linked markers retain LD across many generations.',
			'LD is the foundation of association mapping (GWAS): a marker can serve as a proxy for a causal variant only if the two are in substantial LD.'
		],
		references: [
			{
				authors: 'Lewontin, R.C.',
				title: 'The interaction of selection and linkage. I. General considerations; heterotic models',
				journal: 'Genetics',
				year: 1964,
				doi: '10.1093/genetics/49.1.49'
			},
			{
				authors: 'Hill, W.G. & Robertson, A.',
				title: 'Linkage disequilibrium in finite populations',
				journal: 'Theoretical and Applied Genetics',
				year: 1968,
				doi: '10.1007/BF01245622'
			},
			{
				authors: 'Hedrick, P.W.',
				title: 'Genetics of Populations',
				year: 2011
			},
			{
				authors: 'Huang, X., Zhu, T.-N., Liu, Y.-C., Qi, G.-A., Zhang, J.-N. & Chen, G.-B.',
				title: 'Efficient estimation for large-scale linkage disequilibrium patterns of the human genome',
				journal: 'eLife',
				year: 2023,
				doi: '10.7554/eLife.90636'
			}
		]
	},

	'/linkage/magnitude': {
		title: 'Magnitude of D',
		category: 'Linkage',
		description:
			'Visualizes the decay of linkage disequilibrium over time using normalized measures. The raw disequilibrium coefficient D depends on allele frequencies and is not directly comparable across loci pairs. Normalized measures such as D\u2032 and r\u00b2 address this limitation and provide standardized assessments of LD magnitude suitable for cross-locus and cross-population comparisons.',
		formulas: [
			{
				label: 'D decay over time',
				html: '<var>D</var>(<var>t</var>) = (1 \u2212 <var>r</var>)<sup><var>t</var></sup> \u00b7 <var>D</var><sub>0</sub>'
			},
			{
				label: 'Lewontin\'s D\u2032',
				html: '<var>D</var>\u2032 = <span class="frac"><span class="frac-num"><var>D</var></span><span class="frac-den"><var>D</var><sub>max</sub></span></span>, where <var>D</var><sub>max</sub> = min(<var>p</var><sub>A</sub><var>p</var><sub>b</sub>, <var>p</var><sub>a</sub><var>p</var><sub>B</sub>) if <var>D</var> > 0'
			},
			{
				label: 'Correlation coefficient r\u00b2',
				html: '<var>r</var>\u00b2 = <span class="frac"><span class="frac-num"><var>D</var>\u00b2</span><span class="frac-den"><var>p</var><sub>A</sub> \u00b7 <var>p</var><sub>a</sub> \u00b7 <var>p</var><sub>B</sub> \u00b7 <var>p</var><sub>b</sub></span></span>'
			}
		],
		parameters: [
			{
				name: 'r',
				description: 'Recombination rate between the two loci (range 0 to 0.5, where 0.5 is free recombination)'
			},
			{
				name: 'D\u2080',
				description: 'Initial value of the disequilibrium coefficient D at generation 0'
			},
			{
				name: 'Gen',
				description: 'Number of generations over which to track D decay'
			}
		],
		insights: [
			'Raw D is not standardized and depends heavily on allele frequencies, making comparisons across loci pairs misleading without normalization.',
			'D\u2032 (Lewontin\'s D-prime) ranges from \u22121 to 1 and indicates whether all possible haplotypes are present; |D\u2032| = 1 means at least one haplotype is absent.',
			'r\u00b2 is a better predictor of the power to detect association between a marker and a causal variant, and is preferred in GWAS study design.',
			'Different LD measures can tell different stories about the same pair of loci: D\u2032 can be 1.0 while r\u00b2 is low if allele frequencies differ substantially between the two loci.'
		],
		references: [
			{
				authors: 'Lewontin, R.C.',
				title: 'The interaction of selection and linkage. I. General considerations; heterotic models',
				journal: 'Genetics',
				year: 1964,
				doi: '10.1093/genetics/49.1.49'
			},
			{
				authors: 'Hill, W.G. & Robertson, A.',
				title: 'Linkage disequilibrium in finite populations',
				journal: 'Theoretical and Applied Genetics',
				year: 1968,
				doi: '10.1007/BF01245622'
			},
			{
				authors: 'Devlin, B. & Risch, N.',
				title: 'A comparison of linkage disequilibrium measures for fine-scale mapping',
				journal: 'Genomics',
				year: 1995,
				doi: '10.1006/geno.1995.9003'
			},
			{
				authors: 'Kang, J.T.L. & Rosenberg, N.A.',
				title: 'Mathematical properties of linkage disequilibrium statistics defined by normalization of the coefficient D = pAB − pApB',
				journal: 'Human Heredity',
				year: 2019,
				doi: '10.1159/000504171'
			}
		]
	},

	'/linkage/histogram': {
		title: 'Linkage Histogram',
		category: 'Linkage',
		description:
			'Displays a side-by-side histogram comparison of observed and expected gamete frequencies under the assumption of linkage equilibrium. The observed frequencies are computed directly from gamete counts, while expected frequencies are derived from allele frequencies assuming independence between loci. Visual differences between the two histograms reveal the presence and direction of linkage disequilibrium.',
		formulas: [
			{
				label: 'Observed gamete frequency',
				html: '<var>f</var><sub>AB</sub> = <span class="frac"><span class="frac-num"><var>n</var><sub>AB</sub></span><span class="frac-den"><var>N</var></span></span>'
			},
			{
				label: 'Expected frequency under equilibrium',
				html: '<var>E</var>(<var>f</var><sub>AB</sub>) = <var>p</var><sub>A</sub> \u00b7 <var>p</var><sub>B</sub>'
			},
			{
				label: 'Disequilibrium coefficient',
				html: '<var>D</var> = <var>f</var><sub>AB</sub> \u2212 <var>p</var><sub>A</sub> \u00b7 <var>p</var><sub>B</sub>'
			}
		],
		parameters: [
			{
				name: 'nAB',
				description: 'Observed count of AB gametes'
			},
			{
				name: 'nAb',
				description: 'Observed count of Ab gametes'
			},
			{
				name: 'naB',
				description: 'Observed count of aB gametes'
			},
			{
				name: 'nab',
				description: 'Observed count of ab gametes'
			}
		],
		insights: [
			'Genome-wide patterns of LD reveal population history: recent bottlenecks, admixture events, and population structure all leave characteristic LD signatures.',
			'Populations that have experienced bottlenecks or founder events show elevated LD across the genome compared to large, stable populations.',
			'The distribution of LD across locus pairs helps determine the marker density needed for genome-wide association studies in a given population.',
			'When observed and expected histograms are nearly identical, the loci are in linkage equilibrium and alleles at the two loci segregate independently.'
		],
		references: [
			{
				authors: 'Kruglyak, L.',
				title: 'Prospects for whole-genome linkage disequilibrium mapping of common disease genes',
				journal: 'Nature Genetics',
				year: 1999,
				doi: '10.1038/9642'
			},
			{
				authors: 'Reich, D.E., Cargill, M., Bolk, S., Ireland, J., Sabeti, P.C., Richter, D.J., Lavery, T., Kouyoumjian, R., Farhadian, S.F., Ward, R. & Lander, E.S.',
				title: 'Linkage disequilibrium in the human genome',
				journal: 'Nature',
				year: 2001,
				doi: '10.1038/35075590'
			},
			{
				authors: 'Pritchard, J.K. & Przeworski, M.',
				title: 'Linkage disequilibrium in humans: models and data',
				journal: 'American Journal of Human Genetics',
				year: 2001,
				doi: '10.1086/321275'
			},
			{
				authors: 'Zhang, R., Wu, H., Li, Y., Huang, Z., Yin, Z., Yang, C.-X. & Du, Z.-Q.',
				title: 'GWLD: an R package for genome-wide linkage disequilibrium analysis',
				journal: 'G3: Genes, Genomes, Genetics',
				year: 2023,
				doi: '10.1093/g3journal/jkad154'
			}
		]
	},

	'/frequencies/genotype': {
		title: 'Genotype Frequencies',
		category: 'Frequencies',
		description:
			'Plots Hardy-Weinberg equilibrium genotype frequency curves as a function of allele frequency. For a biallelic locus with alleles A (frequency p) and a (frequency q = 1 \u2212 p), the three genotype frequencies are given by the Hardy-Weinberg proportions. The resulting curves show how homozygote and heterozygote frequencies change across the full range of allele frequencies from 0 to 1.',
		formulas: [
			{
				label: 'AA homozygote frequency',
				html: 'P(AA) = <var>p</var><sup>2</sup>'
			},
			{
				label: 'Heterozygote frequency',
				html: 'P(Aa) = 2<var>p</var><var>q</var>'
			},
			{
				label: 'aa homozygote frequency',
				html: 'P(aa) = <var>q</var><sup>2</sup>'
			},
			{
				label: 'Allele frequency constraint',
				html: '<var>p</var> + <var>q</var> = 1'
			}
		],
		parameters: [
			{
				name: 'P(A)',
				description: 'Allele frequency of A (range 0 to 1); the x-axis of the curve plot. q is computed as 1 \u2212 p.'
			}
		],
		insights: [
			'Hardy-Weinberg equilibrium is achieved in a single generation of random mating, regardless of the initial genotype frequencies.',
			'HWE requires five idealized conditions: infinite population size, random mating, no selection, no mutation, and no migration.',
			'The heterozygote frequency 2pq is maximized when p = q = 0.5, reaching a maximum of 0.5. Rare alleles contribute disproportionately few heterozygotes.',
			'HWE serves as the null hypothesis in population genetics: deviations from expected proportions indicate one or more evolutionary forces are acting on the population.'
		],
		references: [
			{
				authors: 'Hardy, G.H.',
				title: 'Mendelian proportions in a mixed population',
				journal: 'Science',
				year: 1908,
				doi: '10.1126/science.28.706.49'
			},
			{
				authors: 'Weinberg, W.',
				title: '\u00dcber den Nachweis der Vererbung beim Menschen',
				journal: 'Jahreshefte des Vereins f\u00fcr vaterl\u00e4ndische Naturkunde in W\u00fcrttemberg',
				year: 1908
			},
			{
				authors: 'Hedrick, P.W.',
				title: 'Genetics of Populations',
				year: 2011
			},
			{
				authors: 'Abramovs, N., Brass, A. & Tassabehji, M.',
				title: 'Hardy-Weinberg Equilibrium in the Large Scale Genomic Sequencing Era',
				journal: 'Frontiers in Genetics',
				year: 2020,
				doi: '10.3389/fgene.2020.00210'
			}
		]
	},

	'/frequencies/chi-square': {
		title: 'Chi-Square HWE Test',
		category: 'Frequencies',
		description:
			'Performs a chi-square goodness-of-fit test to determine whether observed genotype frequencies deviate significantly from Hardy-Weinberg equilibrium expectations. Allele frequencies are estimated from the observed data, expected genotype counts are computed from HWE proportions, and the chi-square statistic is evaluated against the critical value at the 0.05 significance level with 1 degree of freedom.',
		formulas: [
			{
				label: 'Allele frequency estimation',
				html: '<var>p</var> = <span class="frac"><span class="frac-num">2 \u00b7 N<sub>AA</sub> + N<sub>Aa</sub></span><span class="frac-den">2<var>N</var></span></span>'
			},
			{
				label: 'Expected genotype counts',
				html: 'E(AA) = <var>p</var><sup>2</sup><var>N</var>, E(Aa) = 2<var>p</var><var>q</var><var>N</var>, E(aa) = <var>q</var><sup>2</sup><var>N</var>'
			},
			{
				label: 'Chi-square statistic',
				html: '\u03c7\u00b2 = \u03a3 <span class="frac"><span class="frac-num">(O \u2212 E)\u00b2</span><span class="frac-den">E</span></span>, df = 1'
			},
			{
				label: 'Critical value',
				html: '\u03c7\u00b2<sub>0.05, 1</sub> = 3.841'
			}
		],
		parameters: [
			{
				name: 'N(AA)',
				description: 'Observed count of AA homozygotes in the sample'
			},
			{
				name: 'N(Aa)',
				description: 'Observed count of Aa heterozygotes in the sample'
			},
			{
				name: 'N(aa)',
				description: 'Observed count of aa homozygotes in the sample'
			}
		],
		insights: [
			'The test has 1 degree of freedom for two alleles, not 2, because one parameter (allele frequency) is estimated from the data, reducing the degrees of freedom from 3 genotype classes minus 1 constraint minus 1 estimated parameter.',
			'A significant chi-square value (exceeding 3.841 at alpha = 0.05) indicates that the observed genotype frequencies deviate from HWE expectations, suggesting one or more evolutionary forces are acting.',
			'Common causes of HWE departure include non-random mating (inbreeding produces heterozygote deficit), population structure (Wahlund effect), selection acting on the locus, and genotyping errors.',
			'The chi-square test assumes large sample sizes; for small samples or rare genotypes, an exact test (such as the method of Wigginton et al. 2005) is more appropriate.'
		],
		references: [
			{
				authors: 'Emigh, T.H.',
				title: 'A comparison of tests for Hardy-Weinberg equilibrium',
				journal: 'Biometrics',
				year: 1980,
				doi: '10.2307/2556115'
			},
			{
				authors: 'Wigginton, J.E., Cutler, D.J. & Abecasis, G.R.',
				title: 'A note on exact tests of Hardy-Weinberg equilibrium',
				journal: 'American Journal of Human Genetics',
				year: 2005,
				doi: '10.1086/429864'
			},
			{
				authors: 'Hartl, D.L. & Clark, A.G.',
				title: 'Principles of Population Genetics',
				year: 2007
			},
			{
				authors: 'Graffelman, J.',
				title: 'Exploring Diallelic Genetic Markers: The HardyWeinberg Package',
				journal: 'Journal of Statistical Software',
				year: 2015,
				doi: '10.18637/jss.v064.i03'
			}
		]
	},

	'/definetti': {
		title: 'De Finetti Diagram',
		category: 'Frequencies',
		description:
			'A triangular coordinate plot that represents the full space of possible genotype frequencies for a biallelic locus. The three vertices correspond to the three homozygous/heterozygous genotype classes. A parabola within the triangle traces all populations at Hardy-Weinberg equilibrium. Points plotted above the parabola indicate heterozygote excess, while points below indicate heterozygote deficit, providing an immediate visual assessment of departure from HWE.',
		formulas: [
			{
				label: 'HWE parabola',
				html: 'P(Aa) = 2\u221a(P(AA) \u00b7 P(aa))'
			},
			{
				label: 'Allele frequency from genotype frequencies',
				html: '<var>p</var> = P(AA) + <span class="frac"><span class="frac-num">P(Aa)</span><span class="frac-den">2</span></span>'
			},
			{
				label: 'HWE heterozygote expectation',
				html: 'P(Aa)<sub>HWE</sub> = 2<var>p</var>(1 \u2212 <var>p</var>)'
			}
		],
		parameters: [
			{
				name: 'P(AA)',
				description: 'Frequency of the AA homozygote genotype (range 0 to 1)'
			},
			{
				name: 'P(Aa)',
				description: 'Frequency of the Aa heterozygote genotype (range 0 to 1); P(aa) is computed as 1 \u2212 P(AA) \u2212 P(Aa)'
			}
		],
		insights: [
			'The HWE parabola represents all possible populations that are in Hardy-Weinberg equilibrium; every point on the parabola corresponds to a unique allele frequency p.',
			'The vertical distance from a plotted point to the parabola measures the departure from HWE: above indicates heterozygote excess, below indicates deficit.',
			'Inbreeding systematically moves population points below the parabola by converting heterozygotes into homozygotes, while heterozygote advantage (overdominance) moves populations above it.',
			'The diagram was devised by the Italian mathematician Bruno de Finetti in 1926 and independently applied to population genetics by Edwards and others in the 1960s.'
		],
		references: [
			{
				authors: 'De Finetti, B.',
				title: 'Considerazioni matematiche sull\'ereditariet\u00e0 mendeliana',
				journal: 'Metron',
				year: 1926
			},
			{
				authors: 'Cannings, C. & Edwards, A.W.F.',
				title: 'Natural selection and the de Finetti diagram',
				journal: 'Annals of Human Genetics',
				year: 1968,
				doi: '10.1111/j.1469-1809.1968.tb00575.x'
			},
			{
				authors: 'Hedrick, P.W.',
				title: 'Genetics of Populations',
				year: 2011
			},
			{
				authors: 'Graffelman, J.',
				title: 'Exploring Diallelic Genetic Markers: The HardyWeinberg Package',
				journal: 'Journal of Statistical Software',
				year: 2015,
				doi: '10.18637/jss.v064.i03'
			}
		]
	},

	'/advanced/molecular': {
		title: 'Molecular Population Genetics',
		category: 'Advanced',
		description:
			'Computes standard summary statistics of molecular variation from sequence data parameters, including Watterson\'s theta, nucleotide diversity, and Tajima\'s D. These statistics form the core toolkit for detecting departures from neutral evolution and inferring the demographic and selective history of populations from DNA sequence data.',
		formulas: [
			{
				label: 'Watterson\'s estimator',
				html: '\u03b8<sub>W</sub> = <span class="frac"><span class="frac-num"><var>S</var></span><span class="frac-den"><var>a</var><sub>1</sub></span></span>, where <var>a</var><sub>1</sub> = \u03a3<sub><var>i</var>=1</sub><sup><var>n</var>\u22121</sup> <span class="frac"><span class="frac-num">1</span><span class="frac-den"><var>i</var></span></span>'
			},
			{
				label: 'Nucleotide diversity',
				html: '\u03c0 = <span class="frac"><span class="frac-num"><var>k\u0302</var></span><span class="frac-den"><var>L</var></span></span> (average pairwise differences per site)'
			},
			{
				label: 'Tajima\'s D',
				html: '<var>D</var> = <span class="frac"><span class="frac-num">\u03c0 \u2212 \u03b8<sub>W</sub></span><span class="frac-den">\u221a(Var(\u03c0 \u2212 \u03b8<sub>W</sub>))</span></span>'
			},
			{
				label: 'Jukes-Cantor distance',
				html: '<var>d</var> = \u2212<span class="frac"><span class="frac-num">3</span><span class="frac-den">4</span></span> \u00b7 ln(1 \u2212 <span class="frac"><span class="frac-num">4</span><span class="frac-den">3</span></span> \u00b7 <var>p</var><sub>diff</sub>)'
			}
		],
		parameters: [
			{
				name: 'n (seqs)',
				description: 'Number of sequences sampled from the population'
			},
			{
				name: 'S (sites)',
				description: 'Number of segregating (polymorphic) sites observed in the alignment'
			},
			{
				name: 'L (length)',
				description: 'Total alignment length in nucleotide sites'
			},
			{
				name: 'k\u0302 (diffs)',
				description: 'Average number of pairwise nucleotide differences between sequences'
			}
		],
		insights: [
			'Under strict neutrality, both \u03b8_W and \u03c0 estimate the same parameter (4N\u2091\u03bc), so Tajima\'s D is expected to be near zero. Significant departures indicate selection or demographic events.',
			'Positive Tajima\'s D (D > 2) suggests balancing selection maintaining multiple alleles or a recent population contraction that has eliminated rare variants.',
			'Negative Tajima\'s D (D < \u22122) suggests purifying selection removing deleterious variants or a recent population expansion that has generated an excess of rare variants.',
			'The molecular clock hypothesis predicts that neutral substitutions accumulate at a constant rate over time, allowing sequence divergence to be used as a molecular chronometer for dating evolutionary events.'
		],
		references: [
			{
				authors: 'Kimura, M.',
				title: 'The Neutral Theory of Molecular Evolution',
				year: 1983,
				doi: '10.1017/CBO9780511623486'
			},
			{
				authors: 'Jukes, T.H. & Cantor, C.R.',
				title: 'Evolution of protein molecules',
				journal: 'Mammalian Protein Metabolism',
				year: 1969,
				doi: '10.1016/B978-1-4832-3211-9.50009-7'
			},
			{
				authors: 'Tajima, F.',
				title: 'Statistical method for testing the neutral mutation hypothesis by DNA polymorphism',
				journal: 'Genetics',
				year: 1989,
				doi: '10.1093/genetics/123.3.585'
			},
			{
				authors: 'Hudson, R.R.',
				title: 'Gene genealogies and the coalescent process',
				journal: 'Oxford Surveys in Evolutionary Biology',
				year: 1990
			},
			{
				authors: 'Johri, P., Aquadro, C.F., Beaumont, M. et al.',
				title: 'Recommendations for improving statistical inference in population genomics',
				journal: 'PLOS Biology',
				year: 2022,
				doi: '10.1371/journal.pbio.3001669'
			}
		]
	},

	'/advanced/qtl': {
		title: 'Quantitative Trait Loci',
		category: 'Advanced',
		description:
			'Simulates the evolution of a quantitative trait controlled by multiple loci (QTLs) in a finite population. Each individual carries a diploid genotype at multiple loci with additive allelic effects. Phenotypic values are the sum of genotypic values plus environmental noise drawn from a normal distribution. The simulation tracks allele frequencies at each locus, mean phenotypic and genotypic values, genetic and phenotypic variance, and narrow-sense heritability over generations.',
		formulas: [
			{
				label: 'Phenotypic value',
				html: '<var>P</var> = <var>G</var> + <var>E</var>, where <var>G</var> = \u03a3(<var>allele count</var><sub><var>i</var></sub> \u00b7 \u03b1) and <var>E</var> ~ N(0, \u03c3\u00b2<sub>E</sub>)'
			},
			{
				label: 'Allelic effect',
				html: '\u03b1 = <span class="frac"><span class="frac-num"><var>G</var><sub>max</sub></span><span class="frac-den">2 \u00b7 <var>n</var><sub>QTL</sub></span></span>'
			},
			{
				label: 'Phenotypic variance partition',
				html: '<var>V</var><sub>P</sub> = <var>V</var><sub>G</sub> + <var>V</var><sub>E</sub>'
			},
			{
				label: 'Narrow-sense heritability',
				html: '<var>h</var>\u00b2 = <span class="frac"><span class="frac-num"><var>V</var><sub>G</sub></span><span class="frac-den"><var>V</var><sub>P</sub></span></span>'
			},
			{
				label: 'Breeder\'s equation',
				html: '<var>R</var> = <var>h</var>\u00b2 \u00b7 <var>S</var> (response to selection = heritability \u00d7 selection differential)'
			}
		],
		parameters: [
			{
				name: 'N',
				description: 'Diploid population size (number of individuals)'
			},
			{
				name: 'QTL',
				description: 'Number of quantitative trait loci contributing additively to the trait'
			},
			{
				name: 'Gen',
				description: 'Number of generations to simulate'
			},
			{
				name: 'p\u2080',
				description: 'Initial frequency of the positive-effect allele at each QTL locus'
			},
			{
				name: 'Ve',
				description: 'Environmental variance added to each individual\'s phenotype as Gaussian noise'
			},
			{
				name: 'Sel',
				description: 'Selection strength (0 = neutral drift only; higher values impose stronger directional selection favoring higher phenotypic values)'
			}
		],
		insights: [
			'Most traits of biological and economic importance (height, disease risk, crop yield) are quantitative, controlled by many loci each of small effect plus environmental variation.',
			'Additive genetic variance determines the response to selection: the breeder\'s equation R = h\u00b2S predicts that traits with higher heritability respond more rapidly to selection.',
			'Genetic drift erodes additive genetic variance over time, especially in small populations, reducing heritability and the capacity for further adaptive response.',
			'QTL mapping identifies genomic regions contributing to trait variation by testing for associations between marker genotypes and phenotypic values across a segregating population.'
		],
		references: [
			{
				authors: 'Falconer, D.S. & Mackay, T.F.C.',
				title: 'Introduction to Quantitative Genetics',
				year: 1996
			},
			{
				authors: 'Lynch, M. & Walsh, B.',
				title: 'Genetics and Analysis of Quantitative Traits',
				year: 1998
			},
			{
				authors: 'Lander, E.S. & Botstein, D.',
				title: 'Mapping Mendelian factors underlying quantitative traits using RFLP linkage maps',
				journal: 'Genetics',
				year: 1989,
				doi: '10.1093/genetics/121.1.185'
			},
			{
				authors: 'Visscher, P.M., Wray, N.R., Zhang, Q. et al.',
				title: '10 Years of GWAS Discovery: Biology, Function, and Translation',
				journal: 'The American Journal of Human Genetics',
				year: 2017,
				doi: '10.1016/j.ajhg.2017.06.005'
			},
			{
				authors: 'Uffelmann, E., Huang, Q.Q., Munung, N.S. et al.',
				title: 'Genome-wide association studies',
				journal: 'Nature Reviews Methods Primers',
				year: 2021,
				doi: '10.1038/s43586-021-00056-9'
			}
		]
	}
};
