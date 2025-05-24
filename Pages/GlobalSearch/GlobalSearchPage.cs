using DotnetTaskSeleniumNunit.Helpers;
using log4net;
using OpenQA.Selenium;

namespace DotnetTaskSeleniumNunit.Pages.GlobalSearch;

internal partial class GlobalSearchPage(IWebDriver driver, ConfigsManager configs, ILog logger) : BasePage(driver, configs, logger)
{

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
