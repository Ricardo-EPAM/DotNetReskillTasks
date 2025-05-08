using Microsoft.Extensions.Configuration;
using NUnit.Framework.Internal;
using OpenQA.Selenium;

namespace DotnetTaskSeleniumNunit.Helpers;

static class ScreenshotHelper
{
    public static string? TakesScreenshotIfFailed(IWebDriver driver, IConfiguration configs)
    {
        Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
        var folderName = DateTime.Now.ToString(configs["ScreenshotDirectory"]);
        var fileName = DateTime.Now.ToString(configs["ScreenshotPrefix"]);
        var screenshotPath = Path.Combine(
            configs["ScreenshotsFolder"] ?? "Screenshots",
            folderName);
        if (!Directory.Exists(screenshotPath))
        {
            Directory.CreateDirectory(screenshotPath);
        }
        string screenshotPathFromProject = $"{screenshotPath}/{fileName}.png";
        ss.SaveAsFile($"{TestContext.CurrentContext.TestDirectory}/{screenshotPathFromProject}");
        return screenshotPathFromProject;
    }
}
