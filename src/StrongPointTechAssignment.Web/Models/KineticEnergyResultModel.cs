using StrongPointTechAssignment.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace StrongPointTechAssignment.Web.Models
{
    public class KineticEnergyResultModel : FormulaResultModel
    {
        public KineticEnergyImpactToEarthLevels ImpactToEarthLevel { get; set; }
    }
}
