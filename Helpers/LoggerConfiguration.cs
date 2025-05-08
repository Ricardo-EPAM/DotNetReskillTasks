using System.Reflection;
using log4net.Config;
using log4net;
using log4net.Repository;
using Microsoft.Extensions.Configuration;

namespace DotnetTaskSeleniumNunit.Helpers;

public class LoggerConfiguration
{
    private ILoggerRepository? _logRepository;
    private protected ILog? _logger { get; private set; }

    public LoggerConfiguration(IConfiguration configs)
    {
        string? path = configs["LoggerSettingsFile"];
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

        string? level = configs["LoggerLevel"];
        SetLoggingLevel(level);
    }
    public void SetLoggingLevel(string? loggerLevel)
    {
        ArgumentNullException.ThrowIfNull(_logRepository);

        if (!string.IsNullOrEmpty(loggerLevel))
        {
            var level = log4net.Core.Level.Debug;
            level = loggerLevel.ToUpper() switch
            {
                "DEBUG" => log4net.Core.Level.Debug,
                "INFO" => log4net.Core.Level.Info,
                "WARN" => log4net.Core.Level.Warn,
                "ERROR" => log4net.Core.Level.Error,
                "FATAL" => log4net.Core.Level.Fatal,
                "OFF" => log4net.Core.Level.Off,
                "ALL" => log4net.Core.Level.All,
                _ => throw new ArgumentException($"Invalid logger level {loggerLevel}"),
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
    }
    public ILog GetLogger()
    {
        ArgumentNullException.ThrowIfNull(_logger);
        return _logger;
    }
}
