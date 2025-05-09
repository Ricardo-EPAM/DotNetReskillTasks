using DotnetTaskSeleniumNunit.Constants;
using log4net;
using OpenQA.Selenium;

namespace DotnetTaskSeleniumNunit.Helpers;

public class POMDependency
{
    public IWebDriver Driver { get; }
    public GlobalVariables Variables { get; }
    public ILog Logger { get; }

    public POMDependency(IWebDriver driver, GlobalVariables variables, ILog logger)
    {
        ArgumentNullException.ThrowIfNull(driver);
        ArgumentNullException.ThrowIfNull(variables);
        ArgumentNullException.ThrowIfNull(logger);

        Driver = driver;
        Variables = variables;
        Logger = logger;
    }
}
