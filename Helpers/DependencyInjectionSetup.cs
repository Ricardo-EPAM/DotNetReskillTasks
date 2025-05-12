using DotnetTaskSeleniumNunit.Helpers;
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
            return new LoggerConfiguration(configsManager.RunnerConfiguration);
        });

        services.AddSingleton<DriverFactory>();
        services.AddTransient<IWebDriver>(provider =>
        {
            var factory = provider.GetRequiredService<DriverFactory>();
            return factory.GetDriver();
        });

        return services.BuildServiceProvider();
    }
}
