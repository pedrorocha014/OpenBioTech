import axios from "axios";
import { FormEvent, useEffect, useState } from "react";
import Button from '@mui/material/Button';
import TextField from '@mui/material/TextField';
import "./style.css"

function AnalysisForms() {

    async function analysisHandle(event: FormEvent) {
        event.preventDefault();

        
      }

    const renderForm = (
      <div className="form">
        <form id="form-box" onSubmit={(e) => analysisHandle(e)}>
            <div className="forms-fields">
                <TextField id="outlined-basic operation" label="Operation" variant="outlined" defaultValue="Default Value"/>
                <TextField id="outlined-basic values" label="Values" variant="outlined" defaultValue="Default Value"/>
                <TextField
                  id="outlined-multiline-static protainSequenceText"
                  label="Protain Sequence"
                  multiline
                  rows={10}
                  defaultValue="Default Value"
                  className="multiline-text"
                />
                <TextField
                  id="outlined-multiline-static mutationText"
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