using System.Reflection;
using DotnetTaskSeleniumNunit.Enums;
using DotnetTaskSeleniumNunit.Models.Configurations;
using log4net;
using log4net.Config;
using log4net.Repository;
using Microsoft.Extensions.Configuration;

namespace DotnetTaskSeleniumNunit.Helpers;

public class LoggerConfiguration
{
    private ILoggerRepository? _logRepository;
    private protected ILog? _logger { get; private set; }

    public LoggerConfiguration(RunnerConfiguration configs)
    {
        string? path = configs.LoggerSettingsFile;
        if (string.IsNullOrEmpty(path))
        {
            throw new ArgumentNullException("Please provide a appsettings.json file path");
        }
        var entryAssembly = Assembly.GetEntryAssembly();
        var currentMethod = MethodBase.GetCurrentMethod();
        ArgumentNullException.ThrowIfNull(entryAssembly);
        ArgumentNullException.ThrowIfNull(currentMethod);
        ArgumentNullException.ThrowIfNull(currentMethod.DeclaringType);

        _logger = LogManager.GetLogger("GlobalLogger");
        _logRepository = LogManager.GetRepository(entryAssembly);
        XmlConfigurator.Configure(_logRepository, new FileInfo(path));

        SetLoggingLevel(configs.LoggerLevel);
    }
    public void SetLoggingLevel(LogLevels loggerLevel)
    {
        ArgumentNullException.ThrowIfNull(_logRepository);

        var level = log4net.Core.Level.Debug;
        level = loggerLevel switch
        {
            LogLevels.Debug => log4net.Core.Level.Debug,
            LogLevels.Info => log4net.Core.Level.Info,
            LogLevels.Warn => log4net.Core.Level.Warn,
            LogLevels.Fatal => log4net.Core.Level.Fatal,
            LogLevels.Error => log4net.Core.Level.Error,
            LogLevels.Off => log4net.Core.Level.Off,
            LogLevels.All => log4net.Core.Level.All,
            _ => throw new ArgumentException($"Invalid logger level '{loggerLevel}'"),
        };
        _logRepository.Threshold = level;
        foreach (var appender in _logRepository.GetAppenders())
        {
            if (appender is log4net.Appender.AppenderSkeleton appenderSkeleton)
            {
                appenderSkeleton.Threshold = level;
            }
        }
    }
    public ILog GetLogger()
    {
        ArgumentNullException.ThrowIfNull(_logger);
        return _logger;
    }
}
