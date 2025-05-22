using DotnetTaskSeleniumNunit.Enums;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace DotnetTaskSeleniumNunit.Pages.Insights;

internal partial class InsightsPage
{
    private void SwipeCarouselWithDirection(SwipeDirection direction)
    {
        _logger.Debug($"Swapping Carousel to the {direction}");

        switch (direction)
        {
            case SwipeDirection.Right:
                SwipeCarouselRight();
                break;
            case SwipeDirection.Left:
                SwipeCarouselLeft();
                break;
        }
    }

    private void SwipeCarouselLeft()
    {
        try
        {
            var currentActive = CarouselActiveElement;
            new WebDriverWait(_driver, _configs.UIWaitsConfiguration.DefaultWait).
                Until(ExpectedConditions.ElementIsVisible(_swipeLeft));
            CarouselSwipeRight.Click();
            new WebDriverWait(_driver, _configs.UIWaitsConfiguration.DefaultWait)
                .Until(driver =>
                {
                    string currentClass = currentActive.GetAttribute("class") ?? "";
                    return !currentClass.Contains("active");
                });
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
            var currentActive = CarouselActiveElement;
            new WebDriverWait(_driver, _configs.UIWaitsConfiguration.DefaultWait).
                Until(ExpectedConditions.ElementIsVisible(_swipeRight));
            CarouselSwipeRight.Click();
            new WebDriverWait(_driver, _configs.UIWaitsConfiguration.DefaultWait)
                .Until(driver =>
            {
                string currentClass = currentActive.GetAttribute("class") ?? "";
                return !currentClass.Contains("active");
            });
        }
        catch (Exception ex)
        {
            _logger.Error(_errorSwipeCarousel, ex);
            throw;
        }
    }
    private void SwipeCarouselMultipleTimes(SwipeDirection direction, int clicks)
    {
        for (var i = 0; i != clicks; i++)
        {
            SwipeCarouselWithDirection(direction);
        }
    }

    private string GetCarouselElementTitle()
    {
        _logger.Debug($"Getting Carousel title");
        try
        {
            new WebDriverWait(_driver, _configs.UIWaitsConfiguration.DefaultWait).
                Until(ExpectedConditions.ElementIsVisible(_carouselActiveElement));
            var title = CarouselTitle.Text.Trim();
            return title;
        }
        catch (Exception ex)
        {
            _logger.Error(_errorGetCarouselTitle, ex);
            throw;
        }
    }

    private void ClickReadMoreFromActiveArticleInCarousel()
    {
        _logger.Debug($"Clicking Carousel button: 'Read More'");
        try
        {
            new WebDriverWait(_driver, _configs.UIWaitsConfiguration.DefaultWait).
                Until(ExpectedConditions.ElementToBeClickable(CarouselReadMoreLink));
            CarouselReadMoreLink.Click();
        }
        catch (Exception ex)
        {
            _logger.Error(_errorReadMoreCarousel, ex);
            throw;
        }
    }
}
