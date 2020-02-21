using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC.Y2015.Days
{
    internal class Gate
    {
        public List<string> DependsOn { get; set; } = new List<string>();
        public ushort InputValue { get; set; }
        public Func<ushort, ushort, ushort> Logic { get; }
        public string OutputWire { get; set; }

        public Gate(Func<ushort, ushort, ushort> logic, string output, IEnumerable<string> dependencies, ushort input)
        {
            DependsOn = dependencies.ToList();
            InputValue = input;
            OutputWire = output;
            Logic = logic;
        }
    }
}
