using System;
using System.Diagnostics;

namespace Helper.Common.Profilers
{
    public static class TimeProfilerHelper
    {
        public static void CheckPerformance(Action method, string message)
        {
            Stopwatch _stopWatch = new Stopwatch();

            _stopWatch.Start();
            method.Invoke();
            _stopWatch.Stop();

            Console.WriteLine($"{message}: {_stopWatch.Elapsed}");
        }
    }
}
