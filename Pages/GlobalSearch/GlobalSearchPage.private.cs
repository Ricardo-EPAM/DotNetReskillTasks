using DotnetTaskSeleniumNunit.Constants;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace DotnetTaskSeleniumNunit.Pages.GlobalSearch;

internal partial class GlobalSearchPage
{

    // 2.	Find a magnifier icon and click on it
    internal void ClickMagnifierIcon()
    {
        new WebDriverWait(_driver, GlobalVariables.ExplicitWaitDefault).
            Until(ExpectedConditions.ElementToBeClickable(_magnifierIcon));
        MagnifierIcon.Click();
    }
    // 3.	Find a search string and put there “BLOCKCHAIN”/”Cloud”/”Automation” (use as a parameter for a test)
    internal void EnterSearchCriteria(string searchText)
    {
        new WebDriverWait(_driver, GlobalVariables.ExplicitWaitDefault).
            Until(ExpectedConditions.ElementToBeClickable(_searchField));
        SearchField.SendKeys(searchText);
    }
    // 4.	Click “Find” button
    internal void ClickFindButton()
    {
        new WebDriverWait(_driver, GlobalVariables.ExplicitWaitDefault).
            Until(ExpectedConditions.ElementToBeClickable(_findButton));
        Findbutton.Click();
    }
    // 5.	Validate that all links in a list contain the word “BLOCKCHAIN”/”Cloud”/”Automation” in the text.LINQ should be used.
    internal IEnumerable<string?> GetAllLinksFromSearchResults()
    {
        new WebDriverWait(_driver, GlobalVariables.ExplicitWaitDefault).
            Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(_resultsArticlesDivs));
        var linksWebElements = new List<IWebElement>();
        foreach (var article in ResultsArticles)
        {
            linksWebElements.Add(article.FindElement(_links));
        }
        IEnumerable<string?> links = linksWebElements.Select(a => a.GetAttribute("href"));
        return links;
    }
}
