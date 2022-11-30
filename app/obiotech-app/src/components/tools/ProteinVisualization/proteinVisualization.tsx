import * as THREE from 'three'
import { createRoot } from 'react-dom/client'
import * as ReactBootStrap from 'react-bootstrap'
import React, { useEffect, useRef, useState } from 'react'
import { Canvas, useFrame, ThreeElements, useThree, Vector3 } from '@react-three/fiber'
import { Button, Grid, Paper, Table, TableBody, TableCell, TableContainer, TableHead, TableRow, TextField } from "@mui/material";
import { IProteinVisualizationDto } from '../../../services/interfaces/IProteinVisualizationDto';
import { sendProteinVisualizationData } from '../../../services/httpService';
import { IAtoms } from '../../../services/interfaces/ISendDataResponse'
const { OrbitControls } = require("@react-three/drei");


const atomsColorDictionary = new Map([
  ["C", "black"],
  ["N", "brown"],
  ["H", "blue"],
  ["O",  "red"],
  ["S",  "orange"]
]);

interface SphereInterface{
  positionArray: number[],
  atomType: string
}

function Sphere({positionArray, atomType}: SphereInterface) {
  const ref = useRef<THREE.Mesh>(null!)
  const [hovered, hover] = useState(false)
  const [clicked, click] = useState(false)

  return (
    <mesh
      position={[positionArray[0], positionArray[1], positionArray[2]]}
      ref={ref}
      scale={clicked ? 0.5 : 0.2}
      onClick={(event) => click(!clicked)}
      onPointerOver={(event) => hover(true)}
      onPointerOut={(event) => hover(false)}>
      <sphereGeometry args={[1, 10, 10]} />
      <meshStandardMaterial color={atomsColorDictionary.get(atomType)} />
    </mesh>
  )
}

export function ProteinVisualization() {

    const [loading, setLoading] = useState(false);
    const [atomData, setAtomData] = useState<IAtoms[]>();
  
    async function analysisHandle(event: React.ChangeEvent<HTMLInputElement>) {
        event.preventDefault();

        const files = Array.from(event.target.files || []);

        //const resultElement = (document.getElementById("result-multiline") as HTMLInputElement);

        let data:IProteinVisualizationDto = {
          file: files[0],
          modelNumber: "1"
        }

        setLoading(true);
        const response = await sendProteinVisualizationData(data);
        setAtomData(response.data.normalizedModel?.atoms || [])
        console.log(atomData);
        setLoading(false);
    }

  const form = (
    <Button
        variant="contained"
        component="label"
      >
      Upload PDB File
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
        <h1 className="component-title">Protein Visualization</h1>
      </Grid>
      <Grid item xs={12}>
        <h1 className="grid-title">Visualization Forms</h1>
      </Grid>
      <Grid item xs={12}>
        { loading ? <ReactBootStrap.Spinner animation="border" /> : form}
      </Grid>
      <Grid item xs={12}>
        <h1 className="grid-title">Result</h1>
      </Grid>
      <Grid item xs={12} style={{ width: "50vw", height: "50vh" }}>
      <Canvas camera={{ fov: 50, position: [0, 0, 10] }}>
        <ambientLight />
        <pointLight position={[10, 10, 10]} />
        <OrbitControls enablePan={true} enableZoom={true} enableRotate={true} />
        {atomData?.map((atom, index) => (
          <Sphere key={index} positionArray={[atom.x/1000, atom.y/1000, atom.z/1000]} atomType={atom.type}/>
        ))}
      </Canvas>
      </Grid>
    </Grid>
  );



  return (
    <div className="proteinVisualization">
      {renderForm}
    </div>
  );
}