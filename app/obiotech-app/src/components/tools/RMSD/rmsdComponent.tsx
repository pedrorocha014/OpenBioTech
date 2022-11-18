import { Button, Grid, TextField } from "@mui/material";
import { FormEvent, useState } from "react";
import * as ReactBootStrap from 'react-bootstrap'

export function RmsdComponent() {

    const [loading, setLoading] = useState(false);
  
    async function analysisHandle(event: FormEvent) {
        event.preventDefault();
    }

    const form = (
      <form id="form-box" onSubmit={(e) => analysisHandle(e)}>
        <div className="forms-fields">
            <TextField
              id="rmsd-input-multiline"
              label="Raw Data"
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
        <h1 className="component-title">RMSD</h1>
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
        <h1 className="grid-title">RMSD Forms</h1>
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
    <div className="rmsd">
        {renderForm}
    </div>
  );
}