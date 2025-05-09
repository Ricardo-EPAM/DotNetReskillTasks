using DotnetTaskSeleniumNunit.Enums.Configurations;

namespace DotnetTaskSeleniumNunit.Models.Configurations;

public class AppConfiguration
{
    public string? BaseURL { get; set; }
    public bool Headless { get; set; }

    public BrowserType Browser { get; set; }
}
