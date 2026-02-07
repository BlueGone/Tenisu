using System.Text.Json.Serialization;

namespace Tenisu.Domain.Models;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum PlayerSex
{
    [JsonStringEnumMemberName("M")]
    Male,

    [JsonStringEnumMemberName("F")]
    Female,
}
