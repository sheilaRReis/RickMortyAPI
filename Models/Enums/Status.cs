using System.Text.Json.Serialization;

namespace Rick_MortyAPI.Models.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Status
    {
        Alive,
        Dead,
        Unknown
    }
}
