using DotnetTaskSeleniumNunit.Models.Configurations;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;

namespace DotnetTaskSeleniumNunit.Helpers;

static class ScreenshotHelper
{
    public static string? TakesScreenshotIfFailed(IWebDriver? driver, OutputConfiguration configs, string testName)
    {
        ArgumentNullException.ThrowIfNull(driver);
        Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
        var subFolderName = DateTime.Now.ToString(configs.ScreenshotSubFolder);
        var fileName = DateTime.Now.ToString(configs.ScreenshotPrefix);
        var screenshotPath = Path.Combine(
            configs.ScreenshotsFolder ?? "Screenshots",
            subFolderName,
            testName.Replace("\"", ""));
        if (!Directory.Exists(screenshotPath))
        {
            Directory.CreateDirectory(screenshotPath);
        }
        string screenshotPathFromProject = $"{screenshotPath}/{fileName}.png";
        ss.SaveAsFile($"{TestContext.CurrentContext.TestDirectory}/{screenshotPathFromProject}");
        return screenshotPathFromProject;
    }
}
