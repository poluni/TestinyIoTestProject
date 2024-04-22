using System.Net;
using TestinyTestProject.Models;

namespace TestinyTestProject.Services;

public interface ITestCaseService
{
    Task<TestCaseApi> AddTestCase(TestCaseApi testCase);
    Task<TestCaseApi> GetTestCaseById(TestCaseApi testCase);
    Task<TestCasesWithParam> FindTestCasesInProject();
    Task<TestCasesWithParam> FindTestCasesByPriority();

    HttpStatusCode AddTestCaseStatusCode(TestCaseApi testCase);
    HttpStatusCode GetTestCaseByIdStatusCode(TestCaseApi testCase);
    HttpStatusCode FindTestCaseInProjectStatusCode();
    HttpStatusCode GetTestCaseByIntIdStatusCode(int id);

    Task<Error> GetTestCaseByIntIdErrorMessage(int id);
}
