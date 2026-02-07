namespace Tenisu.Infrastructure.Seeders;

public class PlayersSeederException : Exception
{
    public PlayersSeederException() { }

    public PlayersSeederException(string message)
        : base(message) { }

    public PlayersSeederException(string message, Exception innerException)
        : base(message, innerException) { }
}
