using TestinyTestProject.Pages;
using OpenQA.Selenium;

namespace TestinyTestProject.Steps;

public class BaseStep(IWebDriver driver)
{
    protected readonly IWebDriver Driver = driver;

    protected LoginPage? LoginPage { get; set; }
    protected DashboardPage? DashboardPage { get; set; }
    protected TestCasesPage? TestCasesPage { get; set; }
}
