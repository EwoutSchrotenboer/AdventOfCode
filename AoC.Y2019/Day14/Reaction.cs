using System;
using System.Collections.Generic;
using System.Text;

namespace AoC.Y2019.Days
{
    internal class Reaction
    {
        public List<Reagent> Inputs { get; } = new List<Reagent>();
        public Reagent Output { get; }

        public Reaction(string raw)
        {
            var split = raw.Split("=>");

            var inputs = split[0].Split(',');

            foreach (var input in inputs) 
            {
                Inputs.Add(new Reagent(input));
            }

            Output = new Reagent(split[1]);
        }

        public override string ToString() => $"{string.Join(", ", Inputs)} => {Output}";
    }
}
