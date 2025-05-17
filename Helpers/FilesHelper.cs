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
    /// <param name="fileName">Name of the file with extension.</param>
    /// <param name="waitTime">Wait between tries, if null: default is 3 seconds.</param>
    /// <param name="tries">Number of attempts.</param>
    /// <returns>True if the file exists, false if not (with timeout).</returns>
    /// <exception cref="ArgumentException">Thrown when <c>fileName</c> is empty or consists only of whitespace.</exception>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="fileName"/> is null.</exception>
    /// <exception cref="Exception">Thrown when any other error occurs</exception>
    public bool DoesFileExist(string fileName, TimeSpan? waitTime = null, uint tries = 3)
    {
        try
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(fileName);

            var triesCount = 0;
            var fileExist = File.Exists(Path.Combine(_filesPath, fileName));

            while (!fileExist && triesCount < tries)
            {
                _logger.Info($"Searching for file {fileName} ...");
                Thread.Sleep(waitTime ?? TimeSpan.FromSeconds(3));

                fileExist = File.Exists(Path.Combine(_filesPath, fileName));
                triesCount++;
            }

            var message = fileExist ? "" : "Not ";
            _logger.Info($"File '{fileName}' {message}found.");
            return fileExist;
        }
        catch (ArgumentException ex)
        {
            _logger.Error($"Invalid file name provided: '{fileName}'. Make sure the file name is not empty or whitespace.", ex);
            throw;
        }
        catch (Exception ex)
        {
            _logger.Error($"An unexpected error occurred while checking if file '{fileName}' exists.", ex);
            throw;
        }
    }

    /// <summary>
    /// Deletes a file from the specified working directory path (specified in the constructor).
    /// </summary>
    /// <param name="fileName">Name of the file to delete, including its extension.</param>
    /// <exception cref="ArgumentNullException">Thrown if either <paramref name="fileName"/> or the internal <c>_filesPath</c> is null.</exception>
    /// <exception cref="DirectoryNotFoundException">Thrown when the directory does not exist or is invalid.</exception>
    /// <exception cref="Exception">Thrown when any other error occurs</exception>
    public void DeleteFile(string fileName)
    {
        ArgumentNullException.ThrowIfNull(_filesPath);
        ArgumentNullException.ThrowIfNull(fileName);

        try
        {
            var fullFilePath = Path.Combine(_filesPath, fileName);

            if (File.Exists(fullFilePath))
            {
                File.Delete(fullFilePath);
                _logger.Info($"File '{fileName}' was successfully deleted");
            }
            else
            {
                _logger.Warn($"File '{fileName}' not found in path '{_filesPath}'");
                return;
            }
        }
        catch (DirectoryNotFoundException ex)
        {
            _logger.Error($"Directory not found while trying to delete file '{fileName}'.", ex);
            throw;
        }
        catch (Exception ex)
        {
            _logger.Error($"An unexpected error occurred while deleting file '{fileName}'.", ex);
            throw;
        }
    }
}
