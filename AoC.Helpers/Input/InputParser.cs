using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.Helpers.Input
{
    public static class InputParser
    {
        public static IEnumerable<string> GetInputList(int year, int day)
        {
            var inputProvider = new InputProvider();
            var input = inputProvider.GetInput(year, day);

            return GetFileDataStringList(input);
        }

        public static Point[] GetFileDataCoordinates(IEnumerable<string> inputLines)
        {
            var points = from l in inputLines
                         let split = l.Split(',')
                         select new Point(int.Parse(split[0]), int.Parse(split[1]));

            return points.ToArray();
        }

        public static string GetFileDataString(byte[] byteData) => Encoding.UTF8.GetString(byteData, 0, byteData.Length);

        public static IEnumerable<string> GetFileDataStringList(byte[] byteData) => GetFileDataString(byteData).Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
    }
}
