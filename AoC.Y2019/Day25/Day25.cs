using AoC.Helpers.Days;
using AoC.Helpers.IntComputer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC.Y2019.Days
{
    public class Day25 : BaseDay
    {
        public Day25() : base(2019, 25)
        {
        }

        public Day25(IEnumerable<string> inputLines) : base(2019, 25, inputLines)
        {
        }

        protected override IConvertible PartOne() => PlayGame(inputLines.First());

        protected override IConvertible PartTwo() => "Finished, merry Christmas!";

        private static string PlayGame(string program)
        {
            var android = new Computer(program);
            var commands = GetCommands();

            android.AddAsciiCommands(commands);
            android.Run();

            var output = android.GetAsciiOutputs();
            var target = "Oh, hello! You should be able to get in by typing ";
            var index = output.IndexOf(target);
            return output.Substring(index + target.Length, 9);
        }

        private static List<string> GetCommands()
        {
            return new List<string>()
            {
                West, North, West,
                TakeItem("food ration"),
                South,
                TakeItem("space law space brochure"),
                North, East, South, South, South, West,
                TakeItem("asterisk"),
                South,
                TakeItem("mutex"),
                North, East, North, North, East, South, South, West, South, East
            };
        }

        private static string TakeItem(string item) => $"{Take} {item}";
        private const string North = "north";
        private const string East = "east";
        private const string South = "south";
        private const string West = "west";
        private const string Take = "take";

    }
}