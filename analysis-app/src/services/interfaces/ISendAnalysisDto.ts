export interface Operation {
    operation: string;
    values: string;
}

export interface ISendAnalysisDto {
    sequence: string;
    mutations: string;
    operations: Operation[];
}