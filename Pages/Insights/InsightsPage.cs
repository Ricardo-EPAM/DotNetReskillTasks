using DotnetTaskSeleniumNunit.Enums;
using DotnetTaskSeleniumNunit.Helpers;

namespace DotnetTaskSeleniumNunit.Pages.Insights;

internal partial class InsightsPage(POMDependency pomDependencies) : BasePage(pomDependencies)
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
