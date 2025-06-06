using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace DotnetTaskSeleniumNunit.Pages.About;

internal partial class ServicesPage
{
    private bool IsOurRelatedExpertiseTitleVisible()
    {
        _logger.Debug($"Trying to get the section title 'Our Related Expertise'");
        try
        {
            new WebDriverWait(_driver, _configs.UIWaitsConfiguration.DefaultWait).
                Until(ExpectedConditions.ElementIsVisible(_labelOurRelatedExpertise));
            return OurRelatedExpertiseLabel.Displayed;
        }
        catch (Exception ex)
        {
            _logger.Info(_infoIsOurRelatedExpertiseTitleVisible, ex);
            return false;
        }
    }
}
