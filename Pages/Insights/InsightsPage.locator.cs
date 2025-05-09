using DotnetTaskSeleniumNunit.Pages.GlobalSearch;
using OpenQA.Selenium;

namespace DotnetTaskSeleniumNunit.Pages.Insights;

internal partial class InsightsPage
{
    private readonly By _carouselActiveElement = By.CssSelector("div.media-content *.owl-item.active");
    private readonly By _swipeRight = By.XPath("//button[contains(@class, 'right')]");
    private readonly By _swipeLeft = By.XPath("//button[contains(@class, 'left')]");
    private readonly By _carouselTitle = By.CssSelector(".single-slide__content p");
    private readonly By _carouselLink = By.TagName("a");
    

    private IWebElement CarouselActiveElement => _driver.FindElement(_carouselActiveElement);
    private IWebElement CarouselSwipeRight => CarouselActiveElement.FindElement(_swipeRight);
    private IWebElement CarouselSwipeLeft => CarouselActiveElement.FindElement(_swipeLeft);
    private IWebElement CarouselTitle => CarouselActiveElement.FindElement(_carouselTitle);
    private IWebElement CarouselReadMoreLink => CarouselActiveElement.FindElement(_carouselLink);

}
