using TestinyTestProject.Elements;
using OpenQA.Selenium;
using System.Globalization;

namespace TestinyTestProject.Pages;

public class TestCasesImportDialogue(IWebDriver? driver, bool openByURL = false) : BasePage(driver, openByURL)
{
    private const string END_POINT = "DP/testcases/import";
    
    private static readonly By ImportTestCasesTextBy = By.XPath("//h4[text()='Import test cases']");
    private static readonly By ImportCSVButtonBy = By.XPath("//button//span[text()='CSV']");
    private static readonly By DragDropTextBy = By.XPath("//span[contains(text(),'Drag & drop')]");
    private static readonly By DragDropAreaBy = By.XPath("//div[@data-testid='section-drop-area']");
    private static readonly By FileTitleInputTextBy = By.XPath("//strong[@data-testid='text-file']");
    private static readonly By FileInputBy = By.XPath("//input[@type='file']");
    private static readonly By FileLinkBy = By.XPath("//a[@data-testid='link-choose-file']");
    private static readonly By MappingFieldsTextBy = By.XPath("//h4[text()='Field mapping']");
    private static readonly By ConfirmMappingFieldsButtonBy = By.XPath("//button//div[@class='button-label' and text()='OK']");
    private static readonly By ConfirmImportButtonBy = By.XPath("//button//div[@class='button-label' and text()='Import']");

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

    public bool IsMappingFieldsPageOpened()
    {
        return MappingFieldsText.Displayed;
    }

    public void FileTitleSubmit(string fileName)
    {
        FileTitleInputText.SendKeys(fileName);
    }

    public void ImportCSVButtonClick()
    {
        ImportCSVButton.Click();
    }

    public void ConfirmMappingFieldsButtonClick()
    {
        ConfirmMappingFieldsButton.Click();
    }

    public void ConfirmImportButtonClick()
    {
        ConfirmImportButton.Click();
    }

    public void FileLinkClick()
    {
        FileLink.Click();
    }

    private void FileInputRemoveStyle()
    {
        FileInput.RemoveStyleByXPath();
    }

    public void InputFileName(string fileName)
    {
        FileInputRemoveStyle();
        FileInput.SendKeys(fileName);
    }

    private UIElement ImportTestCasesText => new(Driver, ImportTestCasesTextBy);
    private UIElement DragDropText => new(Driver, DragDropTextBy);
    internal UIElement DragDropArea => new(Driver, DragDropAreaBy);
    private Button ImportCSVButton => new Button(Driver, ImportCSVButtonBy);
    private UIElement FileLink => new(Driver, FileLinkBy);
    private UIElement FileTitleInputText => new(Driver, FileTitleInputTextBy);
    private UIElement MappingFieldsText => new(Driver, MappingFieldsTextBy);
    private Button ConfirmMappingFieldsButton => new Button(Driver, ConfirmMappingFieldsButtonBy);
    private IWebElement ConfirmImportButton => WaitsHelper.FluentWaitForElement(ConfirmImportButtonBy);
    private UIElement FileInput => new(Driver, FileInputBy);
}
