using OpenQA.Selenium;

namespace DotnetTaskSeleniumNunit.Pages.JobDetails;

internal partial class JobDetailsPage
{
    private readonly By _vacancyDescription = By.XPath("//article//section[descendant::p]");
    private IWebElement VacancyDescription => _driver.FindElement(_vacancyDescription);
}
