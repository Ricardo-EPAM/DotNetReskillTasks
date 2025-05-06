using DotnetTaskSeleniumNunit.Pages.Careers;
using DotnetTaskSeleniumNunit.Pages.GlobalSearch;
using DotnetTaskSeleniumNunit.Pages.Navigation;
using NUnit.Framework.Internal;
using OpenQA.Selenium;

namespace DotnetTaskSeleniumNunit.TestFixtures;


[TestFixture]
public class TestSearch : BaseTest
{

    [Test]
    public void testa()
    {
        logger.Debug("ya lo rompi?");
        logger.Error("error");
        logger.Info("info");
        Assert.That(true);
    }


    [TestCase("Perl", "all_locations", "Remote")]
    [TestCase("Python", "all_Mexico", "Relocation")]
    [TestCase(".NET", "all_Mexico", "Office")]
    [TestCase("Java", "Buenos Aires", "Office")]
    public void TestCareersSearch(string searchCriteria, string location, string modality)
    {
        CareerSearchPage careersSearchPage = new(driver: driver, logger, vars);
        NavigationBar navigation = new(driver, logger, vars);
        navigation.AcceptCookies();

        navigation.NavigateToCareersPage();

        careersSearchPage.SearchFor(searchCriteria);

        careersSearchPage.SelectLocation(location);

        careersSearchPage.SelectModality(modality.ToLower());

        careersSearchPage.Search();

        IWebElement jobSection = careersSearchPage.GetLastJobSection();

        careersSearchPage.ApplyAndView(fromSection: jobSection);

        string jobDescription = careersSearchPage.GetJobDescription();
        Assert.That(jobDescription, Does.Contain(searchCriteria));
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
                if(link != null)
                {
                    Assert.That(link.ToLower(), Does.Contain(searchCriteria.ToLower()),
                        "Not all search results links mention the search criteria");
                }
            }
        });
    }
}


