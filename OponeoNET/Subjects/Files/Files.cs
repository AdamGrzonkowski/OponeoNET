using System;
using System.IO;
using System.Text;

namespace OponeoNET.Subjects.Files
{
    public class Files
    {
        private static readonly object lockObject = new object();

        public void WriteAndReadLine()
        {
            lock (lockObject)
            {
                const string path = "jakiejkolwiek.log";

                using (FileStream st = new FileStream(path, FileMode.OpenOrCreate))
                using (StreamWriter wr = new StreamWriter(st))
                {
                    wr.WriteLine("Hello");
                    wr.WriteLine("World");
                    wr.WriteLine("!");
                }

                using (FileStream st = new FileStream(path, FileMode.Open))
                using (StreamReader rd = new StreamReader(st))
                {
                    StringBuilder sb = new StringBuilder();
                    while (!rd.EndOfStream)
                    {
                        sb.AppendLine(rd.ReadLine());
                    }
                    Console.WriteLine(sb.ToString());
                }
            }
        }

        public void WatchFile()
        {
            FileSystemWatcher watcher = new FileSystemWatcher();
            // Path must be an absolute path to the application
            watcher.Path = Environment.CurrentDirectory;
            watcher.Filter = "*.txt"; // filter to check only text files
            watcher.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.FileName;

            watcher.Renamed += Watcher_Renamed;

            watcher.EnableRaisingEvents = true;
        }

        private void Watcher_Renamed(object sender, RenamedEventArgs e)
        {
            Console.WriteLine("FileName changed!");
        }
    }
}
