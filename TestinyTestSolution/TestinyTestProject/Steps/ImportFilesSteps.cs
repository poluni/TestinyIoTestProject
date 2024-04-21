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
    [AllureStep("Import CSV File")]
    public TestCasesImportDialogue ImportCSVFile()
    {
        TestCasesImportDialogue = new TestCasesImportDialogue(Driver, false);
        var fileName = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Resources", "sample_testcase.csv");
        var actions = new Actions(Driver);
        var targetElements = TestCasesImportDialogue.DragDropArea;

        if (TestCasesImportDialogue.IsPageOpened())  
            TestCasesImportDialogue.ImportCSVButtonClick();
        if (TestCasesImportDialogue.IsDragDropPageOpened())
        {
            actions
.DragAndDropToOffset(targetElements, 500, 500)
.Pause(TimeSpan.FromSeconds(3))
.Build()
.Perform();
        }

        return new TestCasesImportDialogue(Driver);
    }
}
