using DotnetTaskSeleniumNunit.Enums.Configurations;
using DotnetTaskSeleniumNunit.Enums;
using DotnetTaskSeleniumNunit.Helpers;
using log4net;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using Microsoft.Extensions.DependencyInjection;

namespace DotnetTaskSeleniumNunit;


[TestFixture]
public class BaseTest : IDisposable
{
    private IWebDriver _driver;
    private ILog _logger;
    private ConfigsManager _config;
    private protected POMDependency _dependencies;
    private ServiceProvider _serviceProvider;

    [OneTimeSetUp]
    public void BaseSetUp()
    {
        _serviceProvider = DependencyInjectionSetup.ConfigureServices();

        _config = _serviceProvider.GetService<ConfigsManager>();
        _logger = _serviceProvider.GetService<ILog>();

        _logger.Info($"Initializing feature: {TestContext.CurrentContext.Test.ClassName}");
    }

    [SetUp]
    public void SetUp()
    {
        _logger.Info($"Setting up test: {TestContext.CurrentContext.Test.Name}");
        
        _driver = _serviceProvider.GetService<IWebDriver>();
        _dependencies = new POMDependency(_driver, _config, _logger);

        _driver.Navigate().GoToUrl(_config.AppConfiguration.BaseURL ?? "");
        _driver.Manage().Window.Maximize();
        _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds((long)Waits.Timeout);

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
            var files = new FilesHelper(SpecialFolders.Downloads, _dependencies.Logger);
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
        if (_driver != null)
        {

            _driver.Quit();
            _driver.Dispose();
        }
        GC.SuppressFinalize(this);
    }

    ~BaseTest()
    {
        Dispose();
    }
}


