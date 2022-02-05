namespace API.Models
{
    public class EnergyCalculationModel
    {
        // TODO: Add units of measurement to the inputs, impact result
        public double Mass { get; set; }
        public double Velocity { get; set; }
        public double? Energy { get; set; }
    }
}