import React, { useState } from 'react';
import './App.css';
import { EnergyCalculationModel } from './models/energy-calculation-model';
import CacluationForm from './components/CalculationForm';
import CalculationResults from './components/CalculationResults';

function App() {
  const [results, updateResults] = useState<EnergyCalculationModel[]>([]);

  function addNewResult(result: EnergyCalculationModel) {
    updateResults([result, ...results]);
  }
  
  return (
    <div className="app">
      <CacluationForm addNewResult={addNewResult} />
      <CalculationResults results={results} />
    </div>
  );
}

export default App;
