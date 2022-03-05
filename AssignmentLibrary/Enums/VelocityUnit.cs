using System.ComponentModel.DataAnnotations;

namespace AssignmentLibrary.Enums
{
    public enum VelocityUnit
    {
        [Display(Name = "m/s")]
        MetersPerSecond,

        [Display(Name = "km/s")]
        KilometersPerHour,

        [Display(Name = "ft/s")]
        FootsPerSecond,

        [Display(Name = "mi/h")]
        MilesPerHour,
    }
}
