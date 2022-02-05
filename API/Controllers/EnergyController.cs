using API.Models;
using API.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnergyController : ControllerBase
    {
        [HttpPost]
        [Route("calculate-energy")]
        public ActionResult<EnergyCalculationModel> CalculateEnergy(EnergyCalculationModel model) {
            model.Energy = EnergyCalculator.CalculateEnergy(model.Mass, model.Velocity);

            return Ok(model);
        }
    }
}