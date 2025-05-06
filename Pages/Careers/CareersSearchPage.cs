using DotnetTaskSeleniumNunit.Constants;
using DotnetTaskSeleniumNunit.Models.Careers;
using log4net;
﻿using DotnetTaskSeleniumNunit.Pages.Navigation;
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

    public void MakeACareerSearch(CareerSearch searchData)
    {
        EnterSearchCriteriaAndIgnoreSuggestion(searchData.Criteria);
        SelectLocationDropdownByValue(searchData.Location);
        SelectModalityCheckboxByText(searchData.Modality);
        ClickFindButton();
    }

    public void SearchFor(string searchText)
    {
        EnterSearchCriteriaAndIgnoreSuggestion(searchText);
    }


    public void SelectLocation(string searchText)
    {
        SelectLocationDropdownByValue(searchText);
    }

    public void SelectModality(CareerModality modality)
    {
        SelectModalityCheckboxByText(modality);
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
