using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace ATA_Dotnet_Selenium_task.Pages.Navigation;

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
