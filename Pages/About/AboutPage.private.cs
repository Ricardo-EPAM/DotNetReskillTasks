using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace DotnetTaskSeleniumNunit.Pages.About;

internal partial class AboutPage
{
    private void ScrollToEPAMGlanceSection()
    {
        _logger.Debug($"Scrolling to the 'EPAM At A Glance' section");
        try
        {
            new WebDriverWait(_driver, _configs.UIWaitsConfiguration.DefaultWait).
                Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(_epamGlanceSection));
            var js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", EPAMGlanceSection);
        }
        catch (Exception ex)
        {
            _logger.Error(_errorScrollToEPAMGlanceSection, ex);
            throw;
        }

    }
    private void DownloadEPAMGlance()
    {
        _logger.Debug($"Clicking 'Download' button from 'EPAM At A Glance' section");
        try
        {
            new WebDriverWait(_driver, _configs.UIWaitsConfiguration.LongWait).
                Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(_downloadButtonLink));
            EPAMGlanceDownloadButton.Click();
        }
        catch (Exception ex)
        {
            _logger.Error(_downloadFailed, ex);
            throw;
        }
    }
}
