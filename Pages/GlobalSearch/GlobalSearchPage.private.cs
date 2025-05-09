using DotnetTaskSeleniumNunit.Enums;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace DotnetTaskSeleniumNunit.Pages.GlobalSearch;

internal partial class GlobalSearchPage
{
    private void ClickMagnifierIcon()
    {
        _logger.Debug($"Clicking magnifier icon from the page header");
        try
        {
            new WebDriverWait(_driver, GetWait(Waits.Default)).
            Until(ExpectedConditions.ElementToBeClickable(_magnifierIcon));
            MagnifierIcon.Click();
        }
        catch (Exception ex)
        {
            _logger.Error(_errorClickMagnifierIcon, ex);
            throw;
        }

    }
    private void EnterSearchCriteria(string searchText)
    {
        _logger.Debug($"Sending '{searchText}' to the search field");
        try
        {
            new WebDriverWait(_driver, GetWait(Waits.Default)).
            Until(ExpectedConditions.ElementToBeClickable(_searchField));
            SearchField.SendKeys(searchText);
        }
        catch (Exception ex)
        {
            _logger.Error(_errorEnterSearchCriteria, ex);
            throw;
        }
    }
    private void ClickFindButton()
    {
        _logger.Debug($"Clicking 'Find' button");
        try
        {
            new WebDriverWait(_driver, GetWait(Waits.Default)).
            Until(ExpectedConditions.ElementToBeClickable(_findButton));
            Findbutton.Click();
        }
        catch (Exception ex)
        {
            _logger.Error(_errorClickFindButton, ex);
            throw;
        }
    }

    /// <summary>
    /// In order to validate article contains expected keyword we search in the Article; link and description.
    /// </summary>
    /// <returns>A list of strings with link+description text</returns>
    private IEnumerable<string?> GetAllArticlesTextFromSearchResults()
    {
        _logger.Debug($"Gathering all text contents from search results");
        var articleTexts = new List<string>();

        try
        {
            new WebDriverWait(_driver, GetWait(Waits.Default)).
            Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(_resultsArticlesDivs));
            foreach (var article in ResultsArticles)
            {
                var linkText = article.FindElement(_links).GetAttribute("href");
                var descriptionText = article.FindElement(_descriptions).Text;
                articleTexts.Add(linkText + descriptionText);
            }
        }
        catch (Exception ex)
        {
            _logger.Error(_errorGetAllArticlesTextFromSearchResults, ex);
            throw;
        }
        return articleTexts;
    }
}
