namespace StrongPointTechAssignment.Domain.Models
{
    public class KineticEnergyFormula : Formula
    {
        public decimal Mass { get; private set; }
        public decimal Velocity { get; private set; }

        public KineticEnergyFormula(decimal mass, decimal velocity) : base($"0.5 * m * v * v")
        {
            Mass = mass;
            Velocity = velocity;
        }

        public override string ReplaceFormula()
        {
            return TextFormula.Replace("m", Mass.ToString()).Replace("v", Velocity.ToString());
        }
    }
}
