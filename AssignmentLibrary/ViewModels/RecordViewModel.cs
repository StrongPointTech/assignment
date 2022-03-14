using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Required]
        [Range(1, 1E+20)]
        public double? Velocity { get; set; }
        [Required]
        [Range(1, 1E+15)]
        public double? Mass { get; set; }
        public double Energy { get; set; }
        public string ImpactResult { get; set; }
        public EnergyUnit EnergeUnit { get; set; } 
        public MassUnit MassUnit { get; set; }
        public VelocityUnit VelocityUnit { get; set; }
    }
}
