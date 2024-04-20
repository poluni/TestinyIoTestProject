using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using LogLevel = OpenQA.Selenium.LogLevel;

namespace TestinyTestProject.Core;

public class DriverFactory
{
    public IWebDriver? GetChromeDriver()
    {
        var chromeOptions = new ChromeOptions();
        chromeOptions.AddArguments("--incognito");
        chromeOptions.AddArguments("--disable-gpu");
        chromeOptions.AddArguments("--disable-extensions");

        chromeOptions.SetLoggingPreference(LogType.Browser, LogLevel.All);
        chromeOptions.SetLoggingPreference(LogType.Driver, LogLevel.All);

        new DriverManager().SetUpDriver(new ChromeConfig());
        return new ChromeDriver(chromeOptions);
    }
}