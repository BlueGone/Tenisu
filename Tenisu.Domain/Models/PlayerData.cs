using System.ComponentModel.DataAnnotations;

namespace Tenisu.Domain.Models;

/// <param name="Weight">Unit : grams</param>
/// <param name="Height">Unit : centimeters</param>
public record PlayerData(
    [property: Range(1, uint.MaxValue, ErrorMessage = "Rank must be positive")] uint Rank,
    uint Points,
    [property: Range(1, uint.MaxValue, ErrorMessage = "Weight must be positive")] uint Weight,
    [property: Range(1, uint.MaxValue, ErrorMessage = "Height must be positive")] uint Height,
    [property: Range(1, uint.MaxValue, ErrorMessage = "Age must be positive")] uint Age,
    MatchResult[] Last
);
