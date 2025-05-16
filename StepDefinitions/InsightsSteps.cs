using DotnetTaskSeleniumNunit.Helpers;
using DotnetTaskSeleniumNunit.Pages.Insights;
using log4net;
using OpenQA.Selenium;
using Reqnroll;

namespace DotnetTaskSeleniumNunit.StepDefinitions;

[Binding]
public class InsightsSteps
{
    private readonly InsightsPage _page;

    public InsightsSteps(IWebDriver driver, ConfigsManager configs, ILog logger)
    {
        _page = new InsightsPage(driver, configs, logger);
    }



}