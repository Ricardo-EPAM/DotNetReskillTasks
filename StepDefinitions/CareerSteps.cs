using DotnetTaskSeleniumNunit.Helpers;
using DotnetTaskSeleniumNunit.Models.Careers;
using DotnetTaskSeleniumNunit.Pages.Careers;
using log4net;
using OpenQA.Selenium;
using Reqnroll;

namespace DotnetTaskSeleniumNunit.StepDefinitions;

[Binding]
public class CareersSteps
{
    private readonly CareerSearchPage _page;
    
    public CareersSteps(IWebDriver driver, ConfigsManager configs, ILog logger)
    {
        _page = new CareerSearchPage(driver, configs, logger);
    }

    [When("the user searches for a career with {string}, in {string}, and with {CareerModality} modality")]
    public void WhenTheUserSearchesForACareer(string searchText, string locationValue, CareerModality modality)
    {
        var careerSearchForm = new CareerSearch(searchText, locationValue, modality);
        _page.MakeACareerSearch(careerSearchForm);
    }

    [When("the user applies and views the job from the last section")]
    public void WhenTheUserAppliesAndViewsTheJobFromTheLastSection()
    {
        _page.ApplyAndViewFromLastSection();
    }
}
