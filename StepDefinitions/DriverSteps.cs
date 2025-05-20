using DotnetTaskSeleniumNunit.Helpers;
using DotnetTaskSeleniumNunit.Pages;
using DotnetTaskSeleniumNunit.Pages.Navigation;
using log4net;
using OpenQA.Selenium;
using Reqnroll;

namespace DotnetTaskSeleniumNunit.StepDefinitions;

[Binding]
public class DriverSteps
{
    private readonly BasePage _page;

    public DriverSteps(IWebDriver driver, ConfigsManager configs, ILog logger)
    {
        _page = new NavigationBar(driver, configs, logger);
    }

    [Given("the user navigates to EPAM")]
    public void UserNavigatesToEPAM()
    {
        _page.NavigateToBaseURL();
    }

    [Then("the page title is {string}")]
    public void ThePageTitleIs(string pageTitle)
    {
        var actualTitle = _page.GetPageTitle();
        Assert.That(actualTitle, Is.EqualTo(pageTitle), $"We expected to get the title '{pageTitle}', but instead we got '{actualTitle}'");
    }
}