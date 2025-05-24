using DotnetTaskSeleniumNunit.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

namespace DotnetTaskSeleniumNunit.Models.Browsers;

class EdgeDriverManager : IDriverManager
{
    public IWebDriver CreateDriver(bool isHeadless)
    {
        var options = new EdgeOptions();
        options.AddArgument("--disable-blink-features=AutomationControlled");
        options.AddArgument("window-size=1920,1080");
        options.AddExcludedArgument("enable-automation");
        options.AddAdditionalOption("useAutomationExtension", false);
        options.AddArgument("user-agent=Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/136.0.7103.49 Safari/537.36");

        if (isHeadless)
        {
            options.AddArgument("--headless=new");
            options.AddArgument("--disable-gpu");
            options.AddArgument("--no-sandbox");
            options.AddArgument("--disable-infobars");
        }

        var driver = new EdgeDriver(options);
        return driver;
    }
}
