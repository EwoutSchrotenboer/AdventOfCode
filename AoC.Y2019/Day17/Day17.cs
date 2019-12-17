using AoC.Helpers.Days;
using AoC.Helpers.IntComputer;
using AoC.Helpers.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace AoC.Y2019.Days
{
    public class Day17 : BaseDay
    {
        private static readonly int[] feed = "N\n".Select(c => (int)c).ToArray();
        private static readonly int[] mainRoutine = "A,B,B,A,C,B,C,C,B,A\n".Select(c => (int)c).ToArray();
        private static readonly int[] subroutineA = "R,10,R,8,L,10,L,10\n".Select(c => (int)c).ToArray();
        private static readonly int[] subroutineB = "R,8,L,6,L,6\n".Select(c => (int)c).ToArray();
        private static readonly int[] subroutineC = "L,10,R,10,L,6\n".Select(c => (int)c).ToArray();

        public Day17() : base(2019, 17)
        {
        }

        public Day17(IEnumerable<string> inputLines) : base(2019, 17, inputLines)
        {
        }

        protected override IConvertible PartOne()
        {
            var vacuumBot = new Computer(inputLines.First());
            var (_, outputs) = vacuumBot.Run();

            var rawMap = new string(outputs.Select(o => (char)o).ToArray());
            var map = GetMap(rawMap);
            return GetAlignmentSum(map);
        }

        protected override IConvertible PartTwo()
        {
            var vacuumBot = new Computer(inputLines.First(), ManualVacuumBotRoutine());
            vacuumBot.SetAddress(0, 2);
            var (_, outputs) = vacuumBot.Run();
            return outputs.Last();
        }

        private static int GetAlignmentSum(Dictionary<Point, char> map)
        {
            var sum = 0;

            foreach (var pos in map.Where(m => m.Value == '#'))
            {
                var intersection = map.ContainsKey(pos.Key.Up()) && map[pos.Key.Up()] == '#';
                intersection &= map.ContainsKey(pos.Key.Down()) && map[pos.Key.Down()] == '#';
                intersection &= map.ContainsKey(pos.Key.Left()) && map[pos.Key.Left()] == '#';
                intersection &= map.ContainsKey(pos.Key.Right()) && map[pos.Key.Right()] == '#';

                if (intersection) { sum += pos.Key.Y * pos.Key.X; }
            }

            return sum;
        }

        private static Dictionary<Point, char> GetMap(IEnumerable<char> outputs)
        {
            var xPos = 0;
            var yPos = 0;
            var map = new Dictionary<Point, char>();

            foreach (var output in outputs)
            {
                if (output == '\n') { yPos++; xPos = 0; }
                else { map.Add(new Point(xPos, yPos), output); xPos++; }
            }

            return map;
        }

        private static IEnumerable<int> ManualVacuumBotRoutine()
        {
            // Manually analyzed the map, which resulted in the following route:
            // R10,R8,L10,L10,R8,L6,L6,R8,L6,L6,R10,R8,L10,L10,L10,R10,L6,R8,L6,L6,L10,R10,L6,L10,R10,L6,R8,L6,L6,R10,R8,L10,L10
            var concatenated = new List<int>();

            // A, B, B, A, C, B, C, C, B, A
            concatenated.AddRange(mainRoutine);

            // R10, R8, L10, L10
            concatenated.AddRange(subroutineA);

            // R8, L6, L6
            concatenated.AddRange(subroutineB);

            // L10, R10, L6
            concatenated.AddRange(subroutineC);

            // Enable camera, Y/N
            concatenated.AddRange(feed);
            return concatenated;
        }
    }
}
