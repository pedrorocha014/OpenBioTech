import { FormEvent } from "react";
import Button from '@mui/material/Button';
import TextField from '@mui/material/TextField';
import "./style.css";
import { ISendAnalysisDto } from "../../../services/interfaces/ISendAnalysisDto";
import { sendAnalysisData } from "../../../services/HttpClient";
import { Checkbox, FormControlLabel, FormGroup, FormLabel } from "@mui/material";

function ProteinForms() {

    async function analysisHandle(event: FormEvent) {
        event.preventDefault();

        const sequenceElement = (document.getElementById("outlined-multiline-sequence") as HTMLInputElement);
        const mutationElement = (document.getElementById("outlined-multiline-mutation") as HTMLInputElement);
        const replaceOperation = (document.getElementById('replace-checkbox') as HTMLInputElement).checked;
        const deleteOperation = (document.getElementById('delete-checkbox') as HTMLInputElement).checked;
        const insertOperation = (document.getElementById('insert-checkbox') as HTMLInputElement).checked;

        let data:ISendAnalysisDto = {
          sequence: sequenceElement.value,
          mutations: mutationElement.value,
          operations: []
        }

        if (replaceOperation){
          data.operations.push({ operation: "REPLACE" });
        }

        if (insertOperation){
          data.operations.push({ operation: "INSERT" });
        }

        if (deleteOperation){
          data.operations.push({ operation: "DELETE" });
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
            <FormLabel component="legend">Operations</FormLabel>
            <FormGroup>
              <FormControlLabel control={<Checkbox defaultChecked id="replace-checkbox"/>} label="Replace" />
              <FormControlLabel control={<Checkbox defaultChecked id="insert-checkbox"/>} label="Insert" />
              <FormControlLabel control={<Checkbox defaultChecked id="delete-checkbox"/>} label="Delete" />
            </FormGroup>
            <div className="button-container">
              <Button variant="outlined" type="submit">Send</Button>
            </div>
        </form>
      </div>
    );

    return (
      <div className="protein-form">
          {renderForm}
      </div>
    );
}


export default ProteinForms;