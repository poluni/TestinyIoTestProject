using TestinyTestProject.Models;
using TestinyTestProject.Fakers;
using TestinyTestProject.Core;
using System.Reflection;
using Bogus;
using NLog;
using Allure.Net.Commons;

namespace TestinyTestProject.Tests;

[TestFixture]
public class TestCaseTest : BaseLoginTest
{
    private TestCase _testCase;
    private static Faker<TestCase> TestCase => new TestCaseFaker();
    private static Faker<TestCase> TestCaseWithInvalidTitleFaker => new TestCaseInvalidDataFaker();
    private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

    [Test]
    public void AddQuickNewTestCaseTest()
    {
        {
            AllureApi.SetTestName("Create quick not first new test case with 200 chars title.");
            AllureApi.SetDescription("Create quick not first new test case with 200 chars title. The test case is successfull created.");
            AllureApi.SetSeverity(SeverityLevel.normal);
            AllureApi.AddTags("UI", "Positive");
            AllureApi.AddParentSuite("TestCases");

            //TO DO сделать подготовку через API первого test case

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
            AllureApi.SetSeverity(SeverityLevel.normal);
            AllureApi.AddTags("UI", "Positive");
            AllureApi.AddParentSuite("TestCases");          

            _navigationSteps.NavigateToTestCasesPage();

            //TO DO сделать подготовку через API первого test case

            _testCaseSteps.DeleteTestCase();

            Assert.That(_testCaseSteps.GetCountSelectedTestCase, Is.EqualTo(0));
        }
    }

    [Test]
    public void AddQuickNewTestCaseWithInvalidTitleTest()
    {
        {
            AllureApi.SetTestName("Create quick new test case with 201 chars title.");
            AllureApi.SetDescription("Create quick new test case with 201 chars title. The test case is not created. Error message is presents.");
            AllureApi.SetSeverity(SeverityLevel.normal);
            AllureApi.AddTags("UI", "Negative");
            AllureApi.AddParentSuite("TestCases");

            _testCase = TestCaseWithInvalidTitleFaker.Generate();
            int titleLength = _testCase.Title.Length;

            Logger.Log(LogLevel.Info, titleLength);

            _navigationSteps.NavigateToTestCasesPage();
            _testCaseSteps.ValidateTitleQuickNewTestCase(_testCase);

            var errorMessage = _testCaseSteps.GetErrorMessageInvalidTitleQuickNewTestCase();

            Logger.Log(LogLevel.Info, errorMessage);

            Assert.Multiple(() =>
            {
                Assert.That(errorMessage,
                    Is.EqualTo($"Has {titleLength} characters. Must not have more than 200 characters."));
                Assert.That(_testCaseSteps.IsDisabledSaveQuickNewTestCaseButton(), Is.EqualTo(true));
            });
        }
    }

    [Test]
    public void AddQuickNewTestCaseWithWhitespaceTitleTest()
    {
        {
            AllureApi.SetTestName("Create quick new test case with whitespace char title.");
            AllureApi.SetDescription("Create quick new test case with whitespace char title. The test case is not created. Error message is presents.");
            AllureApi.SetSeverity(SeverityLevel.trivial);
            AllureApi.AddTags("UI", "Negative");
            AllureApi.AddParentSuite("TestCases");

            _testCase = new TestCase 
            { 
                Title = " "
            };

            Logger.Log(LogLevel.Info, _testCase.Title);

            _navigationSteps.NavigateToTestCasesPage();
            _testCaseSteps.ValidateTitleQuickNewTestCase(_testCase);

            var errorMessage = _testCaseSteps.GetErrorMessageInvalidTitleQuickNewTestCase();

            Logger.Log(LogLevel.Info, errorMessage);

            Assert.Multiple(() =>
            {
                Assert.That(errorMessage,
                    Is.EqualTo("Must have at least 1 characters (leading/trailing white spaces not counted)."));
                Assert.That(_testCaseSteps.IsDisabledSaveQuickNewTestCaseButton(), Is.EqualTo(true));
            });
        }
    }

    [Test]
    public void GetCopiedMessageTestCaseTest()
    {
        {
            AllureApi.SetTestName("Message about copied TestCase is displayed");
            AllureApi.SetSeverity(SeverityLevel.trivial);
            AllureApi.AddTags("UI", "Negative");
            AllureApi.AddParentSuite("TestCases");

            _navigationSteps.NavigateToTestCasesPage();
            _testCaseSteps.FocusTestCaseCopiedInfo();

            string actualTxt = _testCaseSteps.GetTestCaseCopiedInfo();

            Assert.That(actualTxt,
                    Is.EqualTo("Copied link to clipboard"));
        }
    }
    /*
    [Test]
    public void ImportCSVNewTestCaseTest()
    {
        {
            AllureApi.SetTestName("Import CSV file with not first new test case.");
            AllureApi.SetDescription("Import CSV file with not first new test case. The test case is successfull created.");
            AllureApi.SetSeverity(SeverityLevel.critical);
            AllureApi.AddTags("UI", "Positive");
            AllureApi.AddParentSuite("TestCases");

            //TO DO сделать подготовку через API первого test case

            _navigationSteps.NavigateToTestCasesPage();
            _navigationSteps.NavigateToImportTestCasesPage();

            var pathDownload = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Resources", "testiny_testcase_import_sample.csv");



            fileUploadElement.SendKeys(filePath);

            WaitsHelper.WaitForExists(By.Id("file-submit")).Submit();

            var uploadedFile = WaitsHelper.WaitForExists(By.Id("uploaded-files"));
        }
    }
    */
}