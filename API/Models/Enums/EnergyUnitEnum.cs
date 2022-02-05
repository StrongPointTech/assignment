using System.Runtime.Serialization;

namespace API.Models.Enums
{
    public enum EnergyUnitEnum
    {
        [EnumMember(Value = "J")]
        Joule,

        [EnumMember(Value = "MJ")]
        Megajoule,

        [EnumMember(Value = "BTU")]
        BritishTermalUnit,

        [EnumMember(Value = "cal")]
        Calorie,
    }
}
