using DotnetTaskSeleniumNunit.Models.Configurations;
using log4net;
using OpenQA.Selenium;

namespace DotnetTaskSeleniumNunit.Helpers;

static class ScreenshotHelper
{
    /// <summary>
    /// Captures a screenshot and saves it to a specified directory.
    /// </summary>
    /// <param name="driver">The Selenium WebDriver instance used to take the screenshot. Cannot be null.</param>
    /// <param name="logger">The logger instance used for error reporting.</param>
    /// <param name="configs">The configuration object from appsettings.json.</param>
    /// <param name="testName">The name of the current test. Used for naming the screenshot file.</param>
    /// <returns>
    /// The relative file path of the saved screenshot, or null if an error occurs during the save operation.
    /// </returns>
    /// <exception cref="DirectoryNotFoundException">Thrown if the specified directory cannot be created or accessed.</exception>
    /// <exception cref="IOException">Thrown if an error occurs during file handling (e.g., saving the screenshot).</exception>
    public static string TakesScreenshotIfFailed(IWebDriver driver, ILog logger, OutputConfiguration configs, string testName)
    {
        Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
        var subFolderName = DateTime.Now.ToString(configs.ScreenshotSubFolder);
        var fileName = DateTime.Now.ToString(configs.ScreenshotPrefix);
        var screenshotPath = Path.Combine(
            configs.ScreenshotsFolder ?? "Screenshots",
            subFolderName,
            testName.Replace("\"", ""));

        try
        {
            if (!Directory.Exists(screenshotPath))
            {
                Directory.CreateDirectory(screenshotPath);
            }
        }
        catch (Exception ex)
        {
            logger.Error($"Failed to create directories for screenshots '{screenshotPath}'", ex);
            throw;
        }

        try
        {
            string screenshotPathFromProject = $"{screenshotPath}/{fileName}.png";
            ss.SaveAsFile($"{TestContext.CurrentContext.TestDirectory}/{screenshotPathFromProject}");
            return screenshotPathFromProject;
        }
        catch (IOException ex)
        {
            logger.Error($"An I/O error occurred while saving the screenshot to path '{screenshotPath}'", ex);
            throw;
        }
        catch (UnauthorizedAccessException ex)
        {
            logger.Error($"Permission denied while saving screenshot to path '{screenshotPath}'", ex);
            throw;
        }
        catch (Exception ex)
        {
            logger.Error($"An unexpected error occurred while saving the screenshot '{screenshotPath}'", ex);
            throw;
        }
    }
}
