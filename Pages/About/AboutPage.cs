using DotnetTaskSeleniumNunit.Constants;
using DotnetTaskSeleniumNunit.Pages.Navigation;
using log4net;
using OpenQA.Selenium;

namespace DotnetTaskSeleniumNunit.Pages.About;

internal partial class AboutPage

{
    protected readonly IWebDriver _driver;
    protected readonly ILog _logger;
    protected readonly GlobalVariables _vars;

    public AboutPage(IWebDriver? driver, ILog? logger, GlobalVariables variables)
    {
        ArgumentNullException.ThrowIfNull(driver);
        ArgumentNullException.ThrowIfNull(logger);
        ArgumentNullException.ThrowIfNull(variables);
        _driver = driver;
        _logger = logger;
        _vars = variables;
    }
}
