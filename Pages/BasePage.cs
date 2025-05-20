using DotnetTaskSeleniumNunit.Helpers;
using log4net;
using OpenQA.Selenium;

namespace DotnetTaskSeleniumNunit.Pages;

abstract class BasePage
{
    protected readonly IWebDriver _driver;
    protected readonly ILog _logger;
    protected readonly ConfigsManager _configs;

    public BasePage(IWebDriver driver, ConfigsManager configs, ILog logger)
    {
        ArgumentNullException.ThrowIfNull(driver);
        ArgumentNullException.ThrowIfNull(configs);
        ArgumentNullException.ThrowIfNull(logger);
        _driver = driver;
        _configs = configs;
        _logger = logger;
    }

    public string GetPageTitle()
    {
        return _driver.Title;
    }
}
