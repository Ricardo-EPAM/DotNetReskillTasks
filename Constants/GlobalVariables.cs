using OpenQA.Selenium;

namespace DotnetTaskSeleniumNunit.Constants;
public class GlobalVariables
{
    public TimeSpan ExplicitWaitShort = TimeSpan.FromSeconds(3);
    public TimeSpan ExplicitWaitDefault = TimeSpan.FromSeconds(7);
    public TimeSpan ExplicitWaitLong = TimeSpan.FromSeconds(14);
    public TimeSpan ImplicitWaitTimeout = TimeSpan.FromSeconds(2);
    public TimeSpan PageLoadTimeout = TimeSpan.FromSeconds(4);
    public PageLoadStrategy PageLoadStrategy = PageLoadStrategy.Default;
    public bool IsHeadless = false;
}
