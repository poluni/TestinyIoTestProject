using System.Text.Json.Serialization;

namespace TestinyTestProject.Models;

public class TestCasesWithParam
{
    [JsonPropertyName("data")] public List<TestCaseApi> TestCasesList { get; set; }
    [JsonPropertyName("meta")] public TechInfo Meta { get; set; }
}