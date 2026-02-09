using Tenisu.Domain.Extensions;
using Tenisu.Domain.Models;

namespace Tenisu.Domain.Statistic;

public static class StatisticService
{
    public static Domain.Models.Statistic? GetStatistic(IReadOnlyCollection<Player> allPlayers)
    {
        if (!allPlayers.Any())
        {
            return null;
        }

        return new Domain.Models.Statistic(
            GetBestCountry(allPlayers),
            GetAverageBodyMassIndex(allPlayers),
            GetMedianHeight(allPlayers)
        );
    }

    public static PlayerCountry? GetBestCountry(IReadOnlyCollection<Player> players)
    {
        var bestCountryGroup = players
            .GroupBy(player => player.Country, new PlayerCountryByCodeEqualityComparer())
            .Select(grp => new
            {
                Country = grp.Key,
                AverageWinRate = WinRateCalculator.GetPlayersAverageWinRate(grp),
            })
            .MaxBy(grp => grp.AverageWinRate);

        if (bestCountryGroup?.AverageWinRate is null)
        {
            return null;
        }

        return bestCountryGroup.Country;
    }

    public static double GetMedianHeight(IReadOnlyCollection<Player> players)
    {
        return players.Median(player => player.Data.Height);
    }

    public static double GetAverageBodyMassIndex(IReadOnlyCollection<Player> players)
    {
        return players.Average(BodyMassIndexCalculator.GetBodyMassIndex);
    }
}
