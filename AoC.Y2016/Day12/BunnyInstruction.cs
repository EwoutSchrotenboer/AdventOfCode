using System;
using System.Linq;

namespace AoC.Y2016.Days
{
    internal class BunnyInstruction
    {
        public int A { get; } = 0;
        public bool AIsReg { get; } = false;
        public int B { get; } = 0;
        public bool BIsReg { get; } = false;
        public string Name { get; }

        public BunnyInstruction(string input)
        {
            var items = input.Split(' ');

            Name = items[0];
            (AIsReg, A) = GetValue(items[1]);

            if (items.Length == 3)
            {
                (BIsReg, B) = GetValue(items[2]);
            }
        }

        private (bool isRegister, int value) GetValue(string value)
        {
            if (value.Length == 1 && new char[] { 'a', 'b', 'c', 'd' }.Contains(value[0]))
            {
                return (true, value[0] - 97);
            }

            return (false, int.Parse(value));
        }
    }
}
