namespace DotnetTaskSeleniumNunit.Models.Configurations;

public class UIWaitsConfiguration
{
    public TimeSpan DefaultWait { get; set; }
    public TimeSpan LongWait { get; set; }
    public TimeSpan ShortWait { get; set; }
    public TimeSpan ImplicitWait { get; set; }

}
