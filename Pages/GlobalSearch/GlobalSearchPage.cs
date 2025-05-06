using DotnetTaskSeleniumNunit.Constants;
using log4net;
using OpenQA.Selenium;

namespace DotnetTaskSeleniumNunit.Pages.GlobalSearch;

internal partial class GlobalSearchPage
{
    protected readonly IWebDriver _driver;
    protected readonly ILog _logger;
    protected readonly GlobalVariables _vars;

    public GlobalSearchPage(IWebDriver? driver, ILog? logger, GlobalVariables variables)
    {
        ArgumentNullException.ThrowIfNull(driver);
        ArgumentNullException.ThrowIfNull(logger);
        ArgumentNullException.ThrowIfNull(variables);
        _driver = driver;
        _logger = logger;
        _vars = variables;
    }

    public void ClickMagnifier()
    {
        ClickMagnifierIcon();

    }

    public void EnterSearchText(string searchText)
    {
        EnterSearchCriteria(searchText);
    }

    public void Search()
    {
        ClickFindButton();
    }

    public IEnumerable<string?> GetSearchResults()
    {
        return GetAllArticlesTextFromSearchResults();
    }
}
