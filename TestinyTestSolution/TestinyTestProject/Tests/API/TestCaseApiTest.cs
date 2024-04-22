using Bogus;
using System.Net;
using NLog;
using TestinyTestProject.Fakers;
using TestinyTestProject.Models;
using Allure.Net.Commons;

namespace TestinyTestProject.Tests.API;

public class TestCaseApiTest : BaseApiTest
{
    private readonly Logger _logger = LogManager.GetCurrentClassLogger();
    private static Faker<TestCase> TestCase => new TestCaseFaker();
    private TestCaseApi _testCase;

    [OneTimeSetUp]
    public void AddFirstCaseTest()
    {
        _testCase = new TestCaseApi
        {
            Title = TestCase.Generate().Title
        };

        var actualTestCase = TestCaseService!.AddTestCase(_testCase);

        _testCase = actualTestCase.Result;

        _logger.Info(_testCase.ToString);
    }

    [Test]
    [Order(1)]
    [Category("Smoke"), Category("Regression")]
    public void AddTestCaseApiTest()
    {
        AllureApi.SetTestName("[API] Create quick new test case with 200 chars title.");
        AllureApi.SetDescription("Create quick new test case with 200 chars title. The test case is successfull created.");
        AllureApi.SetSeverity(SeverityLevel.critical);
        AllureApi.AddTags("API", "Positive");
        AllureApi.AddParentSuite("TestCases");

        _testCase = new TestCaseApi
        {
            Title = TestCase.Generate().Title
        };

        var actualTestCase = TestCaseService!.AddTestCase(_testCase);

        _testCase = actualTestCase.Result;

        _logger.Info(_testCase.ToString);

        Assert.That(actualTestCase.Result.Title, Is.EqualTo(_testCase.Title));
    }

    [Test]
    [Order(1)]
    [Category("Smoke"), Category("Regression")]
    public void AddTestCaseStatusCodeApiTest()
    {
        AllureApi.SetTestName("[API] StatusCode. Add new test case. OK.");
        AllureApi.SetSeverity(SeverityLevel.critical);
        AllureApi.AddTags("API", "Positive");
        AllureApi.AddParentSuite("TestCases");

        _testCase = new TestCaseApi
        {
            Title = TestCase.Generate().Title
        };

        var result = TestCaseService!.AddTestCaseStatusCode(_testCase);

        _logger.Info(_testCase.ToString);

        Assert.That(result, Is.EqualTo(HttpStatusCode.OK));

        _logger.Info(result);
    }

    [Test]
    [Order(2)]
    [Category("Smoke"), Category("Regression")]
    public void GetTestCaseTestById()
    {
        AllureApi.SetTestName("[API] Get test case by id. OK.");
        AllureApi.SetSeverity(SeverityLevel.critical);
        AllureApi.AddTags("API", "Positive");
        AllureApi.AddParentSuite("TestCases");

        var actualCase = TestCaseService!.GetTestCaseById(_testCase);
        var result = TestCaseService!.GetTestCaseByIdStatusCode(_testCase);

        Assert.Multiple(() =>
        {
            Assert.That(actualCase.Result.Title, Is.EqualTo(_testCase.Title));
            Assert.That(result, Is.EqualTo(HttpStatusCode.OK));
        });

        _logger.Info(actualCase.Result.ToString);

        _logger.Info(result);
    }

    [Test]
    [Order(2)]
    [Category("Regression")]
    public void GetTestCaseTestByInvalidId()
    {
        AllureApi.SetTestName("[API] Get test case by invalid id. BadRequest. API_INVALID_REQUEST.");
        AllureApi.SetSeverity(SeverityLevel.normal); ;
        AllureApi.AddTags("API", "Negative");
        AllureApi.AddParentSuite("TestCases");

        int invlidId = 0;

        var errorMessage = TestCaseService!.GetTestCaseByIntIdErrorMessage(invlidId);
        var result = TestCaseService!.GetTestCaseByIntIdStatusCode(invlidId);

        Assert.Multiple(() =>
        {
            Assert.That(errorMessage.Result.Code, Is.EqualTo("API_INVALID_REQUEST"));
            Assert.That(result, Is.EqualTo(HttpStatusCode.BadRequest));
        });

        _logger.Info(result);
        _logger.Info(errorMessage);
    }

    [Test]
    [Order(2)]
    [Category("Regression")]
    public void GetTestCaseTestByNotExistedId()
    {
        AllureApi.SetTestName("[API] Get test case by not existed id. NotFound. API_DATA_NOT_FOUND.");
        AllureApi.SetSeverity(SeverityLevel.normal); ;
        AllureApi.AddTags("API", "Negative");
        AllureApi.AddParentSuite("TestCases");

        int notExistedId = 1;

        var errorMessage = TestCaseService!.GetTestCaseByIntIdErrorMessage(notExistedId);
        var result = TestCaseService!.GetTestCaseByIntIdStatusCode(notExistedId);

        Assert.Multiple(() =>
        {
            Assert.That(errorMessage.Result.Code, Is.EqualTo("API_DATA_NOT_FOUND"));
            Assert.That(result, Is.EqualTo(HttpStatusCode.NotFound));
        });

        _logger.Info(result);
        _logger.Info(errorMessage);
    }

    [Test]
    [Order(2)]
    [Category("Smoke"), Category("Regression")]
    public void FindTestCaseTestInDemoProject()
    {
        AllureApi.SetTestName("[API] Find TestCases In DemoProject. OK.");        
        AllureApi.SetSeverity(SeverityLevel.normal);
        AllureApi.AddTags("API", "Positive");
        AllureApi.AddParentSuite("TestCases");

        var testCasesList = TestCaseService!.FindTestCasesInProject().Result.TestCasesList;
        var resultCode = TestCaseService!.FindTestCaseInProjectStatusCode();

        _logger.Info(testCasesList.ToString);
        _logger.Info(resultCode.ToString);

        Assert.Multiple(() =>
        {
            foreach (var testCase in testCasesList)
            {
                Assert.That(testCase.ProjectId, Is.EqualTo(2));
            }
            Assert.That(resultCode, Is.EqualTo(HttpStatusCode.OK));
        });
    }

    [Test]
    [Order(3)]
    [Category("Regression")]
    public void FindTestCaseTestByPriority()
    {
        AllureApi.SetTestName("[API] Find TestCases by priority = 1 in all projects.");
        AllureApi.SetSeverity(SeverityLevel.normal);
        AllureApi.AddTags("API", "Positive");
        AllureApi.AddParentSuite("TestCases");

        var testCasesList = TestCaseService!.FindTestCasesByPriority().Result.TestCasesList;

        _logger.Info(testCasesList.ToString);

        Assert.Multiple(() =>
        {
            foreach (var testCase in testCasesList)
            {
                Assert.That(testCase.Priority, Is.EqualTo(1));
            }
        });
    }
}
