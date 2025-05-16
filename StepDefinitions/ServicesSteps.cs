using DotnetTaskSeleniumNunit.Helpers;
using log4net;
using OpenQA.Selenium;
using Reqnroll;

namespace DotnetTaskSeleniumNunit.StepDefinitions;

[Binding]
public class ServicesSteps
{
    private readonly ServicesPage _page;

    public ServicesPage(IWebDriver driver, ConfigsManager configs, ILog logger)
    {
        _page = new ServicesSteps(driver, configs, logger);
    }



}