using DotnetTaskSeleniumNunit.Pages.Article;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace DotnetTaskSeleniumNunit.Pages.Insights;

internal partial class InsightsPage
{
    private void SwipeCarouselWithDirection(string left_or_right)
    {
        var validOptions = new List<string>() { "left", "right" };
        if (!validOptions.Contains(left_or_right.ToLower()))
        {
            throw new ArgumentException(_errorValidOptions + validOptions);
        }
        if (left_or_right.ToLower() == "right")
        {
            SwipeCarouselRight();
        }
        else // left
        {
            SwipeCarouselLeft();
        }
    }

    private void SwipeCarouselLeft()
    {
        try
        {
            new WebDriverWait(_driver, _vars.ExplicitWaitDefault).
            Until(ExpectedConditions.ElementIsVisible(_swipeLeft));
            CarouselSwipeLeft.Click();
        }
        catch (Exception ex)
        {
            _logger.Error(_errorSwipeCarousel, ex);
            throw;
        }
    }

    private void SwipeCarouselRight()
    {
        try
        {
            new WebDriverWait(_driver, _vars.ExplicitWaitDefault).
                Until(ExpectedConditions.ElementIsVisible(_swipeRight));
            CarouselSwipeRight.Click();
        }
        catch (Exception ex)
        {
            _logger.Error(_errorSwipeCarousel, ex);
            throw;
        }
    }
    private void SwipeCarouselMultipleTimes(string left_or_right, int clicks)
    {
        for (var i = 0; i != clicks; i++)
        {
            SwipeCarouselWithDirection(left_or_right);
            // Wait for the carousel animation.
            Thread.Sleep(1000);
        }
    }

    private string GetCarouselElementTitle()
    {
        try
        {
            new WebDriverWait(_driver, _vars.ExplicitWaitDefault).
                Until(ExpectedConditions.ElementIsVisible(_carouselActiveElement));
            return CarouselTitle.Text.Trim();
        }
        catch (Exception ex)
        {
            _logger.Error(_errorGetCarouselTitle, ex);
            throw;
        }
    }

    private ArticlePage ClickReadMoreFromActiveArticleInCarousel()
    {
        try
        {
            new WebDriverWait(_driver, _vars.ExplicitWaitDefault).
           Until(ExpectedConditions.ElementToBeClickable(CarouselReadMoreLink));
            CarouselReadMoreLink.Click();
            return new ArticlePage(_driver, _logger, _vars);
        }
        catch (Exception ex)
        {
            _logger.Error(_errorReadMoreCarousel, ex);
            throw;
        }
    }
}
