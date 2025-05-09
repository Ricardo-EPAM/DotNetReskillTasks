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
            return configsManager.RunnerConfiguration;
        });

        services.AddSingleton(provider =>
        {
            var runnerConfigs = provider.GetRequiredService<RunnerConfiguration>();
            return new LoggerConfiguration(runnerConfigs);
        });

        services.AddSingleton(provider =>
        {
            var loggerConfiguration = provider.GetRequiredService<LoggerConfiguration>();
            return loggerConfiguration.GetLogger();
        });

        services.AddSingleton<DriverFactory>();

        services.AddTransient<IWebDriver>(provider =>
        {
            var driverFactory = provider.GetRequiredService<DriverFactory>();
            return driverFactory.GetDriver();
        });

        return services.BuildServiceProvider();
    }
}