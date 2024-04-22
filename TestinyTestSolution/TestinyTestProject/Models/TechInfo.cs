using System.Text.Json.Serialization;

namespace TestinyTestProject.Models;

public class TechInfo
{
    [JsonPropertyName("count")] public int Count { get; set; }
    [JsonPropertyName("limit")] public int Limit { get; set; }
    [JsonPropertyName("offset")] public int Offset { get; set; }
    [JsonPropertyName("totalCount")] public int TotalCount { get; set; }
}
