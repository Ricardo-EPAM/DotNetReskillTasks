using ATA_Dotnet_Selenium_task.Pages.About;
using ATA_Dotnet_Selenium_task.Pages.Insights;
using DotnetTaskSeleniumNunit.Helpers;
using DotnetTaskSeleniumNunit.Models.Careers;
using DotnetTaskSeleniumNunit.Pages.Careers;
using DotnetTaskSeleniumNunit.Pages.GlobalSearch;
using DotnetTaskSeleniumNunit.Pages.Navigation;
using NUnit.Framework.Internal;
using OpenQA.Selenium;

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
    [TestCase("EPAM_Corporate_Overview_Q4FY-2024.pdf")]
    public void TestDownloadFile(string filePath)
    {
        //1.Create a Chrome instance.
        //2.Navigate to https://www.epam.com/.
        // Done through the Base test SetUp 
        AboutPage aboutPage = new(driver: driver);
        var files = new FilesHelper(vars.DownloadsPath);

        // Preconditions, file should not exist at this point.
        Assert.That(files.DoesFileExist(filePath, tries: 1), Is.False, aboutPage.testPreconditionsFailed);
        aboutPage.ClickAcceptCookies();

        //3.Select “About” from the top menu.
        aboutPage.NavigateToTabByText("About");

        //4.Scroll down to the “EPAM at a Glance” section.
        aboutPage.ScrollToEPAMGlanceSection();

        //5.Click on the “Download” button.
        aboutPage.DownloadEPAMGlance();

        //6.Wait till the file is downloaded.
        // Wait is performed by DoesFileExist() method from next step.

        //7.Validate that file “EPAM_Systems_Company_Overview.pdf” downloaded(use the name of the file as a parameter)
        Assert.That(files.DoesFileExist(filePath), Is.True, aboutPage.downloadFailed);

        //8.Close the browser.
        // Done through the Base test TearDown 
    }

    [TestCase(4)]
    [TestCase(3)]
    [TestCase(2)]
    [TestCase(1)]
    public void TestCarrouselArticles(int carouselIndex)
    {
        //1.Create a Chrome instance.
        //2.Navigate to https://www.epam.com/.
        // Done through the Base test SetUp 
        InsightsPage insightsPage = new(driver: driver);
        var files = new FilesHelper(vars.DownloadsPath);
        insightsPage.ClickAcceptCookies();

        //3.Select “Insights” from the top menu.
        insightsPage.NavigateToTabByText("Insights");

        //4.Swipe a carousel twice.
        insightsPage.SwipeCarousel("Right", carouselIndex);

        //5.Note the name of the article.
        var carouselTitle = insightsPage.GetCarouselTitle(); 

        //6.Click on the “Read More” button.
        insightsPage.ClickReadMoreFromActiveArticleInCarousel();

        //7.Validate that the name of the article matches with the noted above.
        var acticleTitle = insightsPage.GetArticlelTitle();
        Assert.That(acticleTitle, Is.EqualTo(carouselTitle), insightsPage.articleNotMatchinTitle);

        //8.Close the browser.
        // Done through the Base test TearDown 
    }
}


