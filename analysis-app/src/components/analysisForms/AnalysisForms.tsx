import { FormEvent } from "react";
import Button from '@mui/material/Button';
import TextField from '@mui/material/TextField';
import "./style.css"
import { ISendAnalysisDto } from "../../services/interfaces/ISendAnalysisDto";
import { sendAnalysisData } from "../../services/HttpClient";

function AnalysisForms() {

    async function analysisHandle(event: FormEvent) {
        event.preventDefault();

        const data:ISendAnalysisDto = {
          sequence: (document.getElementById("outlined-multiline-sequence") as HTMLInputElement).value,
          mutations: (document.getElementById("outlined-multiline-mutation") as HTMLInputElement).value,
          operations: [{
            operation: (document.getElementById("outlined-basic-operation") as HTMLInputElement).value,
            values: (document.getElementById("outlined-basic-values") as HTMLInputElement).value
          }]
        }

        const succeeded = await sendAnalysisData(data);

        console.log(succeeded);
      }

    const renderForm = (
      <div className="form">
        <form id="form-box" onSubmit={(e) => analysisHandle(e)}>
            <div className="forms-fields">
                <TextField id="outlined-basic-operation" label="Operation" variant="outlined" defaultValue="Default Value"/>
                <TextField id="outlined-basic-values" label="Values" variant="outlined" defaultValue="Default Value"/>
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
      <div className="app">
        <div className="login-form">
          <h1>Protain Analysis Forms</h1>
          {renderForm}
        </div>
      </div>
    );
}


export default AnalysisForms;