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
    private protected ChromeDriver? driver;
    private protected ILog logger;
    private protected IConfiguration? config;
    private protected GlobalVariables vars;

    [OneTimeSetUp]
    public void BaseSetUp()
    {
        var entryAssembly = Assembly.GetEntryAssembly();
        var currentMethod = MethodBase.GetCurrentMethod();
        ArgumentNullException.ThrowIfNull(entryAssembly);
        ArgumentNullException.ThrowIfNull(currentMethod);
        ArgumentNullException.ThrowIfNull(currentMethod.DeclaringType);

        logger = LogManager.GetLogger(currentMethod.DeclaringType);
        var logRepository = LogManager.GetRepository(entryAssembly);
        XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));

        logger.Info($"Loading settings file");
        config = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        logger.Info($"Feature execution started: {TestContext.CurrentContext.Test.ClassName}");
    }

    [SetUp]
    public void SetUp()
    {
        logger.Info($"Setup test: {TestContext.CurrentContext.Test.Name}");
        vars = new GlobalVariables();

        var options = new ChromeOptions
        {
            PageLoadStrategy = vars.PageLoadStrategy,
            PageLoadTimeout = vars.PageLoadTimeout,
        };

        ArgumentNullException.ThrowIfNull(config);
        string? url = config["ApplicationSettings:BaseURL"];
        ArgumentNullException.ThrowIfNull(url);
        bool isHeadless = vars.IsHeadless;

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

        driver = new ChromeDriver(options);
        driver.Navigate().GoToUrl(url);
        driver.Manage().Window.Maximize();
        driver.Manage().Timeouts().ImplicitWait = vars.ImplicitWaitTimeout;

        if (isHeadless)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("Object.defineProperty(navigator, 'webdriver', { get: () => false })");
        }
        ArgumentNullException.ThrowIfNull(driver);
        logger.Info("Setup completed");
        logger.Info($"Initializing test: {TestContext.CurrentContext.Test.Name}");


    }

    [TearDown]
    public void TearDown()
    {
        Dispose();
        logger.Info($"Test finalized: {TestContext.CurrentContext.Test.Name}");
    }

    [OneTimeTearDown]
    public void BaseTearDown()
    {
        logger.Info($"Feature execution finished: {TestContext.CurrentContext.Test.ClassName}");
    }

    public void Dispose()
    {
        if (driver != null)
        {
            driver.Dispose();
        }
    }
}


