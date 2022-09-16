import axios from "axios";
import { ISendAnalysisDto } from "./interfaces/ISendAnalysisDto";

export async function sendAnalysisData(data:ISendAnalysisDto): Promise<boolean> {
    const url = 'https://localhost:44392/File';
    const result = await axios.post(url, data);

    return result.status == 200
}