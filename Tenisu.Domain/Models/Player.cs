namespace Tenisu.Domain.Models;

public record Player(
    int Id,
    string FirstName,
    string LastName,
    string ShortName,
    PlayerSex Sex,
    PlayerCountry Country,
    Uri Picture,
    PlayerData Data
);
