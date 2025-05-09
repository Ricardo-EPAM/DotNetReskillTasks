using DotnetTaskSeleniumNunit.Helpers;

namespace DotnetTaskSeleniumNunit.Pages.Insights;

internal partial class InsightsPage(POMDependencies pomDependencies) : BasePage(pomDependencies)
{
    public void SwipeCarousel(string left_or_right, int numberOfTimes = 1)
    {
        SwipeCarouselMultipleTimes(left_or_right, numberOfTimes);
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
