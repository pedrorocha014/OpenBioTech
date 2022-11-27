import { Button, Grid, Paper, Table, TableBody, TableCell, TableContainer, TableHead, TableRow, TextField } from "@mui/material";
import { FormEvent, useState } from "react";
import * as ReactBootStrap from 'react-bootstrap'
import { sendRMSDData } from "../../../services/httpService";
import { IRmsdValue } from "../../../services/interfaces/ISendDataResponse";
import { IRMSDDto } from "../../../services/interfaces/IRMSDDto";

export function RmsdComponent() {

    const [loading, setLoading] = useState(false);
    const [rmsdData, setRmsdData] = useState<IRmsdValue[]>();
  
    async function analysisHandle(event: React.ChangeEvent<HTMLInputElement>) {
        event.preventDefault();

        const files = Array.from(event.target.files || []);

        const resultElement = (document.getElementById("result-multiline") as HTMLInputElement);

        let data:IRMSDDto = {
          file: files[0]
        }

        setLoading(true);
        const response = await sendRMSDData(data);
      
        alert(response.data.isSuccess ? "RMSD requested successfully !" : response.data.message );
      
        setRmsdData(response.data.rmsdResult || []);
        setLoading(false);
    }

    const form = (
      <Button
          variant="contained"
          component="label"
        >
        Upload File
        <input
          onChange={ (e) => analysisHandle(e) }
          type="file"
          hidden
        />
      </Button>
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
        <TableContainer component={Paper}>
          <Table sx={{ minWidth: 650 }} aria-label="simple table">
            <TableHead>
              <TableRow>
                <TableCell>Models</TableCell>
                <TableCell align="right">Values</TableCell>
              </TableRow>
            </TableHead>
            <TableBody>
              {rmsdData?.map((row) => (
                <TableRow
                  key={row.models}
                  sx={{ '&:last-child td, &:last-child th': { border: 0 } }}
                >
                  <TableCell component="th" scope="row">
                    {row.models}
                  </TableCell>
                  <TableCell align="right">{row.rmsd.toFixed(4)}</TableCell>
                </TableRow>
              ))}
            </TableBody>
          </Table>
        </TableContainer>
      </Grid>
    </Grid>
  );

  return (
    <div className="rmsd">
        {renderForm}
    </div>
  );
}