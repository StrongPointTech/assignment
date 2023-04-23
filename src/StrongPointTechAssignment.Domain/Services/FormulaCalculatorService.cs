using StrongPointTechAssignment.Domain.Interfaces;
using StrongPointTechAssignment.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrongPointTechAssignment.Domain.Services
{
    public class FormulaCalculatorService : IFormulaCalculatorService
    {
        public decimal CalculateFormula(Formula formula)
        {
            var replacedFormula = formula.ReplaceFormula();
            var result = Convert.ToDecimal(new DataTable().Compute(replacedFormula, null));
            return result;
        }
    }
}
