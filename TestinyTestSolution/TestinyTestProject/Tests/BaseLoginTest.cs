namespace TestinyTestProject.Tests;

public class BaseLoginTest : BaseTest
{
    [SetUp]
    public void SuccessfulLoginTest()
    {
        _navigationSteps.SuccessfulLogin(Admin);
    }
}
