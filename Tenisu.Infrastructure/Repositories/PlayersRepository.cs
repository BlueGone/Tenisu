using Tenisu.Application.Repositories;
using Tenisu.Domain.Models;
using Tenisu.Infrastructure.Seeders;

namespace Tenisu.Infrastructure.Repositories;

public class PlayersRepository(IPlayersSeeder seeder) : IPlayersRepository
{
    private readonly List<Player> _players = seeder.GetSeedPlayers();

    public Task<IReadOnlyCollection<Player>> ListPlayersAsync()
    {
        return Task.FromResult<IReadOnlyCollection<Player>>([.. _players]);
    }

    public Task<Player?> GetPlayerAsync(int id)
    {
        return Task.FromResult(_players.FirstOrDefault(player => player.Id == id));
    }
}
