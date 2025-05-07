using OpenQA.Selenium;

namespace DotnetTaskSeleniumNunit.Pages.About;

internal partial class BasePage
{
    private readonly By _epamGlanceSection = By.XPath("//section[contains(normalize-space(.),'EPAM at a Glance')]");
    private readonly By _downloadButtonLink = By.XPath("//a[@download]");

    private IWebElement EPAMGlanceSection => _driver.FindElement(_epamGlanceSection);

    private IWebElement EPAMGlanceDownloadButton => _driver.FindElement(_downloadButtonLink);
}
