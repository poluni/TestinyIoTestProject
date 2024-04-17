using TestinyTestProject.Models;
using TestinyTestProject.Pages;
using OpenQA.Selenium;

namespace TestinyTestProject.Steps;

public class NavigationSteps(IWebDriver driver) : BaseStep(driver)
{
    public DashboardPage SuccessfulLogin(User user)
    {
        return Login<DashboardPage>(user);
    }

    public TestCasesPage NavigateToTestCasesPage()
    {
        DashboardPage = new DashboardPage(driver);

        DashboardPage.CreateTestCaseClick();

        return new TestCasesPage(Driver);
    }

    public T Login<T>(User user) where T : BasePage
    {
        LoginPage = new LoginPage(driver);

        LoginPage.SetEmail(user.Email);
        LoginPage.SetPassword(user.Password);
        LoginPage.LogInClick();

        return (T)Activator.CreateInstance(typeof(T), Driver, false);
    }
}
