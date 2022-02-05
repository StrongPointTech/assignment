using System.Runtime.Serialization;

namespace API.Utilities
{
    public static class EnumHelper
    {
        // Used to get the EnumMember attribute's value
        // Based on a solution by Amir Popovich, https://stackoverflow.com/questions/27372816/how-to-read-the-value-for-an-enummember-attribute/52122369
        public static string? GetEnumValue<T>(this T value) where T : Enum
        {
            var member = typeof(T).GetMember(value.ToString());

            var attribute = member[0]
                .GetCustomAttributes(false)
                .OfType<EnumMemberAttribute>()
                .FirstOrDefault();

            return attribute != null ? attribute.Value : null;
        }
    }

    
}