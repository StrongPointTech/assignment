import React from "react";
import { EnergyCalculationModel } from "../models/energy-calculation-model";

interface Props {
  results: EnergyCalculationModel[];
}

export default function CalculationResults({results}: Props) {
  return (
    <div className="results-container">
      <h1>Results</h1>
      <div className="table-container">
        {results.length > 0 ? (
          <>
            <table>
              <thead>
                <tr>
                  <th style={{width: 50}}>Masss</th>
                  <th style={{width: 20}}>Mass Unit</th>
                  <th style={{width: 50}}>Velocity</th>
                  <th style={{width: 20}}>Velocity Unit</th>
                  <th style={{width: 50}}>Energy</th>
                  <th style={{width: 20}}>Energy Unit</th>
                  <th style={{width: 500}}>Impact</th>
                </tr>
              </thead>
              <tbody>
                {results.map((result, index) => (
                  <tr key={index}>
                    <td>{result.mass}</td>
                    <td>{result.massUnit}</td>
                    <td>{result.velocity}</td>
                    <td>{result.velocityUnit}</td>
                    <td>{result.energy}</td>
                    <td>{result.energyUnit}</td>
                    <td>{result.impact}</td>
                  </tr>
                ))}
              </tbody>
            </table>
          </>
        ) : <span>Results to your calculations will be displayed here</span>}
      </div>
    </div>
  );
}