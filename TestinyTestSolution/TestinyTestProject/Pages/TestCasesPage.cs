using TestinyTestProject.Elements;
using OpenQA.Selenium;

namespace TestinyTestProject.Pages;

public class TestCasesPage(IWebDriver? driver, bool openByURL = false) : BasePage(driver, openByURL)
{
    private const string END_POINT = "DP/testcases";

    private static readonly By TitleBy = By.TagName("title");
    private static readonly By CreateQuickTestCaseButtonBy = By.XPath("//button/div[text()='Quick create']");
    private static readonly By TitleNewTestCaseInputBy = By.XPath("//input[@placeholder='New test case']");
    private static readonly By SaveQuickNewTestCaseButtonBy = By.XPath("//button[@title='Commit']");
    private static readonly By TestCaseTableBy = By.CssSelector("table.sc-bWbSeO.ckdLtt");

    protected override bool EvaluateLoadedStatus()
    {
        try
        {
            return TitleLabel.Displayed;
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
        return TitleLabel.Text.Contains("Test cases");
    }

    public void CreateQuickNewTestCaseClick()
    {
        CreateQuickTestCaseButton.Click();
    }

    public void SetTitleNewTestCase(string value)
    {
        TitleNewTestCaseInput.SendKeys(value);
    }

    public void SaveQuickNewTestCaseClick()
    {
        SaveQuickNewTestCaseButton.Click();
    }

    private UIElement TitleLabel => new(Driver, TitleBy);
    private UIElement CreateQuickTestCaseButton => new(Driver, CreateQuickTestCaseButtonBy);
    private UIElement TitleNewTestCaseInput => new(Driver, TitleNewTestCaseInputBy);
    private Button SaveQuickNewTestCaseButton => new Button(Driver, SaveQuickNewTestCaseButtonBy);
    internal Table TestCaseTable => new Table(Driver, TestCaseTableBy);
}
