using System.Reflection.Metadata;
using DotnetTaskSeleniumNunit.Constants;
using log4net;
using OpenQA.Selenium;

namespace DotnetTaskSeleniumNunit.Pages.Article;

internal partial class ArticlePage : BasePage
{
    public ArticlePage(IWebDriver? driver,
                       ILog? logger,
                       GlobalVariables variables) : base(driver, logger, variables)
    {

    }
    public string GetTitle()
    {
        return GetTitleFromArticle();
    }
}
