using KineticEnergy.Server.Interfaces;
using KineticEnergy.Shared;
using Microsoft.AspNetCore.Mvc;

namespace KineticEnergy.Server.Controllers;

[Route("[controller]")]
[ApiController]
public class EnergyController : ControllerBase
{
    protected IEnergyCalculationService EnergyCalculationService { get; }
    protected ICacheService CacheService { get; }


    public EnergyController(IEnergyCalculationService energyCalculationService, ICacheService cacheService)
    {
        EnergyCalculationService = energyCalculationService;
        CacheService = cacheService;
    }

    [HttpGet("{value}")]
    public async Task<ActionResult<EnergyImpactResponse>> Get(double value, CancellationToken cancellationToken)
    {
        if(CacheService.TryGetImpact(value, out var impact))
        {
            return Ok(new EnergyImpactResponse() { Impact = impact });
        }

        var result = await EnergyCalculationService.CalculateImpact(value, cancellationToken);

        CacheService.CacheImpact(value, result);

        return Ok(new EnergyImpactResponse() { Impact = result });
    }

    [HttpPost]
    public ActionResult<double> Post([FromBody] EnergyRequest request)
    {
        var result = EnergyCalculationService.CalculateEnergy(request.Mass, request.Speed);

        return Ok(result);
    }

}

