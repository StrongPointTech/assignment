namespace API.Models
{
    public class EnergyCalculationRequestModel
    {
        public double Mass { get; set; }
        public string MassUnit { get; set; }
        public double Velocity { get; set; }
        public string VelocityUnit { get; set; }
        public string EnergyUnit { get; set; }
    }
}