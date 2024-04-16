using TestinyTestProject.Elements;
using OpenQA.Selenium;

namespace TestinyTestProject.Pages;

public class DashboardPage(IWebDriver? driver, bool openByURL = false) : BasePage(driver, openByURL)
{
    private const string END_POINT = "DP/dashboard";

    private static readonly By TitleBy = By.TagName("title");

    protected override bool EvaluateLoadedStatus()
    {
        try
        {
            return TitleLabel.Text.Contains("Dashboard");
        }
        catch (Exception)
        {
            return false;
        }
    }

    protected override string GetEndpoint()
    {
        return END_POINT;
    }

    public bool IsPageOpened()
    {
        return TitleLabel.Text.Contains("Dashboard");
    }

    internal UIElement TitleLabel => new(Driver, TitleBy);
}
