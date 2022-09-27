import './App.css';
import { BrowserRouter, Routes, Route } from "react-router-dom";
import AnalysisMenu from './components/analysisMenu/AnalysisMenu';
import ProteinSequenceForms from './components/operations/proteinSequenceForms/ProteinSequenceForms';
import AnalysisTableResult from './components/analysisTableResult/AnalysisTableResult';

function App() {

  return (
    <div className="App">
      <header className="App-header">
      </header>
      <h1>Protain Analysis</h1>
      <BrowserRouter>
        <aside>
          <AnalysisMenu/>
        </aside>
        <main>
          <Routes>
            <Route path="/" element={<h1>WELCOME !</h1>} />
            <Route path="/proteinSequence" element={<ProteinSequenceForms/>} />
            <Route path="/Results" element={<AnalysisTableResult/>} />
          </Routes>
        </main>
      </BrowserRouter>
    </div>
  );
}

export default App;
