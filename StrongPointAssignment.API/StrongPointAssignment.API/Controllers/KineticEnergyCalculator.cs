using Microsoft.AspNetCore.Mvc;
using StrongPointAssignment.API.Data;
using StrongPointAssignment.API.Models;

namespace StrongPointAssignment.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KineticEnergyController : Controller
    {
        TargetObjectRepo _targetObjectRepo;

        public KineticEnergyController(TargetObjectRepo targetObjectRepo)
        {
            _targetObjectRepo = targetObjectRepo;
        }

        [HttpPost]
        public TargetObject Post(TargetObject targetObject)
        {
            _targetObjectRepo.Objects.Add(targetObject);
            return targetObject;
        }

        [HttpGet]
        public IEnumerable<TargetObject> Get()
        {
            return _targetObjectRepo.Objects;
        }
    }
}
