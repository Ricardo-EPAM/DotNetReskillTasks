using OpenQA.Selenium;

namespace DotnetTaskSeleniumNunit.Pages.Navigation;

internal partial class NavigationBar
{
    private readonly By _topPageLinks = By.XPath("//a[contains(@class, 'top-navigation__item-link')]");
    private readonly By _topPageSubLinks = By.CssSelector("a.top-navigation__sub-link");
    private readonly By _linkSubItemsContainer = By.ClassName("top-navigation__sub-items-container");
    private readonly By _acceptCookiesButton = By.XPath("//*[@id='onetrust-accept-btn-handler']");

    private IList<IWebElement> TopPageLinks => _driver.FindElements(_topPageLinks);
    private IWebElement AcceptCookiesButton => _driver.FindElement(_acceptCookiesButton);
    private IList<IWebElement> SubItemsLinks => _driver.FindElements(_topPageSubLinks);

}
