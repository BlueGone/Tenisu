using System.ComponentModel.DataAnnotations;

namespace Tenisu.Domain.Models;

public record PlayerCountry(Uri Picture, [property: Length(3, 3)] string Code);
