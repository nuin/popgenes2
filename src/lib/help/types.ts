export interface Formula {
	label?: string;
	html: string;
}

export interface ParameterHelp {
	name: string;
	description: string;
}

export interface Reference {
	authors: string;
	title: string;
	journal?: string;
	year: number;
	doi?: string;
}

export interface HelpContent {
	title: string;
	category: string;
	description: string;
	formulas: Formula[];
	parameters: ParameterHelp[];
	insights: string[];
	references: Reference[];
}
