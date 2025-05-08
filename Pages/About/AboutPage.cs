using DotnetTaskSeleniumNunit.Helpers;

namespace DotnetTaskSeleniumNunit.Pages.About;

internal partial class AboutPage(POMDependencies pomDependencies) : BasePage(pomDependencies)
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
