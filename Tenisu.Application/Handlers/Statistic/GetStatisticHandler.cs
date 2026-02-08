using Tenisu.Application.Repositories;
using Tenisu.Domain.Statistic;

namespace Tenisu.Application.Handlers.Statistic;

public class GetStatisticHandler(IPlayersRepository playersRepository)
{
    public async Task<Domain.Models.Statistic?> HandleAsync()
    {
        var allPlayers = await playersRepository.ListPlayersAsync();

        if (!allPlayers.Any())
        {
            return null;
        }

        return StatisticService.GetStatistic(allPlayers);
    }
}
