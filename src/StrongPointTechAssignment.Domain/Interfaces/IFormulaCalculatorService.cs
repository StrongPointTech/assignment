using StrongPointTechAssignment.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrongPointTechAssignment.Domain.Interfaces
{
    public interface IFormulaCalculatorService
    {
        public decimal CalculateFormula(Formula formula);
    }
}
