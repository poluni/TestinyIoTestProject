using TestinyTestProject.Helpers.Configuration;
using OpenQA.Selenium;

namespace TestinyTestProject.Core;

public class Browser
{
    public IWebDriver Driver { get; private set; }

    public Browser()
    {
    }

    public void SetUpDriver()
    {
        Driver = Configurator.BrowserType?.ToLower() switch
        {
            "chrome" => new DriverFactory().GetChromeDriver(),
            _ => Driver
        } ?? throw new InvalidOperationException("Browser is not supported.");

        Driver.Manage().Window.Maximize();
        Driver.Manage().Cookies.DeleteAllCookies();
        //Driver!.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
    }
}