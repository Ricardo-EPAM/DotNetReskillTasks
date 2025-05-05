using ATA_Dotnet_Selenium_task.Constants;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace ATA_Dotnet_Selenium_task.Pages.Insights;

internal partial class InsightsPage
{

    internal void SwipeCarrousel(string left_or_right)
    {
        var validOptions = new List<string>() { "left", "right" };
        if (!validOptions.Contains(left_or_right.ToLower()))
        {
            throw new ArgumentException($"Pease use one of the supported options: {validOptions}");
        }
        if (left_or_right.ToLower() == "right")
        {

        }
        else // left
        {

        }
    }

    //5.	Note the name of the article.
    internal string GetCarouselTitle()
    {
        new WebDriverWait(_driver, GlobalVariables.ExplicitWaitLong).
            Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(_downloadButtonLink));
        EPAMGlanceDownloadButton.Click();
    }

    //6.	Click on the “Read More” button. ClickReadMoreFromActiveArticleInCarousel
    internal void ClickReadMoreFromActiveArticleInCarousel()
    {
        new WebDriverWait(_driver, GlobalVariables.ExplicitWaitLong).
            Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(_downloadButtonLink));
        EPAMGlanceDownloadButton.Click();
    }

    //7.	Validate that the name of the article matches with the noted above.  GetArticlelTitle
    internal string GetArticlelTitle()
    {
        new WebDriverWait(_driver, GlobalVariables.ExplicitWaitLong).
            Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(_downloadButtonLink));
        EPAMGlanceDownloadButton.Click();
    }
}
