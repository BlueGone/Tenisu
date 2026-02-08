using Tenisu.Domain.Models;

namespace Tenisu.Domain.Statistic;

public static class BodyMassIndexCalculator
{
    public static double GetBodyMassIndex(Player player) => GetBodyMassIndex(player.Data);

    public static double GetBodyMassIndex(PlayerData playerData) =>
        GetBodyMassIndex(playerData.Weight, playerData.Height);

    public static double GetBodyMassIndex(double weightInGrams, double heightInCentimeters)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(weightInGrams);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(heightInCentimeters);

        var weightInKilograms = weightInGrams / 1000;
        var heightInMeters = heightInCentimeters / 100;

        return weightInKilograms / (heightInMeters * heightInMeters);
    }
}
