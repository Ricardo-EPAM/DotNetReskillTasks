using DotnetTaskSeleniumNunit.Helpers;
using log4net;
using OpenQA.Selenium;

namespace DotnetTaskSeleniumNunit.Pages.Article;

internal partial class ArticlePage(IWebDriver driver, ConfigsManager configs, ILog logger) : BasePage(driver, configs, logger)
{
    public string GetTitle()
    {
        return GetTitleFromArticle();
    }
}
