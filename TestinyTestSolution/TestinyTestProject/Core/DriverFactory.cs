using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Reflection;
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

        var pathDownload = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Resources");

        Dictionary<string, object> chromePrefs = new()
        {
           { "downloded.default_directory", pathDownload },
            {"savefile.default_directory", pathDownload },
            { "download.prompt_for_download", false},
            { "disable-popup-blocking", true},
            { "profile.default_content_settings.images", 0 },
            { "download.directory_upgrade", true},
            { "safebrowsing.enabled", true},
            { "profile.default_content_setting_values.automatic_downloads", 1}
        };

        chromeOptions.AddUserProfilePreference("prefs", chromePrefs);

        new DriverManager().SetUpDriver(new ChromeConfig());
        return new ChromeDriver(chromeOptions);
    }
}