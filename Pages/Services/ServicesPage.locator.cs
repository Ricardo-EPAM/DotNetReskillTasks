using NUnit.Framework;
using System.ComponentModel.DataAnnotations;
using OpenQA.Selenium;

namespace DotnetTaskSeleniumNunit.Pages.About;

internal partial class ServicesPage
{
    private readonly By _labelOurRelatedExpertise = By.XPath("//span[@class='museo-sans-light' and contains(text(),'Our Related Expertise')]");

    private IWebElement OurRelatedExpertiseLabel => _driver.FindElement(_labelOurRelatedExpertise);
}
