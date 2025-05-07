using DotnetTaskSeleniumNunit.Constants;
using DotnetTaskSeleniumNunit.Pages.Article;
using log4net;
using OpenQA.Selenium;

namespace DotnetTaskSeleniumNunit.Pages.Insights;

internal partial class InsightsPage
{
    protected readonly IWebDriver _driver;
    protected readonly ILog _logger;
    protected readonly GlobalVariables _vars;

    public InsightsPage(IWebDriver? driver, ILog? logger, GlobalVariables variables)
    {
        ArgumentNullException.ThrowIfNull(driver);
        ArgumentNullException.ThrowIfNull(logger);
        ArgumentNullException.ThrowIfNull(variables);
        _driver = driver;
        _logger = logger;
        _vars = variables;
    }

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
