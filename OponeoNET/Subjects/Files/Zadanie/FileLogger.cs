using Helper.Common.Constants;
using Helper.Common.Files;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace OponeoNET.Subjects.Files.Zadanie
{
    public class FileLogger : ILogger
    {
        private static readonly object _lockObject = new object();
        private string _filePath = null;

        public void Fatal(Exception ex)
        {
            WriteNewLog(ex, nameof(Fatal));
        }

        public void Error(Exception ex)
        {
            WriteNewLog(ex, nameof(Error));
        }

        public void Info(string message)
        {
            WriteNewLog(message, nameof(Info));
        }

        public void Warn(Exception ex)
        {
            WriteNewLog(ex, nameof(Warn));
        }

        public void Fatal(string message)
        {
            WriteNewLog(message, nameof(Fatal));
        }

        public void Error(string message)
        {
            WriteNewLog(message, nameof(Error));
        }

        public void Warn(string message)
        {
            WriteNewLog(message, nameof(Warn));
        }

        private void WriteNewLog(string message, string fileName)
        {
            string msg = $@"[{fileName.ToUpper()}] {DateTime.Now} | {message}";
            Log(msg, fileName);
        }

        private void WriteNewLog(Exception ex, string fileName)
        {
            string msg = $@"[{fileName.ToUpper()}] {DateTime.Now} | {ex.Message} {Environment.NewLine} Stack trace: {Environment.NewLine} {ex.StackTrace}";
            Log(msg, fileName);
        }

        private void AssignFilePath(string fileName)
        {
            _filePath = $"{fileName}.log";
        }

        /// <summary>
        /// Main logic for logging into file.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="fileName"></param>
        private void Log(string message, string fileName)
        {
            AssignFilePath(fileName);
            bool archiveFile = false;

            if (File.Exists(_filePath))
            {
                using (FileStream st = new FileStream(_filePath, FileMode.Open, FileAccess.ReadWrite, FileShare.None)) // open stream to get the size of file
                {
                    long maxSize = 52428800; // 50 MB
                    archiveFile = st.Length >= maxSize ? true : false; // if file is larger than 50 MB, then archive it
                }

                if (archiveFile)
                {
                    ArchiveLogFile(fileName);
                }
            }

            TextFileHelper.WriteToFile(message, _filePath);
        }

        private void ArchiveLogFile(string fileName)
        {
            string directory = Environment.CurrentDirectory;
            string sourcePath = $"{directory}{Path.DirectorySeparatorChar}{_filePath}";
            string destinationPath = $"{directory}{Path.DirectorySeparatorChar}{fileName}{DateTime.Today.ToString(Formatting.ShortDateYearMonthDay)}_archived.log";
            if (!File.Exists(destinationPath))
            {
                File.Move(sourcePath, destinationPath);
            }

            DeleteOldLogFiles(directory);
        }

        /// <summary>
        /// Deletes archived log files older than 6 months.
        /// </summary>
        private void DeleteOldLogFiles(string directory)
        {
            IEnumerable<string> oldLogFilePaths = Directory.GetFiles(directory).Where(filePath => filePath.Contains(".log") && filePath.Contains("_archived"));
            
            foreach(string filePath in oldLogFilePaths)
            {
                ProcessFileDeletion(filePath);
            }
        }

        private void ProcessFileDeletion(string filePath)
        {
            // Double-checked pattern
            if (File.Exists(filePath))
            {
                lock (_lockObject)
                {
                    if (File.Exists(filePath)) // in case file was removed / renamed during locking
                    {
                        string fileName = Path.GetFileName(filePath);
                        string dateString = Regex.Match(fileName, @"\d+", RegexOptions.Compiled).Value; // gets only numbers from string - date portion from filename
                        DateTime date = DateTime.ParseExact(dateString, Formatting.ShortDateYearMonthDay, CultureInfo.InvariantCulture);

                        if (date.AddMonths(6) < DateTime.Today) // if log was archived more than 6 months ago, then delete it
                        {
                            File.Delete(filePath);
                        }
                    }
                }
            }
        }
    }
}