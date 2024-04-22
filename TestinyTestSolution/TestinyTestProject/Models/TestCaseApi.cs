using System.Text.Json.Serialization;

namespace TestinyTestProject.Models;

public class TestCaseApi : TestCase
{
    [JsonPropertyName("id")] public int Id { get; set; }
    [JsonPropertyName("project_id")] public int ProjectId { get; set; } = 2;
    [JsonPropertyName("owner_user_id")] public int OwnerUserId { get; set; } = 9343;
    [JsonPropertyName("template")] public string Template { get; set; } = "STEPS";
    [JsonPropertyName("precondition_text")] public string PreconditionText { get; set; }
    [JsonPropertyName("content_text")] public string ContentText { get; set; }
    [JsonPropertyName("steps_text")] public string StepsText { get; set; }
    [JsonPropertyName("expected_result_text")] public string ExpectedResultText { get; set; }
    [JsonPropertyName("priority")] public int Priority { get; set; } = 1;
    [JsonPropertyName("status")] public string Status { get; set; }
    [JsonPropertyName("testcase_type")] public string TestcaseType { get; set; }
}
