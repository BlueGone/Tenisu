using Tenisu.Domain.Models;
using Tenisu.Domain.Statistic;

namespace Tenisu.Domain.Tests;

public class StatisticServiceTests
{
    [Fact]
    public void GetBestCountry_WhenTwoPlayers_ReturnsBestCountry()
    {
        Player[] players =
        [
            new PlayerBuilder()
                .WithLast([MatchResult.Win, MatchResult.Win])
                .WithCountryCode("FRA")
                .Player,
            new PlayerBuilder()
                .WithLast([MatchResult.Lose, MatchResult.Lose])
                .WithCountryCode("SRB")
                .Player,
        ];

        var bestCountry = StatisticService.GetBestCountry(players);

        Assert.NotNull(bestCountry);
        Assert.Equal("FRA", bestCountry.Code);
    }

    [Fact]
    public void GetBestCountry_WhenTwoCountriesHaveSameWinRate_ReturnsFirstCountry()
    {
        Player[] players =
        [
            new PlayerBuilder()
                .WithLast([MatchResult.Win, MatchResult.Lose])
                .WithCountryCode("FRA")
                .Player,
            new PlayerBuilder()
                .WithLast([MatchResult.Lose, MatchResult.Win])
                .WithCountryCode("SRB")
                .Player,
        ];

        var bestCountry = StatisticService.GetBestCountry(players);

        Assert.NotNull(bestCountry);
        Assert.Equal("FRA", bestCountry.Code);
    }

    [Fact]
    public void GestBestCountry_WhenMultiplePlayersPlayedMatches_ReturnsBestCountry()
    {
        Player[] players =
        [
            new PlayerBuilder()
                .WithLast([MatchResult.Win, MatchResult.Win])
                .WithCountryCode("FRA")
                .Player,
            new PlayerBuilder()
                .WithLast([MatchResult.Lose, MatchResult.Lose])
                .WithCountryCode("SRB")
                .Player,
            new PlayerBuilder()
                .WithLast([MatchResult.Win, MatchResult.Lose])
                .WithCountryCode("FRA")
                .Player,
            new PlayerBuilder()
                .WithLast([MatchResult.Win, MatchResult.Win])
                .WithCountryCode("SRB")
                .Player,
        ];

        var bestCountry = StatisticService.GetBestCountry(players);

        Assert.NotNull(bestCountry);
        Assert.Equal("FRA", bestCountry.Code);
    }

    [Fact]
    public void GetBestCountry_WhenOnlyOnePlayerPlayedMatches_ReturnsPlayingCountry()
    {
        Player[] players =
        [
            new PlayerBuilder().WithLast([]).WithCountryCode("SRB").Player,
            new PlayerBuilder().WithLast([MatchResult.Lose]).WithCountryCode("FRA").Player,
        ];

        var bestCountry = StatisticService.GetBestCountry(players);

        Assert.NotNull(bestCountry);
        Assert.Equal("FRA", bestCountry.Code);
    }

    [Fact]
    public void GetBestCountry_WhenNoPlayerPlayedAnyMatch_ReturnsNull()
    {
        Player[] players =
        [
            new PlayerBuilder().WithLast([]).Player,
            new PlayerBuilder().WithLast([]).Player,
        ];

        var bestCountry = StatisticService.GetBestCountry(players);

        Assert.Null(bestCountry);
    }
}
