using DotnetTaskSeleniumNunit.Constants;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools;

namespace DotnetTaskSeleniumNunit;


[TestFixture]
public class BaseTest : IDisposable
{
    protected ChromeDriver? driver;


    [SetUp]
    public void SetUp()
    {
        bool isHeadless = GlobalVariables.IsHeadless;

        var options = new ChromeOptions
        {
            PageLoadStrategy = GlobalVariables.PageLoadStrategy,
            PageLoadTimeout = GlobalVariables.PageLoadTimeout,

        };

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
        driver.Navigate().GoToUrl(GlobalVariables.BaseURL);
        driver.Manage().Window.Maximize();
        driver.Manage().Timeouts().ImplicitWait = GlobalVariables.ImplicitWaitTimeout;

        if (isHeadless)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("Object.defineProperty(navigator, 'webdriver', { get: () => false })");
        }
        ArgumentNullException.ThrowIfNull(driver);
    }

    [TearDown]
    public void TearDown()
    {
        driver?.Quit();
    }

    public void Dispose()
    {
        if (driver != null)
        {
            driver.Dispose();
        }
    }
}


