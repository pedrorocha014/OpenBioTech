import axios, { AxiosResponse } from "axios";
import { ISendAnalysisDto } from "./interfaces/ISendAnalysisDto";
import { ISendDataResponse } from "./interfaces/ISendDataResponse";
import { ISendRMSDDto } from "./interfaces/ISendRMSDDto";


export async function sendAnalysisData(data:ISendAnalysisDto): Promise<AxiosResponse<ISendDataResponse>> {
    const url = 'https://obiotech-solution.azurewebsites.net/analysis/sequence';

    const result = await axios.post<ISendDataResponse>(url, data);

    return result;
}

export async function sendRMSDData(data:ISendRMSDDto): Promise<AxiosResponse<ISendDataResponse>> {
    const url = 'https://obiotech-solution.azurewebsites.net/analysis/rmsd';

    const formData = new FormData();

    formData.append('file', data.file);
    formData.append('type', data.type);

    const result = await axios.post<ISendDataResponse>(url, formData);

    return result;
}