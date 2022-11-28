export interface ISendDataResponse {
    isSuccess: boolean;
    message: string;
    operation: string;
    value?: string;
    rmsdResult?: IRmsdValue[]
    normalizedModel?: IPdbModel
}

export interface IRmsdValue{
    models: string;
    rmsd: number;
}

export interface IPdbModel{
    id: number,
    atoms: IAtoms[]
}

export interface IAtoms{
    type: string;
    x: number
    y: number
    z: number
}