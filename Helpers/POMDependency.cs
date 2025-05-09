using DotnetTaskSeleniumNunit.Models.Configurations;
using log4net;
using OpenQA.Selenium;

namespace DotnetTaskSeleniumNunit.Helpers;

public class POMDependency
{
    public IWebDriver Driver { get; }
    public ConfigsManager Configurations { get; }
    public ILog Logger { get; }

    public POMDependency(IWebDriver driver, ConfigsManager configs, ILog logger)
    {
        ArgumentNullException.ThrowIfNull(driver);
        ArgumentNullException.ThrowIfNull(configs);
        ArgumentNullException.ThrowIfNull(logger);

        Driver = driver;
        Configurations = configs;
        Logger = logger;
    }
}
