namespace Tenisu.Domain.Tests;

using Models;
using Statistic;

public class WinRateCalculatorTests
{
    [Theory]
    [MemberData(nameof(MatchHistoryWinRateTestData))]
    public void GetPlayerWinRate_WithCommonMatchHistories_ReturnsExpectedRate(
        MatchResult[] last,
        float expected
    )
    {
        var player = new PlayerBuilder().WithLast(last).Player;

        var actual = WinRateCalculator.GetPlayerWinRate(player);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void GetPlayerWinRate_WithEmptyHistory_ThrowsInvalidOperationException()
    {
        var player = new PlayerBuilder().WithLast([]).Player;

        var winRate = WinRateCalculator.GetPlayerWinRate(player);

        Assert.Null(winRate);
    }

    [Fact]
    public void GetPlayersAverageWinRate_WithMixedRates_ReturnsExpectedAverage_WithPrecision()
    {
        var players = new[]
        {
            new PlayerBuilder().WithLast([MatchResult.Win, MatchResult.Win]).Player, // 1.0
            new PlayerBuilder().WithLast([MatchResult.Lose, MatchResult.Lose]).Player, // 0.0
            new PlayerBuilder()
                .WithLast([MatchResult.Win, MatchResult.Win, MatchResult.Lose])
                .Player, // 0.666
        };

        var actual = WinRateCalculator.GetPlayersAverageWinRate(players);

        Assert.NotNull(actual);
        Assert.Equal(0.555f, actual.Value, precision: 2);
    }

    [Fact]
    public void GetPlayersAverageWinRate_WithEmptyPlayersCollection_ThrowsInvalidOperationException()
    {
        var players = Array.Empty<Player>();

        var averageWinRate = WinRateCalculator.GetPlayersAverageWinRate(players);

        Assert.Null(averageWinRate);
    }

    public static TheoryData<MatchResult[], float> MatchHistoryWinRateTestData() =>
        new()
        {
            { [MatchResult.Win], 1.0f },
            { [MatchResult.Lose], 0.0f },
            { [MatchResult.Lose, MatchResult.Win], 0.5f },
            { [MatchResult.Lose, MatchResult.Lose, MatchResult.Win], 1 / 3f },
            { [MatchResult.Lose, MatchResult.Lose, MatchResult.Lose, MatchResult.Win], 0.25f },
        };
}
