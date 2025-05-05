using DotnetTaskSeleniumNunit.Pages.Navigation;
using OpenQA.Selenium;

namespace DotnetTaskSeleniumNunit.Pages.Article;

internal partial class ArticlePage
{
    private readonly By _artivcleTitle = By.CssSelector("main p:first-of-type[style]");
    private readonly By _artivcleTitleV2 = By.CssSelector("div.content-container>div.section:first-of-type p[style]");
    private IWebElement ArticleTitle => _driver.FindElement(_artivcleTitle);
    private IWebElement ArticleTitleV2 => _driver.FindElement(_artivcleTitle);
}
