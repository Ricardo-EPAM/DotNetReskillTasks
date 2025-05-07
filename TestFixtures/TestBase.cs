using System.Reflection;
using DotnetTaskSeleniumNunit.Constants;
using log4net;
using log4net.Config;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DotnetTaskSeleniumNunit;


[TestFixture]
public class BaseTest : IDisposable
{
#pragma warning disable CA1859 // Use concrete types when possible for improved performance
    private IWebDriver? _driver;
#pragma warning restore CA1859 // Use concrete types when possible for improved performance
    private ILog _logger;
    private IConfiguration? _config;
    private GlobalVariables _vars;
    private string? _baseURL;
    private protected POMDependencies _pomDependencies;

    [OneTimeSetUp]
    public void BaseSetUp()
    {
        var entryAssembly = Assembly.GetEntryAssembly();
        var currentMethod = MethodBase.GetCurrentMethod();
        ArgumentNullException.ThrowIfNull(entryAssembly);
        ArgumentNullException.ThrowIfNull(currentMethod);
        ArgumentNullException.ThrowIfNull(currentMethod.DeclaringType);
     

        _logger = LogManager.GetLogger(currentMethod.DeclaringType);
        var logRepository = LogManager.GetRepository(entryAssembly);
        XmlConfigurator.Configure(logRepository, new FileInfo("log4net._config"));

        _logger.Info($"Loading settings file");
        _config = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();
        ArgumentNullException.ThrowIfNull(_config);
        _baseURL = _config["ApplicationSettings:BaseURL"];
        ArgumentNullException.ThrowIfNull(_baseURL);

        _logger.Info($"Feature execution started: {TestContext.CurrentContext.Test.ClassName}");
    }

    [SetUp]
    public void SetUp()
    {
        _logger.Info($"Setup test: {TestContext.CurrentContext.Test.Name}");
        _vars = new GlobalVariables();

        var options = new ChromeOptions
        {
            PageLoadStrategy = _vars.PageLoadStrategy,
            PageLoadTimeout = _vars.PageLoadTimeout,
        };

        bool isHeadless = _vars.IsHeadless;

        if (isHeadless)
        {
            options.AddArgument("--headless=new");
            options.AddArgument("--disable-gpu");
            options.AddArgument("--disable-blink-features=AutomationControlled"); // Hide automation traces
            options.AddArgument("--disable-dev-shm-usage"); // Prevent shared memory issues
            options.AddArgument("--no-sandbox"); // Bypass OS restriction for performance
            options.AddArgument("--disable-infobars"); // Disable Chrome's "automation" bar
            options.AddArgument("window-size=1366,768");
            options.AddExcludedArgument("enable-automation");
            options.AddArgument("user-agent=Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/136.0.7103.49 Safari/537.36");
        }

        _driver = new ChromeDriver(options);
        _driver.Navigate().GoToUrl(_baseURL);
        _driver.Manage().Window.Maximize();
        _driver.Manage().Timeouts().ImplicitWait = _vars.ImplicitWaitTimeout;

        if (isHeadless)
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("Object.defineProperty(navigator, 'webdriver', { get: () => false })");
        }
        ArgumentNullException.ThrowIfNull(_driver);
        _logger.Info("Setup completed");
        _logger.Info($"Initializing test: {TestContext.CurrentContext.Test.Name}");

        _pomDependencies = new POMDependencies(_driver, _vars, _logger);
    }

    [TearDown]
    public void TearDown()
    {
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


