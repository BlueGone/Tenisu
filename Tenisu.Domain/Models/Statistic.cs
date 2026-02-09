namespace Tenisu.Domain.Models;

/// <param name="BestCountry">Maybe null when no country played any match</param>
public record Statistic(
    PlayerCountry? BestCountry,
    double AverageBodyMassIndex,
    double MedianHeight
);
