using TestinyTestProject.Models;
using TestinyTestProject.Pages;
using OpenQA.Selenium;

namespace TestinyTestProject.Steps;

public class TestCaseSteps(IWebDriver driver) : BaseStep(driver)
{
    private readonly TestCasesPage _testCasesPage;

    public TestCasesPage AddQuickNewTestCase(TestCase testcase)
    {
        TestCasesPage = new TestCasesPage(Driver, false);

        TestCasesPage.CreateQuickNewTestCaseClick();
        TestCasesPage.SetTitleNewTestCase(testcase.Title);
        TestCasesPage.SaveQuickNewTestCaseClick();

        return new TestCasesPage(Driver);
    }

    internal string GetTestCase(TestCase testCaseToFind)
    {
        TestCasesPage testCasesPage = new TestCasesPage(driver);
        string txt = testCasesPage.TestCaseTable.GetCell("TITLE", testCaseToFind.Title, 4).Text;
        return txt;
    }
}
