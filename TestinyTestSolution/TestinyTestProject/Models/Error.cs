using System.Text.Json.Serialization;

namespace TestinyTestProject.Models;

public class Error
{
    [JsonPropertyName("code")] public string Code { get; set; }
    [JsonPropertyName("status")] public int Status { get; set; }
    [JsonPropertyName("message")] public required string Message { get; set; }
    [JsonPropertyName("reqid")] public string Reqid { get; set; }
}
