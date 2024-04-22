namespace TestinyTestProject.Tests.GUI;

public class BaseLoginTest : BaseGUITest
{
    [SetUp]
    public void SuccessfulLoginTest()
    {
        _navigationSteps.SuccessfulLogin(Admin);
    }
}
