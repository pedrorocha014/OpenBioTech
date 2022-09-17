import './App.css';
import AnalysisMenu from './components/analysisMenu/AnalysisMenu';
import AnalysisForms from './components/analysisForms/AnalysisForms';

function App() {
  return (
    <div className="App">
      <header className="App-header">
      </header>
      <h1>Protain Analysis</h1>
      <aside>
        <AnalysisMenu/>
      </aside>
      <main>
        <AnalysisForms/>
      </main>
    </div>
  );
}

export default App;
