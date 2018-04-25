using Helper.Common.Profilers;
using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace OponeoNET.Subjects
{
    public class MemoryStreams
    {
        private static readonly int _max = 5000000;

        public void CheckOutMemoryStream()
        {
            TimeProfilerHelper.CheckPerformance(StreamingWithBuffer, "Streaming with buffer: ");
            TimeProfilerHelper.CheckPerformance(StreamingWithoutBuffer, "Basic streaming: ");

        }

        private static void StreamingWithBuffer()
        {
            using (MemoryStream stream = new MemoryStream())
            using (BufferedStream bf = new BufferedStream(stream))
            {
                IFormatter br = new BinaryFormatter();

                for (int i = 0; i < _max; i++)
                {
                    br.Serialize(bf, i);
                }

                stream.Position = 0;

                for (int i = 0; i < _max; i++)
                {
                    object wynik = br.Deserialize(stream);
                    Console.WriteLine($"{wynik}");
                }
            }
        }

        private static void StreamingWithoutBuffer()
        {
            using (MemoryStream stream = new MemoryStream())
            {
                IFormatter br = new BinaryFormatter();

                for (int i = 0; i < _max; i++)
                {
                    br.Serialize(stream, i);
                }

                stream.Position = 0;

                for (int i = 0; i < _max; i++)
                {
                    object wynik = br.Deserialize(stream);
                    Console.WriteLine($"{wynik}");
                }
            }
        }
    }
}
