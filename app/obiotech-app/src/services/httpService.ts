import axios, { AxiosResponse } from "axios";
import { ISequenceDto } from "./interfaces/ISequenceDto";
import { ISendDataResponse } from "./interfaces/ISendDataResponse";
import { IRMSDDto } from "./interfaces/IRMSDDto";
import { IProteinVisualizationDto } from "./interfaces/IProteinVisualizationDto";


export async function sendAnalysisData(data:ISequenceDto): Promise<AxiosResponse<ISendDataResponse>> {
    const url = 'https://obiotech-solution.azurewebsites.net/operation/sequence';
    //const url = 'https://localhost:7165/operation/sequence';

    const result = await axios.post<ISendDataResponse>(url, data);

    return result;
}

export async function sendRMSDData(data:IRMSDDto): Promise<AxiosResponse<ISendDataResponse>> {
    const url = 'https://obiotech-solution.azurewebsites.net/operation/rmsd';
    //const url = 'https://localhost:7165/operation/rmsd';    

    const formData = new FormData();

    formData.append('file', data.file);

    const result = await axios.post<ISendDataResponse>(url, formData);

    return result;
}

export async function sendProteinVisualizationData(data:IProteinVisualizationDto): Promise<AxiosResponse<ISendDataResponse>> {
    const url = 'https://obiotech-solution.azurewebsites.net/operation/proteinVizualization';
    //const url = 'https://localhost:7165/Operation/proteinVizualization';    

    const formData = new FormData();

    formData.append('file', data.file);
    formData.append('modelNumber', data.modelNumber);

    const result = await axios.post<ISendDataResponse>(url, formData);

    return result;
}