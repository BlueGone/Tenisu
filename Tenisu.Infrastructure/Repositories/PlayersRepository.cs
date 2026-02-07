using Tenisu.Application.Repositories;
using Tenisu.Domain.Models;

namespace Tenisu.Infrastructure.Repositories;

public class PlayersRepository : IPlayersRepository
{
    public Task<IReadOnlyCollection<Player>> ListPlayersAsync()
    {
        return Task.FromResult<IReadOnlyCollection<Player>>([Player.NovakDjokovic]);
    }

    public Task<Player?> GetPlayerAsync(int id)
    {
        if (id == Player.NovakDjokovic.Id)
        {
            return Task.FromResult<Player?>(Player.NovakDjokovic);
        }

        return Task.FromResult<Player?>(null);
    }
}
