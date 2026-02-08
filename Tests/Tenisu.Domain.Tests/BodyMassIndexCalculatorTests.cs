namespace Tenisu.Domain.Tests;

using Statistic;

public class BodyMassIndexCalculatorTests
{
    [Theory]
    // https://fr.wikipedia.org/wiki/Indice_de_masse_corporelle#Exemples
    [InlineData(95_000, 181, 29.0)]
    [InlineData(48_000, 169, 16.8)]
    [InlineData(61_000, 157, 24.7)]
    [InlineData(140_000, 204, 33.6)]
    public void GetBodyMassIndex_WithNominalInputs_ReturnsExpectedBmi(
        double weightInGrams,
        double heightInCentimeters,
        double expectedBmi
    )
    {
        var actualBmi = BodyMassIndexCalculator.GetBodyMassIndex(
            weightInGrams,
            heightInCentimeters
        );

        Assert.Equal(expectedBmi, actualBmi, precision: 1);
    }

    [Theory]
    [InlineData(70_000, 0)]
    [InlineData(70_000, -175)]
    [InlineData(0, 175)]
    [InlineData(0, 0)]
    [InlineData(0, -175)]
    [InlineData(-70_000, 175)]
    [InlineData(-70_000, 0)]
    [InlineData(-70_000, -175)]
    public void GetBodyMassIndex_WithNegativeOrZeroWidthOrHeight_ThrowsArgumentOutOfRangeException(
        double weightInGrams,
        double heightInCentimeters
    )
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
            BodyMassIndexCalculator.GetBodyMassIndex(weightInGrams, heightInCentimeters)
        );
    }
}
