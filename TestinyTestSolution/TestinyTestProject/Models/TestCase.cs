using System.Text.Json.Serialization;

namespace TestinyTestProject.Models;

public class TestCase
{
    [JsonPropertyName("title")]  public required string Title { get; set; }
}
