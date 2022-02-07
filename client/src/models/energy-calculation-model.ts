export interface EnergyCalculationModel {
  mass: number;
  massUnit: string;
  velocity: number;
  velocityUnit: string;
  energy: number | null;
  energyUnit: string | null;
  impact: string | null;
}