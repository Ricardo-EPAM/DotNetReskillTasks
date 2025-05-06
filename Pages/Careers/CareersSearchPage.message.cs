namespace DotnetTaskSeleniumNunit.Pages.Careers;

internal partial class CareerSearchPage
{
    private readonly string _infoIgnoreSearchSuggestions = "No suggestions were found, continuing with test execution";
    private readonly string _errorEnteringSearchCriteria = "Unable to enter keyword in the search field";
    private readonly string _errorGetVacancyContainerElement = "No vacancy container web elements found";
    private readonly string _errorClickApplyAndViewFromSection = "Unable to click 'Apply and View' from vacancy selected";
    private readonly string _errorSelectModalityCheckboxByText = "Error selecting Modality checkbox, available options are Remote, Office and Relocation";
    private readonly string _errorSelectLocationDropdownByValue = "There was an error selecting the Location, please verify you are using 'value' attribute";
    private readonly string _errorGetJobSections = "No job sections were found";
    private readonly string _erroClickFindButton = "Unable to click Find button from search page";
}
