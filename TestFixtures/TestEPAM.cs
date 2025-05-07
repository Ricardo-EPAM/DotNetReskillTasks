using DotnetTaskSeleniumNunit.Pages.Insights;
using DotnetTaskSeleniumNunit.Pages.About;
using DotnetTaskSeleniumNunit.Pages.Careers;
using DotnetTaskSeleniumNunit.Pages.Article;
using DotnetTaskSeleniumNunit.Pages.GlobalSearch;
using DotnetTaskSeleniumNunit.Pages.JobDetails;
using DotnetTaskSeleniumNunit.Helpers;

using NUnit.Framework.Internal;
using OpenQA.Selenium;
using DotnetTaskSeleniumNunit.Models.Careers;
using DotnetTaskSeleniumNunit.Pages.Navigation;
using DotnetTaskSeleniumNunit.Enums;
namespace DotnetTaskSeleniumNunit.TestFixtures;


[TestFixture]
public class TestEPAM : BaseTest
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
        JobDetailsPage jobDetails = careersSearchPage.ApplyAndView(fromSection: jobSection);

        string jobDescription = jobDetails.GetJobDescriptionText();
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

    [TestCase("EPAM_Corporate_Overview_Q4FY-2024.pdf")]
    public void TestDownloadFile(string filePath)
    {
        NavigationBar navigation = new(driver, logger, vars);
        AboutPage aboutPage = new(driver, logger, vars);
        var files = new FilesHelper(SpecialFolders.Downloads);

        Assert.That(files.DoesFileExist(filePath, tries: 1), Is.False, "File should not exist before download it");

        navigation.AcceptCookies();
        navigation.NavigateToAboutPage();
        aboutPage.ScrollToEPAMAtAGlanceSection();
        aboutPage.DownloadEPAMAtAGlanceDocument();

        Assert.That(files.DoesFileExist(filePath), Is.True, "File was not downloaded");
        files.DeleteFile(filePath);
    }

    [TestCase(1)]
    [TestCase(2)]
    [TestCase(3)]
    [TestCase(4)]
    public void TestCarrouselArticles(int carouselIndex)
    {
        NavigationBar navigation = new(driver, logger, vars);
        InsightsPage insightsPage = new(driver, logger, vars);

        var files = new FilesHelper(vars.DownloadsLocation);
        navigation.AcceptCookies();
        navigation.NavigateToInsightsPage();
        insightsPage.SwipeCarousel("Right", carouselIndex);

        var carouselTitle = insightsPage.GetCarouselTitle(); 
        ArticlePage articlePage = insightsPage.ClickReadMoreFromCarousel();

        var acticleTitle = articlePage.GetTitle();
        Assert.That(acticleTitle, Is.EqualTo(carouselTitle), "Article title doesn't match the expected value");
    }
}


