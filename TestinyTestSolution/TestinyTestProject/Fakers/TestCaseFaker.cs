using Bogus;
using TestinyTestProject.Models;

namespace TestinyTestProject.Fakers;

public class TestCaseFaker : Faker<TestCase>
{
    public TestCaseFaker()
    {
        RuleFor(b => b.Title, f => f.Random.AlphaNumeric(200));
    }
}
