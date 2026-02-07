using Tenisu.Application.Repositories;
using Tenisu.Domain.Models;

namespace Tenisu.Application.Handlers.Players;

public class GetPlayerHandler(IPlayersRepository playersRepository)
{
    public Task<Player?> HandleAsync(int id)
    {
        return playersRepository.GetPlayerAsync(id);
    }
}
