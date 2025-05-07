using DotnetTaskSeleniumNunit.Constants;
using log4net;
using OpenQA.Selenium;

namespace DotnetTaskSeleniumNunit.Pages.JobDetails;

internal partial class JobDetailsPage(IWebDriver? driver,
                   ILog? logger,
                   GlobalVariables variables) : BasePage(driver, logger, variables)
{
    public string GetJobDescription()
    {
        return GetJobDescriptionText();
    }
}
