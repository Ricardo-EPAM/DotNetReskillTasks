using DotnetTaskSeleniumNunit.Constants;
using DotnetTaskSeleniumNunit.Enums;
using DotnetTaskSeleniumNunit.Helpers;
using log4net;
using Microsoft.Extensions.Configuration;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;

namespace DotnetTaskSeleniumNunit;


[TestFixture]
public class BaseTest : IDisposable
{
#pragma warning disable CA1859 // Use concrete types when possible for improved performance
    private IWebDriver? _driver;
#pragma warning restore CA1859 // Use concrete types when possible for improved performance
    private ILog _logger;
    private IConfiguration _config;
    private GlobalVariables _vars;
    private string _baseURL;
    private protected POMDependencies _pomDependencies;

    [OneTimeSetUp]
    public void BaseSetUp()
    {
        _config = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        LoggerConfiguration loggerConfig = new(_config.GetSection("Runner"));
        _logger = loggerConfig.GetLogger();

        _baseURL = _config["App:BaseURL"] ?? "";
        _logger.Info($"Feature execution started: {TestContext.CurrentContext.Test.ClassName}");

        _vars = new GlobalVariables();

    }

    [SetUp]
    public void SetUp()
    {
        _logger.Info($"Setup test: {TestContext.CurrentContext.Test.Name}");

        bool isHeadless = bool.Parse(_config["Runner:Headless"] ?? false.ToString());

        _driver = DriverFactory.CreateInstance(Browsers.Chrome, isHeadless);
        _driver.Navigate().GoToUrl(_baseURL);
        _driver.Manage().Window.Maximize();
        _driver.Manage().Timeouts().ImplicitWait = _vars.ImplicitWaitTimeout;

        _logger.Info("Setup completed");
        _logger.Info($"Initializing test: {TestContext.CurrentContext.Test.Name}");

        _pomDependencies = new POMDependencies(_driver, _vars, _logger);
    }

    [TearDown]
    public void TearDown()
    {
        if (TestContext.CurrentContext.Result.Outcome.Status != TestStatus.Failed)
        {
            var screenshotFileName = ScreenshotHelper.TakesScreenshotIfFailed(_driver, _config.GetSection("Output"));
            _logger.Error($"Failed test screenshot was saved in: {screenshotFileName}");
        }

        Dispose();
        _logger.Info($"Test finalized: {TestContext.CurrentContext.Test.Name}");
    }

    [OneTimeTearDown]
    public void BaseTearDown()
    {
        _logger.Info($"Feature execution finished: {TestContext.CurrentContext.Test.ClassName}");
    }

    public void Dispose()
    {
        if (_driver != null)
        {
            _driver.Dispose();
        }
    }
}


