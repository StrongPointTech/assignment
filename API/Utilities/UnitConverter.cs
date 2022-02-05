using API.Models.Enums;

namespace API.Utilities
{
    public static class UnitConverter
    {
        public static double? ConvertMassUnitsToKilograms(string unit, double value)
        {
            // Use kilograms as the default units of measurement
            if (CheckIfUnitMatchesEnum(unit, MassUnitEnum.Kilogram))
            {
                return value;
            } else if (CheckIfUnitMatchesEnum(unit, MassUnitEnum.Gram))
            {
                return value / 1000;
            } else if (CheckIfUnitMatchesEnum(unit, MassUnitEnum.Ounce))
            {
                return value * 0.02835;
            } else if (CheckIfUnitMatchesEnum(unit, MassUnitEnum.Pound))
            {
                return value * 0.45359237;
            } else {
                return null;
            }
        }

        public static double? ConvertVelocityUnitsToMetersPerSecond(string unit, double value)
        {
            // Use meters per second as the default units of measurement
            if (CheckIfUnitMatchesEnum(unit, VelocityUnitEnum.MetersPerSecond))
            {
                return value;
            } else if (CheckIfUnitMatchesEnum(unit, VelocityUnitEnum.KilometersPerHour))
            {
                return value * 0.277778;
            } else if (CheckIfUnitMatchesEnum(unit, VelocityUnitEnum.FeetPerSecond))
            {
                return value * 0.3048;
            } else if (CheckIfUnitMatchesEnum(unit, VelocityUnitEnum.MilesPerHour))
            {
                return value * 0.44704;
            } else {
                return null;
            }
        }

        public static double? ConvertEnergyUnitsToJoules(string unit, double value)
        {
            // Use joules as the default units of measurement
            if (CheckIfUnitMatchesEnum(unit, EnergyUnitEnum.Joule))
            {
                return value;
            } else if (CheckIfUnitMatchesEnum(unit, EnergyUnitEnum.Megajoule))
            {
                return value / 1000000;
            } else if (CheckIfUnitMatchesEnum(unit, EnergyUnitEnum.BritishThermalUnit))
            {
                return value * 0.000948;
            } else if (CheckIfUnitMatchesEnum(unit, EnergyUnitEnum.Calorie))
            {
                return value * 0.239006;
            } else
            {
                return null;
            }
        }

        private static bool CheckIfUnitMatchesEnum<T>(string unit, T enumValue) where T : Enum
        {
            return string.Equals(unit, enumValue.GetEnumValue(), StringComparison.OrdinalIgnoreCase);
        }
    }
}