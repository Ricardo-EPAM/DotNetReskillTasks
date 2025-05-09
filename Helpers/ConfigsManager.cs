using DotnetTaskSeleniumNunit.Models.Configurations;
using Microsoft.Extensions.Configuration;

namespace DotnetTaskSeleniumNunit.Helpers;

public class ConfigsManager
{
    public AppConfiguration AppConfiguration { get; }
    public OutputConfiguration OutputConfiguration { get; }
    public RunnerConfiguration RunnerConfiguration { get; }
    public UIWaitsConfiguration UIWaitsConfiguration { get; }

    private readonly IConfiguration _configuration;

    public ConfigsManager(string settingsFile = "appsettings.json")
    {
        _configuration = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile(settingsFile, optional: false, reloadOnChange: true)
                .Build();

        AppConfiguration = GetRequiredSection<AppConfiguration>("AppConfiguration");
        OutputConfiguration = GetRequiredSection<OutputConfiguration>("OutputConfiguration");
        RunnerConfiguration = GetRequiredSection<RunnerConfiguration>("RunnerConfiguration");
        UIWaitsConfiguration = GetRequiredSection<UIWaitsConfiguration>("UIWaitsConfiguration");
    }

    private T GetRequiredSection<T>(string sectionName) where T : class
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(sectionName);

        var section = _configuration.GetSection(sectionName).Get<T>();

        if (Equals(section, default(T)) || section is null)
        {
            throw new ArgumentException($"Section {sectionName} not found in _configuration file.");
        }

        return section;
    }

}
