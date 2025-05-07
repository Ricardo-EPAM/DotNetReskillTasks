using DotnetTaskSeleniumNunit.Constants;
using OpenQA.Selenium.DevTools.V134.Page;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace DotnetTaskSeleniumNunit.Pages.Article;

internal partial class ArticlePage
{
    private string GetTitleFromArticle()
    {
        try
        {
            new WebDriverWait(_driver, _vars.ExplicitWaitDefault).
               Until(ExpectedConditions.ElementIsVisible(_artivcleTitle));
            return ArticleTitle.Text;
        }
        catch (Exception ex)
        {
            _logger.Error(_errorGetTitleFromArticle, ex);
            throw;
        }
    }
}
