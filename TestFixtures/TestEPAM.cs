
using DotnetTaskSeleniumNunit.Pages.Insights;
using DotnetTaskSeleniumNunit.Pages.About;
using DotnetTaskSeleniumNunit.Pages.Careers;
using DotnetTaskSeleniumNunit.Pages.Article;
using DotnetTaskSeleniumNunit.Pages.GlobalSearch;
using DotnetTaskSeleniumNunit.Pages.JobDetails;
using DotnetTaskSeleniumNunit.Constants;
using DotnetTaskSeleniumNunit.Helpers;

using NUnit.Framework.Internal;
using OpenQA.Selenium;
namespace DotnetTaskSeleniumNunit.TestFixtures;


[TestFixture]
public class TestEPAM : BaseTest
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
        JobDetailsPage jobDetails = careersSearchPage.ClickApplyAndViewFromSection(section: jobSection);

        // 9.Validate that the programming language mentioned in the step above is on a page
        string jobDescription = jobDetails.GetJobDescription();
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
        var links = globalSearchPage.GetAllLinksFromSearchResults();
        // GetAllLinksFromSearchResults() method uses LINQ, for assertion is better to use Assert.Multiple instead of:
        // Assert.That(links.All(x => x.Contains(searchCriteria)), globalSearchPage.invalidGlobalSearchResult);
        Assert.Multiple(() =>
        {
            foreach (var link in links)
            {
                if (link != null)
                {
                    Assert.That(link.ToLower(), Does.Contain(searchCriteria.ToLower()), globalSearchPage.invalidGlobalSearchResult);
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
        var files = new FilesHelper();

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

    [TestCase(1)]
    [TestCase(2)]
    [TestCase(3)]
    [TestCase(4)]
    public void TestCarrouselArticles(int carouselIndex)
    {
        //1.Create a Chrome instance.
        //2.Navigate to https://www.epam.com/.
        // Done through the Base test SetUp 
        InsightsPage insightsPage = new(driver: driver);
        insightsPage.ClickAcceptCookies();

        //3.Select “Insights” from the top menu.
        insightsPage.NavigateToTabByText("Insights");

        //4.Swipe a carousel twice.
        insightsPage.SwipeCarousel("Right", carouselIndex);

        //5.Note the name of the article.
        var carouselTitle = insightsPage.GetCarouselTitle(); 

        //6.Click on the “Read More” button.
        ArticlePage articlePage = insightsPage.ClickReadMoreFromActiveArticleInCarousel();

        //7.Validate that the name of the article matches with the noted above.
        var acticleTitle = articlePage.GetArticlelTitle();
        Assert.That(acticleTitle, Is.EqualTo(carouselTitle), insightsPage.articleNotMatchinTitle);

        //8.Close the browser.
        // Done through the Base test TearDown 
    }
}


