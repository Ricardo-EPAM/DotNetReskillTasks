using DotnetTaskSeleniumNunit.Constants;
using log4net;
using OpenQA.Selenium;

namespace DotnetTaskSeleniumNunit.Pages.Careers;

internal partial class CareerSearchPage
{
    
    protected readonly IWebDriver _driver;
    protected readonly ILog _logger;
    protected readonly GlobalVariables _vars;

    public CareerSearchPage(IWebDriver? driver, ILog? logger, GlobalVariables variables)
    {
        ArgumentNullException.ThrowIfNull(driver);
        ArgumentNullException.ThrowIfNull(logger);
        ArgumentNullException.ThrowIfNull(variables);
        _driver = driver;
        _logger = logger;
        _vars = variables;
    }

    public void SearchFor(string searchText)
    {
        EnterSearchCriteriaAndIgnoreSuggestion(searchText);
    }


    public void SelectLocation(string searchText)
    {
        SelectLocationDropdownByValue(searchText);
    }

    public void SelectModality(string modalityText)
    {
        SelectModalityCheckboxByText(modalityText);
    }

    public void Search()
    {
        ClickFindButton();
    }

    public IWebElement GetLastJobSection()
    {
        return GetLastJobSectionElement();
    }

    public void ApplyAndView(IWebElement fromSection)
    {
        ClickApplyAndViewFromSection(fromSection);
    }

    public string GetJobDescription()
    {
        return GetVacancyContainerText();

    }
}
