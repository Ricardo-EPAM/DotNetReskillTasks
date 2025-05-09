using DotnetTaskSeleniumNunit.Enums;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace DotnetTaskSeleniumNunit.Pages.Navigation;

internal partial class NavigationBar
{
    private IWebElement SelectElementByText(IList<IWebElement> elements, string text)
    {
        return elements.First(x => x.Text == text);
    }

    private void ClickTopLlinkByText(string linkText)
    {
        _logger.Debug($"Clicking link from top bar using the text '{linkText}'");
        try
        {
            var foundLink = new WebDriverWait(_driver, GetWait(Waits.Default)).
            Until(ExpectedConditions.ElementToBeClickable(SelectElementByText(TopPageLinks, linkText)));
            foundLink.Click();
        }
        catch (Exception ex)
        {
            _logger.Error(_errorClickingTopLink, ex);
            throw;
        }
    }

    private void ClickAcceptCookies()
    {
        _logger.Debug($"Trying to accept cookies from recently opened page");
        try
        {
            var cookiesButton = new WebDriverWait(_driver, GetWait(Waits.Default)).
                Until(ExpectedConditions.ElementToBeClickable(AcceptCookiesButton));
            cookiesButton.Click();
        }
        catch (Exception ex)
        {
            _logger.Info(_infoCookiesSkipped, ex);
        }
    }
}
