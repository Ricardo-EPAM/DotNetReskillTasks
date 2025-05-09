using DotnetTaskSeleniumNunit.Enums.Configurations;
using DotnetTaskSeleniumNunit.Interfaces;
using DotnetTaskSeleniumNunit.Models.Browsers;
using OpenQA.Selenium;

namespace DotnetTaskSeleniumNunit.Helpers;

public class DriverFactory
{
    private readonly ConfigsManager _configsManager;

    public DriverFactory(ConfigsManager configsManager)
    {
        _configsManager = configsManager ?? throw new ArgumentNullException(nameof(configsManager));
    }

    public IWebDriver GetDriver()
    {
        var browser = _configsManager.AppConfiguration.Browser;
        var isHeadless = _configsManager.AppConfiguration.Headless;

        IDriverManager driverManager = browser switch
        {
            BrowserType.Chrome => new ChromeDriverManager(),
            BrowserType.Firefox => new FirefoxDriverManager(),
            _ => throw new ArgumentException("Browser not supported"),
        };

        return driverManager.CreateDriver(isHeadless: isHeadless);
    }
}