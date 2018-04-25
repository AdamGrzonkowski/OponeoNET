using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Helper.Common.Files
{
    public static class TextFileHelper
    {
        public static void WriteToFile(IEnumerable<string> textToWrite, string filePath)
        {
            foreach(var line in textToWrite)
            {
                WriteToFile(textToWrite, filePath);
            }
        }

        public static void WriteToFile(string textToWrite, string filePath)
        {
            using (FileStream st = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None)) // creates file if not exists
            {
            }

            using (FileStream st = new FileStream(filePath, FileMode.Append, FileAccess.Write, FileShare.None))
            using (StreamWriter wr = new StreamWriter(st))
            {
                wr.WriteLine(textToWrite);
            }
        }

        public static IEnumerable<string> ReadFromFile(string filePath)
        {
            using (FileStream st = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.None))
            using (StreamReader rd = new StreamReader(st))
            {
                while (!rd.EndOfStream)
                {
                    yield return rd.ReadLine(); // yield return in this place will pass partial result after each iteration, without the need to store entire collection in memory
                }
            }
        }

        public static string ReadFile(string filePath)
        {
            StringBuilder sb = new StringBuilder();

            using (FileStream st = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.None))
            using (StreamReader rd = new StreamReader(st))
            {
                while (!rd.EndOfStream)
                {
                    sb.AppendLine(rd.ReadLine());
                }
            }

            return sb.ToString();
        }
    }
}
