﻿using DotnetTaskSeleniumNunit.Enums.Configurations;

namespace DotnetTaskSeleniumNunit.Models.Configurations;

public class RunnerConfiguration
{
    public required string LoggerSettingsFile { get; set; }
    public LogLevels LoggerLevel { get; set; }

}
