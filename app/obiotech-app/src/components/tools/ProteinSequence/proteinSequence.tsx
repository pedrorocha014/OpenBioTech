import Button from '@mui/material/Button';
import TextField from '@mui/material/TextField';
import "./style.css";
import { FormGroup, FormLabel, Grid } from "@mui/material";
import { FormEvent, useState } from "react";
import { sendAnalysisData } from "../../../services/httpService";
import { ISendAnalysisDto } from "../../../services/interfaces/ISendAnalysisDto";
import * as ReactBootStrap from 'react-bootstrap'

export function ProteinSequence() {

  const [loading, setLoading] = useState(false);

  async function analysisHandle(event: FormEvent) {
    event.preventDefault();

    const sequenceElement = (document.getElementById("outlined-multiline-sequence") as HTMLInputElement);
    const mutationElement = (document.getElementById("outlined-multiline-mutation") as HTMLInputElement);
    const resultElement = (document.getElementById("result-multiline-mutation") as HTMLInputElement);

    let data:ISendAnalysisDto = {
      sequence: sequenceElement.value,
      mutations: mutationElement.value,
      type: "protein_sequence"
    }

    sequenceElement.value = "";
    mutationElement.value = "";
    
    setLoading(true);
    const response = await sendAnalysisData(data);

    alert(response.data.isSuccess ? "Analysis requested successfully !" : response.data.message );

    resultElement.value = response.data.value.replaceAll('[', '').replaceAll(']','').replaceAll('"','').replaceAll(',','');
    setLoading(false);
  }

  const form = (
    <form id="form-box" onSubmit={(e) => analysisHandle(e)}>
      <div className="forms-fields">
          <TextField
            id="outlined-multiline-sequence"
            label="Sequence"
            multiline
            rows={10}
            className="multiline-text"
          />
          <TextField
            id="outlined-multiline-mutation"
            label="Mutations"
            multiline
            rows={10}
            className="multiline-text"
          />
      </div>
      <div className="button-container">
        <Button variant="outlined" type="submit">Send</Button>
      </div>
    </form>
  );
  
  const renderForm = (
    <Grid container spacing={2} className="protein-sequence">
      <Grid item xs={12}>
        <h1 className="component-title">Sequence</h1>
      </Grid>
      <Grid item xs={12}>
        <h1 className="grid-title">What ?</h1>
      </Grid>
      <Grid item xs={12}>
        <p className="description">Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged.</p>
        <p className="description">It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.</p>
      </Grid>
      <Grid item xs={12}>
        <h1 className="grid-title">How To Use</h1>
      </Grid>
      <Grid item xs={12}>
        <p className="description">Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged.</p>
      </Grid>
      <Grid item xs={12}>
        <h1 className="grid-title">Sequence Forms</h1>
      </Grid>
      <Grid item xs={12}>
        { loading ? <ReactBootStrap.Spinner animation="border" /> : form}
      </Grid>
      <Grid item xs={12}>
        <h1 className="grid-title">Result</h1>
      </Grid>
      <Grid item xs={12}>
        <TextField
          id="result-multiline-mutation"
          label="Result"
          multiline
          rows={10}
          defaultValue="Default Value"
          className="multiline-text"
        />
      </Grid>
    </Grid>
  );

  return (
    <div className="protein-form">
        { renderForm }
    </div>
  );
}