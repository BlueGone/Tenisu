using Tenisu.Domain.Models;

namespace Tenisu.Application.Repositories;

public interface IPlayersRepository
{
    Task<IReadOnlyCollection<Player>> ListPlayersAsync();
    Task<Player?> GetPlayerAsync(int id);
}
