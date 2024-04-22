using OpenQA.Selenium;
using TestinyTestProject.Core;
using TestinyTestProject.Helpers;
using TestinyTestProject.Helpers.Configuration;
using TestinyTestProject.Steps;
using Allure.Net.Commons;
using NUnit.Allure.Core;
using NLog;
using TestinyTestProject.Models;
using TestinyTestProject.Services;

namespace TestinyTestProject.Tests;

public class BaseTest
{
    protected User Admin { get; private set; }

    [OneTimeSetUp]
    public static void GlobalSetup()
    {
        AllureLifecycle.Instance.CleanupResultDirectory();
    }   
}
