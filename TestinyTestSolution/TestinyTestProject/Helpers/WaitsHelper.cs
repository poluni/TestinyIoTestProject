using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace TestinyTestProject.Helpers;

public class WaitsHelper(IWebDriver driver, TimeSpan timeout)
{
    private readonly WebDriverWait _wait = new(driver, timeout);

    public IWebElement WaitForExists(By locator)
    {
        return _wait.Until(ExpectedConditions.ElementExists(locator));
    }

    public IWebElement FluentWaitForElement(By locator)
    {
        WebDriverWait fluentWait = new WebDriverWait(driver, TimeSpan.FromSeconds(3))
        {
            PollingInterval = TimeSpan.FromMilliseconds(50)
        };

        fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));

        return fluentWait.Until(_ => driver.FindElement(locator));
    }
}