using DotnetTaskSeleniumNunit.Helpers;

namespace DotnetTaskSeleniumNunit.Pages.JobDetails;

internal partial class JobDetailsPage(POMDependency pomDependencies) : BasePage(pomDependencies)
{
    public string GetJobDescription()
    {
        return GetJobDescriptionText();
    }
}
