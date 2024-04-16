using TestinyTestProject.Elements;
using OpenQA.Selenium;

namespace TestinyTestProject.Pages;

public class LoginPage(IWebDriver? driver, bool openByURL = false) : BasePage(driver, openByURL)
{
    private const string END_POINT = "";

    private static readonly By EmailInputBy = By.Name("email");
    private static readonly By PswInputBy = By.Name("password");
    private static readonly By LoginInButtonBy = By.XPath("//div[contains(text(),'Log in')]");

    protected override string GetEndpoint()
    {
        return END_POINT;
    }

    protected override bool EvaluateLoadedStatus()
    {
        return LoginInButton.Displayed && EmailInput.Displayed;
    }

    public void SetEmail(string value)
    {
        EmailInput.SendKeys(value);
    }

    public void SetPassword(string value)
    {
        PswInput.SendKeys(value);
    }

    public void LogInClick()
    {
        LoginInButton.Click();
    }

    internal UIElement EmailInput => new(Driver, EmailInputBy);
    internal UIElement PswInput => new(Driver, PswInputBy);
    internal Button LoginInButton => new Button(Driver, LoginInButtonBy);
}