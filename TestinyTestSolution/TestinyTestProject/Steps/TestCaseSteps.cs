using Allure.NUnit.Attributes;
using TestinyTestProject.Models;
using TestinyTestProject.Pages;
using OpenQA.Selenium;

namespace TestinyTestProject.Steps;

public class TestCaseSteps(IWebDriver driver) : BaseStep(driver)
{
    [AllureStep("Create quick new test case.")]
    public TestCasesPage AddQuickNewTestCase(TestCase testcase)
    {
        TestCasesPage = new TestCasesPage(Driver, false);

        TestCasesPage.CreateQuickNewTestCaseClick();
        TestCasesPage.SetTitleNewTestCase(testcase.Title);
        TestCasesPage.SaveQuickNewTestCaseClick();

        return new TestCasesPage(Driver);
    }

    [AllureStep("Create quick new test case without saving.")]
    public TestCasesPage ValidateTitleQuickNewTestCase(TestCase testcase)
    {
        TestCasesPage = new TestCasesPage(Driver, false);

        TestCasesPage.CreateQuickNewTestCaseClick();
        TestCasesPage.SetTitleNewTestCase(testcase.Title);

        return new TestCasesPage(Driver);
    }

    [AllureStep("ErrorMessage is presents for invalid title quick new test case")]
    public string GetErrorMessageInvalidTitleQuickNewTestCase()
    {
        TestCasesPage = new TestCasesPage(Driver, false);

        TestCasesPage.FocusTitleNewTestCase();

        return TestCasesPage.GetErrorMessageTestCaseTitle();
    }

    [AllureStep("Save quick new testcase button is disabled.")]
    public bool IsDisabledSaveQuickNewTestCaseButton()
    {
        TestCasesPage = new TestCasesPage(Driver, false);

        return TestCasesPage.IsDisabledSaveQuickNewTestCaseButtonDisplayed();
    }

    [AllureStep("Delete all test cases.")]
    public TestCasesPage DeleteTestCase()
    {
        TestCasesPage = new TestCasesPage(Driver, false);

        TestCasesPage.AllTestCaseUnselectedCheckboxClick();
        TestCasesPage.DeleteButtonClick();
        if (TestCasesPage.IsDeletePopUpWindowDisplayed())
            TestCasesPage.DeleteConfirmationButtonClick();

        return new TestCasesPage(Driver);
    }

    [AllureStep("Find created test case.")]
    internal string GetTestCaseTitle(TestCase testCaseToFind)
    {
        TestCasesPage testCasesPage = new TestCasesPage(driver);

        string txt = testCasesPage.TestCaseTable.GetCell("TITLE", testCaseToFind.Title, 4).Text;

        return txt;
    }

    [AllureStep("Focus TestCase copied info")]
    public TestCasesPage FocusTestCaseCopiedInfo()
    {
        TestCasesPage testCasesPage = new TestCasesPage(driver);

        testCasesPage.AllTestCaseLinkClick();
        testCasesPage.AllTestCaseLinkFocus();

        return new TestCasesPage(Driver);
    }

    [AllureStep("Message about copied text.")]
    internal string GetTestCaseCopiedInfo()
    {
        TestCasesPage testCasesPage = new TestCasesPage(driver);

        return testCasesPage.GetCopiedMessageTestCaseText();
    }

    [AllureStep("Current count test cases is ")]
    public int GetCountSelectedTestCase()
    {
        TestCasesPage = new TestCasesPage(Driver, false);

        TestCasesPage.GetCountSelectedTestCaseText();
        int count = int.Parse(TestCasesPage.GetCountSelectedTestCaseText());

        return count;
    }

    public bool IsOpenedTestCasesPage()
    {
        TestCasesPage = new TestCasesPage(Driver, false);
        
        return TestCasesPage.IsPageOpened();
    }
}
