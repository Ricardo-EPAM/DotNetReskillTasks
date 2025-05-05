using ATA_Dotnet_Selenium_task.Constants;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace ATA_Dotnet_Selenium_task.Pages.About;

internal partial class AboutPage
{
    internal void ScrollToEPAMGlanceSection()
    {
        new WebDriverWait(_driver, GlobalVariables.ExplicitWaitLong).
            Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(_epamGlanceSection));
        new Actions(_driver).ScrollToElement(EPAMGlanceSection).Perform();
    }
    internal void DownloadEPAMGlance()
    {
        new WebDriverWait(_driver, GlobalVariables.ExplicitWaitLong).
            Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(_downloadButtonLink));
        EPAMGlanceDownloadButton.Click();
    }
}
