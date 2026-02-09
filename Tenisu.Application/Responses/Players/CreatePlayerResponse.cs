using Tenisu.Domain.Models;

namespace Tenisu.Application.Responses.Players;

public abstract record CreatePlayerResponse
{
    protected CreatePlayerResponse() { }

    public record Created(Player Player) : CreatePlayerResponse;

    public record PlayerWithRankAlreadyExist(uint Rank) : CreatePlayerResponse;
}
