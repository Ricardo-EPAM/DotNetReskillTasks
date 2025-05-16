using DotnetTaskSeleniumNunit.Helpers;
using DotnetTaskSeleniumNunit.Pages.GlobalSearch;
using log4net;
using OpenQA.Selenium;
using Reqnroll;

namespace DotnetTaskSeleniumNunit.StepDefinitions;

[Binding]
public class GlobalSearchSteps
{
    private readonly GlobalSearchPage _page;

    public GlobalSearchSteps(IWebDriver driver, ConfigsManager configs, ILog logger)
    {
        _page = new GlobalSearchPage(driver, configs, logger);
    }



}