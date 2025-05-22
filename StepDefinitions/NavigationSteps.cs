using DotnetTaskSeleniumNunit.Helpers;
using DotnetTaskSeleniumNunit.Pages.Navigation;
using log4net;
using OpenQA.Selenium;
using Reqnroll;

namespace DotnetTaskSeleniumNunit.StepDefinitions;

[Binding]
public class NavigationSteps
{
    private readonly NavigationBar _page;
    
    public NavigationSteps(IWebDriver driver, ConfigsManager configs, ILog logger)
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

    [Given("the user accepts cookies")]
    public void GivenTheUserAcceptsCookies()
    {
        _page.AcceptCookies();
    }

    [Given("the user navigates to the Careers page")]
    public void GivenTheUserNavigatesToTheCareersPage()
    {
        _page.NavigateToCareersPage();
    }

    [Given("the user navigates to the About page")]
    public void GivenTheUserNavigatesToTheAboutPage()
    {
        _page.NavigateToAboutPage();
    }

    [Given("the user navigates to the Insights page")]
    public void GivenTheUserNavigatesToTheInsightsPage()
    {
        _page.NavigateToInsightsPage();
    }
    
    [When("the user navigates to the {string} sub link from {string}")]
    public void GivenTheUserNavigatesToTheSubLinkFromLink(string subLinkText, string linkText)
    {
        _page.HoverServicesLinkAndClickByText(linkText, subLinkText);
    }
}