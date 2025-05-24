using DotnetTaskSeleniumNunit.Helpers;
using log4net;
using OpenQA.Selenium;

namespace DotnetTaskSeleniumNunit.Pages.About;

internal partial class AboutPage(IWebDriver driver, ConfigsManager configs, ILog logger) : BasePage(driver, configs, logger)
{
    public void ScrollToEPAMAtAGlanceSection()
    {
        ScrollToEPAMGlanceSection();
    }
    public void DownloadEPAMAtAGlanceDocument()
    {
        DownloadEPAMGlance();
    }
}
