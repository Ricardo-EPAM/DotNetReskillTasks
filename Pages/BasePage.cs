using DotnetTaskSeleniumNunit.Constants;
using DotnetTaskSeleniumNunit.Helpers;
using log4net;
using OpenQA.Selenium;

namespace DotnetTaskSeleniumNunit.Pages;

internal class BasePage
{
    protected readonly IWebDriver _driver;
    protected readonly ILog _logger;
    protected readonly GlobalVariables _vars;

    public BasePage(POMDependencies pomDependencies)
    {
        ArgumentNullException.ThrowIfNull(pomDependencies.Driver);
        ArgumentNullException.ThrowIfNull(pomDependencies.Logger);
        ArgumentNullException.ThrowIfNull(pomDependencies.Variables);
        _driver = pomDependencies.Driver;
        _logger = pomDependencies.Logger;
        _vars = pomDependencies.Variables;
    }
}
