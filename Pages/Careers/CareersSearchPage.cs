using DotnetTaskSeleniumNunit.Helpers;
using DotnetTaskSeleniumNunit.Models.Careers;

namespace DotnetTaskSeleniumNunit.Pages.Careers;


internal partial class CareerSearchPage(POMDependency pomDependencies) : BasePage(pomDependencies)
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
