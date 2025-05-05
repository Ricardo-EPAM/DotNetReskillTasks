using System.Collections.ObjectModel;
using DotnetTaskSeleniumNunit.Constants;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace DotnetTaskSeleniumNunit.Pages.Navigation;

internal partial class NavigationBar
{
    public IWebElement SelectElementByText(IEnumerable<IWebElement> elements, string text)
    {
        // Screenshot used to debug headless mode.
        //((ITakesScreenshot)_driver).GetScreenshot().SaveAsFile($"screenshot{new Random().NextInt64(1000)}.png");
        return elements.First(x => x.Text == text);
    }

    public void ClickTopLlinkByText(string linkText)
    {
        var link = new WebDriverWait(_driver, GlobalVariables.ExplicitWaitLong).
           Until(ExpectedConditions.ElementToBeClickable(SelectElementByText(TopPageLinks, linkText)));
        link.Click();
    }

    public void ClickAcceptCookies()
    {
        try
        {
            var cookiesButton = new WebDriverWait(_driver, GlobalVariables.ExplicitWaitDefault).
          Until(ExpectedConditions.ElementToBeClickable(AcceptCookiesButton));
            cookiesButton.Click();
        }
        catch
        {
            // Continue the test.
        }
    }
}
