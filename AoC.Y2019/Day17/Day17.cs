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
            var vacuumBot = new Computer(inputLines.First());
            var (_, outputs) = vacuumBot.Run();

            // Replaced by the automated version. Leaving it here as it was my original solution.
            // var routine = ManualVacuumBotRoutine();
            var routine = AutomatedVacuumBotRoutine(outputs, false);

            vacuumBot = new Computer(inputLines.First(), routine);
            vacuumBot.SetAddress(0, 2);
            (_, outputs) = vacuumBot.Run();
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

        private static IEnumerable<int> AutomatedVacuumBotRoutine(List<long> outputs, bool camera)
        {
            var rawMap = new string(outputs.Select(o => (char)o).ToArray());
            var map = GetMap(rawMap);

            var (main, subroutines) = RouteCompressor.GenerateCompressedRoute(map);

            var concatenated = new List<int>();
            concatenated.AddRange(main.Select(c => (int)c).ToArray());
            concatenated.AddRange(subroutines[0].ParsableSubroutine());
            concatenated.AddRange(subroutines[1].ParsableSubroutine());
            concatenated.AddRange(subroutines[2].ParsableSubroutine());
            concatenated.AddRange(EnableFeed(camera));
            return concatenated;
        }

        private static IEnumerable<int> ManualVacuumBotRoutine(bool camera)
        {
            // Manually analyzed the map, which resulted in the following route:
            // R10,R8,L10,L10,R8,L6,L6,R8,L6,L6,R10,R8,L10,L10,L10,R10,L6,R8,L6,L6,L10,R10,L6,L10,R10,L6,R8,L6,L6,R10,R8,L10,L10
            // First subroutine was at the start, second should be the next, then the leftover is the third pattern.
            var concatenated = new List<int>();

            concatenated.AddRange("A,B,B,A,C,B,C,C,B,A\n".Select(c => (int)c).ToArray());
            concatenated.AddRange("R,10,R,8,L,10,L,10\n".Select(c => (int)c).ToArray());
            concatenated.AddRange("R,8,L,6,L,6\n".Select(c => (int)c).ToArray());
            concatenated.AddRange("L,10,R,10,L,6\n".Select(c => (int)c).ToArray());

            // Enable camera, Y/N
            concatenated.AddRange(EnableFeed(camera));
            return concatenated;
        }

        private static int[] EnableFeed(bool enable) => $"{(enable ? "Y" : "N")}\n".Select(c => (int)c).ToArray();
    }
}
