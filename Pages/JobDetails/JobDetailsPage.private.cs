using DotnetTaskSeleniumNunit.Constants;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace DotnetTaskSeleniumNunit.Pages.JobDetails;

internal partial class JobDetailsPage
{
    private string GetJobDescriptionText()
    {
		try
		{
            new WebDriverWait(_driver, _vars.ExplicitWaitDefault).
            Until(ExpectedConditions.ElementIsVisible(_vacancyDescription));
            return VacancyDescription.Text;
        }
		catch (Exception ex)
		{
            _logger.Error(_errorGetJobDescription, ex);
			throw;
		}
    }
}
