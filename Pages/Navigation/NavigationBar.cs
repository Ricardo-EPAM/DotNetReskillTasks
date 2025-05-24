using DotnetTaskSeleniumNunit.Helpers;
using log4net;
using OpenQA.Selenium;

namespace DotnetTaskSeleniumNunit.Pages.Navigation;

internal partial class NavigationBar(IWebDriver driver, ConfigsManager configs, ILog logger) : BasePage(driver, configs, logger)
{
    public void NavigateToCareersPage()
    {
        ClickTopLlinkByText("Careers");
    }
    public void NavigateToInsightsPage()
    {
        ClickTopLlinkByText("Insights");
    }
    public void NavigateToAboutPage()
    {
        ClickTopLlinkByText("About");
    }

    public void AcceptCookies()
    {
        ClickAcceptCookies();
    }

    public void HoverServicesLinkAndClickByText(string link, string subItem)
    {
        HoverLink(link);
        ClickSubItemFromHoveredLink(subItem);
    }
}
