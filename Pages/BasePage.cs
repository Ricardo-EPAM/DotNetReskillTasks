using DotnetTaskSeleniumNunit.Constants;
using DotnetTaskSeleniumNunit.Enums.Configurations;
using DotnetTaskSeleniumNunit.Helpers;
using log4net;
using OpenQA.Selenium;

namespace DotnetTaskSeleniumNunit.Pages;

abstract class BasePage
{
    protected readonly IWebDriver _driver;
    protected readonly ILog _logger;
    protected readonly GlobalVariables _vars;

    public BasePage(POMDependency pomDependencies)
    {
        ArgumentNullException.ThrowIfNull(pomDependencies);
        _driver = pomDependencies.Driver;
        _logger = pomDependencies.Logger;
        _vars = pomDependencies.Variables;
    }

    private protected TimeSpan GetWait(Waits wait)
    {
        return TimeSpan.FromSeconds((long) wait);
    }
}
