using DotnetTaskSeleniumNunit.Helpers;
using log4net;
using Reqnroll;
using RestSharp;

namespace DotnetTaskSeleniumNunit.Bindings;

[Binding]
public class APIHooks
{
    public IRestClient _restClient;

    [BeforeFeature("@API")]
    public static void BeforeFeature(FeatureContext featureContext, ILog logger)
    {
        logger.Info($"Initializing API feature: {featureContext.FeatureInfo.Title}");
    }

    [BeforeScenario("@API")]
    public void BeforeScenario(ScenarioContext scenarioContext, ILog logger, ConfigsManager configs)
    {
        logger.Info($"Setting up API test scenario: {scenarioContext.ScenarioInfo.Title}");

        _restClient = new RestClient(
            options: new() { BaseUrl = new(configs.AppConfiguration.APIBaseURL) });
        logger.Info($"Initialized Rest client for scenario: {scenarioContext.ScenarioInfo.Title}");
    }

    [AfterScenario("@API")]
    public void AfterFilesScenario(ScenarioContext scenarioContext, ILog logger)
    {
        logger.Info($"Initialized Rest client for scenario: {scenarioContext.ScenarioInfo.Title}");
        _restClient.Dispose();
    }
}