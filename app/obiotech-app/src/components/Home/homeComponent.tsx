import { Grid } from "@mui/material";
import "./style.css";

export function HomeComponent() {
  
  const renderForm = (
    <Grid container spacing={2} className="obiotech-home">
      <Grid item xs={5}>
        <h1 className="component-title">Welcome to OBioTech!</h1>
      </Grid>
      <Grid item xs={6}>
        <p className="description">OBioTech is a project whose main objective is the free access to tools for biotechnology.</p>
        <p className="description">Feel free to use and contribute to our tools.</p>
      </Grid>
    </Grid>
  );

  return (
    <div className="home">
        {renderForm}
    </div>
  );
}