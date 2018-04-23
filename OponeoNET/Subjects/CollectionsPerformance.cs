using System.Collections.Generic;
using TimeProfiler = Helper.Common.Profilers.TimeProfilerHelper;

namespace OponeoNET.Subjects
{
    public class CollectionsPerformance
    {
        public void CheckCollectionsPerformance()
        {
            const int _max = 100000;
            int _lookupValue = 53759;
            List<int> list = new List<int>();
            Dictionary<int, int> list2 = new Dictionary<int, int>();

            TimeProfiler.CheckPerformance(() => {
                for (int i = 0; i < _max; i++)
                {
                    list.Add(i);
                }
            }, $"Adding {_max} elements to List");

            TimeProfiler.CheckPerformance(() => {
                for (int i = 0; i < _max; i++)
                {
                    list2.Add(i, i);
                }
            }, $"Adding {_max} elements to Dictionary");

            TimeProfiler.CheckPerformance(() => list.Contains(_lookupValue), "Contains for List");
            TimeProfiler.CheckPerformance(() => list2.ContainsKey(_lookupValue), "Contains for Dictionary by Key");
            TimeProfiler.CheckPerformance(() => list2.ContainsValue(_lookupValue), "Contains for Dictionary by Value");
        }
    }
}
