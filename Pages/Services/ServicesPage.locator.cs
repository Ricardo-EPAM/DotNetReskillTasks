using NUnit.Framework;
using System.ComponentModel.DataAnnotations;
using OpenQA.Selenium;
using OpenQA.Selenium.BiDi.Modules.BrowsingContext;

namespace DotnetTaskSeleniumNunit.Pages.About;

internal partial class ServicesPage
{
    private readonly By _LabelOurRelatedExpertise = By.XPath("//span[@class='museo-sans-light' and contains(text(),'Our Related Expertise')]");

    private IWebElement OurRelatedExpertiseLabel => _driver.FindElement(_LabelOurRelatedExpertise);
}
