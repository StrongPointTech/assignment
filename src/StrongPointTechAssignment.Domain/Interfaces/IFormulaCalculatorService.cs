using StrongPointTechAssignment.Domain.Models;

namespace StrongPointTechAssignment.Domain.Interfaces
{
    public interface IFormulaCalculatorService
    {
        public decimal CalculateFormula(Formula formula);
    }
}
