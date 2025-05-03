using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace ATA_Dotnet_Selenium_task.Pages.Navigation;

internal partial class NavigationBar
{
    public IWebElement SelectElementByText(IEnumerable<IWebElement> elements, string text)
    {
        return elements.First(x => x.Text == text);
    }

    public void ClickTopLlinkByText(string linkText)
    {
        var link = new WebDriverWait(_driver, TimeSpan.FromSeconds(6)).
           Until(ExpectedConditions.ElementToBeClickable(SelectElementByText(TopPageLinks, linkText)));
        link.Click();
    }

    public void ClickAcceptCookies()
    {
        try
        {
            var cookiesButton = new WebDriverWait(_driver, TimeSpan.FromSeconds(6)).
          Until(ExpectedConditions.ElementToBeClickable(AcceptCookiesButton));
            cookiesButton.Click();
        }
        catch
        {
            // Continue the test.
        }
    }
}
