using DotnetTaskSeleniumNunit.Constants;
using DotnetTaskSeleniumNunit.Helpers;
using log4net;
using OpenQA.Selenium;

namespace DotnetTaskSeleniumNunit.Pages.JobDetails;

internal partial class JobDetailsPage(POMDependencies pomDependencies) : BasePage(pomDependencies)
{
    public string GetJobDescription()
    {
        return GetJobDescriptionText();
    }
}
