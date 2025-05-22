using DotnetTaskSeleniumNunit.Helpers;
using DotnetTaskSeleniumNunit.Pages.JobDetails;
using log4net;
using OpenQA.Selenium;
using Reqnroll;

namespace DotnetTaskSeleniumNunit.StepDefinitions;

[Binding]
public class JobDetailsSteps
{
    private readonly JobDetailsPage _page;

    public JobDetailsSteps(IWebDriver driver, ConfigsManager configs, ILog logger)
    {
        _page = new JobDetailsPage(driver, configs, logger);
    }

    [Then("the job details should contain {string}")]
    public void ThenTheJobDetailsShouldContain(string searchText)
    {
        var jobDescription = _page.GetJobDescription();
        Assert.That(jobDescription, Does.Contain(searchText));
    }
}
