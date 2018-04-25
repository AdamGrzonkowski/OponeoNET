using System;
using System.IO;

namespace OponeoNET.Subjects.Files.Zadanie
{
    public class Watcher : IWatcher
    {
        private readonly ILogger _logger;

        public Watcher(ILogger logger)
        {
            _logger = logger;
        }

        public void WatchDllIntegrity()
        {
            FileSystemWatcher watcher = new FileSystemWatcher();
            // Path must be an absolute path to the application
            watcher.Path = Environment.CurrentDirectory;
            watcher.Filter = "*.dll"; // filter to check only text files
            watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
                                | NotifyFilters.FileName | NotifyFilters.DirectoryName;

            watcher.Renamed += Watcher_Renamed;
            watcher.Changed += Watcher_Changed;
            watcher.Deleted += Watcher_Deleted;

            watcher.EnableRaisingEvents = true;
            _logger.Info("FileWatcher has been started - tracking changes in *.dll files in the main directory.");
        }

        private void Watcher_Deleted(object sender, FileSystemEventArgs e)
        {
            _logger.Fatal($"File {e.Name} has been deleted from {e.FullPath}");
        }

        private void Watcher_Changed(object sender, FileSystemEventArgs e)
        {
            _logger.Warn($"File {e.Name} has been changed at {e.FullPath}");
        }

        private void Watcher_Renamed(object sender, RenamedEventArgs e)
        {
            _logger.Warn($"File has been renamed to {e.Name} at {e.FullPath}");
        }
    }
}
