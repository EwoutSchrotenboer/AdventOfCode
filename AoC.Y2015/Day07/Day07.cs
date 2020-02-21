using AoC.Helpers.Days;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC.Y2015.Days
{
    public class Day07 : BaseDay
    {
        private readonly Dictionary<string, ushort?> wires = new Dictionary<string, ushort?>();
        private readonly List<Gate> gates = new List<Gate>();
        private string returnWire = "a";

        public Day07() : base(2015, 7)
        {
        }

        public Day07(IEnumerable<string> inputLines) : base(2015, 7, inputLines)
        {
            returnWire = "i";
        }

        protected override IConvertible PartOne()
        {
            ParseBooklet(inputLines);
            Execute();

            return wires[returnWire];
        }

        protected override IConvertible PartTwo()
        {
            ParseBooklet(inputLines);
            Execute();
            var wireValueOverride = wires[returnWire];

            wires.Clear();
            gates.Clear();

            ParseBooklet(inputLines);
            wires["b"] = wireValueOverride;

            Execute();
            return wires[returnWire];
        }

        private void Execute()
        {
            while (wires.Values.Any(v => v == null))
            {
                foreach (var gate in gates.Where(g => wires[g.OutputWire] == null))
                {
                    if (gate.DependsOn.Count == 0)
                    {
                        wires[gate.OutputWire] = gate.Logic(gate.InputValue, gate.InputValue);
                    }
                    else if (gate.DependsOn.Count == 1 && wires[gate.DependsOn[0]].HasValue)
                    {
                        wires[gate.OutputWire] = gate.Logic(wires[gate.DependsOn[0]].Value, gate.InputValue);
                    }
                    else if (gate.DependsOn.Count == 2 && wires[gate.DependsOn[0]].HasValue && wires[gate.DependsOn[1]].HasValue)
                    {
                        wires[gate.OutputWire] = gate.Logic(wires[gate.DependsOn[0]].Value, wires[gate.DependsOn[1]].Value);
                    }
                }
            }
        }

        private void ParseBooklet(IEnumerable<string> booklet)
        {
            foreach (var instruction in booklet)
            {
                var io = instruction.Split(" -> ");
                var output = io[1];

                if (!wires.ContainsKey(output))
                {
                    wires.Add(output, null);
                }

                var input = io[0].Split(" ");

                if (input.Length == 1)
                {
                    if (ushort.TryParse(input.Single(), out var parsedInput))
                    {
                        gates.Add(new Gate(operations["SET"], output, new List<string>(), parsedInput));
                    }
                    else
                    {
                        gates.Add(new Gate(operations["SET"], output, new List<string>() { input.Single() }, 0));
                    }

                }
                else if (input.Length == 2)
                {
                    gates.Add(new Gate(operations["NOT"], output, new List<string>() { input[1] }, 0));
                }
                else if (input.Length == 3)
                {
                    var dependencies = new List<string>();
                    var firstInputParsed = false;

                    if (ushort.TryParse(input[0], out ushort firstInput)) { firstInputParsed = true; }
                    else { dependencies.Add(input[0]); }

                    if (ushort.TryParse(input[2], out ushort secondInput)) { }
                    else { dependencies.Add(input[2]); }

                    var inputValue = firstInputParsed ? firstInput : secondInput;

                    gates.Add(new Gate(operations[input[1]], output, dependencies, inputValue));
                }
            }
        }

        private static Dictionary<string, Func<ushort, ushort, ushort>> operations = new Dictionary<string, Func<ushort, ushort, ushort>>()
        {
            ["AND"] = (ushort first, ushort second) => (ushort)(first & second),
            ["LSHIFT"] = (ushort first, ushort second) => (ushort)(first << second),
            ["NOT"] = (ushort first, ushort _) => (ushort)(~first),
            ["OR"] = (ushort first, ushort second) => (ushort)(first | second),
            ["RSHIFT"] = (ushort first, ushort second) => (ushort)(first >> second),
            ["SET"] = (ushort first, ushort _) => first
        };
    }
}
