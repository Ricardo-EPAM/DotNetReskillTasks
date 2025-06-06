using DotnetTaskSeleniumNunit.Enums;
using DotnetTaskSeleniumNunit.Helpers;
using log4net;
using OpenQA.Selenium;
using Reqnroll;

namespace DotnetTaskSeleniumNunit.Bindings;

[Binding]
public class GlobalHooks
{
    [BeforeFeature]
    public static void BeforeFeature(FeatureContext featureContext, ILog logger)
    {
        logger.Info($"Initializing feature: {featureContext.FeatureInfo.Title}");
    }

    [BeforeScenario]
    public void BeforeScenario(ScenarioContext scenarioContext, ILog logger, IWebDriver driver, ConfigsManager configs)
    {
        logger.Info($"Setting up test scenario: {scenarioContext.ScenarioInfo.Title}");
        driver.Manage().Window.Maximize();
        logger.Info($"Initialized web driver for scenario: {scenarioContext.ScenarioInfo.Title}");
    }

    [AfterScenario(Order = 1)]
    public void AfterScenario(ScenarioContext scenarioContext, ILog logger, IWebDriver driver, ConfigsManager configs)
    {
        if (scenarioContext.ScenarioExecutionStatus == ScenarioExecutionStatus.TestError)
        {
            var screenshotFileName = ScreenshotHelper.TakesScreenshotIfFailed(
                driver,
                logger,
                configs.OutputConfiguration,
                scenarioContext.ScenarioInfo.Title
            );
            logger.Error($"Failed scenario screenshot was saved in: {screenshotFileName}");
        }

        driver.Dispose();
        logger.Info($"Scenario finalized: {scenarioContext.ScenarioInfo.Title}");
    }

    [AfterScenario("@Files", Order = 0)]
    public void AfterFilesScenario(ScenarioContext scenarioContext, ILog logger)
    {
        if (scenarioContext.ScenarioInfo.Tags.Contains("RequiresDirectoryCleanUp"))
        {
            var files = new FilesHelper(SpecialFolders.Downloads, logger);
            ArgumentNullException.ThrowIfNull(scenarioContext.ScenarioInfo.Arguments);
            string fileName = scenarioContext.ScenarioInfo.Arguments["filename"]?.ToString() ?? "";
            files.DeleteFile(fileName);
        }
    }
}