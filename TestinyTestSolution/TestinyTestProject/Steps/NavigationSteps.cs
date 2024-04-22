using Allure.NUnit.Attributes;
using TestinyTestProject.Models;
using TestinyTestProject.Pages;
using OpenQA.Selenium;

namespace TestinyTestProject.Steps;

public class NavigationSteps(IWebDriver driver) : BaseStep(driver)
{
    [AllureStep("LogIn with ")]
    public DashboardPage SuccessfulLogin([Name("User: ")] User user)
    {
        return Login<DashboardPage>(user);
    }

    [AllureStep("Navigate to import test case ")]
    public TestCasesImportDialogue NavigateToImportTestCasesPage()
    {
        TestCasesPage = new TestCasesPage(driver);

        TestCasesPage.ImportNewTestCaseClick();

        return new TestCasesImportDialogue(Driver);
    }

    [AllureStep("Navigate to test cases page")]
    public TestCasesPage NavigateToTestCasesPage()
    {
        DashboardPage = new DashboardPage(driver);

        DashboardPage.CreateTestCaseClick();

        return new TestCasesPage(Driver);
    }

    public T Login<T>(User user) where T : BasePage
    {
        LoginPage = new LoginPage(driver);

        LoginPage.SetEmail(user.Username);
        LoginPage.SetPassword(user.Password);
        LoginPage.LogInClick();

        return (T)Activator.CreateInstance(typeof(T), Driver, false);
    }
}
