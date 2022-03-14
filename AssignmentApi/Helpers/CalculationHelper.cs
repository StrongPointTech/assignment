using AssignmentLibrary.Enums;

namespace AssignmentApi.Helpers
{
    public static class CalculationHelper
    {
        public static string ImpactResult(double energy)
        {
            if ((double)Math.Pow(10, 9) > energy)
                return "It will burn in the atmosphere";
            else if (energy > (double)Math.Pow(10, 9) && (double)Math.Pow(10, 16) > energy)
                return "The impact does not shift the Earth's orbit noticeably.";
            else return "The Earth is completely disrupted by the impact and its debris forms a new asteroid belt orbiting the sun between Venus and Mars.";
        }

        public static double CalculateEnergy(double mass, double velocity)
        {
            return Math.Round(mass * velocity / 2);

        }

        public static double MassToSiSystemUnits(double mass, MassUnit unit)
        {
            var calculation = unit switch
            {
                MassUnit.kg => mass,
                MassUnit.g => mass / 1000,
                MassUnit.lb => mass * (double)0.454,
                MassUnit.oz => mass * (double)0.02835,
                MassUnit.t => mass * 1000
            };

            return Math.Round(calculation, 3);
        }

        public static double VelocityToSiSystemUnits(double velocity, VelocityUnit unit)
        {
            var calculation = unit switch
            {
                VelocityUnit.MetersPerSecond => velocity,
                VelocityUnit.FootsPerSecond => velocity * (double)0.3048,
                VelocityUnit.KilometersPerHour => velocity * (double)1000 / 3600,
                VelocityUnit.MilesPerHour => velocity * (double)1609 / 3600
            };

            return Math.Round(calculation, 2);
        }

        public static double EnergyFromSiSystemUnits(double energy, EnergyUnit unit)
        {
            var calculation = unit switch
            {
                EnergyUnit.BTU => energy / (double)1055.05585262,
                EnergyUnit.J => energy,
                EnergyUnit.MJ => energy / 1000000,
                EnergyUnit.cal => energy / (double)4.184
            };
            return Math.Round(calculation, 2);
        }

        public static double VelocityFromSiSystemUnits(double velocity, VelocityUnit unit)
        {
            var calculation = unit switch
            {
                VelocityUnit.MetersPerSecond => velocity,
                VelocityUnit.FootsPerSecond => velocity / (double)0.3048,
                VelocityUnit.KilometersPerHour => velocity / (double)1000 * 3600,
                VelocityUnit.MilesPerHour => velocity / (double)1609 * 3600
            };

            return Math.Round(calculation, 2);
        }

        public static double MassFromSiSystemUnits(double mass, MassUnit unit)
        {
            var calculation = unit switch
            {
                MassUnit.kg => mass,
                MassUnit.g => mass * 1000,
                MassUnit.lb => mass / (double)0.454,
                MassUnit.oz => mass / (double)0.02835,
                MassUnit.t => mass / 1000
            };

            return Math.Round(calculation, 2);
        }
    }
}
