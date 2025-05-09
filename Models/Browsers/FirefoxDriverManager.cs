using DotnetTaskSeleniumNunit.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace DotnetTaskSeleniumNunit.Models.Browsers;

class FirefoxDriverManager : IDriverManager
{
    public IWebDriver CreateDriver(bool isHeadless)
    {
        var options = new FirefoxOptions();
        if (isHeadless)
        {
            options.AddArgument("-headless");
        }

        return new FirefoxDriver(options);
    }
}
