using OpenQA.Selenium;

namespace DotnetTaskSeleniumNunit.Pages.About;

internal partial class AboutPage
{
    private static By _epamGlanceSection = By.XPath("//section[contains(normalize-space(.),'EPAM at a Glance')]");
    private static By _downloadButtonLink = By.XPath("//a[@download]");

    private IWebElement EPAMGlanceSection => _driver.FindElement(_epamGlanceSection);

    private IWebElement EPAMGlanceDownloadButton => _driver.FindElement(_downloadButtonLink);
}
