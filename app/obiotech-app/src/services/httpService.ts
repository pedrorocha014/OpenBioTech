import axios, { AxiosResponse } from "axios";
import { ISendAnalysisDto } from "./interfaces/ISendAnalysisDto";
import { ISendDataResponse } from "./interfaces/ISendDataResponse";


export async function sendAnalysisData(data:ISendAnalysisDto): Promise<AxiosResponse<ISendDataResponse>> {
    const url = 'https://obiotech-solution.azurewebsites.net/analysis';
    const result = await axios.post<ISendDataResponse>(url, data);

    return result;
}