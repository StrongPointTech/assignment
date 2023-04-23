using FluentAssertions;
using StrongPointTechAssignment.Domain;
using StrongPointTechAssignment.Domain.Models;
using Xunit;

namespace StrongPointTechAssignment.Tests
{
    public class KineticEnergyImpactCalculatorHelperTests
    {
        public static TheoryData<decimal?, KineticEnergyImpactToEarthLevels> Data =>
            new()
            {
                    { null, KineticEnergyImpactToEarthLevels.None },
                    { 90000, KineticEnergyImpactToEarthLevels.Minimal },
                    { 10000000001, KineticEnergyImpactToEarthLevels.Medium },
                    { 100000000005, KineticEnergyImpactToEarthLevels.High },
            };

        [Theory]
        [MemberData(nameof(Data))]
        public void KineticEnergyImpactCalculatorHelper_Returns_Correct(decimal? input, KineticEnergyImpactToEarthLevels expectedLevel)
        {
            // Given
            var result = KineticEnergyImpactCalculatorHelper.CalculateLevel(input);

            // Then
            result.Should().Be(expectedLevel);
        }
    }
}