using TestinyTestProject.Helpers.Configuration;
using TestinyTestProject.Models;
using TestinyTestProject.Fakers;
using TestinyTestProject.Pages;
using Bogus;

namespace TestinyTestProject.Tests;

public class TestCaseTest : BaseLoginTest
{
    private TestCase _testCase;
    private static Faker<TestCase> TestCase => new TestCaseFaker();

    [Test]
    public void AddQuickNewTestCaseTest()
    {
        {
            _testCase = TestCase.Generate();
            _navigationSteps.NavigateToTestCasesPage();
            _testCaseSteps.AddQuickNewTestCase(_testCase);

            Assert.That(_testCaseSteps.GetTestCase(_testCase),
                Is.EqualTo(_testCase.Title));
        }
    }
}
