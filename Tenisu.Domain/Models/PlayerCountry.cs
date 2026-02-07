namespace Tenisu.Domain.Models;

public record PlayerCountry(Uri Picture, string Code)
{
    public static PlayerCountry Serbia =>
        new PlayerCountry(new Uri("https://tenisu.latelier.co/resources/Serbie.png"), "SRB");
};
