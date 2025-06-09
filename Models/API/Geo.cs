using System.Text.Json.Serialization;

namespace DotnetTaskSeleniumNunit.Models.API;

public class Geo
{
    [JsonPropertyName("lat")]
    public string Lat { get; set; }

    [JsonPropertyName("lng")]
    public string Lng { get; set; }
}
