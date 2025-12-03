using DotnetTaskSeleniumNunit.Helpers;
using DotnetTaskSeleniumNunit.Pages.GlobalSearch;
using log4net;
using OpenQA.Selenium;
using Reqnroll;

namespace DotnetTaskSeleniumNunit.StepDefinitions;

[Binding]
public class GlobalSearchSteps
{
    private readonly GlobalSearchPage _page;

    public GlobalSearchSteps(IWebDriver driver, ConfigsManager configs, ILog logger)
    {
        _page = new GlobalSearchPage(driver, configs, logger);
    }

    [Given("the user clicks on the magnifier icon")]
    public void UserClicksMagnifierIcon ()
    {
        _page.ClickMagnifier();
    }

    [Given("the user enters the keyword {string} in the global search")]
    public void UserEntersKeywordInGlobalSearch (string searchText)
    {
        _page.EnterSearchText(searchText);
    }

    [When("the user initiates the search")]
    public void UserInitiatesTheSearch()
    {
        _page.Search();
    }

    [Then("all displayed search result links should contain the keyword {string}")]
    public void AllDisplayedSearchResultsContainsLinks(string searchText)
    {
        var links = _page.GetSearchResults();
        Assert.Multiple(() =>
        {
            foreach (var link in links)
            {
                if (link != null)
                {
                    Assert.That(link.ToLower(), Does.Contain(searchText.ToLower()),
                        "Not all search results links mention the search criteria");
                }
            }
        });
    }
}
