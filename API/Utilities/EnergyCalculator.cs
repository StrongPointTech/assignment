using API.Models;

namespace API.Utilities
{
    public class EnergyCalculator
    {
        private readonly double? mass;
        private readonly double? velocity;
        private readonly string energyUnit;

        public EnergyCalculator(EnergyCalculationRequestModel model)
        {
            // Assume the default units of measurement are kg for mass, m/s for velocity
            // Convert any other measurements into these before doing any calculations
            this.mass = UnitConverter.ConvertMassUnitsToKilograms(model.MassUnit, model.Mass);
            this.velocity = UnitConverter.ConvertVelocityUnitsToMetersPerSecond(model.VelocityUnit, model.Velocity);

            this.energyUnit = model.EnergyUnit;
        }

        public EnergyCalculationResponseModel CalculateEnergyAndImpact()
        {
            var energy = CalculateEnergy();

            return new EnergyCalculationResponseModel
            {
                Energy = energy,
            };
        }

        private double? CalculateEnergy()
        {
            if (!mass.HasValue || !velocity.HasValue)
            {
                return null;
            }

            var energyInJoules = 0.5 * mass.Value * (velocity.Value * velocity.Value);

            return UnitConverter.ConvertEnergyUnitsToJoules(energyUnit, energyInJoules);
        }
    }
}