using DotnetTaskSeleniumNunit.Helpers;
using Microsoft.Extensions.DependencyInjection;
using OpenQA.Selenium;
using Reqnroll.Microsoft.Extensions.DependencyInjection;

public class DependencyInjectionSetup
{
    [ScenarioDependencies]
    public static IServiceCollection ConfigureFeatureServices()
    {
        var services = new ServiceCollection();

        services.AddSingleton(provider => new ConfigsManager());
        services.AddSingleton(provider =>
        {
            var configsManager = provider.GetRequiredService<ConfigsManager>();
            return new LoggerConfiguration(configsManager.RunnerConfiguration).GetLogger();
        });

        services.AddSingleton<DriverFactory>();
        services.AddScoped<IWebDriver>(provider =>
        {
            var factory = provider.GetRequiredService<DriverFactory>();
            return factory.GetDriver();
        });

        return services;
    }
}
