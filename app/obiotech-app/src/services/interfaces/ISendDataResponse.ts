export interface ISendDataResponse {
    isSuccess: boolean;
    message: string;
    operation: string;
    value?: string;
    rmsdResult?: IRmsdValue[]
}

export interface IRmsdValue{
    models: string;
    rmsd: number;
}