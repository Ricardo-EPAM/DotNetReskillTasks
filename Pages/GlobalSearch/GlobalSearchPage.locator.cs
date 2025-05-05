using OpenQA.Selenium;

namespace ATA_Dotnet_Selenium_task.Pages.GlobalSearch;

internal partial class GlobalSearchPage
{
    private readonly By _magnifierIcon = By.CssSelector("span.header-search__search-icon");
    private readonly By _searchField = By.Name("q");
    private readonly By _findButton = By.XPath("//input[ @name = 'q']/../following-sibling::button");
    private readonly By _resultsArticlesDivs = By.TagName("article");
    private readonly By _links = By.TagName("a");
    private readonly By _descriptions = By.TagName("p");

    private IWebElement MagnifierIcon => _driver.FindElement(_magnifierIcon);
    private IWebElement SearchField => _driver.FindElement(_searchField);
    private IWebElement Findbutton => _driver.FindElement(_findButton);
    private IEnumerable<IWebElement> ResultsArticles => _driver.FindElements(_resultsArticlesDivs);
}
