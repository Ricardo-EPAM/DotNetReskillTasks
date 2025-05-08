using DotnetTaskSeleniumNunit.Enums;
using DotnetTaskSeleniumNunit.Interfaces;
using DotnetTaskSeleniumNunit.Models.Browsers;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace DotnetTaskSeleniumNunit.Helpers;

static class DriverFactory
{
    public static IWebDriver CreateInstance(Browsers browser, bool isHeadless)
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
