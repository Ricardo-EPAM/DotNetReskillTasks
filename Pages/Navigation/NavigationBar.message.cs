using System.Collections.ObjectModel;
using OpenQA.Selenium;

namespace DotnetTaskSeleniumNunit.Pages.Navigation;

internal partial class NavigationBar
{
    private readonly string _errorClickingTopLink = "Error trying to search and click the link from top bar";
    private readonly string _infoCookiesSkipped = "No Cookies prompt found, skipping";
}
