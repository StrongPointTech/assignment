using KineticEnergy.Server.Interfaces;
using KineticEnergy.Shared;
using Microsoft.AspNetCore.Mvc;

namespace KineticEnergy.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EnergyController : ControllerBase
    {
        protected IEnergyCalculationService EnergyCalculationService { get; }
        private static Dictionary<double, string> impactCache = new();


        public EnergyController(IEnergyCalculationService energyCalculationService)
        {
            EnergyCalculationService = energyCalculationService;
        }

        [HttpGet("{value}")]
        public async Task<ActionResult<EnergyImpactResponse>> Get(double value)
        {
            if(impactCache.TryGetValue(value, out var impact))
            {
                return Ok(new EnergyImpactResponse() { Impact = impact });
            }

            var result = await EnergyCalculationService.CalculateImpact(value);
            
            impactCache.Add(value, result);

            return Ok(new EnergyImpactResponse() { Impact = result });
        }

        [HttpPost]
        public ActionResult<double> Post([FromBody] EnergyRequest request)
        {
            var result = EnergyCalculationService.CalculateEnergy(request.Mass, request.Speed);

            return Ok(result);
        }


    }
}
