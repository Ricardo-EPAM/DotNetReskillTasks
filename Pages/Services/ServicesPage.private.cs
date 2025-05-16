using NUnit.Framework;
using OpenQA.Selenium.BiDi.Modules.BrowsingContext;
using System.ComponentModel.DataAnnotations;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace DotnetTaskSeleniumNunit.Pages.About;

internal partial class ServicesPage
{
    private void ScrollToEPAMGlanceSection()
    {
        _logger.Debug($"Scrolling to the 'EPAM At A Glance' section");
        try
        {
            new WebDriverWait(_driver, _configs.UIWaitsConfiguration.DefaultWait).
                Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(_epamGlanceSection));
            new Actions(_driver).ScrollToElement(EPAMGlanceSection).Perform();
        }
        catch (Exception ex)
        {
            _logger.Error(_errorScrollToEPAMGlanceSection, ex);
            throw;
        }

    }

(parameterize the category selection).
4.	Validate that the page contains the correct title.
5.	Validate that the section ‘Our Related Expertise’ is displayed on the page

}
