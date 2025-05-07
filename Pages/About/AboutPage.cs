using DotnetTaskSeleniumNunit.Constants;
using DotnetTaskSeleniumNunit.Pages.Navigation;
using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

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
