using NUnit.Framework;
using System.ComponentModel.DataAnnotations;
using OpenQA.Selenium;
using OpenQA.Selenium.BiDi.Modules.BrowsingContext;

namespace DotnetTaskSeleniumNunit.Pages.About;

internal partial class ServicesPage
{
    private readonly By _downloadButtonLink = By.XPath("//a[@download]");

    2.	Locate and click on the "Services" link in the main navigation menu.
3.	From the dropdown, select a specific service category: “Generative AI” or “Responsible AI” (parameterize the category selection).
4.	Validate that the page contains the correct title.
5.	Validate that the section ‘Our Related Expertise’ is displayed on the page

    private IWebElement EPAMGlanceDownloadButton => _driver.FindElement(_downloadButtonLink);
}
