using OpenQA.Selenium;

namespace DotnetTaskSeleniumNunit.Constants;
static class GlobalVariables
{
    public static TimeSpan ExplicitWaitShort = TimeSpan.FromSeconds(3);
    public static TimeSpan ExplicitWaitDefault = TimeSpan.FromSeconds(7);
    public static TimeSpan ExplicitWaitLong = TimeSpan.FromSeconds(14);
    public static TimeSpan ImplicitWaitTimeout = TimeSpan.FromSeconds(2);
    public static TimeSpan PageLoadTimeout = TimeSpan.FromSeconds(4);
    public static PageLoadStrategy PageLoadStrategy = PageLoadStrategy.Default;
    public static string BaseURL = "https://www.epam.com";
    public static bool IsHeadless = false;
    public static string DownloadsPath = "C:\\Users\\{username}\\Downloads";

}
