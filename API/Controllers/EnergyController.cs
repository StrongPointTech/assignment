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
            var responseModel = new EnergyCalculationResponseModel
            {
                Energy = EnergyCalculator.CalculateEnergy(requestModel.Mass, requestModel.Velocity),
            };

            return Ok(responseModel);
        }
    }
}