using AoC.Helpers.Chronal;
using AoC.Helpers.Days;
using AoC.Helpers.IntComputer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC.Y2019.Days
{
    public class Day21 : BaseDay
    {
        public Day21() : base(2019, 21)
        {
        }

        public Day21(IEnumerable<string> inputLines) : base(2019, 21, inputLines)
        {
        }

        protected override IConvertible PartOne() => RunSpringDroid(inputLines.First(), false);

        protected override IConvertible PartTwo() => RunSpringDroid(inputLines.First(), true);

        private static int RunSpringDroid(string program, bool second)
        {
            var springdroid = new Computer(program);
            springdroid.Run();

            var springProgram = CreateSpringProgram(second);
            springdroid.AddAsciiCommands(springProgram);

            var (_, outputs) = springdroid.Run();

            return (int)outputs.Last();
        }

        private static List<string> CreateSpringProgram(bool second)
        {
            var program = new List<string>();

            // If B or C are not hull, but D is: Jump.
            program.Add(Not("B", Jump)); // !B
            program.Add(Not("C", Temp)); // !C
            program.Add(Or(Temp, Jump)); // !B || !C
            program.Add(And("D", Jump)); // (!B || !C) && D

            if (second)
            {
                // And if E or H are hull, jump
                program.Add(Not("E", Temp)); // !E
                program.Add(Not(Temp, Temp)); // !!E
                program.Add(Or("H", Temp)); // !!E || H == E || H
                program.Add(And(Temp, Jump));  // (!B || !C) && D && (E || H)
            }

            // If A is not hull, jump
            program.Add(Not("A", Temp)); // !A
            program.Add(Or(Temp, Jump)); // !A || (!B || !C) && D && (E || H) - Where && (E || H) is for part 2.

            program.Add(Go(second));
            return program;
        }

        
        private static string Not(string a, string b) => Instruction("NOT", a, b);
        private static string And(string a, string b) => Instruction("AND", a, b);
        private static string Or(string a, string b) => Instruction("OR", a, b);
        private static string Instruction(string instruction, string a, string b) => $"{instruction} {a} {b}".ToUpper();
        private static string Go(bool second) => second ? "RUN" : "WALK";
        private const string Jump = "J";
        private const string Temp = "T";
    }
}