using Bogus;
using TestinyTestProject.Models;

namespace TestinyTestProject.Fakers;

public class TestCaseInvalidDataFaker : Faker<TestCase>
{
    public TestCaseInvalidDataFaker()
    {
        RuleFor(b => b.Title, f => f.Random.AlphaNumeric(201)); 
    }
}
