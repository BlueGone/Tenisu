namespace Tenisu.Domain.Models;

public record Statistic(
    PlayerCountry BestCountry,
    double AverageBodyMassIndex,
    double MedianHeight
);
