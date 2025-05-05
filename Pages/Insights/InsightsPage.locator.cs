using ATA_Dotnet_Selenium_task.Pages.GlobalSearch;
using OpenQA.Selenium;

namespace ATA_Dotnet_Selenium_task.Pages.Insights;

internal partial class InsightsPage
{



//3.	Select “Insights” from the top menu.
//4.	Swipe a carousel twice.
//5.	Note the name of the article.
//6.	Click on the “Read More” button.
//7.	Validate that the name of the article matches with the noted above. 



    private readonly By _epamGlanceSection = By.XPath("//section[contains(normalize-space(.),'EPAM at a Glance')]");
    private readonly By _downloadButtonLink = By.XPath("//a[@download]");

    private IWebElement EPAMGlanceSection => _driver.FindElement(_epamGlanceSection);

    private IWebElement EPAMGlanceDownloadButton => _driver.FindElement(_downloadButtonLink);
}
