using TestinyTestProject.Helpers.Configuration;
using TestinyTestProject.Models;
using TestinyTestProject.Fakers;
using TestinyTestProject.Pages;
using Bogus;
using NLog;
using TestinyTestProject.Core;
using NLog.Fluent;

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
            _testCase = TestCase.Generate();
            
            Logger.Log(LogLevel.Info, _testCase.Title);

            _navigationSteps.NavigateToTestCasesPage();
            _testCaseSteps.AddQuickNewTestCase(_testCase);

            var actualTestCaseTitle = _testCaseSteps.GetTestCase(_testCase);

            Logger.Log(LogLevel.Info, actualTestCaseTitle);

            Assert.That(actualTestCaseTitle,
               Is.EqualTo(_testCase.Title));
        }
    }
}
