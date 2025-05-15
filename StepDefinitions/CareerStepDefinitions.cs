using DotnetTaskSeleniumNunit.Helpers;
using DotnetTaskSeleniumNunit.Models.Careers;
using DotnetTaskSeleniumNunit.Pages.Careers;
using DotnetTaskSeleniumNunit.Pages.JobDetails;
using DotnetTaskSeleniumNunit.Pages.Navigation;
using Reqnroll;

[Binding]
public class CareersSearchSteps
{
    private readonly POMDependency _dependencies; 
    private readonly CareerSearchPage _careersSearchPage;
    private readonly NavigationBar _navigationBar;
    private readonly JobDetailsPage _jobDetailsPage;
    private string jobDescription;
    
    public CareersSearchSteps(POMDependency dependencies)
    {
        ArgumentNullException.ThrowIfNull(dependencies);
        _dependencies = dependencies;

        _careersSearchPage = new CareerSearchPage(_dependencies);
        _navigationBar = new NavigationBar(_dependencies);
        _jobDetailsPage = new JobDetailsPage(_dependencies);
    }

    [Given(@"the user accepts cookies")]
    public void GivenTheUserAcceptsCookies()
    {
        _navigationBar.AcceptCookies();
    }

    [Given(@"the user navigates to the Careers page")]
    public void GivenTheUserNavigatesToTheCareersPage()
    {
        _navigationBar.NavigateToCareersPage();
    }

    [When(@"the user searches for a career with ""(.*)"", in ""(.*)"", and with ""(.*)"" modality")]
    public void WhenTheUserSearchesForACareer(string searchText, string locationValue, string locationModality)
    {
        CareerModality modality = Enum.Parse<CareerModality>(locationModality);
        var careerSearchForm = new CareerSearch(searchText, locationValue, modality);
        _careersSearchPage.MakeACareerSearch(careerSearchForm);
    }

    [When(@"the user applies and views the job from the last section")]
    public void WhenTheUserAppliesAndViewsTheJobFromTheLastSection()
    {
        _careersSearchPage.ApplyAndViewFromLastSection();
    }

    [Then(@"the job details should contain ""(.*)""")]
    public void ThenTheJobDetailsShouldContain(string searchText)
    {
        jobDescription = _jobDetailsPage.GetJobDescription();
        Assert.That(jobDescription, Does.Contain(searchText));
    }
}