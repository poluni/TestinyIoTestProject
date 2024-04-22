using Allure.NUnit;
using NLog;
using TestinyTestProject.Clients;
using TestinyTestProject.Services;

namespace TestinyTestProject.Tests;

[AllureNUnit]
public class BaseApiTest : BaseTest
{
    private readonly Logger _logger = LogManager.GetCurrentClassLogger();
    protected TestCaseService? TestCaseService;

    [OneTimeSetUp]
    public void SetUpApi()
    {
        var restClient = new RestClientExtended();
        TestCaseService = new TestCaseService(restClient);
    }

    [OneTimeTearDown]
    public void TearDownAPI()
    {
        TestCaseService?.Dispose();
    }
}
