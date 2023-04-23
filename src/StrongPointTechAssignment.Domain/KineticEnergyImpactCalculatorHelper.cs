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
            else if (energyReleased < 10000000000)
            { 
                return KineticEnergyImpactToEarthLevels.Minimal;
            }
            else if (energyReleased > 10000000000 && energyReleased < 100000000000)
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
