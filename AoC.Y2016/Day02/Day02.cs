using AoC.Helpers.Days;
using AoC.Helpers.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC.Y2016.Days
{
    public class Day02 : BaseDay
    {
        public Day02(IEnumerable<string> input) : base(2016, 2, input)
        {
        }

        public Day02() : base(2016, 2)
        {
        }

        protected override IConvertible PartOne() => GetCode(inputLines, FirstNumpad());

        protected override IConvertible PartTwo() => GetCode(inputLines, SecondNumpad());

        private static string GetCode(IEnumerable<string> instructions, Dictionary<AoCPoint, char> numpad)
        {
            var code = string.Empty;
            var pos = numpad.Single(n => n.Value == '5').Key;

            foreach (var instruction in instructions)
            {
                foreach (var step in instruction)
                {
                    var next = step == 'U' ? pos.Up()
                             : step == 'L' ? pos.Left()
                             : step == 'D' ? pos.Down()
                             : pos.Right();

                    if (numpad.ContainsKey(next))
                    {
                        pos = next;
                    }
                }

                code += numpad[pos];
            }

            return code;
        }

        private static Dictionary<AoCPoint, char> FirstNumpad() =>
            new Dictionary<AoCPoint, char>()
            {
                [P(-1, -1)] = '1', [P( 0, -1)] = '2', [P( 1, -1)] = '3',
                [P(-1,  0)] = '4', [P( 0,  0)] = '5', [P( 1,  0)] = '6',
                [P(-1,  1)] = '7', [P( 0,  1)] = '8', [P( 1,  1)] = '9',
            };

        private static Dictionary<AoCPoint, char> SecondNumpad() =>
            new Dictionary<AoCPoint, char>
            {
                                                        [P(0, -2)] = '1',
                                     [P(-1, -1)] = '2', [P(0, -1)] = '3',  [P(1, -1)] = '4',
                  [P(-2,  0)] = '5', [P(-1,  0)] = '6', [P(0,  0)] = '7',  [P(1,  0)] = '8', [P(2, 0)] = '9',
                                     [P(-1,  1)] = 'A', [P(0,  1)] = 'B',  [P(1,  1)] = 'C',
                                                        [P(0,  2)] = 'D',
            };

        private static AoCPoint P(int x, int y) => new AoCPoint(x, y);
    }
}
