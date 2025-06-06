using DotnetTaskSeleniumNunit.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace DotnetTaskSeleniumNunit.Models.Browsers;

class FirefoxDriverManager : IDriverManager
{
    public IWebDriver CreateDriver(bool isHeadless)
    {
        var options = new FirefoxOptions();
        options.SetPreference("dom.webdriver.enabled", false);
        options.SetPreference("useAutomationExtension", false);
        options.SetPreference("general.useragent.override", "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:106.0) Gecko/20100101 Firefox/106.0");

        if (isHeadless)
        {
            options.AddArgument("--headless");
            options.AddArgument("--disable-gpu");
            options.AddArgument("--width=1920");
            options.AddArgument("--height=1080");
        }

        var driver = new FirefoxDriver(options);
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
        return driver;
    }
}
