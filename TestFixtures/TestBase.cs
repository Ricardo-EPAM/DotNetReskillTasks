using DotnetTaskSeleniumNunit.Constants;
using DotnetTaskSeleniumNunit.Enums;
using DotnetTaskSeleniumNunit.Enums.Configurations;
using DotnetTaskSeleniumNunit.Helpers;
using log4net;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;

namespace DotnetTaskSeleniumNunit;


[TestFixture]
public class BaseTest : IDisposable
{
    private IWebDriver _driver;
    private ILog _logger;
    private ConfigsManager _config;
    private GlobalVariables _vars;
    private protected POMDependency _pomDependencies;
    private bool _disposed = false;

    [OneTimeSetUp]
    public void BaseSetUp()
    {
        _config = new ConfigsManager();
        LoggerConfiguration loggerConfig = new(_config.RunnerConfiguration);
        _logger = loggerConfig.GetLogger();
        _logger.Info($"Initializing feature: {TestContext.CurrentContext.Test.ClassName}");
        _vars = new GlobalVariables();
    }

    [SetUp]
    public void SetUp()
    {
        _logger.Info($"Setting up test: {TestContext.CurrentContext.Test.Name}");

        bool isHeadless = _config.RunnerConfiguration.HeadLess;
        _driver = DriverFactory.GetDriver(Browsers.Chrome, isHeadless);

        _driver.Navigate().GoToUrl(_config.AppConfiguration.BaseURL ?? "");
        _driver.Manage().Window.Maximize();
        _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds((long)Waits.Timeout);

        _pomDependencies = new POMDependency(_driver, _vars, _logger);
        _logger.Info($"Initializing test: {TestContext.CurrentContext.Test.Name}");
    }

    [TearDown]
    public void TearDown()
    {
        if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
        {
            var screenshotFileName = ScreenshotHelper.TakesScreenshotIfFailed(
                _driver,
                _config.OutputConfiguration,
                TestContext.CurrentContext.Test.Name);
            _logger.Error($"Failed test screenshot was saved in: {screenshotFileName}");
        }
        if (TestContext.CurrentContext.Test.AllCategories().Contains("RequiresDirectoryCleanUp"))
        {
            var files = new FilesHelper(SpecialFolders.Downloads, _pomDependencies.Logger);
            ArgumentNullException.ThrowIfNull(TestContext.CurrentContext.Test.Arguments);
            var fileName = TestContext.CurrentContext.Test.Arguments.First().ToString();
            files.DeleteFile(fileName);
        }

        Dispose();
        _logger.Info($"Test finalized: {TestContext.CurrentContext.Test.Name}");
    }

    [OneTimeTearDown]
    public void BaseTearDown()
    {
        Dispose();
        _logger.Info($"Feature execution finished: {TestContext.CurrentContext.Test.ClassName}");
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (_disposed)
            return;

        if (disposing)
        {
            _driver?.Quit();
            _driver?.Dispose();
            _logger?.Info("WebDriver disposed.");
        }
        _disposed = true;
    }

    ~BaseTest()
    {
        Dispose(false);
    }
}


