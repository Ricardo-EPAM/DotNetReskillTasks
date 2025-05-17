using DotnetTaskSeleniumNunit.Enums.Configurations;
using DotnetTaskSeleniumNunit.Helpers;
using DotnetTaskSeleniumNunit.Models.Configurations;
using log4net;
using OpenQA.Selenium;

namespace DotnetTaskSeleniumNunit.Pages;

abstract class BasePage
{
    protected readonly IWebDriver _driver;
    protected readonly ILog _logger;
    protected readonly ConfigsManager _configs;

    public BasePage(POMDependency pomDependencies)
    {
        ArgumentNullException.ThrowIfNull(pomDependencies);
        _driver = pomDependencies.Driver;
        _logger = pomDependencies.Logger;
        _configs = pomDependencies.Configurations;
    }
}
