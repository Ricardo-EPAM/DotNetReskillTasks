using DotnetTaskSeleniumNunit.Helpers;

namespace DotnetTaskSeleniumNunit.Pages.Article;

internal partial class ArticlePage(POMDependency pomDependencies) : BasePage(pomDependencies)
{
    public string GetTitle()
    {
        return GetTitleFromArticle();
    }
}
