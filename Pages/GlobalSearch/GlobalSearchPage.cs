using DotnetTaskSeleniumNunit.Helpers;

namespace DotnetTaskSeleniumNunit.Pages.GlobalSearch;

internal partial class GlobalSearchPage(POMDependency pomDependencies) : BasePage(pomDependencies)
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
