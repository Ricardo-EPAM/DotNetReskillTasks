using DotnetTaskSeleniumNunit.Constants;
using DotnetTaskSeleniumNunit.Pages.Article;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace DotnetTaskSeleniumNunit.Pages.Insights;

internal partial class InsightsPage
{
    internal void SwipeCarousel(string left_or_right)
    {
        var validOptions = new List<string>() { "left", "right" };
        if (!validOptions.Contains(left_or_right.ToLower()))
        {
            throw new ArgumentException($"Pease use one of the supported options: {validOptions}");
        }
        if (left_or_right.ToLower() == "right")
        {
            new WebDriverWait(_driver, _vars.ExplicitWaitDefault).
            Until(ExpectedConditions.ElementIsVisible(_swipeRight));
            CarouselSwipeRight.Click();
        }
        else // left
        {
            new WebDriverWait(_driver, _vars.ExplicitWaitDefault).
            Until(ExpectedConditions.ElementIsVisible(_swipeLeft));
            CarouselSwipeLeft.Click();
        }
    }
    internal void SwipeCarousel(string left_or_right, int clicks)
    {
        // For test DataDriven.
        for (var i = 0; i != clicks; i++)
        {
            SwipeCarousel(left_or_right);
            // Wait for the carousel animation.
            Thread.Sleep(1000);
        }
    }

    //5.	Note the name of the article.
    internal string GetCarouselTitle()
    {
        new WebDriverWait(_driver, _vars.ExplicitWaitDefault).
            Until(ExpectedConditions.ElementIsVisible(_carouselActiveElement));
        return CarouselTitle.Text.Trim();
    }

    //6.	Click on the “Read More” button. ClickReadMoreFromActiveArticleInCarousel
    internal ArticlePage ClickReadMoreFromActiveArticleInCarousel()
    {
        new WebDriverWait(_driver, _vars.ExplicitWaitDefault).
            Until(ExpectedConditions.ElementToBeClickable(CarouselReadMoreLink));
        CarouselReadMoreLink.Click();
        return new ArticlePage(_driver, _logger, _vars);
    }
}
