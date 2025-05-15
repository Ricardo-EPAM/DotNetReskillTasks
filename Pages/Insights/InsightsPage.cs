using DotnetTaskSeleniumNunit.Enums;
using DotnetTaskSeleniumNunit.Helpers;
using log4net;
using OpenQA.Selenium;

namespace DotnetTaskSeleniumNunit.Pages.Insights;

internal partial class InsightsPage(IWebDriver driver, ConfigsManager configs, ILog logger) : BasePage(driver, configs, logger)
{
    public void SwipeCarousel(SwipeDirection direction, int numberOfTimes = 1)
    {
        SwipeCarouselMultipleTimes(direction, numberOfTimes);
    }

    public string GetCarouselTitle()
    {
        return GetCarouselElementTitle();
    }

    public void ClickReadMoreFromCarousel()
    {
        ClickReadMoreFromActiveArticleInCarousel();
    }
}
