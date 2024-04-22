using Allure.NUnit.Attributes;
using System.Reflection;
using TestinyTestProject.Pages;
using OpenQA.Selenium;

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

        try
        {
            if (TestCasesImportDialogue.IsPageOpened())
                TestCasesImportDialogue.ImportCSVButtonClick();
            if (TestCasesImportDialogue.IsDragDropPageOpened())
            {
                var pathDownload = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Resources");
                FileInfo[] files = new DirectoryInfo(pathDownload).GetFiles(searchPattern: $"*.csv");
                var fileName = Path.Combine(pathDownload, Path.GetFileName(files[0].FullName));

                TestCasesImportDialogue.InputFileName(fileName);
            }
            if (TestCasesImportDialogue.IsMappingFieldsPageOpened())
                TestCasesImportDialogue.ConfirmMappingFieldsButtonClick();
        }
        catch (FileNotFoundException)
        {
            new FileNotFoundException("File Not Found.");
        }

        return (T)Activator.CreateInstance(typeof(T), Driver, false);
    }
}
