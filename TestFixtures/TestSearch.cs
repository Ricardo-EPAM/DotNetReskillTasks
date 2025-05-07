using DotnetTaskSeleniumNunit.Models.Careers;
using DotnetTaskSeleniumNunit.Pages.Careers;
using DotnetTaskSeleniumNunit.Pages.GlobalSearch;
using DotnetTaskSeleniumNunit.Pages.Navigation;
using NUnit.Framework.Internal;
using OpenQA.Selenium;

namespace DotnetTaskSeleniumNunit.TestFixtures;


[TestFixture]
public class TestSearch : BaseTest
{

    [TestCase("Perl", "all_locations", CareerModality.Remote)]
    [TestCase("Python", "all_Mexico", CareerModality.Relocation)]
    [TestCase(".NET", "all_Mexico", CareerModality.Office)]
    [TestCase("Java", "Buenos Aires", CareerModality.Office)]
    public void TestCareersSearch(string searchText, string locationValue, CareerModality locationModality)
    {
        CareerSearchPage careersSearchPage = new(driver: driver, logger, vars);
        NavigationBar navigation = new(driver, logger, vars);
        navigation.AcceptCookies();

        navigation.NavigateToCareersPage();

        var careerSearchForm = new CareerSearch(searchText, locationValue, locationModality);
        careersSearchPage.MakeACareerSearch(careerSearchForm);

        IWebElement jobSection = careersSearchPage.GetLastJobSection();

        careersSearchPage.ApplyAndView(fromSection: jobSection);

        string jobDescription = careersSearchPage.GetJobDescription();
        Assert.That(jobDescription, Does.Contain(searchText));
    }

    [TestCase("BLOCKCHAIN")]
    [TestCase("Cloud")]
    [TestCase("Automation")]
    public void TestGlobalSearchKeywords(string searchCriteria)
    {
        GlobalSearchPage globalSearchPage = new(driver, logger, vars);
        NavigationBar navigation = new(driver, logger, vars);
        navigation.AcceptCookies();

        globalSearchPage.ClickMagnifier();

        globalSearchPage.EnterSearchText(searchCriteria);

        globalSearchPage.Search();

        var links = globalSearchPage.GetSearchResults();
        Assert.Multiple(() =>
        {
            foreach (var link in links)
            {
                if (link != null)
                {
                    Assert.That(link.ToLower(), Does.Contain(searchCriteria.ToLower()),
                        "Not all search results links mention the search criteria");
                }
            }
        });
    }
}


