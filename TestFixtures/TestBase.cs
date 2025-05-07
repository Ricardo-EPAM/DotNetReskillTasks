using System.Reflection;
using DotnetTaskSeleniumNunit.Constants;
using log4net;
using log4net.Config;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium.Chrome;

namespace DotnetTaskSeleniumNunit;


[TestFixture]
public class BaseTest
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
        driver = new ChromeDriver(options);

        ArgumentNullException.ThrowIfNull(config);
        string? url = config["ApplicationSettings:BaseURL"];
        ArgumentNullException.ThrowIfNull(url);
        driver.Navigate().GoToUrl(url);
        driver.Manage().Window.Maximize();
        driver.Manage().Timeouts().ImplicitWait = vars.ImplicitWaitTimeout;

        ArgumentNullException.ThrowIfNull(driver);
        logger.Info("Setup completed");
        logger.Info($"Initializing test: {TestContext.CurrentContext.Test.Name}");


    }

    [TearDown]
    public void TearDown()
    {
        driver?.Dispose();
        logger.Info($"Test finalized: {TestContext.CurrentContext.Test.Name}");
    }

    [OneTimeTearDown]
    public void BaseTearDown()
    {
        logger.Info($"Feature execution finished: {TestContext.CurrentContext.Test.ClassName}");
    }
}


