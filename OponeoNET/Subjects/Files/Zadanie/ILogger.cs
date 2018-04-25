using System;

namespace OponeoNET.Subjects.Files.Zadanie
{
    public interface ILogger
    {
        void Fatal(Exception ex);
        void Fatal(string message);
        void Error(Exception ex);
        void Error(string message);
        void Warn(Exception ex);
        void Warn(string message);
        void Info(string message);
    }
}
