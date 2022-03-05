using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssignmentLibrary.Enums;

namespace AssignmentLibrary.ViewModels
{
    public class RecordViewModel
    {
        public RecordViewModel()
        {
            EnergeUnit = EnergyUnit.J;
            MassUnit = MassUnit.kg;
            VelocityUnit = VelocityUnit.MetersPerSecond;
        }

        public decimal Velocity { get; set; }
        public decimal Mass { get; set; }
        public decimal Energy { get; set; }
        public string ImpactResult { get; set; }
        public EnergyUnit EnergeUnit { get; set; } 
        public MassUnit MassUnit { get; set; }
        public VelocityUnit VelocityUnit { get; set; }
    }
}
