using Tenisu.Application.Repositories;
using Tenisu.Application.Responses.Players;
using Tenisu.Domain.Models;

namespace Tenisu.Application.Handlers.Players;

public class CreatePlayerHandler(IPlayersRepository playersRepository)
{
    public async Task<CreatePlayerResponse> HandleAsync(Player player)
    {
        if (await playersRepository.AnyWithRankAsync(player.Data.Rank))
        {
            return new CreatePlayerResponse.PlayerWithRankAlreadyExist(player.Data.Rank);
        }

        player = await playersRepository.AddPlayerAsync(player);
        return new CreatePlayerResponse.Created(player);
    }
}
