using AoC.Helpers.Days;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC.Y2017.Days
{
    public class Day25 : BaseDay
    {
        public Day25() : base(2017, 25)
        {
        }

        public Day25(IEnumerable<string> inputLines) : base(2017, 25, inputLines)
        {
        }

        protected override IConvertible PartOne()
        {
            var (states, startState, diagnosticStep) = ParseInput(inputLines);
            var machine = new TuringMachine(states, startState, diagnosticStep);
            machine.Run();
            return machine.DiagnosticValue;
        }

        protected override IConvertible PartTwo() => "Merry Christmas!";

        private static (List<TuringState> states, string startState, int diagnosticStep) ParseInput(IEnumerable<string> inputLines)
        {
            var lines = inputLines.ToList();
            var startState = lines[0].Replace(".", "").Split(' ')[3];
            var diagnosticStep = int.Parse(lines[1].Split(' ')[5]);
            var states = new List<TuringState>();

            var stateLines = lines.Skip(2);

            for (int i = 0; i < 6; i++)
            {
                var stateData = stateLines.Skip(9 * i).Take(9).ToList();
                states.Add(new TuringState(stateData));
            }

            return (states, startState, diagnosticStep);
        }
    }
}
