using DotnetTaskSeleniumNunit.Constants;
using DotnetTaskSeleniumNunit.Pages.JobDetails;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace DotnetTaskSeleniumNunit.Pages.Careers;

internal partial class CareerSearchPage
{
    //3.	Write the name of any programming language in the field “Keywords” (should be taken from test parameter)
    internal void EnterKeywordSearchCriteria(string searchText)
    {
        new WebDriverWait(_driver, GlobalVariables.ExplicitWaitDefault).
            Until(ExpectedConditions.ElementToBeClickable(_keywordInput));
        KeywordInput.Clear();
        KeywordInput.SendKeys(searchText);

        // Ignore search suggestions.
        try
        {
            new WebDriverWait(_driver, GlobalVariables.ExplicitWaitShort).
                   Until(ExpectedConditions.ElementIsVisible(_keywordSuggestions));
            KeywordInput.SendKeys(Keys.Tab);
        }
        catch
        {
            // Continue with test execution.
        }
    }

    //4.	Select “All Locations” in the “Location” field(should be taken from the test parameter)
    internal void SelectLocationByText(string searchText)
    {

        new WebDriverWait(_driver, GlobalVariables.ExplicitWaitDefault).
            Until(ExpectedConditions.ElementToBeClickable(_locationClickable));
        LocationClickable.Click();
        try
        {
            // Select by visible options (without searching).
            var selection = LocationOptions.First(x => x.GetAttribute("title") == searchText);
            selection.Click();
        }
        catch (Exception)
        {
            // Select by searching
            LocationInput.SendKeys(searchText);
            var selection = LocationOptions.First();
            selection.Click();
        }
    }
    internal void SelectLocationByTextV2(string searchText)
    {
        // I tried but its not working.
        new WebDriverWait(_driver, GlobalVariables.ExplicitWaitDefault).
            Until(x => x.FindElement(_locationSelect).Enabled);
        try
        {
            var selectInput = new SelectElement(LocationSelect);
            selectInput.SelectByValue(searchText);
        }
        catch
        {
            var selectInput = new SelectElement(LocationSelect);
            selectInput.SelectByText(searchText);
        }
    }

    //5.	Select the option “Remote”
    internal void SelectModality(string modalityText)
    {
        new WebDriverWait(_driver, GlobalVariables.ExplicitWaitLong).
            Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(_modalityCheckboxes));
        var selection = ModalityBoxes.First(x => x.GetAttribute("name")?.Contains(modalityText) == true);
        selection.FindElement(_followingLabel).Click();
    }

    //6.	Click on the button “Find”
    internal void ClickFindButton()
    {
        new WebDriverWait(_driver, GlobalVariables.ExplicitWaitDefault).
            Until(ExpectedConditions.ElementToBeClickable(_findButton));
        FindVacancyButton.Click();
    }

    //7.	Find the latest element in the list of results
    internal IWebElement GetLastJobSection()
    {
        // Using LINQ.
        var results = new WebDriverWait(_driver, GlobalVariables.ExplicitWaitDefault).
            Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(_vacanciesContainers));
        return results.Last();
    }
    internal IWebElement GetLastJobSectionV2()
    {
        // Using last-child css axe.
        new WebDriverWait(_driver, GlobalVariables.ExplicitWaitDefault).
            Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(_vacanciesContainers));
        return LatestVacancyDiv;
    }

    //8.	Click on the button “View and apply”

    internal JobDetailsPage ClickApplyAndViewFromSection(IWebElement section)
    {
        new WebDriverWait(_driver, GlobalVariables.ExplicitWaitDefault).
            Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(_applyButtonFromVacancy));
        section.FindElement(_applyButtonFromVacancy).Click();
        return new JobDetailsPage(_driver);
    }

   
}
