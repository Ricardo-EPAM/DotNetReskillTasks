using System.Configuration;
using DotnetTaskSeleniumNunit.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DotnetTaskSeleniumNunit.Models.Browsers;

class ChromeDriverManager : IDriverManager
{
    public IWebDriver CreateDriver(bool isHeadless)
    {
        var options = new ChromeOptions
        {
            PageLoadStrategy = PageLoadStrategy.Default
        };
        options.AddArgument("--no-sandbox");
        options.AddArgument("--disable-dev-shm-usage");

        if (isHeadless)
        {
            options.AddExcludedArgument("enable-automation");
            options.AddArgument("--headless=new");
            options.AddArgument("--disable-gpu");
            options.AddArgument("--disable-blink-features=AutomationControlled");
            options.AddArgument("--disable-dev-shm-usage");
            options.AddArgument("--no-sandbox");
            options.AddArgument("--disable-infobars");
            options.AddArgument("window-size=1920,1080");
            options.AddArgument("user-agent=Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/136.0.7103.49 Safari/537.36");
        }

        return new ChromeDriver(options);
    }
}
