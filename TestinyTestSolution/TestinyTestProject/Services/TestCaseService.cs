using System.Net;
using RestSharp;
using TestinyTestProject.Models;
using TestinyTestProject.Clients;

namespace TestinyTestProject.Services;

public class TestCaseService : ITestCaseService, IDisposable
{
    private readonly RestClientExtended _client;

    public TestCaseService(RestClientExtended client)
    {
        _client = client;
    }

    public Task<TestCaseApi> AddTestCase(TestCaseApi testCase)
    {
        var request = new RestRequest("api/v1/testcase", Method.Post)
        .AddJsonBody(testCase);

        return _client.ExecuteAsync<TestCaseApi>(request);
    }

    public HttpStatusCode AddTestCaseStatusCode(TestCaseApi testCase)
    {
        var request = new RestRequest("api/v1/testcase", Method.Post)
        .AddJsonBody(testCase);

        return _client.ExecuteAsync(request).Result.StatusCode;
    }

    public Task<TestCaseApi> GetTestCaseById(TestCaseApi testCase)
    {
        var request = new RestRequest("api/v1/testcase/{id}", Method.Get)
        .AddUrlSegment("id", testCase.Id);

        return _client.ExecuteAsync<TestCaseApi>(request);
    }

    public Task<TestCasesWithParam> FindTestCasesByPriority()
    {
        var request = new RestRequest("api/v1/testcase", Method.Get)
        .AddQueryParameter(
                "q",
                "{\"filter\": {\"priority\": 1}}");

        return _client.ExecuteAsync<TestCasesWithParam>(request);
    }

    public Task<TestCasesWithParam> FindTestCasesInProject()
    {
        var request = new RestRequest("api/v1/testcase", Method.Get)
        .AddQueryParameter
        (
                "q",
                "{\"filter\":{ \"project_id\": 2}}");

        return _client.ExecuteAsync<TestCasesWithParam>(request);
    }

    public HttpStatusCode FindTestCaseInProjectStatusCode()
    {
        var request = new RestRequest("api/v1/testcase", Method.Get)
        .AddQueryParameter
        (
                "q",
                "{\"filter\":{ \"project_id\": 2}}");

        return _client.ExecuteAsync(request).Result.StatusCode;
    }

    public HttpStatusCode GetTestCaseByIdStatusCode(TestCaseApi testCase)
    {
        var request = new RestRequest("api/v1/testcase/{id}", Method.Get)
        .AddUrlSegment("id", testCase.Id);

        return _client.ExecuteAsync(request).Result.StatusCode;
    }

    public HttpStatusCode GetTestCaseByIntIdStatusCode(int id)
    {
        var request = new RestRequest("api/v1/testcase/{id}", Method.Get)
        .AddUrlSegment("id", id);

        return _client.ExecuteAsync(request).Result.StatusCode;
    }

    public Task<Error> GetTestCaseByIntIdErrorMessage(int id)
    {
        var request = new RestRequest("api/v1/testcase/{id}", Method.Get)
        .AddUrlSegment("id", id);

        return _client.ExecuteAsync<Error>(request);
    }

    public void Dispose()
    {
        _client?.Dispose();
        GC.SuppressFinalize(this);
    }
}
