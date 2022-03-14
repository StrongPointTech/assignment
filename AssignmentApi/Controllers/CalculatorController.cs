using AssignmentApi.Services;
using AssignmentLibrary.Enums;
using AssignmentLibrary.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AssignmentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        private readonly IRecordService recordService;

        public CalculatorController(IRecordService recordService)
        {
            this.recordService = recordService;
        }

        [HttpGet]
        public ActionResult<List<RecordViewModel>> Get([FromQuery]MassUnit massUnit, [FromQuery]VelocityUnit velocityUnit, [FromQuery]EnergyUnit energyUnit)
        {
            return Ok(recordService.GetAllRecords(massUnit, velocityUnit, energyUnit));
        }

        [HttpPost]
        public ActionResult Post([FromBody] RecordViewModel model)
        {
            return Ok(recordService.CreateRecord(model));
        }
    }
}
