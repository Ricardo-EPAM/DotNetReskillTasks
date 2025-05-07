using DotnetTaskSeleniumNunit.Constants;
using log4net;
using OpenQA.Selenium;

namespace DotnetTaskSeleniumNunit.Pages.Article;

internal partial class ArticlePage(POMDependencies pomDependencies) : BasePage(pomDependencies)
{
    public string GetTitle()
    {
        return GetTitleFromArticle();
    }
}
