using Tenisu.Domain.Extensions;
using Tenisu.Domain.Models;

namespace Tenisu.Domain.Statistic;

public static class StatisticService
{
    public static Domain.Models.Statistic GetStatistic(IReadOnlyCollection<Player> allPlayers)
    {
        return new Domain.Models.Statistic(
            GetBestCountry(allPlayers),
            GetAverageBodyMassIndex(allPlayers),
            GetMedianHeight(allPlayers)
        );
    }

    private static PlayerCountry GetBestCountry(IReadOnlyCollection<Player> players)
    {
        var bestCountryGroup = players
            .GroupBy(player => player.Country, new PlayerCountryByCodeEqualityComparer())
            .MaxBy(WinRateCalculator.GetPlayersAverageWinRate);

        if (bestCountryGroup is null)
        {
            throw new InvalidOperationException("Sequence contains no elements");
        }

        return bestCountryGroup.Key;
    }

    private static double GetMedianHeight(IReadOnlyCollection<Player> players)
    {
        return players.Median(player => player.Data.Height);
    }

    private static double GetAverageBodyMassIndex(IReadOnlyCollection<Player> players)
    {
        return players.Average(BodyMassIndexCalculator.GetBodyMassIndex);
    }
}
