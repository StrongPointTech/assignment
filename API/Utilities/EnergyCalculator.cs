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
            var energyInJoules = CalculateEnergyInJoules();

            return new EnergyCalculationResponseModel
            {
                Energy = energyInJoules.HasValue ?
                    UnitConverter.ConvertEnergyUnitsToJoules(energyUnit, energyInJoules.Value) : null,
                Impact = CalculateImpact(energyInJoules),
            };
        }

        private double? CalculateEnergyInJoules()
        {
            if (!mass.HasValue || !velocity.HasValue)
            {
                return null;
            }

            return 0.5 * mass.Value * (velocity.Value * velocity.Value);
        }

        private string CalculateImpact(double? energy)
        {
            // This assumes that the energy is in joules

            if (!energy.HasValue)
            {
                return "Error while calculating energy. Please check if all inputs are correct";
            } else if (energy.Value < 0)
            {
                return "Error - negative energy cannot exist";
            } else if (energy.Value == 0)
            {
                return "No impact as there's no energy";
            } else
            {
                // TODO: Display proper message
                return "Impact will be displayed here...";
            }
        }
    }
}