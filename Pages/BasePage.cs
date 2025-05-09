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
    protected TimeSpan DefaultWait;
    protected TimeSpan LongWait;
    protected TimeSpan ShortWait;

    public BasePage(POMDependency pomDependencies)
    {
        ArgumentNullException.ThrowIfNull(pomDependencies);
        _driver = pomDependencies.Driver;
        _logger = pomDependencies.Logger;
        _configs = pomDependencies.Configurations;


        DefaultWait = TimeSpan.FromSeconds(_configs.UIWaitsConfiguration.DefaultWait);
        LongWait = TimeSpan.FromSeconds(_configs.UIWaitsConfiguration.LongWait);
        ShortWait = TimeSpan.FromSeconds(_configs.UIWaitsConfiguration.ShortWait);
    }
}
