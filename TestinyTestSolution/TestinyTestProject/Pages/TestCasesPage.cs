using TestinyTestProject.Elements;
using OpenQA.Selenium;
using AngleSharp.Text;

namespace TestinyTestProject.Pages;

public class TestCasesPage(IWebDriver? driver, bool openByURL = false) : BasePage(driver, openByURL)
{
    private const string END_POINT = "DP/testcases";

    private static readonly By TitleBy = By.TagName("title");
    private static readonly By CreateQuickTestCaseButtonBy = By.XPath("//button/div[text()='Quick create']");
    private static readonly By ImportTestCaseButtonBy = By.XPath("//button[@title='Import']");
    private static readonly By TitleNewTestCaseInputBy = By.XPath("//input[@placeholder='New test case']");
    private static readonly By SaveQuickNewTestCaseButtonBy = By.XPath("//button[@title='Commit']");
    private static readonly By DisabledSaveQuickNewTestCaseButtonBy = By.XPath("//button[@title='Commit' and @disabled]");
    private static readonly By TestCaseTableBy = By.TagName("table");
    private static readonly By AllTestCaseUnselectedCheckboxBy = By.XPath("//label[@title='Select all'][1]");
    private static readonly By AllTestCaseLinkBy = By.XPath("//a[@href='https://app.testiny.io/DP/testcases']/button");
    private static readonly By CountTestCaseTextBy = By.XPath("//div/span[text()='All test cases']/following::span[1]");
    private static readonly By DeleteButtonBy = By.XPath("//div[@class='button-label' and text()='Delete']");
    private static readonly By DeletePopUpWindowTextBy = By.XPath("//h4[text()='Confirm test case deletion']");
    private static readonly By DeleteConfirmationButtonBy = By.XPath("//div[@aria-label='Confirm test case deletion']//div[@class='button-label' and text()='Delete']");
    private static readonly By ErrorMessageTestCaseTitleTextBy = By.XPath("//div[@id='portal-root']//p");
    private static readonly By MessageCopyTestCaseTextBy = By.XPath("//div[@id='portal-root']//span");

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

    public void ImportNewTestCaseClick()
    {
        ImportTestCaseButton.Click();
    }

    public void SetTitleNewTestCase(string value)
    {
        TitleNewTestCaseInput.SendKeys(value);
    }
    
    public void FocusTitleNewTestCase()
    {
        TitleNewTestCaseInput.MoveToElement();
    }

    public void SaveQuickNewTestCaseClick()
    {
        SaveQuickNewTestCaseButton.Click();
    }

    public bool IsDisabledSaveQuickNewTestCaseButtonDisplayed()
    {
        return DisabledSaveQuickNewTestCaseButton.Displayed;
    }

    public void AllTestCaseUnselectedCheckboxClick()
    {
        AllTestCaseUnselectedCheckbox.Click();
    }

    public void AllTestCaseLinkClick()
    {
        AllTestCaseLink.Click();
    }

    public void AllTestCaseLinkFocus()
    {
        AllTestCaseLink.MoveToElement();
    }

    public string GetCopiedMessageTestCaseText()
    {
        return MessageCopyTestCaseText.Text.Trim();
    }

    public void DeleteButtonClick()
    {
        DeleteButton.Click();
    }

    public bool IsDeleteButtonDisplayed()
    {
        return DeleteButton.Displayed;
    }

    public string GetCountSelectedTestCaseText()
    {
        return CountTestCaseText.Text.Trim().Split(['|', ' ']).ToList()[2];
    }

    public bool IsDeletePopUpWindowDisplayed()
    {
        return DeletePopUpWindowText.Displayed;
    }

    public void DeleteConfirmationButtonClick()
    {
        DeleteConfirmationButton.Click();
    }

    public string GetErrorMessageTestCaseTitle()
    {
        return ErrorMessageTestCaseTitleText.Text.Trim();
    }

    private UIElement TitleLabel => new(Driver, TitleBy);
    private UIElement CreateQuickTestCaseButton => new(Driver, CreateQuickTestCaseButtonBy);
    private Button ImportTestCaseButton => new Button(Driver, ImportTestCaseButtonBy);
    private UIElement TitleNewTestCaseInput => new(Driver, TitleNewTestCaseInputBy);
    private Button SaveQuickNewTestCaseButton => new Button(Driver, SaveQuickNewTestCaseButtonBy);
    private Button DisabledSaveQuickNewTestCaseButton => new Button(Driver, DisabledSaveQuickNewTestCaseButtonBy);
    internal Table TestCaseTable => new Table(Driver, TestCaseTableBy);
    private UIElement AllTestCaseUnselectedCheckbox => new (Driver, AllTestCaseUnselectedCheckboxBy);
    private UIElement AllTestCaseLink => new(Driver, AllTestCaseLinkBy);
    private UIElement CountTestCaseText => new(Driver, CountTestCaseTextBy);
    private Button DeleteButton => new Button(Driver, DeleteButtonBy);
    private UIElement DeletePopUpWindowText => new(Driver, DeletePopUpWindowTextBy);
    private Button DeleteConfirmationButton => new Button(Driver, DeleteConfirmationButtonBy);
    private UIElement ErrorMessageTestCaseTitleText => new(Driver, ErrorMessageTestCaseTitleTextBy);
    private UIElement MessageCopyTestCaseText => new(Driver, MessageCopyTestCaseTextBy);
}
