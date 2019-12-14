using System;

namespace AoC.Y2019.Days
{
    internal class Reagent
    {
        public int Amount { get; set; }
        public string Name { get; set; }

        public Reagent(string input)
        {
            var parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Amount = int.Parse(parts[0].Trim());
            Name = parts[1].Trim();
        }

        public Reagent(string name, int count)
        {
            Name = name;
            Amount = count;
        }

        public override string ToString() => $"{Amount} {Name}";
    }
}
