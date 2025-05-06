using DotnetTaskSeleniumNunit.Constants;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace DotnetTaskSeleniumNunit.Pages.About;

internal partial class AboutPage
{
    internal void ScrollToEPAMGlanceSection()
    {
        new WebDriverWait(_driver, _vars.ExplicitWaitLong).
            Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(_epamGlanceSection));
        new Actions(_driver).ScrollToElement(EPAMGlanceSection).Perform();
    }
    internal void DownloadEPAMGlance()
    {
        new WebDriverWait(_driver, _vars.ExplicitWaitLong).
            Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(_downloadButtonLink));
        EPAMGlanceDownloadButton.Click();
    }
}
