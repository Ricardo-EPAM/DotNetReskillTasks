using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
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
            var foundLink = new WebDriverWait(_driver, _configs.UIWaitsConfiguration.DefaultWait).
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
            var cookiesButton = new WebDriverWait(_driver, _configs.UIWaitsConfiguration.ShortWait).
                Until(ExpectedConditions.ElementToBeClickable(AcceptCookiesButton));
            var js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].click()", cookiesButton);
        }
        catch (Exception ex)
        {
            _logger.Info(_infoCookiesSkipped, ex);
            throw;
        }
    }

    private void HoverLink(string linkText)
    {
        _logger.Debug($"Hovering on the '{linkText}' link");
        try
        {
            var linkElement = new WebDriverWait(_driver, _configs.UIWaitsConfiguration.DefaultWait).
                Until(ExpectedConditions.ElementToBeClickable(SelectElementByText(TopPageLinks, linkText)));
            new Actions(_driver).MoveToElement(linkElement).Perform();
            new WebDriverWait(_driver, _configs.UIWaitsConfiguration.DefaultWait).
                Until(ExpectedConditions.ElementIsVisible(_linkSubItemsContainer));
        }
        catch (Exception ex)
        {
            _logger.Error(_errorHoverLink, ex);
            throw;
        }
    }
    private void ClickSubItemFromHoveredLink(string itemText)
    {
        _logger.Debug($"Clicking on '{itemText}' link from sub items (Hovered top section)");
        try
        {
            var linkElement = new WebDriverWait(_driver, _configs.UIWaitsConfiguration.DefaultWait).
                 Until(ExpectedConditions.ElementToBeClickable(SelectElementByText(SubItemsLinks, itemText)));
            linkElement.Click();
        }
        catch (Exception ex)
        {
            _logger.Error(_errorClickSubItemFromHoveredLink, ex);
            throw;
        }
    }
}
