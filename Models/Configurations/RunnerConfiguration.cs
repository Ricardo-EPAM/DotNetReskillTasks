using DotnetTaskSeleniumNunit.Enums.Configurations;

namespace DotnetTaskSeleniumNunit.Models.Configurations;

public class RunnerConfiguration
{
    public bool HeadLess { get; set; }
    public string? LoggerSettingsFile { get; set; }
    public LogLevels LoggerLevel { get; set; }

}
