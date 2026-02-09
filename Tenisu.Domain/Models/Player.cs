using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Tenisu.Domain.Models;

public record Player(
    int Id,
    [property: MinLength(1, ErrorMessage = "FirstName must not be empty")] string FirstName,
    [property: MinLength(1, ErrorMessage = "LastName must not be empty")] string LastName,
    [property: Length(1, 10)] string ShortName,
    PlayerSex Sex,
    PlayerCountry Country,
    Uri Picture,
    PlayerData Data
);
