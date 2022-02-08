import React from "react";
import axios, { AxiosResponse } from "axios";
import { Field, Form, Formik } from "formik";
import { EnergyCalculationModel } from "../models/energy-calculation-model";
import { EnergyCalculationRequestModel } from "../models/energy-calculation-request-model";
import { EnergyCalculationResponseModel } from "../models/energy-calculation-response-model";

interface Props {
  addNewResult: (result: EnergyCalculationModel) => void;
  clearResults: () => void;
}

export default function CacluationForm({addNewResult, clearResults}: Props) {
  const requestModel: EnergyCalculationRequestModel = {
    mass: 0,
    massUnit: "kg",
    velocity: 0,
    velocityUnit: "m/s",
    energyUnit: "J",
  };

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

    addNewResult(result);
  }
  
  return (
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
            <button type="button" style={{float: "right"}} onClick={clearResults}>Clear results</button>
          </Form>
        </Formik>
      </div>
    </div>
  );
}