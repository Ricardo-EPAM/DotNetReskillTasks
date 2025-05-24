using DotnetTaskSeleniumNunit.Helpers;
using DotnetTaskSeleniumNunit.Models.Careers;
using log4net;
using OpenQA.Selenium;

namespace DotnetTaskSeleniumNunit.Pages.Careers;


internal partial class CareerSearchPage(IWebDriver driver, ConfigsManager configs, ILog logger) : BasePage(driver, configs, logger)
{
    public void MakeACareerSearch(CareerSearch searchData)
    {
        EnterSearchCriteriaAndIgnoreSuggestion(searchData.Criteria);
        SelectLocationDropdownByValue(searchData.Location);
        SelectModalityCheckboxByText(searchData.Modality);
        ClickFindButton();
    }

    public void ApplyAndViewFromLastSection()
    {
        ClickApplyAndViewFromSection(GetLastJobSectionElement());
    }

    public string GetJobDescription()
    {
        return GetVacancyContainerText();

    }
}
