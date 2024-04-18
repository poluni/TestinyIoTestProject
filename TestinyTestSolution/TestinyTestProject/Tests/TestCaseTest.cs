using TestinyTestProject.Helpers.Configuration;
using TestinyTestProject.Models;
using TestinyTestProject.Fakers;
using TestinyTestProject.Pages;
using Bogus;
using NLog;
using TestinyTestProject.Core;
using NLog.Fluent;
using Allure.Net.Commons;
using NUnit.Allure.Attributes;

namespace TestinyTestProject.Tests;

[TestFixture]
public class TestCaseTest : BaseLoginTest
{
    private TestCase _testCase;
    private static Faker<TestCase> TestCase => new TestCaseFaker();
    private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

    [Test]
    public void AddQuickNewTestCaseTest()
    {
        {
            AllureApi.SetTestName("Create quick new test case with 200 chars title.");
            AllureApi.SetDescription("Create quick new test case with 200 chars title. The test case is successfull created.");
            AllureApi.SetSeverity(SeverityLevel.normal);
            AllureApi.AddTags("UI");
            AllureApi.AddParentSuite("TestCases");

            _testCase = TestCase.Generate();

            Logger.Log(LogLevel.Info, _testCase.Title);

            _navigationSteps.NavigateToTestCasesPage();
            _testCaseSteps.AddQuickNewTestCase(_testCase);

            var actualTestCaseTitle = _testCaseSteps.GetTestCaseTitle(_testCase);

            Logger.Log(LogLevel.Info, actualTestCaseTitle);

            Assert.That(actualTestCaseTitle,
               Is.EqualTo(_testCase.Title));
        }
    }
}
