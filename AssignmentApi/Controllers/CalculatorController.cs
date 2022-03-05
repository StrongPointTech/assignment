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
        private IRecordService recordService;

        public CalculatorController(IRecordService recordService)
        {
            this.recordService = recordService;
        }

        [HttpGet("{massUnit}/{velocityUnit}/{energyUnit}")]
        public ActionResult<List<RecordViewModel>> Get(MassUnit massUnit, VelocityUnit velocityUnit, EnergyUnit energyUnit)
        {
            return Ok(recordService.GetAllRecords(massUnit, velocityUnit, energyUnit));
        }

        [HttpPost]
        public ActionResult Post([FromBody] RecordViewModel model)
        {
            recordService.CreateRecord(model);
            return StatusCode(201);
        }
    }
}
