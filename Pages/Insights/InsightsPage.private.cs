using ATA_Dotnet_Selenium_task.Constants;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace ATA_Dotnet_Selenium_task.Pages.Insights;

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
            new WebDriverWait(_driver, GlobalVariables.ExplicitWaitDefault).
            Until(ExpectedConditions.ElementIsVisible(_swipeRight));
            CarouselSwipeRight.Click();
        }
        else // left
        {
            new WebDriverWait(_driver, GlobalVariables.ExplicitWaitDefault).
            Until(ExpectedConditions.ElementIsVisible(_swipeLeft));
            CarouselSwipeLeft.Click();
        }
    }
    internal void SwipeCarousel(string left_or_right, int clicks)
    {
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
        new WebDriverWait(_driver, GlobalVariables.ExplicitWaitDefault).
            Until(ExpectedConditions.ElementIsVisible(_carouselActiveElement));
        return CarouselTitle.Text.Trim();
    }

    //6.	Click on the “Read More” button. ClickReadMoreFromActiveArticleInCarousel
    internal void ClickReadMoreFromActiveArticleInCarousel()
    {
        new WebDriverWait(_driver, GlobalVariables.ExplicitWaitDefault).
            Until(ExpectedConditions.ElementToBeClickable(CarouselReadMoreLink));
        CarouselReadMoreLink.Click();
    }

    //7.	Validate that the name of the article matches with the noted above.  GetArticlelTitle
    internal string GetArticlelTitle()
    {
        try // EPAM Continum, etc.
        {
            new WebDriverWait(_driver, GlobalVariables.ExplicitWaitDefault).
               Until(ExpectedConditions.ElementIsVisible(_artivcleTitle));
            return ArticleTitle.Text;
        }
        catch (Exception) // AI Report, etc.
        {
            new WebDriverWait(_driver, GlobalVariables.ExplicitWaitDefault).
          Until(ExpectedConditions.ElementIsVisible(_artivcleTitleV2));
            return ArticleTitleV2.Text.Trim();
        }
    }
}
