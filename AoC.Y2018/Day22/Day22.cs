using AoC.Helpers.Days;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace AoC.Y2018.Days
{
    public class Day22 : BaseDay
    {
        private static int depth;
        private static (int x, int y) dest;

        public Day22() : base(2018, 22)
        {
        }

        public Day22(IEnumerable<string> inputLines) : base(2018, 22, inputLines)
        {
        }

        protected override IConvertible PartOne()
        {
            ParseInput(inputLines);
            var risk = 0;
            for (int y = 0; y <= dest.y; y++)
            {
                for (int x = 0; x <= dest.x; x++)
                {
                    switch (GetRegionType(x, y))
                    {
                        case 'W': risk++; break;
                        case 'N': risk += 2; break;
                    }
                }
            }

            return risk;
        }

        protected override IConvertible PartTwo()
        {
            ParseInput(inputLines);
            return BreadthFirstSearch();
        }

        private int BreadthFirstSearch()
        {
            (int x, int y)[] neis = { (-1, 0), (0, 1), (1, 0), (0, -1) };

            Queue<(int x, int y, char tool, int switching, int minutes)> queue = new Queue<(int x, int y, char tool, int switching, int minutes)>();
            HashSet<(int x, int y, char tool)> seen = new HashSet<(int x, int y, char tool)>();
            queue.Enqueue((0, 0, 'T', 0, 0));
            seen.Add((0, 0, 'T'));

            while (queue.Count > 0)
            {
                (int x, int y, char tool, int switching, int minutes) = queue.Dequeue();
                if (switching > 0)
                {
                    if (switching != 1 || seen.Add((x, y, tool)))
                    {
                        queue.Enqueue((x, y, tool, switching - 1, minutes + 1));
                    }

                    continue;
                }

                if ((x, y) == dest && tool == 'T')
                {
                    return minutes;
                }

                foreach ((int xo, int yo) in neis)
                {
                    (int nx, int ny) = (x + xo, y + yo);

                    if (nx < 0 || ny < 0)
                    {
                        continue;
                    }


                    if (GetAllowedTools(GetRegionType(nx, ny)).Contains(tool) && seen.Add((nx, ny, tool)))
                    {
                        queue.Enqueue((nx, ny, tool, 0, minutes + 1));
                    }

                }

                foreach (char otherTool in GetAllowedTools(GetRegionType(x, y)))
                {
                    queue.Enqueue((x, y, otherTool, 6, minutes + 1));
                }

            }

            return 0;
        }

        private static readonly Dictionary<(int x, int y), int> erosionLevels = new Dictionary<(int x, int y), int>();
        private static int ErosionLevel(int x, int y)
        {
            if (erosionLevels.TryGetValue((x, y), out int val)) { return val; }

            if ((x, y) == (0, 0)) { val = 0; }
            else if ((x, y) == dest) { val = 0; }
            else if (y == 0) { val = x * 16807; }
            else if (x == 0) { val = y * 48271; }
            else { val = ErosionLevel(x - 1, y) * ErosionLevel(x, y - 1); }

            val += depth;
            val %= 20183;
            erosionLevels.Add((x, y), val);
            return val;
        }
        private static char GetRegionType(int x, int y)
        {
            int erosionLevel = ErosionLevel(x, y);
            return "RWN"[erosionLevel % 3];
        }

        private static string GetAllowedTools(char region)=>
            region switch
            {
                'R' => "CT",
                'W' => "CN",
                'N' => "TN",
                _ => throw new Exception("Unreachable"),
            };

        private static void ParseInput(IEnumerable<string> input)
        {
            var parsedDepth = input.First().Split(' ')[1];
            var parsedTarget = input.Last().Split(' ')[1].Split(',');

            depth = int.Parse(parsedDepth);
            dest = (int.Parse(parsedTarget[0]), int.Parse(parsedTarget[1]));
        }
    }
}