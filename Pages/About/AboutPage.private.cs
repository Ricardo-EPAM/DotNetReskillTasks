using DotnetTaskSeleniumNunit.Enums;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace DotnetTaskSeleniumNunit.Pages.About;

internal partial class AboutPage
{
    private void ScrollToEPAMGlanceSection()
    {
        try
        {
            new WebDriverWait(_driver, GetWait(Waits.Long)).
                        Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(_epamGlanceSection));
            new Actions(_driver).ScrollToElement(EPAMGlanceSection).Perform();
        }
        catch (Exception ex)
        {
            _logger.Error(_errorScrollToEPAMGlanceSection, ex);
            throw;
        }

    }
    private void DownloadEPAMGlance()
    {
        try
        {
            new WebDriverWait(_driver, GetWait(Waits.Long)).
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
