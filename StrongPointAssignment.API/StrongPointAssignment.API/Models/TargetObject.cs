namespace StrongPointAssignment.API.Models
{
    public class TargetObject
    {
        public Guid Id { get; }
        public double Mass { get; }
        public double Velocity { get; }
        public double Energy { get; }

        public TargetObject(double mass, double velocity)
        {
            Id = Guid.NewGuid();
            Mass = mass;
            Velocity = velocity;
            Energy = CalculateEnergy();
        }

        double CalculateEnergy()
        {
            return (Mass * Math.Pow(Velocity, 2)) / 2;
        }
    }
}
