using System.ComponentModel.DataAnnotations;
using DotnetTaskSeleniumNunit.Helpers;
using log4net;
using OpenQA.Selenium;

namespace DotnetTaskSeleniumNunit.Pages.About;

internal partial class ServicesPage(IWebDriver driver, ConfigsManager configs, ILog logger) : BasePage(driver, configs, logger)
{
    public bool IsOurRelatedExpertiseVisibleOnPage()
    {
        return IsOurRelatedExpertiseTitleVisible();
    }
}
