using Tenisu.Application.Repositories;
using Tenisu.Domain.Models;
using Tenisu.Infrastructure.Seeders;

namespace Tenisu.Infrastructure.Repositories;

public class PlayersRepository : IPlayersRepository
{
    private readonly List<Player> _players;
    private int _nextId;

    public PlayersRepository(IPlayersSeeder seeder)
    {
        _players = seeder.GetSeedPlayers();
        _nextId =
            _players.Select(player => player.Id).OrderByDescending(id => id).FirstOrDefault(0) + 1;
    }

    public Task<IReadOnlyCollection<Player>> ListPlayersAsync()
    {
        return Task.FromResult<IReadOnlyCollection<Player>>([
            .. _players.OrderBy(player => player.Data.Rank),
        ]);
    }

    public Task<Player?> GetPlayerAsync(int id)
    {
        return Task.FromResult(_players.FirstOrDefault(player => player.Id == id));
    }

    public Task<Player> AddPlayerAsync(Player player)
    {
        player = player with { Id = _nextId++ };
        _players.Add(player);
        return Task.FromResult(player);
    }

    public Task<bool> AnyWithRankAsync(uint rank)
    {
        return Task.FromResult(_players.Any(player => player.Data.Rank == rank));
    }
}
