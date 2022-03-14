using System.Net.Http.Json;
using AssignmentLibrary.Enums;
using AssignmentLibrary.ViewModels;

namespace AssignmentBlazor.DataService
{
    public interface IRecordService
    {
        Task<List<RecordViewModel>> GetAllRecordsAsync(MassUnit massUnit, VelocityUnit velocityUnit, EnergyUnit energyUnit);
        Task<RecordViewModel?> CreateRecordAsync(RecordViewModel model);
    }

    public class RecordService : IRecordService
    {
        private readonly HttpClient httpCLient;

        public RecordService(HttpClient Http)
        {
            httpCLient = Http;
        }

        public async Task<List<RecordViewModel>> GetAllRecordsAsync(MassUnit massUnit, VelocityUnit velocityUnit, EnergyUnit energyUnit)
        {
            return await httpCLient.GetFromJsonAsync<List<RecordViewModel>>($"https://localhost:7112/api/Calculator/?massUnit={massUnit}&velocityUnit={velocityUnit}&energyUnit={energyUnit}");
        }

        public async Task<RecordViewModel> CreateRecordAsync(RecordViewModel model)
        {
            var response =  await httpCLient.PostAsJsonAsync($"https://localhost:7112/api/Calculator", model);
            return await response.Content.ReadFromJsonAsync<RecordViewModel>();
        }
    }
}
