using KineticEnergy.Client.Models;
using KineticEnergy.Shared;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace KineticEnergy.Client.Pages;

public partial class Energy
{
    [Inject]
    protected HttpClient Http { get; set; } = default!;

    private EnergyParameters energyParameters = new();

    private double? lastCalculatedEnergy;
    private readonly Dictionary<double, string> history = new();

    private string impact = string.Empty;

    private bool collapsed = true;

    private async Task HandleValidSubmit()
    {
        if(lastCalculatedEnergy.HasValue && !history.ContainsKey(lastCalculatedEnergy.Value))
            history.Add(lastCalculatedEnergy.Value, impact);
        var result = await Http.PostAsJsonAsync("Energy", new EnergyRequest(energyParameters.Mass, energyParameters.Speed));
        lastCalculatedEnergy = await result.Content.ReadFromJsonAsync<double>();

        if(lastCalculatedEnergy.HasValue)
            impact = await GetImpact(lastCalculatedEnergy.Value);

    }

    private async Task<string> GetImpact(double energy)
    {
        if (energy >= 0)
        {
            var result = await Http.GetFromJsonAsync<EnergyImpactResponse>($"Energy/{energy}");
            return result?.Impact ?? string.Empty;
        }
        return "Negative energy does not exist";
    }

    private void Collapse()
    {
        collapsed = !collapsed;
    }
}

