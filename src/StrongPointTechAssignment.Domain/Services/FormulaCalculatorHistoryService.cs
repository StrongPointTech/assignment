using StrongPointTechAssignment.Domain.Interfaces;
using StrongPointTechAssignment.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrongPointTechAssignment.Domain.Services
{
    public class FormulaCalculatorHistoryService : IFormulaCalculatorHistoryService
    {
        private List<CalculatorHistoryItem> _calculatorHistoricalRecords { get; set; }

        public FormulaCalculatorHistoryService()
        {
            _calculatorHistoricalRecords = new List<CalculatorHistoryItem>();
        }

        public void AddHistoricalRecord(CalculatorHistoryItem historicalRecord)
        {
            _calculatorHistoricalRecords.Add(historicalRecord);
        }

        public List<CalculatorHistoryItem> RetrieveAllHistoryRecords()
        {
            return _calculatorHistoricalRecords;
        }
    }
}
