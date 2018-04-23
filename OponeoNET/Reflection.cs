using System;
using TimeProfiler = Helper.Common.Profilers.TimeProfilerHelper;

namespace OponeoNET
{
    public class Reflection
    {
        private void CheckBasicPerformance()
        {
            Klasa ins = new StaticOperatorsOverloading().NewInstance;

            TimeProfiler.CheckPerformance(() => {
                Type bang = ins.GetType(); 
                }, "GetType() of class Klasa performance");

            TimeProfiler.CheckPerformance(() => {
                Type bang = typeof(Klasa);
            }, "typeof(Klasa) performance");
        }
    }
}
