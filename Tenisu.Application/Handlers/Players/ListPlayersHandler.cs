using Tenisu.Application.Repositories;
using Tenisu.Domain.Models;

namespace Tenisu.Application.Handlers.Players;

public class ListPlayersHandler(IPlayersRepository playersRepository)
{
    public Task<IReadOnlyCollection<Player>> HandleAsync()
    {
        return playersRepository.ListPlayersAsync();
    }
}
