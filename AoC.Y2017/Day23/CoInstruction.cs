namespace AoC.Y2017.Days
{
    internal class CoInstruction
    {
        public string A { get; set; }
        public string B { get; set; }
        public int Index { get; set; }
        public string Name { get; set; }
        public string Raw { get; set; }

        public CoInstruction(int index, string input)
        {
            Index = index;
            Raw = input;
            var items = input.Split(' ');

            Name = items[0];
            A = items[1];

            if (items.Length == 3)
            {
                B = items[2];
            }
        }
    }
}
