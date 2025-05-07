using DotnetTaskSeleniumNunit.Constants;
using log4net;
using OpenQA.Selenium;

namespace DotnetTaskSeleniumNunit.Pages.GlobalSearch;

internal partial class GlobalSearchPage(IWebDriver? driver,
                   ILog? logger,
                   GlobalVariables variables) : BasePage(driver, logger, variables)
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
