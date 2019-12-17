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

            var score = GetAlignmentSum(map);

            return score;
        }

        protected override IConvertible PartTwo()
        {
            // manually analyzed the map, which resulted in the following route:
            // R10,R8,L10,L10,R8,L6,L6,R8,L6,L6,R10,R8,L10,L10,L10,R10,L6,R8,L6,L6,L10,R10,L6,L10,R10,L6,R8,L6,L6,R10,R8,L10,L10

            // Repeating patterns:
            // 3x R10, R8, L10, L10 (A)
            // 4x R8, L6, L6 (B)
            // 3x L10, R10, L6 (C)
            // A, B, B, A, C, B, C, C, B, A
            var vacuumBot = new Computer(inputLines.First(), VacuumBotRoutine());
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

        private static int[] VacuumBotRoutine()
        {
            var main = mainRoutine;
            var a = subroutineA;
            var b = subroutineB;
            var c = subroutineC;

            var concatenated = new int[main.Length + a.Length + b.Length + c.Length + feed.Length];
            main.CopyTo(concatenated, 0);
            a.CopyTo(concatenated, main.Length);
            b.CopyTo(concatenated, main.Length + a.Length);
            c.CopyTo(concatenated, main.Length + a.Length + b.Length);
            feed.CopyTo(concatenated, main.Length + a.Length + b.Length + c.Length);

            return concatenated;
        }
    }
}
