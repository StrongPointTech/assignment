using StrongPointTechAssignment.Domain.Models;

namespace StrongPointTechAssignment.Domain.Interfaces
{
    public interface IFormulaCalculatorHistoryService
    {
        public void AddHistoricalRecord(CalculatorHistoryItem historicalRecord);
        public List<CalculatorHistoryItem> RetrieveAllHistoryRecords();
    }
}