using DotnetTaskSeleniumNunit.Constants;
using log4net;
using OpenQA.Selenium;

namespace DotnetTaskSeleniumNunit.Pages.Navigation;

internal partial class NavigationBar
{
    protected readonly IWebDriver _driver;
    protected readonly ILog _logger;
    protected readonly GlobalVariables _vars;

    public NavigationBar(IWebDriver? driver, ILog? logger, GlobalVariables variables)
    {
        ArgumentNullException.ThrowIfNull(driver);
        ArgumentNullException.ThrowIfNull(logger);
        ArgumentNullException.ThrowIfNull(variables);
        _driver = driver;
        _logger = logger;
        _vars = variables;
    }

    public void NavigateToCareersPage()
    {
        ClickTopLlinkByText("Careers");
    }

    public void AcceptCookies()
    {
        ClickAcceptCookies();
    }

}
