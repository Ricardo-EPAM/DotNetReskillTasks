using DotnetTaskSeleniumNunit.Enums;
using DotnetTaskSeleniumNunit.Helpers;
using log4net;
using OpenQA.Selenium;
using Microsoft.Extensions.DependencyInjection;
using Reqnroll;

namespace DotnetTaskSeleniumNunit.Bindings;

[Binding]
public class GlobalHooks : IDisposable
{
    private IWebDriver _driver;
    private ILog _logger;
    private ConfigsManager _config;
    private POMDependency _dependencies;
    private ServiceProvider _serviceProvider;
    private readonly ScenarioContext _scenarioContext;

    public GlobalHooks(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }

    [BeforeFeature]
    public void BeforeFeature()
    {

        ServiceProvider serviceProvider = DependencyInjectionSetup.ConfigureServices();
        _logger = serviceProvider.GetService<LoggerConfiguration>().GetLogger();
        _logger.Info($"Initializing feature: {_scenarioContext.ScenarioInfo.Title}");
    }

    [BeforeScenario]
    public void BeforeScenario()
    {
        _serviceProvider = DependencyInjectionSetup.ConfigureServices();

        _config = _serviceProvider.GetService<ConfigsManager>();
        _logger = _serviceProvider.GetService<LoggerConfiguration>().GetLogger();

        _logger.Info($"Setting up test scenario: {_scenarioContext.ScenarioInfo.Title}");

        _driver = _serviceProvider.GetService<IWebDriver>();
        _dependencies = new POMDependency(_driver, _config, _logger);

        // Configuración inicial del navegador
        _driver.Navigate().GoToUrl(_config.AppConfiguration.BaseURL ?? "");
        _driver.Manage().Window.Maximize();

        _logger.Info($"Initialized web driver for scenario: {_scenarioContext.ScenarioInfo.Title}");
    }

    [AfterScenario, Order(1)]
    public void AfterScenario()
    {
        if (_scenarioContext.ScenarioExecutionStatus == ScenarioExecutionStatus.TestError)
        {
            var screenshotFileName = ScreenshotHelper.TakesScreenshotIfFailed(
                _driver,
                _config.OutputConfiguration,
                _scenarioContext.ScenarioInfo.Title
            );

            _logger.Error($"Failed scenario screenshot was saved in: {screenshotFileName}");
        }

        Dispose();

        _logger.Info($"Scenario finalized: {_scenarioContext.ScenarioInfo.Title}");
    }

    [AfterScenario("Files"), Order(0)]
    public void AfterFilesScenario()
    {
        if (_scenarioContext.ScenarioInfo.Tags.Contains("RequiresDirectoryCleanUp"))
        {
            var files = new FilesHelper(SpecialFolders.Downloads, _dependencies.Logger);
            ArgumentNullException.ThrowIfNull(_scenarioContext.ScenarioInfo.Arguments);
            var fileName = _scenarioContext.ScenarioInfo.Arguments["filename"].ToString();
            files.DeleteFile(fileName);
        }
    }

    [AfterFeature]
    public void AfterFeature()
    {
        _logger.Info($"Execution of feature finished: {_scenarioContext.ScenarioInfo.Title}");
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

    ~GlobalHooks()
    {
        Dispose();
    }
}