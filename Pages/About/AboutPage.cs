using DotnetTaskSeleniumNunit.Constants;
using log4net;
using OpenQA.Selenium;

namespace DotnetTaskSeleniumNunit.Pages.About;

internal partial class AboutPage(IWebDriver? driver,
                   ILog? logger,
                   GlobalVariables variables) : BasePage(driver, logger, variables)
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
