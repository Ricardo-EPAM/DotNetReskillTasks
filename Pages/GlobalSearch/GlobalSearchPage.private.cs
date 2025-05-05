using ATA_Dotnet_Selenium_task.Constants;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace ATA_Dotnet_Selenium_task.Pages.GlobalSearch;

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

    /// <summary>
    /// In order to validate article contains expected keyword we search in the Article; link and description.
    /// </summary>
    /// <returns>A list of strings with link+description text</returns>
    internal IEnumerable<string?> GetAllArticlesTextFromSearchResults()
    {
        new WebDriverWait(_driver, GlobalVariables.ExplicitWaitDefault).
            Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(_resultsArticlesDivs));
        var articleTexts = new List<string>();
        foreach (var article in ResultsArticles)
        {
            var linkText = article.FindElement(_links).GetAttribute("href");
            var descriptionText = article.FindElement(_descriptions).Text;
            articleTexts.Add(linkText + descriptionText);
        }
        return articleTexts;
    }
}
