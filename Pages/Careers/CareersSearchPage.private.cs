using DotnetTaskSeleniumNunit.Constants;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace DotnetTaskSeleniumNunit.Pages.Careers;

internal partial class CareerSearchPage
{
    private void EnterSearchCriteriaAndIgnoreSuggestion(string searchText)
    {
        EnterSearchCriteria(searchText);
        IgnoreSearchSuggestions();
    }
    private void EnterSearchCriteria(string searchText)
    {
        try
        {
            new WebDriverWait(_driver, _vars.ExplicitWaitDefault).
                Until(ExpectedConditions.ElementToBeClickable(_keywordInput));
            KeywordInput.Clear();
            KeywordInput.SendKeys(searchText);
        }
        catch (Exception ex)
        {
            _logger.Error(_errorEnteringSearchCriteria, ex);
            throw;
        }

    }

    private void IgnoreSearchSuggestions()
    {
        try
        {
            new WebDriverWait(_driver, _vars.ExplicitWaitShort).
                   Until(ExpectedConditions.ElementIsVisible(_keywordSuggestions));
            KeywordInput.SendKeys(Keys.Tab);
        }
        catch (Exception ex)
        {
            _logger.Error(_infoIgnoreSearchSuggestions, ex);
            throw;
        }
    }

    private void SelectLocationDropdownByValue(string searchText)
    {
        try
        {
            new WebDriverWait(_driver, _vars.ExplicitWaitDefault).
                Until(x => x.FindElement(_locationSelect).Enabled);
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript($"arguments[0].value = '{searchText}'", LocationSelect);
        }
        catch (Exception ex)
        {
            _logger.Error(_errorSelectLocationDropdownByValue, ex);
            throw;
        }
    }

    private void SelectModalityCheckboxByText(string modalityText)
    {
        try
        {
            new WebDriverWait(_driver, _vars.ExplicitWaitLong).
                Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(_modalityCheckboxes));
            var selection = ModalityBoxes.First(x => x.GetAttribute("name")?.Contains(modalityText) == true);
            selection.FindElement(_followingLabel).Click();
        }
        catch (Exception ex)
        {
            _logger.Error(_errorSelectModalityCheckboxByText, ex);
            throw;
        }
    }

    private void ClickFindButton()
    {
        try
        {
            new WebDriverWait(_driver, _vars.ExplicitWaitDefault).
                Until(ExpectedConditions.ElementToBeClickable(_findButton));
            FindVacancyButton.Click();
        }
        catch (Exception ex)
        {
            _logger.Error(_erroClickFindButton, ex);
            throw;
        }
    }

    private IList<IWebElement> GetJobSections()
    {
        try
        {
            var results = new WebDriverWait(_driver, _vars.ExplicitWaitDefault).
               Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(_vacanciesContainers));
            return results;
        }
        catch (Exception ex)
        {
            _logger.Error(_errorGetJobSections, ex);
            throw;
        }
    }

    private IWebElement GetLastJobSectionElement()
    {
        return GetJobSections().Last();
    }

    private void ClickApplyAndViewFromSection(IWebElement section)
    {
        try
        {
            new WebDriverWait(_driver, _vars.ExplicitWaitDefault).
                Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(_applyButtonFromVacancy));
            section.FindElement(_applyButtonFromVacancy).Click();
        }
        catch (Exception ex)
        {
            _logger.Error(_errorClickApplyAndViewFromSection, ex);
            throw;
        }
    }

    private string GetVacancyContainerText()
    {
        IWebElement jobElements;
        try
        {
            jobElements = new WebDriverWait(_driver, _vars.ExplicitWaitDefault).
                Until(ExpectedConditions.ElementIsVisible(_vacancyDescription));
            return  jobElements.Text;
        }
        catch (Exception ex)
        {
            _logger.Error(_errorGetVacancyContainerElement, ex);
            throw;
        }
    }
}
