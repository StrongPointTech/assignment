using System.ComponentModel.DataAnnotations;

namespace StrongPointTechAssignment.Domain.Models
{
    public abstract class Formula
    {
        public string TextFormula { get; private set; }

        public Formula(string formula)
        {
            TextFormula = formula;
        }

        public abstract string ReplaceFormula();
    }
}
