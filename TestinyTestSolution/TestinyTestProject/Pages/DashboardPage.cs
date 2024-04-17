using TestinyTestProject.Elements;
using OpenQA.Selenium;

namespace TestinyTestProject.Pages;

public class DashboardPage(IWebDriver? driver, bool openByURL = false) : BasePage(driver, openByURL)
{
    private const string END_POINT = "DP/dashboard";

    private static readonly By TitleBy = By.TagName("title");
    private static readonly By CreateTestCaseLinkBy = By.XPath("//a/div/h4[contains(text(),'Create test cases')]");

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

    public void CreateTestCaseClick()
    {
        CreateTestCaseLink.Click();
    }

    private UIElement TitleLabel => new(Driver, TitleBy);
    private UIElement CreateTestCaseLink => new(Driver, CreateTestCaseLinkBy);
}
