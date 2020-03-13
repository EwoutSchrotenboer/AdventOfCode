using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC.Y2017.Days
{
    internal class BalanceProgram
    {
        public List<string> ChildNames { get; set; }
        public List<BalanceProgram> Children { get; set; }
        public string Name { get; set; }
        public int Weight { get; set; }

        public BalanceProgram(string input)
        {
            Children = new List<BalanceProgram>();
            ChildNames = new List<string>();

            var items = input.Replace("(", "").Replace(")", "").Replace(",", "").Split(' ');

            Name = items[0];
            Weight = int.Parse(items[1]);

            if (items.Count() > 2)
            {
                for (int i = 3; i < items.Count(); i++)
                {
                    ChildNames.Add(items[i]);
                }
            }
        }

        public int GetStackWeight()
        {
            var sum = Weight;

            foreach (var child in Children)
            {
                sum += child.GetStackWeight();
            }

            return sum;
        }
    }
}
