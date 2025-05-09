using DotnetTaskSeleniumNunit.Enums;
using log4net;

namespace DotnetTaskSeleniumNunit.Helpers;

class FilesHelper
{
    private readonly string _filesPath;
    private readonly ILog _logger;

    public FilesHelper(SpecialFolders workingDirectory, ILog logger)
    {
        ArgumentNullException.ThrowIfNull(logger);
        _logger = logger;
        _filesPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), workingDirectory.ToString());
        _logger.Info($"FilesHelper initialized using path: {_filesPath}");
    }

    /// <summary>
    /// Used to assert if a file was downloaded.
    /// </summary>
    /// <param name="fileName">Name of the file with extension</param>
    /// <param name="waitTime">Wait between tries, if null: default is 3 seconds</param>
    /// <param name="tries">Number of attempts</param>
    /// <returns>True if the file exist, false if not (with timeout)</returns>
    public bool DoesFileExist(string fileName, TimeSpan? waitTime = null, uint tries = 3)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(fileName);
        for (int i = 0; i <= tries; i++)
        {
            _logger.Info($"Searching for file {fileName} ...");

            if (File.Exists(Path.Combine(_filesPath, fileName)))
            {
                _logger.Info($"File Found {fileName}");
                return true;
            }
            Thread.Sleep(waitTime ?? TimeSpan.FromSeconds(3));
        }
        _logger.Info($"File not found {fileName}");
        return false;
    }

    public void DeleteFile(string fileName)
    {
        ArgumentNullException.ThrowIfNull(_filesPath);
        ArgumentNullException.ThrowIfNull(_logger);
        try
        {
            File.Delete(Path.Combine(_filesPath, fileName));
        }
        catch (Exception ex)
        {
            _logger.Info($"File not found {fileName}", ex);
        }
    }
}
