using TestinyTestProject.Models;
using TestinyTestProject.Fakers;
using Bogus;
using NLog;
using Allure.Net.Commons;

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

    [Test]
    public void DeleteTestCaseTest()
    {
        {
            AllureApi.SetTestName("Delete test case.");
            AllureApi.SetDescription("Delete test case. The test case is successfull deleted.");
            AllureApi.SetSeverity(SeverityLevel.critical);
            AllureApi.AddTags("UI");
            AllureApi.AddParentSuite("TestCases");

            //Arrange
            _testCase = TestCase.Generate();

            Logger.Log(LogLevel.Info, _testCase.Title);

            _navigationSteps.NavigateToTestCasesPage();
            _testCaseSteps.AddQuickNewTestCase(_testCase);

            //Act

            //Assert

            var actualTestCaseTitle = _testCaseSteps.GetTestCaseTitle(_testCase);

            Logger.Log(LogLevel.Info, actualTestCaseTitle);

            Assert.That(actualTestCaseTitle,
               Is.EqualTo(_testCase.Title));
        }
    }
}
