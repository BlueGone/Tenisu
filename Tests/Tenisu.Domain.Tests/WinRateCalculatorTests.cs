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
        var player = CreatePlayerWithLast(last);

        var actual = WinRateCalculator.GetPlayerWinRate(player);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void GetPlayerWinRate_WithEmptyHistory_ThrowsInvalidOperationException()
    {
        var player = CreatePlayerWithLast([]);

        Assert.Throws<InvalidOperationException>(() => WinRateCalculator.GetPlayerWinRate(player));
    }

    [Fact]
    public void GetPlayersAverageWinRate_WithMixedRates_ReturnsExpectedAverage_WithPrecision()
    {
        var players = new[]
        {
            CreatePlayerWithLast([MatchResult.Win, MatchResult.Win]), // 1.0
            CreatePlayerWithLast([MatchResult.Lose, MatchResult.Lose]), // 0.0
            CreatePlayerWithLast([MatchResult.Win, MatchResult.Win, MatchResult.Lose]), // 0.666
        };

        var actual = WinRateCalculator.GetPlayersAverageWinRate(players);

        Assert.Equal(0.555f, actual, precision: 2);
    }

    [Fact]
    public void GetPlayersAverageWinRate_WithEmptyPlayersCollection_ThrowsInvalidOperationException()
    {
        var players = Array.Empty<Player>();

        Assert.Throws<InvalidOperationException>(() =>
            WinRateCalculator.GetPlayersAverageWinRate(players)
        );
    }

    private static Player CreatePlayerWithLast(MatchResult[] last) =>
        new(
            Id: 52,
            FirstName: "Novak",
            LastName: "Djokovic",
            ShortName: "N.DJO",
            PlayerSex.Male,
            new PlayerCountry(new Uri("https://tenisu.latelier.co/resources/Serbie.png"), "SRB"),
            Picture: new Uri("https://tenisu.latelier.co/resources/Djokovic.png"),
            new PlayerData(Rank: 2, Points: 2542, Weight: 80000, Height: 188, Age: 31, Last: last)
        );

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
