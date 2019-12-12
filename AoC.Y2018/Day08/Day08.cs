using AoC.Helpers.Days;
using AoC.Helpers.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC.Y2018.Days
{
    public class Day08 : BaseDay
    {
        public Day08() : base(2018, 8)
        {
        }

        public Day08(IEnumerable<string> inputLines) : base(2018, 8, inputLines)
        {
        }

        protected override IConvertible PartOne()
        {
            var items = inputLines.First().GetNumbers(' ');

            var tree = new Node(items.ToList());
            tree.Init();

            return tree.GetMetaDataSum();
        }

        protected override IConvertible PartTwo()
        {
            var items = inputLines.First().GetNumbers(' ');

            var tree = new Node(items.ToList());
            tree.Init();

            return tree.GetRootNodeValue();
        }
    }
}