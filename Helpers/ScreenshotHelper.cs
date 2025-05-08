using Microsoft.Extensions.Configuration;
using NUnit.Framework.Internal;
using OpenQA.Selenium;

namespace DotnetTaskSeleniumNunit.Helpers;

static class ScreenshotHelper
{
    public static string? TakesScreenshotIfFailed(IWebDriver driver, IConfiguration configs, TestContext context)
    {
        if (context.Result.Outcome.Status != NUnit.Framework.Interfaces.TestStatus.Failed)
        {
            return null;
        }
        Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
        var folderName = DateTime.Now.ToString(configs["ScreenshotDirectory"]);
        var fileName = DateTime.Now.ToString(configs["ScreenshotPrefix"]);
        var testName = context.Test.Name.Replace("\"", "");
        var screenshotPath = Path.Combine(
            configs["ScreenshotsFolder"] ?? "Screenshots",
            folderName,
            testName);
        if (!Directory.Exists(screenshotPath))
        {
            Directory.CreateDirectory(screenshotPath);
        }
        string screenshotPathFromProject = $"{screenshotPath}/{fileName}_{testName}.png";
        ss.SaveAsFile($"{TestContext.CurrentContext.TestDirectory}/{screenshotPathFromProject}");
        return screenshotPathFromProject;
    }
}
