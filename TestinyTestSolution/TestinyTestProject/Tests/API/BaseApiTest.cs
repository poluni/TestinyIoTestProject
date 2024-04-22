using Allure.NUnit;
using Allure.Net.Commons;
using NLog;
using TestinyTestProject.Clients;
using TestinyTestProject.Services;
using TestinyTestProject.Models;

namespace TestinyTestProject.Tests;

[AllureNUnit]
public class BaseApiTest
{
    private readonly Logger _logger = LogManager.GetCurrentClassLogger();
    protected TestCaseService? TestCaseService;

    protected User Admin { get; private set; }

    [OneTimeSetUp]
    public void SetUpApi()
    {
        var restClient = new RestClientExtended();
        TestCaseService = new TestCaseService(restClient);
    }
    
    [OneTimeSetUp]
    public static void GlobalSetup()
    {
        AllureLifecycle.Instance.CleanupResultDirectory();
    }
    
    [OneTimeTearDown]
    public void TearDownAPI()
    {
        TestCaseService?.Dispose();
    }
}
