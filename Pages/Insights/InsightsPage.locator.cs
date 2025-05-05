using ATA_Dotnet_Selenium_task.Pages.GlobalSearch;
using OpenQA.Selenium;

namespace ATA_Dotnet_Selenium_task.Pages.Insights;

internal partial class InsightsPage
{
    private readonly By _carouselActiveElement = By.CssSelector("div.media-content *.owl-item.active");
    private readonly By _swipeRight = By.XPath("//button[contains(@class, 'right')]");
    private readonly By _swipeLeft = By.XPath("//button[contains(@class, 'left')]");
    private readonly By _carouselTitle = By.CssSelector(".single-slide__content p");
    private readonly By _carouselLink = By.TagName("a");
    private readonly By _artivcleTitle = By.CssSelector("main p:first-of-type[style]");
    private readonly By _artivcleTitleV2 = By.CssSelector("div.content-container>div.section:first-of-type p[style]");

    private IWebElement CarouselActiveElement => _driver.FindElement(_carouselActiveElement);
    private IWebElement CarouselSwipeRight => CarouselActiveElement.FindElement(_swipeRight);
    private IWebElement CarouselSwipeLeft => CarouselActiveElement.FindElement(_swipeLeft);
    private IWebElement CarouselTitle => CarouselActiveElement.FindElement(_carouselTitle);
    private IWebElement CarouselReadMoreLink => CarouselActiveElement.FindElement(_carouselLink);
    private IWebElement ArticleTitle => _driver.FindElement(_artivcleTitle);
    private IWebElement ArticleTitleV2 => _driver.FindElement(_artivcleTitle);
}
