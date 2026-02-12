import type { HelpContent } from './types';
import { driftContent } from './_drift';
import { selectionMutationContent } from './_selection_mutation';
import { matingGeneflowContent } from './_mating_geneflow';
import { linkageFreqAdvancedContent } from './_linkage_freq_advanced';

export const helpContent: Record<string, HelpContent> = {
	...driftContent,
	...selectionMutationContent,
	...matingGeneflowContent,
	...linkageFreqAdvancedContent
};
