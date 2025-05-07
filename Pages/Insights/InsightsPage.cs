using DotnetTaskSeleniumNunit.Constants;
using DotnetTaskSeleniumNunit.Pages.Article;
using log4net;
using OpenQA.Selenium;

namespace DotnetTaskSeleniumNunit.Pages.Insights;

internal partial class InsightsPage(IWebDriver? driver,
                   ILog? logger,
                   GlobalVariables variables) : BasePage(driver, logger, variables)

    public void SwipeCarousel(string left_or_right, int numberOfTimes = 1)
    {
        SwipeCarouselMultipleTimes(left_or_right, numberOfTimes);
    }


    public string GetCarouselTitle()
    {
        return GetCarouselElementTitle();
    }

    public ArticlePage ClickReadMoreFromCarousel()
    {
        return ClickReadMoreFromActiveArticleInCarousel();
    }
}
