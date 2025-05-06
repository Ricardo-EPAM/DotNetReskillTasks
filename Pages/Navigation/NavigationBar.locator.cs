using OpenQA.Selenium;

namespace DotnetTaskSeleniumNunit.Pages.Navigation;

internal partial class NavigationBar
{
    private readonly By _TopPageLinks = By.XPath("//a[contains(@class, 'top-navigation__item-link')]");
    private readonly By _CareersLink = By.XPath("//a[contains(@class, 'top-navigation__item-link') and .='{?}']");
    private readonly By _acceptCookiesButton = By.Id("onetrust-accept-btn-handler");

<<<<<<< HEAD
    private IList<IWebElement> TopPageLinks => _driver.FindElements(_TopPageLinks);
=======
    private IEnumerable<IWebElement> TopPageLinks => _driver.FindElements(_TopPageLinks);
>>>>>>> 1dc53b1bb3f1bab72cec8987b9727d48a50a4e25
    private IWebElement CareerLink => _driver.FindElement(_CareersLink);
    private IWebElement AcceptCookiesButton => _driver.FindElement(_acceptCookiesButton);

}
