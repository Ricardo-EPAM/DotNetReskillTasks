using DotnetTaskSeleniumNunit.Helpers;

namespace DotnetTaskSeleniumNunit.Pages.Navigation;

internal partial class NavigationBar(POMDependency pomDependencies) : BasePage(pomDependencies)
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
