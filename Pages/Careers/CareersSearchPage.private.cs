using DotnetTaskSeleniumNunit.Enums;
using DotnetTaskSeleniumNunit.Models.Careers;
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
        _logger.Debug($"Sending '{searchText}' to the search input field");
        try
        {
            new WebDriverWait(_driver, GetWait(Waits.Default)).
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
        _logger.Debug($"Trying to close the 'suggestions' prompt");
        try
        {
            new WebDriverWait(_driver, GetWait(Waits.Short)).
                   Until(ExpectedConditions.ElementIsVisible(_keywordSuggestions));
            KeywordInput.SendKeys(Keys.Tab);
        }
        catch (Exception ex)
        {
            _logger.Info(_infoIgnoreSearchSuggestions, ex);
        }
    }

    private void SelectLocationDropdownByValue(string searchText)
    {
        _logger.Debug($"Selecting '{searchText}' from Location dropdown");
        try
        {
            new WebDriverWait(_driver, GetWait(Waits.Default)).
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

    private void SelectModalityCheckboxByText(CareerModality modality)
    {
        _logger.Debug($"Selecting '{modality}' from Modality checkboxes");
        var modalityText = modality.ToString().ToLower();
        try
        {
            new WebDriverWait(_driver, GetWait(Waits.Long)).
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
        _logger.Debug($"Clicking 'Find' button'");
        try
        {
            new WebDriverWait(_driver, GetWait(Waits.Default)).
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
        _logger.Debug($"Getting Vacancies sections from results");
        try
        {
            new WebDriverWait(_driver, GetWait(Waits.Default)).
               Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(_vacanciesContainers));
            return VacanciesContainers;
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
        _logger.Debug($"Clicking 'Apply and View' button from the selected section");
        try
        {
            new WebDriverWait(_driver, GetWait(Waits.Default)).
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
        _logger.Debug($"Getting text from Vacancy description");
        IWebElement jobElements;
        try
        {
            jobElements = new WebDriverWait(_driver, GetWait(Waits.Default)).
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
