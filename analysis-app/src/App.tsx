import './App.css';
import { BrowserRouter, Routes, Route } from "react-router-dom";
import AnalysisMenu from './components/analysisMenu/AnalysisMenu';
import ReplaceForm from './components/operations/replaceForm/ReplaceForm';
import InsertForm from './components/operations/insertForm/InsertForm';
import DeleteForm from './components/operations/deleteForm/DeleteForm';
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
                  <Route path="/Replace" element={<ReplaceForm/>} />
                  <Route path="/Insert" element={<InsertForm/>} />
                  <Route path="/Delete" element={<DeleteForm/>} />
                  <Route path="/Results" element={<AnalysisTableResult/>} />
              </Routes>
            </main>
        </BrowserRouter>
    </div>
  );
}

export default App;
