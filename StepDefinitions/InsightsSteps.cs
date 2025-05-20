using System.Text;
using DotnetTaskSeleniumNunit.Enums;
using DotnetTaskSeleniumNunit.Helpers;
using DotnetTaskSeleniumNunit.Pages.Article;
using DotnetTaskSeleniumNunit.Pages.Insights;
using log4net;
using OpenQA.Selenium;
using Reqnroll;

namespace DotnetTaskSeleniumNunit.StepDefinitions;

[Binding]
public class InsightsSteps
{
    private readonly InsightsPage _page;

    public InsightsSteps(IWebDriver driver, ConfigsManager configs, ILog logger)
    {
        _page = new InsightsPage(driver, configs, logger);
    }

    [Given("the user clicks on the right arrow from carousel {int} times")]
    public void UserSwipesCarousel(int numberOfClicks)
    {
        _page.SwipeCarousel(SwipeDirection.Right, numberOfClicks);
    }

    [Given("the user validates the carousel title is {string}")]
    public void ValidateCarouselTitle(string expectedTitle)
    {
        var carouselTitle = _page.GetCarouselTitle();
        Assert.That(carouselTitle, Is.EqualTo(expectedTitle.Normalize(NormalizationForm.FormC)));
    }

    [When("the user clicks on 'Read More' from the carousel active item")]
    public void UserClicksOnReadMoreButtonFromCarousel()
    {
        _page.ClickReadMoreFromCarousel();
    }
}