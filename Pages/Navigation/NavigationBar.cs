using OpenQA.Selenium;

namespace DotnetTaskSeleniumNunit.Pages.Navigation;

internal partial class NavigationBar
{
    protected readonly IWebDriver _driver;

    public NavigationBar(IWebDriver? driver)
    {
        ArgumentNullException.ThrowIfNull(driver);
        _driver = driver;
    }

    public void NavigateToTabByText(string tabName)
    {
        ClickTopLlinkByText(tabName);
    }

}
