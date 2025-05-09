using DotnetTaskSeleniumNunit.Constants;
using DotnetTaskSeleniumNunit.Helpers;
using log4net;
using OpenQA.Selenium;

namespace DotnetTaskSeleniumNunit.Pages.Article;

internal partial class ArticlePage(POMDependency pomDependencies) : BasePage(pomDependencies)
{
    public string GetTitle()
    {
        return GetTitleFromArticle();
    }
}
