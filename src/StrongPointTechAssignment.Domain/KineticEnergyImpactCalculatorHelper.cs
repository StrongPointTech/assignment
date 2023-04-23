using StrongPointTechAssignment.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrongPointTechAssignment.Domain
{
    public static class KineticEnergyImpactCalculatorHelper
    {
        public static KineticEnergyImpactToEarthLevels CalculateLevel(decimal? energyReleased)
        {
            if (energyReleased.HasValue is false)
            {
                return KineticEnergyImpactToEarthLevels.None;
            }
            else if (energyReleased < 1000)
            { 
                return KineticEnergyImpactToEarthLevels.Minimal;
            }
            else if (energyReleased > 1000 && energyReleased < 10000)
            {
                return KineticEnergyImpactToEarthLevels.Medium;
            }
            else
            {
                return KineticEnergyImpactToEarthLevels.High;
            }
        }
    }
}
