using AoC.Helpers.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AoC.Helpers.Output
{
    /// <summary>
    /// Write output to the temp folder, for later reference
    /// </summary>
    public static class OutputWriter
    {
        public static void SaveOutput(int year, int day, Part part, IConvertible output)
        {
            var s = output.ToString();

            WriteOutput(year, day, part, s.SingleItemList());
        }

        public static void SaveOutput(int year, int day, Part part, IEnumerable<IConvertible> output)
        {
            var sl = output.Select(o => o.ToString());

            WriteOutput(year, day, part, sl);
        }

        private static void WriteOutput(int year, int day, Part part, IEnumerable<string> output)
        {
            var tempFilePath = GetTempFile(year.ToString(), day.ToString(), (int)part);

            File.WriteAllLines(tempFilePath, output);
        }

        private static string GetTempFile(string year, string day, int part)
        {
            var path = GetAocTempPath(year);
            var filePath = Path.Combine(path, $"{day}.{part}.output");

            if (!File.Exists(filePath))
            {
                var file = File.Create(filePath);
                file.Close();
            }

            return filePath;
        }

        private static string GetAocTempPath(string year)
        {
            var aocPath = Path.Combine(Path.GetTempPath(), "AoC", year);

            Directory.CreateDirectory(aocPath);

            return aocPath;
        }
    }
}