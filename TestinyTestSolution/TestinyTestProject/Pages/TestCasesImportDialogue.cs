using TestinyTestProject.Elements;
using OpenQA.Selenium;

namespace TestinyTestProject.Pages;

public class TestCasesImportDialogue(IWebDriver? driver, bool openByURL = false) : BasePage(driver, openByURL)
{
    private const string END_POINT = "DP/testcases/import";
    
    private static readonly By ImportTestCasesTextBy = By.XPath("//h4[text()='Import test cases']");
    private static readonly By ImportCSVButtonBy = By.XPath("//button//span[text()='CSV']");
    private static readonly By DragDropTextBy = By.XPath("//span[contains(text(),'Drag & drop')]");
    private static readonly By DragDropAreaBy = By.XPath("//div[@data-testid='section-drop-area']");
    private static readonly By FileTitleInputTextBy = By.XPath("//strong[@data-testid='text-file']");
    private static readonly By FileLinkBy = By.XPath("//a[@data-testid='link-choose-file']");

    protected override bool EvaluateLoadedStatus()
    {
        try
        {
            return ImportTestCasesText.Displayed;
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
        return ImportTestCasesText.Text.Contains("Import test cases");
    }

    public bool IsDragDropPageOpened()
    {
        return DragDropText.Displayed;
    }

    public void FileTitleSubmit(string fileName)
    {
        FileTitleInputText.SendKeys(fileName);
    }

    public void ImportCSVButtonClick()
    {
        ImportCSVButton.Click();
    }

    public void FileLinkClick()
    {
        FileLink.Click();
    }

    private UIElement ImportTestCasesText => new(Driver, ImportTestCasesTextBy);
    private UIElement DragDropText => new(Driver, DragDropTextBy);
    internal UIElement DragDropArea => new(Driver, DragDropAreaBy);
    private Button ImportCSVButton => new Button(Driver, ImportCSVButtonBy);
    private UIElement FileLink => new(Driver, FileLinkBy);
    private UIElement FileTitleInputText => new(Driver, FileTitleInputTextBy);
}
