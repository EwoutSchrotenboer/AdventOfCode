using System;
using System.Linq;

namespace AoC.Helpers.Assembunny
{
    public class BunnyInstruction
    {
        public int A { get; } = 0;
        public bool AIsReg { get; } = false;
        public int B { get; } = 0;
        public bool BIsReg { get; } = false;
        public string Name { get; private set; }

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

        public void Print(int index, int pointer)
        {
            var p1 = AIsReg ? ((char)(97 + A)).ToString() : A.ToString();
            var p2 = BIsReg ? ((char)(97 + B)).ToString() : B.ToString();
            Console.Write($"[{index.ToString().PadLeft(7)}] {pointer.ToString().PadLeft(2)} {Name} ");

            if ((Name == "inc" || Name == "dec" || Name == "tgl"))
            {
                Console.Write(p1.PadLeft(2));
            }
            else
            {
                Console.Write($"{p1.PadLeft(2)} {p2.PadLeft(2)}");
            }

            if (pointer == 9) { Console.WriteLine(" <= "); } else { Console.WriteLine(); }
        }

        public void ToggleInstruction()
        {
            switch (Name)
            {
                case "inc": Name = "dec"; break;
                case "dec": Name = "inc"; break;
                case "tgl": Name = "inc"; break;
                case "jnz": Name = "cpy"; break;
                case "cpy": Name = "jnz"; break;
                default: break;
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
