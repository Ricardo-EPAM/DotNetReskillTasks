using DotnetTaskSeleniumNunit.Constants;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace DotnetTaskSeleniumNunit.Pages.JobDetails;

internal partial class JobDetailsPage
{
    //9.	Validate that the programming language mentioned in the step above is on a page
    internal string GetJobDescription()
    {
        new WebDriverWait(_driver, _vars.ExplicitWaitDefault).
            Until(ExpectedConditions.ElementIsVisible(_vacancyDescription));
        return VacancyDescription.Text;
    }
}
