using AoC.Helpers.Days;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC.Y2017.Days
{
    public class Day16 : BaseDay
    {
        private static int characterCount;

        public Day16() : base(2017, 16)
        {
            characterCount = 16;
        }

        public Day16(IEnumerable<string> inputLines) : base(2017, 16, inputLines)
        {
            characterCount = 5;
        }

        protected override IConvertible PartOne() => ExecuteDanceNTimes(ParseInput(inputLines), 1);

        protected override IConvertible PartTwo() => ExecuteDanceNTimes(ParseInput(inputLines), 1_000_000_000);

        private static string ExecuteDanceNTimes(List<DanceMove> moves, int times)
        {
            var programs = new List<char>();
            programs.AddRange(Enumerable.Range(0, characterCount).Select(c => (char)(c + 97)));

            var states = new HashSet<string>
            {
                new string(programs.ToArray())
            };

            // Programs are in the same order after 30 cycles, so we can take "times % 30"-cycles to define the state at "times"
            // Note: this might differ for other inputs. 
            var shortenedTime = times % 30;

            for (int i = 0; i < shortenedTime; i++)
            {
                programs = ExecuteDance(moves, programs);
            }

            return new string(programs.ToArray());
        }

        private static List<char> ExecuteDance(List<DanceMove> moves, List<char> programs)
        {
            foreach (var move in moves)
            {
                programs = ExecuteDanceMove(move, programs);
            }

            return programs;
        }

        private static List<char> ExecuteDanceMove(DanceMove move, List<char> programs) =>
            move.Name switch
            {
                "s" => Spin(programs, int.Parse(move.A)),
                "x" => Exchange(programs, int.Parse(move.A), int.Parse(move.B)),
                "p" => Partner(programs, move.A[0], move.B[0]),
                _ => throw new Exception($"Programs are terrible at dancing, unknown move. {move.Name}")
            };

        private static List<char> Spin(List<char> current, int a)
        {
            var end = current.Skip(current.Count() - a).Take(a);
            var start = current.Take(current.Count() - a);

            return end.Concat(start).ToList();
        }

        private static List<char> Exchange(List<char> current, int a, int b)
        {
            var temp = current[a];
            current[a] = current[b];
            current[b] = temp;

            return current;
        }

        private static List<char> Partner(List<char> current, char a, char b)
        {
            var indexA = current.IndexOf(a);
            var indexB = current.IndexOf(b);

            return Exchange(current, indexA, indexB);
        }

        private static List<DanceMove> ParseInput(IEnumerable<string> inputLines) => inputLines.Single().Split(',').Select(i => new DanceMove(i)).ToList();

    }
}
