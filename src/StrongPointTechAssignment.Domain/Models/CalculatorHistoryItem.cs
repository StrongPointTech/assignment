using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrongPointTechAssignment.Domain.Models
{
    public class CalculatorHistoryItem
    {
        public DateTime Timestamp { get; set; }
        public KineticEnergyFormula Formula { get; set; }

        public decimal? Result { get; set; }

        public CalculatorHistoryItem(DateTime timestamp, KineticEnergyFormula formula, decimal? result)
        {
            Timestamp = timestamp;
            Formula = formula;
            Result = result;
        }
    }
}
