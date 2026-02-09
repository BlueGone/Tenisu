using Tenisu.Domain.Models;

namespace Tenisu.Domain.Tests;

public record PlayerBuilder
{
    public static readonly Player DefaultPlayer = new(
        Id: 52,
        FirstName: "Novak",
        LastName: "Djokovic",
        ShortName: "N.DJO",
        PlayerSex.Male,
        new PlayerCountry(new Uri("https://tenisu.latelier.co/resources/Serbie.png"), "SRB"),
        Picture: new Uri("https://tenisu.latelier.co/resources/Djokovic.png"),
        new PlayerData(
            Rank: 2,
            Points: 2542,
            Weight: 80000,
            Height: 188,
            Age: 31,
            Last:
            [
                MatchResult.Win,
                MatchResult.Win,
                MatchResult.Win,
                MatchResult.Lose,
                MatchResult.Lose,
            ]
        )
    );

    public Player Player { get; init; } = DefaultPlayer;

    public PlayerBuilder WithLast(MatchResult[] last) =>
        new() { Player = Player with { Data = Player.Data with { Last = last } } };

    public PlayerBuilder WithCountryCode(string countryCode) =>
        new() { Player = Player with { Country = Player.Country with { Code = countryCode } } };
}
