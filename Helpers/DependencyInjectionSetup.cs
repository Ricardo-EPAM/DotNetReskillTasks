using DotnetTaskSeleniumNunit.Helpers;
using log4net;
using Microsoft.Extensions.DependencyInjection;
using OpenQA.Selenium;
using Reqnroll.Microsoft.Extensions.DependencyInjection;

public class DependencyInjectionSetup
{
    [ScenarioDependencies]
    public static IServiceCollection ConfigureServices()
    {
        var services = new ServiceCollection();

        services.AddSingleton(provider => new ConfigsManager());

        services.AddSingleton(provider =>
        {
            var configsManager = provider.GetRequiredService<ConfigsManager>();
            return new LoggerConfiguration(configsManager.RunnerConfiguration).GetLogger();
        });

        services.AddSingleton<DriverFactory>();
        services.AddTransient<IWebDriver>(provider =>
        {
            var factory = provider.GetRequiredService<DriverFactory>();
            return factory.GetDriver();
        });

        return services;
    }
}
