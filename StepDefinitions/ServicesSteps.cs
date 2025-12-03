using DotnetTaskSeleniumNunit.Helpers;
using DotnetTaskSeleniumNunit.Pages.About;
using log4net;
using OpenQA.Selenium;
using Reqnroll;

namespace DotnetTaskSeleniumNunit.StepDefinitions;

[Binding]
public class ServicesSteps
{
    private readonly ServicesPage _page;

    public ServicesSteps(IWebDriver driver, ConfigsManager configs, ILog logger)
    {
        _page = new ServicesPage(driver, configs, logger);
    }

    [Then("the user is able to locate the section \"Our Related Expertise\"")]
    public void UserIsAbleToLocateSectionOurRelatedExpertise()
    {
        Assert.That(_page.IsOurRelatedExpertiseVisibleOnPage(), Is.True, "The section 'Our Related Expertise' was not found");
    }
}
