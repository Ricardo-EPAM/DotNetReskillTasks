using OpenQA.Selenium;

namespace ATA_Dotnet_Selenium_task.Pages.Careers;

internal partial class CareerSearchPage
{
    private readonly By _careersLink = By.LinkText("Careers");
    private readonly By _keywordInput = By.Id("new_form_job_search-keyword");
    private readonly By _keywordSuggestions = By.ClassName("autocomplete-suggestion");
    private readonly By _locationClickable = By.XPath("//*[@id='new_form_job_search-location']/..");
    private readonly By _locationSelect = By.CssSelector("select#new_form_job_search-location");
    private readonly By _locationInput = By.XPath("//select[@id ='new_form_job_search-location']/..//input");
    private readonly By _locationOption = By.TagName("li");
    private readonly By _modalityCheckboxes = By.CssSelector("fieldset input");
    private readonly By _followingLabel = By.XPath("./following-sibling::label"); 
    private readonly By _findButton = By.CssSelector("form#jobSearchFilterForm>button");
    private readonly By _vacanciesContainers = By.CssSelector("section.search-result>ul>li");
    private readonly By _latestVacancyContainer = By.CssSelector("section.search-result>ul>li:last-child");
    private readonly By _applyButtonFromVacancy = By.PartialLinkText("APPLY");
    private readonly By _vacancyDescription = By.XPath("//article//section[descendant::p]");

    private IWebElement CareersLinkTabElement => _driver.FindElement(_careersLink);

    private IWebElement KeywordInput => _driver.FindElement(_keywordInput);

    private IWebElement LocationClickable => _driver.FindElement(_locationClickable);

    private IWebElement LocationSelect => _driver.FindElement(_locationSelect);

    private IEnumerable<IWebElement> LocationOptions => LocationClickable.FindElements(_locationOption);

    private IEnumerable<IWebElement> ModalityBoxes => _driver.FindElements(_modalityCheckboxes);

    private IWebElement FindVacancyButton => _driver.FindElement(_findButton);

    private IEnumerable<IWebElement> VacanciesContainers => _driver.FindElements(_vacanciesContainers);

    private IWebElement LatestVacancyDiv => _driver.FindElement(_latestVacancyContainer);

    private IWebElement VacancyDescription => _driver.FindElement(_vacancyDescription);

    private IWebElement ApplyButtonFromLatestVacancy => LatestVacancyDiv.FindElement(_applyButtonFromVacancy);

    private IWebElement LocationInput => _driver.FindElement(_locationInput);

}
