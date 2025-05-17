using DotnetTaskSeleniumNunit.Helpers;

namespace DotnetTaskSeleniumNunit.Pages.About;

internal partial class AboutPage(POMDependency pomDependencies) : BasePage(pomDependencies)
{
    public void ScrollToEPAMAtAGlanceSection()
    {
        ScrollToEPAMGlanceSection();
    }
    public void DownloadEPAMAtAGlanceDocument()
    {
        DownloadEPAMGlance();
    }
}
