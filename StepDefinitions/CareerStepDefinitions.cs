using DotnetTaskSeleniumNunit.Helpers;
using DotnetTaskSeleniumNunit.Models.Careers;
using DotnetTaskSeleniumNunit.Pages.Careers;
using DotnetTaskSeleniumNunit.Pages.JobDetails;
using DotnetTaskSeleniumNunit.Pages.Navigation;
using log4net;
using OpenQA.Selenium;
using Reqnroll;

namespace DotnetTaskSeleniumNunit.StepDefinitions;

[Binding]
public class CareersSearchSteps
{
    private CareerSearchPage _careersSearchPage;
    private NavigationBar _navigationBar;
    private JobDetailsPage _jobDetailsPage;
    
    public CareersSearchSteps(IWebDriver driver, ConfigsManager configs, ILog logger)
    {
        _careersSearchPage = new CareerSearchPage(driver, configs, logger);
        _navigationBar = new NavigationBar(driver, configs, logger);
        _jobDetailsPage = new JobDetailsPage(driver, configs, logger);
    }

    [Given("the user accepts cookies")]
    public void GivenTheUserAcceptsCookies()
    {
        _navigationBar.AcceptCookies();
    }

    [Given("the user navigates to the Careers page")]
    public void GivenTheUserNavigatesToTheCareersPage()
    {
        _navigationBar.NavigateToCareersPage();
    }

    [When("the user searches for a career with {string}, in {string}, and with {string} modality")]
    public void WhenTheUserSearchesForACareer(string searchText, string locationValue, string locationModality)
    {
        CareerModality modality = Enum.Parse<CareerModality>(locationModality);
        var careerSearchForm = new CareerSearch(searchText, locationValue, modality);
        _careersSearchPage.MakeACareerSearch(careerSearchForm);
    }

    [When("the user applies and views the job from the last section")]
    public void WhenTheUserAppliesAndViewsTheJobFromTheLastSection()
    {
        _careersSearchPage.ApplyAndViewFromLastSection();
    }

    [Then("the job details should contain {string}")]
    public void ThenTheJobDetailsShouldContain(string searchText)
    {
        var jobDescription = _jobDetailsPage.GetJobDescription();
        Assert.That(jobDescription, Does.Contain(searchText));
    }
}