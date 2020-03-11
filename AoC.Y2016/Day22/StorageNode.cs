using System;
using System.Collections.Generic;
using System.Text;

namespace AoC.Y2016.Days
{
    internal class StorageNode
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Size { get; set; }
        public int Used { get; set; }
        public int Available { get; set; }

        public StorageNode(string input)
        {
            var items = input
                .Replace("x", "")
                .Replace("y", "")
                .Replace("T", "")
                .Replace("%", "")
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var coords = items[0].Split('-');
            X = int.Parse(coords[1]);
            Y = int.Parse(coords[2]);

            Size = int.Parse(items[1]);
            Used = int.Parse(items[2]);
            Available = int.Parse(items[3]);
        }
    }
}
