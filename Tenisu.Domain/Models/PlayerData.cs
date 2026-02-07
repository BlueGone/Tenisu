namespace Tenisu.Domain.Models;

public record PlayerData(
    uint Rank,
    uint Points,
    uint Weight,
    uint Height,
    uint Age,
    MatchResult[] Last
);
