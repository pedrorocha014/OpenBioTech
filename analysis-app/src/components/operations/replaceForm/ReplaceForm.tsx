import { FormEvent } from "react";
import Button from '@mui/material/Button';
import TextField from '@mui/material/TextField';
import "./style.css";
import { ISendAnalysisDto } from "../../../services/interfaces/ISendAnalysisDto";
import { sendAnalysisData } from "../../../services/HttpClient";

function ReplaceForm() {

    async function analysisHandle(event: FormEvent) {
        event.preventDefault();

        const sequenceElement = (document.getElementById("outlined-multiline-sequence") as HTMLInputElement);
        const mutationElement = (document.getElementById("outlined-multiline-mutation") as HTMLInputElement);

        const operation = "REPLACE";

        const data:ISendAnalysisDto = {
          sequence: sequenceElement.value,
          mutations: mutationElement.value,
          operations: [{
            operation: operation
          }]
        }

        sequenceElement.value = "";
        mutationElement.value = "";
        
        const succeeded = await sendAnalysisData(data);

        alert(succeeded ? "Analysis requested successfully !" : "Error sending data !");
      }
      
    const renderForm = (
      <div className="form">
        <form id="form-box" onSubmit={(e) => analysisHandle(e)}>
            <div className="forms-fields">
                <TextField
                  id="outlined-multiline-sequence"
                  label="Protain Sequence"
                  multiline
                  rows={10}
                  defaultValue="Default Value"
                  className="multiline-text"
                />
                <TextField
                  id="outlined-multiline-mutation"
                  label="Mutations"
                  multiline
                  rows={10}
                  defaultValue="Default Value"
                  className="multiline-text"
                />
            </div>
            <div className="button-container">
              <Button variant="outlined" type="submit">Send</Button>
            </div>
        </form>
      </div>
    );

    return (
      <div className="login-form">
          {renderForm}
      </div>
    );
}


export default ReplaceForm;