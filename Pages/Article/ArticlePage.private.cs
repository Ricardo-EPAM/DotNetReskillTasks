using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace DotnetTaskSeleniumNunit.Pages.Article;

internal partial class ArticlePage
{
    private string GetTitleFromArticle()
    {
        _logger.Debug("Getting Article main header text");
        try
        {
            new WebDriverWait(_driver, _configs.UIWaitsConfiguration.DefaultWait).
                Until(ExpectedConditions.ElementIsVisible(_articleTitle));
            return ArticleTitle.Text;
        }
        catch (Exception ex)
        {
            _logger.Error(_errorGetTitleFromArticle, ex);
            throw;
        }
    }
}
