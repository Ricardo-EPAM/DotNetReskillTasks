using System.Reflection;
using DotnetTaskSeleniumNunit.Enums.Configurations;
using DotnetTaskSeleniumNunit.Models.Configurations;
using log4net;
using log4net.Config;
using log4net.Repository;

namespace DotnetTaskSeleniumNunit.Helpers;

public class LoggerConfiguration
{
    private readonly ILoggerRepository _logRepository;
    private readonly protected ILog _logger;

    public LoggerConfiguration(RunnerConfiguration configs)
    {
        ArgumentNullException.ThrowIfNull(configs);
        string path = configs.LoggerSettingsFile;
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

        SetGlobalLoggingLevel(configs.LoggerLevel);
    }

    public void SetGlobalLoggingLevel(LogLevels loggerLevel)
    {
        SetLoggerRepositoryThresholdLevel(loggerLevel);
        SetLoggerRepositoryAppendersThresholdLevel();
    }

    private void SetLoggerRepositoryThresholdLevel(LogLevels loggerLevel)
    {
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
    }

    private void SetLoggerRepositoryAppendersThresholdLevel()
    {
        foreach (var appender in _logRepository.GetAppenders())
        {
            if (appender is log4net.Appender.AppenderSkeleton appenderSkeleton)
            {
                appenderSkeleton.Threshold = _logRepository.Threshold;
            }
        }
    }

    public ILog GetLogger()
    {
        return _logger;
    }
}
