using TestinyTestProject.Helpers.Configuration;
using OpenQA.Selenium;

namespace TestinyTestProject.Core;

public class Browser
{
    public IWebDriver? Driver { get; }

    public Browser()
    {
        Driver = Configurator.BrowserType?.ToLower() switch
        {
            "chrome" => new DriverFactory().GetChromeDriver(),
            _ => Driver
        };

        Driver?.Manage().Window.Maximize();
        Driver?.Manage().Cookies.DeleteAllCookies();
        //Driver!.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
    }
}