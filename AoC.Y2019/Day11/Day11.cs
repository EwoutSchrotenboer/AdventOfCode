using AoC.Helpers.Days;
using AoC.Helpers.IntComputer;
using AoC.Helpers.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace AoC.Y2019.Days
{
    public class Day11 : BaseDay
    {
        public Day11() : base(2019, 11)
        {
        }

        public Day11(IEnumerable<string> inputLines) : base(2019, 11, inputLines)
        {
        }

        protected override IConvertible PartOne()
        {
            var program = ParseInput(inputLines);
            var paintedHull = Paint(program, 0);
            return paintedHull.Keys.Count;
        }

        protected override IConvertible PartTwo()
        {
            var program = ParseInput(inputLines);
            var paintedHull = Paint(program, 1);
            PrintHull(paintedHull);

            return "Image output";
        }

        private static Dictionary<Point, int> Paint(string program, int startColor)
        {
            var paintComputer = new Computer(program);
            var current = new Point(0, 0);
            var paintedHull = new Dictionary<Point, int>() { { current, startColor } };
            var direction = Direction.Up;


            while (!paintComputer.Finished)
            {
                var input = paintedHull.GetOrCreate(current);
                var (_, outputs) = paintComputer.Resume(input);
                paintedHull[current] = (int)outputs[^2];
                direction = direction.TurnTo((Turn)outputs[^1]);
                current = current.MoveTo(direction);
            }

            return paintedHull;
        }

        private void PrintHull(Dictionary<Point, int> paintedHull)
        {
            var (minPos, maxPos) = paintedHull.Keys.GetDimensions();

            var hullLines = new List<string>();

            for (int yPos = minPos.Y; yPos <= maxPos.Y; yPos++)
            {
                var sb = new StringBuilder();
                for (int xPos = minPos.X; xPos <= maxPos.X; xPos++)
                {
                    var pos = new Point(xPos, yPos);
                    sb.Append(paintedHull.ContainsKey(pos) ? paintedHull[pos] == 0 ? ' ' : '█' : ' ');
                }

                hullLines.Add(sb.ToString());
            }

            Console.WriteLine("Y2019 Day 11 Part Two visual:");
            foreach (var line in hullLines) { Console.WriteLine(line); }
        }

        private static string ParseInput(IEnumerable<string> inputLines) => inputLines.Single();
    }
}