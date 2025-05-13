using DotnetTaskSeleniumNunit.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace DotnetTaskSeleniumNunit.Models.Browsers;

class FirefoxDriverManager : IDriverManager
{
    public IWebDriver CreateDriver(bool isHeadless)
    {
        _ = new DriverManager().SetUpDriver(new FirefoxConfig(), VersionResolveStrategy.MatchingBrowser);

        var options = new FirefoxOptions();

        //if (isHeadless)
        //{
        //    options.AddArgument("--headless");
        //}

        //var driver = new FirefoxDriver(options);
        var driver = new FirefoxDriver(options);
        return driver;
    }
}
