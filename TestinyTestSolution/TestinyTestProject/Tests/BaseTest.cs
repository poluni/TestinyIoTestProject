using OpenQA.Selenium;
using TestinyTestProject.Core;
using TestinyTestProject.Helpers;
using TestinyTestProject.Helpers.Configuration;
using TestinyTestProject.Steps;
using Allure.Net.Commons;
using Allure.NUnit;
using System.Text;
using TestinyTestProject.Models;

namespace TestinyTestProject.Tests;

[AllureNUnit]
public class BaseTest
{
    protected IWebDriver Driver { get; private set; }
    protected WaitsHelper WaitsHelper { get; private set; }

    protected NavigationSteps _navigationSteps;
    protected TestCaseSteps _testCaseSteps;

    protected User Admin { get; private set; }
    
    [OneTimeSetUp]
    public static void SuiteSetup()
    {
        new NLogConfig().Config();
    }
    
    [OneTimeSetUp]
    public static void GlobalSetup()
    {
        AllureLifecycle.Instance.CleanupResultDirectory();
    }

    [SetUp]
    public void FactoryDriverTest()
    {
        Driver = new Browser().Driver;
        WaitsHelper = new WaitsHelper(Driver, TimeSpan.FromSeconds(Configurator.WaitsTimeout));

        _navigationSteps = new NavigationSteps(Driver);
        _testCaseSteps = new TestCaseSteps(Driver);

        Admin = new User
        {
            Email = Configurator.AppSettings.Username,
            Password = Configurator.AppSettings.Password
        };

        Driver.Navigate().GoToUrl(Configurator.AppSettings.URL);
    }

    [TearDown]
    public void TearDown()
    {
        if (TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
        {
            Screenshot screenshot = ((ITakesScreenshot)Driver).GetScreenshot();
            byte[] screenshotBytes = screenshot.AsByteArray;

            AllureApi.AddAttachment("Screenshot", "image/png", screenshotBytes);
            AllureApi.AddAttachment("data.txt", "text/plain", Encoding.UTF8.GetBytes(""));
        }
        
        Driver.Quit();
    }
}
