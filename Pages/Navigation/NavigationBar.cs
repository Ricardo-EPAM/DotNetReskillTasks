using DotnetTaskSeleniumNunit.Constants;
using log4net;
using OpenQA.Selenium;

namespace DotnetTaskSeleniumNunit.Pages.Navigation;

internal partial class NavigationBar(POMDependencies pomDependencies) : BasePage(pomDependencies)
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
}
