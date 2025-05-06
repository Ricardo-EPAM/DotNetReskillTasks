using DotnetTaskSeleniumNunit.Constants;
using log4net;
using OpenQA.Selenium;

namespace DotnetTaskSeleniumNunit.Pages.JobDetails;

internal partial class JobDetailsPage
{
    protected readonly IWebDriver _driver;
    protected readonly ILog _logger;
    protected readonly GlobalVariables _vars;

    public JobDetailsPage(IWebDriver? driver, ILog? logger, GlobalVariables variables)
    {
        ArgumentNullException.ThrowIfNull(driver);
        ArgumentNullException.ThrowIfNull(logger);
        ArgumentNullException.ThrowIfNull(variables);
        _driver = driver;
        _logger = logger;
        _vars = variables;
    }
}
