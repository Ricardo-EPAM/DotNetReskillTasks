using ATA_Dotnet_Selenium_task.Constants;
using OpenQA.Selenium.Chrome;

namespace ATA_Dotnet_Selenium_task;


[TestFixture]
public class BaseTest
{
    protected ChromeDriver? driver;


    [SetUp]
    public void SetUp()
    {
        var options = new ChromeOptions
        {
            PageLoadStrategy = GlobalVariables.PageLoadStrategy,
            PageLoadTimeout = GlobalVariables.PageLoadTimeout,
        };
        driver = new ChromeDriver(options);

        driver.Navigate().GoToUrl(GlobalVariables.BaseURL);
        driver.Manage().Window.Maximize();
        driver.Manage().Timeouts().ImplicitWait = GlobalVariables.ImplicitWaitTimeout;

        ArgumentNullException.ThrowIfNull(driver);
    }

    [TearDown]
    public void TearDown()
    {
        driver?.Dispose();
    }
}


