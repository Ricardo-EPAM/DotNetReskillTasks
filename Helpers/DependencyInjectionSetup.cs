using DotnetTaskSeleniumNunit.Helpers;
using DotnetTaskSeleniumNunit.Models.Configurations;
using Microsoft.Extensions.DependencyInjection;
using OpenQA.Selenium;

public static class DependencyInjectionSetup
{
    public static ServiceProvider ConfigureServices()
    {
        var services = new ServiceCollection();

        services.AddSingleton(provider => new ConfigsManager());

        services.AddSingleton(provider =>
        {
            var configsManager = provider.GetRequiredService<ConfigsManager>();
            var runnerConfig = configsManager.RunnerConfiguration;
            return new LoggerConfiguration(runnerConfig);
        });

        services.AddTransient<DriverFactory>();

        return services.BuildServiceProvider();
    }
}