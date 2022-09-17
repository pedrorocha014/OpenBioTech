import './App.css';
import { BrowserRouter, Routes, Route } from "react-router-dom";
import AnalysisMenu from './components/analysisMenu/AnalysisMenu';
import AnalysisForms from './components/analysisForms/AnalysisForms';

function App() {
  return (
    <div className="App">
      <header className="App-header">
      </header>
      <h1>Protain Analysis</h1>
      <main>
        <BrowserRouter>
          <aside>
            <AnalysisMenu/>
          </aside>
          <Routes>
              <Route path="/" element={<h1>WELCOME !</h1>} />
              <Route path="/analysisForms" element={<AnalysisForms/>} />
          </Routes>
        </BrowserRouter>
      </main>
    </div>
  );
}

export default App;
