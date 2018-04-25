using OponeoNET.Subjects.Files.Zadanie;
using System;
using System.Threading;

namespace OponeoNET
{
    public class Program
    {
        static void Main(string[] args)
        {
            ILogger logger = SetUpLoggersAndWatchers();

            try
            {
                int zero = 0;
                int divideByZero = 5 / zero;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }

            Console.WriteLine("Infinite loop starting. You can test FileWatcher now. Mess around with .dll files in the folder where this .exe resides.");
            Run();
        }

        private static ILogger SetUpLoggersAndWatchers()
        {
            ILogger logger = new FileLogger();
            IWatcher watcher = new Watcher(logger);
            watcher.WatchDllIntegrity();

            return logger;
        }

        private static void Run()
        {
            Console.WriteLine("Press 'q' or 'ESC' to exit program");

            while (true)
            {
                Thread.Sleep(10); // let processor rest for a while
                ConsoleKey keyPressed = Console.ReadKey().Key;
                if (keyPressed == ConsoleKey.Q || keyPressed == ConsoleKey.Escape)
                {
                    Environment.Exit(0);
                }
            }
        }
    }
}
