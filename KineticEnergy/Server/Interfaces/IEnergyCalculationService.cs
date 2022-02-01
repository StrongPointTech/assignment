namespace KineticEnergy.Server.Interfaces
{
    public interface IEnergyCalculationService
    {
        public double CalculateEnergy(double mass, double speed);
        public Task<string> CalculateImpact(double energy);
    }
}
