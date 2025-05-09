using DotnetTaskSeleniumNunit.Enums.Configurations;
using DotnetTaskSeleniumNunit.Interfaces;
using DotnetTaskSeleniumNunit.Models.Browsers;
using OpenQA.Selenium;

namespace DotnetTaskSeleniumNunit.Helpers;

public class DriverFactory
{
    public static IWebDriver GetDriver(Browsers browser, bool isHeadless)
    {
        IDriverManager driverManager = browser switch
        {
            Browsers.Chrome => new ChromeDriverManager(),
            Browsers.Firefox => new FirefoxDriverManager(),
            _ => throw new ArgumentException("Browser not supported"),
        };
        return driverManager.CreateDriver(isHeadless: isHeadless);
    }
}
