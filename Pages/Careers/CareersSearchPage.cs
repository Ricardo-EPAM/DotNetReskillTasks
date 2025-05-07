using DotnetTaskSeleniumNunit.Constants;
using DotnetTaskSeleniumNunit.Models.Careers;
using log4net;
using OpenQA.Selenium;
using DotnetTaskSeleniumNunit.Pages.JobDetails;

namespace DotnetTaskSeleniumNunit.Pages.Careers;


internal partial class CareerSearchPage(IWebDriver? driver,
                   ILog? logger,
                   GlobalVariables variables) : BasePage(driver, logger, variables)
{
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

    public JobDetailsPage ApplyAndViewFromLastSection()
    {
        return ClickApplyAndViewFromSection(GetLastJobSectionElement());
    }

    public string GetJobDescription()
    {
        return GetVacancyContainerText();

    }
}
