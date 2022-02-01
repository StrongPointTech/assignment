using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KineticEnergy.Shared
{
    public class EnergyRequest
    {
        public double Mass { get; }
        public double Speed { get; }

        public EnergyRequest(double mass, double speed)
        {
            Mass = mass;
            Speed = speed;
        }
    }
}
