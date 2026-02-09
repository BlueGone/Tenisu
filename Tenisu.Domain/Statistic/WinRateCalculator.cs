using Tenisu.Domain.Models;

namespace Tenisu.Domain.Statistic;

public class WinRateCalculator
{
    public static float? GetPlayersAverageWinRate(IEnumerable<Player> players)
    {
        if (!players.SelectMany(player => player.Data.Last).Any())
        {
            return null; // No matches played by any player
        }

        return players.Select(GetPlayerWinRate).OfType<float>().Average();
    }

    public static float? GetPlayerWinRate(Player player)
    {
        if (!player.Data.Last.Any())
        {
            return null;
        }

        return player.Data.Last.Average(score => (float)score);
    }
}
