using Allure.NUnit.Attributes;
using TestinyTestProject.Models;
using TestinyTestProject.Helpers;
using System.Reflection;
using TestinyTestProject.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace TestinyTestProject.Steps;

public class ImportFilesSteps(IWebDriver driver) : BaseStep(driver)
{
    [AllureStep("CSV File is successfull imported.")]
    public TestCasesPage SuccessfullImportCSVFile()
    {
        return ImportCSVFile<TestCasesPage>();
    }

    public T ImportCSVFile<T>() where T : BasePage
    {
        TestCasesImportDialogue = new TestCasesImportDialogue(Driver, false);

        var fileName = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Resources", "testiny_testcase_import_sample.csv");

        if (TestCasesImportDialogue.IsPageOpened())
            TestCasesImportDialogue.ImportCSVButtonClick();
        if (TestCasesImportDialogue.IsDragDropPageOpened())
            TestCasesImportDialogue.InputFileName(fileName);
        if (TestCasesImportDialogue.IsMappingFieldsPageOpened())
            TestCasesImportDialogue.ConfirmMappingFieldsButtonClick();

        return (T)Activator.CreateInstance(typeof(T), Driver, false);
    }
}
