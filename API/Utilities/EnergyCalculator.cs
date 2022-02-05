namespace API.Utilities
{
    public static class EnergyCalculator
    {
        public static double CalculateEnergy(double mass, double velocity) {
            return 0.5 * mass * (velocity * velocity);
        }
    }
}