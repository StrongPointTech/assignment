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
        public ActionResult<EnergyCalculationResponseModel> CalculateEnergy(EnergyCalculationRequestModel requestModel)
        {
            var calculator = new EnergyCalculator(requestModel);

            return Ok(calculator.CalculateEnergyAndImpact());
        }
    }
}