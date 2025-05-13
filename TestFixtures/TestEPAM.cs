using DotnetTaskSeleniumNunit.Enums;
using DotnetTaskSeleniumNunit.Helpers;
using DotnetTaskSeleniumNunit.Models.Careers;
using DotnetTaskSeleniumNunit.Pages.About;
using DotnetTaskSeleniumNunit.Pages.Article;
using DotnetTaskSeleniumNunit.Pages.Careers;
using DotnetTaskSeleniumNunit.Pages.GlobalSearch;
using DotnetTaskSeleniumNunit.Pages.Insights;
using DotnetTaskSeleniumNunit.Pages.JobDetails;
using DotnetTaskSeleniumNunit.Pages.Navigation;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace DotnetTaskSeleniumNunit.TestFixtures;


[TestFixture]
public class TestEPAM : BaseTest
{


    [Test]
    public void TestFirefoxDriver()
    {
        IWebDriver driverr;
        driverr = new FirefoxDriver();
        driverr.Navigate().GoToUrl("https://www.epam.com/careers");
        Thread.Sleep(1000);
        driverr.Dispose();

    }

    [TestCase("Golang", "all_locations", CareerModality.Remote)]
    [TestCase("Python", "all_Poland", CareerModality.Relocation)]
    [TestCase(".NET", "Warsaw", CareerModality.Office)]
    [TestCase("Java", "Buenos Aires", CareerModality.Office)]
    public void TestCareersSearch(string searchText, string locationValue, CareerModality locationModality)
    {
        CareerSearchPage careersSearchPage = new(_dependencies);
        NavigationBar navigation = new(_dependencies);

        navigation.AcceptCookies();
        navigation.NavigateToCareersPage();

        var careerSearchForm = new CareerSearch(searchText, locationValue, locationModality);
        careersSearchPage.MakeACareerSearch(careerSearchForm);
        careersSearchPage.ApplyAndViewFromLastSection();

        JobDetailsPage jobDetails = new(_dependencies);
        string jobDescription = jobDetails.GetJobDescription();
        Assert.That(jobDescription, Does.Contain(searchText));
    }

    [TestCase("BLOCKCHAIN")]
    [TestCase("Cloud")]
    [TestCase("Automation")]
    public void TestGlobalSearchKeywords(string searchCriteria)
    {
        GlobalSearchPage globalSearchPage = new(_dependencies);
        NavigationBar navigation = new(_dependencies);

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

    [Category("RequiresDirectoryCleanUp")]
    [TestCase("EPAM_Corporate_Overview_Q4FY-2024.pdf")]
    public void TestDownloadFile(string filePath)
    {
        NavigationBar navigation = new(_dependencies);
        AboutPage aboutPage = new(_dependencies);
        var files = new FilesHelper(SpecialFolders.Downloads, _dependencies.Logger);

        Assert.That(files.DoesFileExist(filePath, tries: 1), Is.False, "File should not exist before download it");

        navigation.AcceptCookies();
        navigation.NavigateToAboutPage();
        aboutPage.ScrollToEPAMAtAGlanceSection();
        aboutPage.DownloadEPAMAtAGlanceDocument();

        Assert.That(files.DoesFileExist(filePath), Is.True, "File was not downloaded");
    }

    [TestCase(1)]
    [TestCase(2)]
    [TestCase(3)]
    [TestCase(4)]
    public void TestCarrouselArticles(int carouselIndex)
    {
        NavigationBar navigation = new(_dependencies);
        InsightsPage insightsPage = new(_dependencies);

        navigation.AcceptCookies();
        navigation.NavigateToInsightsPage();
        insightsPage.SwipeCarousel(SwipeDirection.Right, carouselIndex);

        var carouselTitle = insightsPage.GetCarouselTitle();
        insightsPage.ClickReadMoreFromCarousel();

        ArticlePage articlePage = new(_dependencies);
        var acticleTitle = articlePage.GetTitle();
        Assert.That(acticleTitle, Is.EqualTo(carouselTitle), "Article title doesn't match the expected value");
    }
}


