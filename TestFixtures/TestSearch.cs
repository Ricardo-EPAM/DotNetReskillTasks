using ATA_Dotnet_Selenium_task.Pages.Careers;
using ATA_Dotnet_Selenium_task.Pages.GlobalSearch;
using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenQA.Selenium;

namespace ATA_Dotnet_Selenium_task.TestFixtures;


[TestFixture]
public class TestSearch : BaseTest
{

    [TestCase("Perl", "All Locations", "Remote")]
    [TestCase("Python", "All Cities in Mexico", "Relocation")]
    [TestCase(".NET", "All Cities in Mexico", "Office")]
    [TestCase("Java", "Buenos Aires", "Office")]
    public void TestCareersSearch(string searchCriteria, string location, string modality)
    {
        // 1.Navigate to https://www.epam.com/ 
        // Done through the Base test SetUp 
        CareerSearchPage careersSearchPage = new(driver: driver);
        careersSearchPage.ClickAcceptCookies();

        // 2.Find a link “Carriers” and click on it
        careersSearchPage.NavigateToTabByText("Careers");

        // 3.Write the name of any programming language in the field “Keywords” (should be taken from test parameter)
        careersSearchPage.EnterKeywordSearchCriteria(searchCriteria);

        // 4.Select “All Locations” in the “Location” field(should be taken from the test parameter)
        careersSearchPage.SelectLocationByText(location);

        // 5.Select the option “Remote”
        careersSearchPage.SelectModality(modality.ToLower());

        // 6.Click on the button “Find”
        careersSearchPage.ClickFindButton();

        // 7.Find the latest element in the list of results
        IWebElement jobSection = careersSearchPage.GetLastJobSection();

        // 8.Click on the button “View and apply”
        careersSearchPage.ClickApplyAndViewFromSection(section: jobSection);

        // 9.Validate that the programming language mentioned in the step above is on a page
        string jobDescription = careersSearchPage.GetJobDescription();
        Assert.That(jobDescription, Does.Contain(searchCriteria));
    }

    [TestCase("BLOCKCHAIN")]
    [TestCase("Cloud")]
    [TestCase("Automation")]
    public void TestGlobalSearchKeywords(string searchCriteria)
    {
        // 1.Navigate to https://www.epam.com/
        // Done through the Base test SetUp 
        GlobalSearchPage globalSearchPage = new(driver: driver);
        globalSearchPage.ClickAcceptCookies();

        // 2.Find a magnifier icon and click on it
        globalSearchPage.ClickMagnifierIcon();

        // 3.Find a search string and put there “BLOCKCHAIN”/”Cloud”/”Automation” (use as a parameter for a test)
        globalSearchPage.EnterSearchCriteria(searchCriteria);

        // 4.Click “Find” button
        globalSearchPage.ClickFindButton();

        // 5.Validate that all links in a list contain the word “BLOCKCHAIN”/”Cloud”/”Automation” in the text. LINQ should be used.

        // We only read the articles loaded (10) in order to get them all we would need to scroll many times.
        var links = globalSearchPage.GetAllArticlesTextFromSearchResults();
        // GetAllLinksFromSearchResults() method uses LINQ, for assertion is better to use Assert.Multiple instead of:
        // Assert.That(links.All(x => x.Contains(searchCriteria)), globalSearchPage.invalidGlobalSearchResult);
        Assert.Multiple(() =>
        {
            foreach (var link in links)
            {
                if(link != null)
                {
                    Assert.That(link.ToLower(), Does.Contain(searchCriteria.ToLower()), globalSearchPage.invalidGlobalSearchResult);
                }
            }
        });
    }
}


