using DotnetTaskSeleniumNunit.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace DotnetTaskSeleniumNunit.Models.Browsers;

class FirefoxDriverManager : IDriverManager
{
    public IWebDriver CreateDriver(bool isHeadless)
    {
        if (isHeadless)
            throw new NotImplementedException("Firefox headless mode is not implemented");
        return new FirefoxDriver();
    }
}
