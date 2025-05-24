using DotnetTaskSeleniumNunit.Helpers;
using log4net;
using OpenQA.Selenium;

namespace DotnetTaskSeleniumNunit.Pages.JobDetails;

internal partial class JobDetailsPage(IWebDriver driver, ConfigsManager configs, ILog logger) : BasePage(driver, configs, logger)
{
    public string GetJobDescription()
    {
        return GetJobDescriptionText();
    }
}
