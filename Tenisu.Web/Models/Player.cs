namespace Tenisu.Web.Models;

public record Player(
    int Id,
    string FirstName,
    string LastName,
    string ShortName,
    PlayerSex Sex,
    PlayerCountry Country,
    Uri Picture,
    PlayerData Data
)
{
    public static readonly Player NovakDjokovic = new Player(
        Id: 52,
        FirstName: "Novak",
        LastName: "Djokovic",
        ShortName: "N.DJO",
        PlayerSex.Male,
        PlayerCountry.Serbia,
        Picture: new Uri("https://tenisu.latelier.co/resources/Djokovic.png"),
        new PlayerData(
            Rank: 2,
            Points: 2542,
            Weight: 80000,
            Height: 188,
            Age: 31,
            Last: Enumerable.Repeat(MatchResult.Win, 5).ToArray()
        )
    );
};
