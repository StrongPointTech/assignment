import React, { useState } from 'react';
import './App.css';
import { EnergyCalculationRequestModel } from './models/energy-calculation-request-model';
import { Field, Form, Formik } from 'formik';
import axios, { AxiosResponse } from 'axios';
import { EnergyCalculationResponseModel } from './models/energy-calculation-response-model';
import { EnergyCalculationModel } from './models/energy-calculation-model';

function App() {
  const requestModel: EnergyCalculationRequestModel = {
    mass: 0,
    massUnit: "kg",
    velocity: 0,
    velocityUnit: "m/s",
    energyUnit: "J",
  };

  const [results, updateResults] = useState<EnergyCalculationModel[]>([]);

  async function handleFormSubmit(model: EnergyCalculationRequestModel) {
    const responseModel = await axios
      .post<EnergyCalculationResponseModel>("https://localhost:7238/Energy/calculate-energy", model)
      .then((response: AxiosResponse<EnergyCalculationResponseModel>) => response.data);

    const result: EnergyCalculationModel = {
      mass: model.mass,
      massUnit: model.massUnit,
      velocity: model.velocity,
      velocityUnit: model.velocityUnit,
      energy: responseModel.energy,
      energyUnit: model.energyUnit,
      impact: responseModel.impact,
    };

    updateResults([result, ...results]);
  }
  
  return (
    <div className="app">
      <div className="calculator-container">
        <h1 className="header">Kinetic Energy calculator</h1>
        <div className="form-container">
          <Formik
            initialValues={requestModel}
            onSubmit={(values) => {
              handleFormSubmit(values);
            }}
          >
            <Form>
              <div className="form-header">
                <span className="first-column">Measurement</span>
                <span className="second-column">Value</span>
                <span className="third-column">Unit</span>
                <hr />
              </div>

              <div className="form-group">
                <label>
                  <span className="first-column">
                    <i>energy</i> m =
                  </span>
                  <span className="second-column">
                    <Field type="number" name="mass" placeholder="Mass" />
                  </span>
                  <span className="third-column">
                    <Field as="select" name="massUnit">
                      <option value="kg">kg</option>
                      <option value="g">g</option>
                      <option value="oz">oz</option>
                      <option value="lb">lb</option>
                    </Field>
                  </span>
                </label>
              </div>
              
              <div className="form-group">
                <label>
                  <span className="first-column">
                    <i>velocity</i> v =
                  </span>
                  <span className="second-column">
                    <Field type="number" name="velocity" placeholder="Velocity" />
                  </span>
                  <span className="third-column">
                    <Field as="select" name="velocityUnit">
                      <option value="m/s">m/s</option>
                      <option value="km/h">km/h</option>
                      <option value="ft/s">ft/s</option>
                      <option value="mi/h">mi/h</option>
                    </Field>
                  </span>
                </label>
              </div>

              <div className="form-group">
                <label>
                  <span className="first-column">
                    <i>energy</i> KE =
                  </span>
                  <span className="second-column"></span>
                  <span className="third-column">
                    <Field as="select" name="energyUnit">
                      <option value="J">J</option>
                      <option value="MJ">MJ</option>
                      <option value="BTU">BTU</option>
                      <option value="cal">cal</option>
                    </Field>
                  </span>
                </label>
              </div>

              <button type="submit">Calculate</button>
            </Form>
          </Formik>
        </div>
      </div>

      <div className="results-container">
        <h3>Results</h3>
        <div className="table-container">
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
        </div>
      </div>
    </div>
  );
}

export default App;
