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
            return PrintHull(paintedHull, false);
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

        private string PrintHull(Dictionary<Point, int> paintedHull, bool print)
        {
            var (minPos, maxPos) = paintedHull.Keys.GetDimensions();

            var hullLines = new List<string>();

            for (int yPos = minPos.Y; yPos <= maxPos.Y; yPos++)
            {
                var sb = new StringBuilder();
                for (int xPos = minPos.X + 1; xPos <= maxPos.X; xPos++)
                {
                    var pos = new Point(xPos, yPos);

                    if (print)
                    {
                        sb.Append(paintedHull.ContainsKey(pos) ? paintedHull[pos] == 0 ? ' ' : '█' : ' ');
                    }
                    else
                    {
                        sb.Append(paintedHull.ContainsKey(pos) ? paintedHull[pos] : 0);
                    }
                }

                hullLines.Add(sb.ToString());
            }

            if (print)
            {
                Console.WriteLine("Y2019 Day 11 Part Two visual:");
                foreach (var line in hullLines) { Console.WriteLine(line); }
                return "printed hull";
            }
            else
            {
                return Letters.ParseLetters(hullLines);
            }

        }

        private static string ParseInput(IEnumerable<string> inputLines) => inputLines.Single();
    }
}