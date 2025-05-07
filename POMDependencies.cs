using DotnetTaskSeleniumNunit.Constants;
using log4net;
using OpenQA.Selenium;

namespace DotnetTaskSeleniumNunit;

public class POMDependencies
{
    public IWebDriver Driver { get; }
    public GlobalVariables Variables { get; }
    public ILog Logger { get; }

    public POMDependencies(IWebDriver driver, GlobalVariables variables, ILog logger)
    {
        Driver = driver;
        Variables = variables;
        Logger = logger;
    }
}
