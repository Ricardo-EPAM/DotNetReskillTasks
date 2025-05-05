using System;

namespace DotnetTaskSeleniumNunit.Helpers
{
    class FilesHelper
    {
        private readonly string _filesPath;

        public FilesHelper(string downloadsPath)
        {
            _filesPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
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
            for (int i = 0; i <= tries; i++)
            {
                if (File.Exists(Path.Combine(_filesPath, fileName)))
                    return true;
                Thread.Sleep(waitTime ?? TimeSpan.FromSeconds(3));
            }
            return false;
        }
    }
}
