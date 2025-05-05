using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace DotnetTaskSeleniumNunit.Pages.Navigation;

internal partial class NavigationBar
{
    private IWebElement SelectElementByText(IList<IWebElement> elements, string text)
    {
        // Screenshot used to debug headless mode.
        //((ITakesScreenshot)_driver).GetScreenshot().SaveAsFile($"screenshot{new Random().NextInt64(1000)}.png");
        return elements.First(x => x.Text == text);
    }

    private void ClickTopLlinkByText(string linkText)
    {
        try
        {
            var foundLink = new WebDriverWait(_driver, _vars.ExplicitWaitDefault).
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
        try
        {
            var cookiesButton = new WebDriverWait(_driver, _vars.ExplicitWaitDefault).
                Until(ExpectedConditions.ElementToBeClickable(AcceptCookiesButton));
            cookiesButton.Click();
        }
        catch (Exception ex)
        {
            _logger.Info(_infoCookiesSkipped, ex);
        }
    }
}
