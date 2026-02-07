using System.Reflection;
using System.Text.Json;
using Tenisu.Domain.Models;

namespace Tenisu.Infrastructure.Seeders;

public interface IPlayersSeeder
{
    List<Player> GetSeedPlayers();
}

public class PlayersSeeder : IPlayersSeeder
{
    private static readonly JsonSerializerOptions JsonOptions = new(JsonSerializerDefaults.Web);
    private const string SeederEmbeddedRessourceName = "players_seed.json";

    public List<Player> GetSeedPlayers()
    {
        try
        {
            using var stream = OpenEmbeddedSeedPlayersStream();
            var root = JsonSerializer.Deserialize<PlayersSeed>(stream, JsonOptions);

            return root?.Players
                ?? throw new PlayersSeederException("Could not deserialize players seed data");
        }
        catch (Exception ex) when (ex is not PlayersSeederException)
        {
            throw new PlayersSeederException("An error occurred while seeding players data", ex);
        }
    }

    private static Stream OpenEmbeddedSeedPlayersStream() =>
        Assembly
            .GetExecutingAssembly()
            .GetManifestResourceStream(typeof(PlayersSeeder), SeederEmbeddedRessourceName)
        ?? throw new PlayersSeederException(
            $"Could not find embedded resource with name {SeederEmbeddedRessourceName}"
        );
}
