using Tenisu.Domain.Models;

namespace Tenisu.Domain.Statistic;

public class WinRateCalculator
{
    public static float GetPlayersAverageWinRate(IEnumerable<Player> players)
    {
        return players.Average(GetPlayerWinRate);
    }

    public static float GetPlayerWinRate(Player player)
    {
        return player.Data.Last.Average(score => (float)score);
    }
}
