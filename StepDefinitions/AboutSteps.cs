using DotnetTaskSeleniumNunit.Enums;
using DotnetTaskSeleniumNunit.Helpers;
using DotnetTaskSeleniumNunit.Pages.About;
using DotnetTaskSeleniumNunit.Pages.Article;
using log4net;
using OpenQA.Selenium;
using Reqnroll;

namespace DotnetTaskSeleniumNunit.StepDefinitions;

[Binding]
public class AboutSteps
{
    private readonly AboutPage  _page;
    private readonly FilesHelper  _files;

    public AboutSteps(IWebDriver driver, ConfigsManager configs, ILog logger)
    {
        _page = new AboutPage(driver, configs, logger);
        _files = new FilesHelper(SpecialFolders.Downloads, logger);
    }

    [Given("the user scrolls to the 'EPAM At A Glance' Section")]
    public void GivenTheUserNavigatesToTheAboutPage()
    {
        _page.ScrollToEPAMAtAGlanceSection();
    }

    [When("the user clicks on the download button from 'EPAM At A Glance' Section")]
    public void UserClicksOnDownloadButton()
    {
        _page.DownloadEPAMAtAGlanceDocument();
    }

    [Then("the file {string} is downloaded")]
    public void ValidateFileIsDownloaded(string fileName)
    {
        Assert.That(_files.DoesFileExist(fileName), Is.True, "File was not downloaded");
        _files.DeleteFile(fileName);
    }
}