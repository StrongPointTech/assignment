using System.Runtime.Serialization;

namespace API.Models.Enums
{
    public enum VelocityUnitEnum
    {
        [EnumMember(Value = "m/s")]
        MetersPerSecond,

        [EnumMember(Value = "km/h")]
        KilometersPerHour,

        [EnumMember(Value = "ft/s")]
        FeetPerSecond,

        [EnumMember(Value = "mi/h")]
        MilesPerHour,
    }
}
