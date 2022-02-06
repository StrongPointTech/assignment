import React from 'react';
import './App.css';
import { EnergyCalculationRequestModel } from './models/energy-calculation-request-model';
import { Field, Form, Formik } from 'formik';
import axios, { AxiosResponse } from 'axios';
import { EnergyCalculationResponseModel } from './models/energy-calculation-response-model';

function App() {
  const requestModel: EnergyCalculationRequestModel = {
    mass: 0,
    massUnit: "kg",
    velocity: 0,
    velocityUnit: "m/s",
    energyUnit: "J",
  };

  async function handleFormSubmit(model: EnergyCalculationRequestModel) {
    const result = await axios
      .post<EnergyCalculationResponseModel>("https://localhost:7238/Energy/calculate-energy", model)
      .then((response: AxiosResponse<EnergyCalculationResponseModel>) => response.data);
    alert(JSON.stringify(result, null, 2));
  }
  
  return (
    <div className="app">
      <div className="container">
        <h1 className="header">Kinetic Energy calculator</h1>
        <div className="form-container">
          <Formik
            initialValues={requestModel}
            onSubmit={(values, actions) => {
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
    </div>
  );
}

export default App;
