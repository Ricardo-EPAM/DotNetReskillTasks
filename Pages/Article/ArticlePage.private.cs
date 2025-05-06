using DotnetTaskSeleniumNunit.Constants;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace DotnetTaskSeleniumNunit.Pages.Article;

internal partial class ArticlePage
{
    internal string GetArticlelTitle()
    {
        try // EPAM Continum, etc.
        {
            new WebDriverWait(_driver, _vars.ExplicitWaitDefault).
               Until(ExpectedConditions.ElementIsVisible(_artivcleTitle));
            return ArticleTitle.Text;
        }
        catch (Exception) // AI Report, etc.
        {
            new WebDriverWait(_driver, _vars.ExplicitWaitDefault).
          Until(ExpectedConditions.ElementIsVisible(_artivcleTitleV2));
            return ArticleTitleV2.Text.Trim();
        }
    }
}
