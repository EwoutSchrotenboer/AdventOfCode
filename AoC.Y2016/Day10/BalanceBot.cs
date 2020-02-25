using System.Collections.Generic;

namespace AoC.Y2016.Days
{
    internal class BalanceBot
    {
        public (string type, int id) HighOutput { get; }
        public int Id { get; }
        public (string type, int id) LowOutput { get; }
        public bool Processed { get; set; } = false;
        public List<int> Values { get; set; } = new List<int>();

        public BalanceBot(string input)
        {
            var items = input.Split(' ');
            Id = int.Parse(items[1]);
            LowOutput = (items[5], int.Parse(items[6]));
            HighOutput = (items[10], int.Parse(items[11]));
        }
    }
}
