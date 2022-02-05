using System.Runtime.Serialization;

namespace API.Models.Enums
{
    public enum MassUnitEnum
    {
        [EnumMember(Value = "kg")]
        Kilogram,

        [EnumMember(Value = "g")]
        Gram,

        [EnumMember(Value = "oz")]
        Ounce,

        [EnumMember(Value = "lb")]
        Pound,
    }
}
