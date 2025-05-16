using DotnetTaskSeleniumNunit.Helpers;
using DotnetTaskSeleniumNunit.Pages.Article;
using log4net;
using OpenQA.Selenium;
using Reqnroll;

namespace DotnetTaskSeleniumNunit.StepDefinitions;

[Binding]
public class ArticleSteps
{
    private readonly ArticlePage  _page;

    public ArticleSteps(IWebDriver driver, ConfigsManager configs, ILog logger)
    {
        _page = new ArticlePage (driver, configs, logger);
    }



}