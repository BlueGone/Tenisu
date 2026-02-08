namespace Tenisu.Domain.Models;

/// <param name="Weight">Unit : grams</param>
/// <param name="Height">Unit : centimeters</param>
public record PlayerData(
    uint Rank,
    uint Points,
    uint Weight,
    uint Height,
    uint Age,
    MatchResult[] Last
);
