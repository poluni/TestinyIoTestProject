using TestinyTestProject.Models;
using TestinyTestProject.Pages;
using OpenQA.Selenium;

namespace TestinyTestProject.Steps;

public class NavigationSteps : BaseStep
{
    private readonly LoginPage _loginPage;

    public NavigationSteps(IWebDriver driver) : base(driver)
    {
        _loginPage = new LoginPage(Driver);
    }

    public DashboardPage SuccessfulLogin(User user)
    {
        return Login<DashboardPage>(user);
    }

    public T Login<T>(User user) where T : BasePage
    {
        LoginPage = new LoginPage(Driver);

        LoginPage.SetEmail(user.Email);
        LoginPage.SetPassword(user.Password);
        LoginPage.LogInClick();

        return (T)Activator.CreateInstance(typeof(T), Driver, false);
    }
}
