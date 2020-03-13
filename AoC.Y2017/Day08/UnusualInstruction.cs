namespace AoC.Y2017.Days
{
    internal class UnusualInstruction
    {
        public string Comparator { get; set; }
        public string ComparisonRegister { get; set; }
        public int ComparisonValue { get; set; }
        public bool Increase { get; set; }
        public string Register { get; set; }
        public int Value { get; set; }

        public UnusualInstruction(string input)
        {
            var items = input.Split(' ');

            Register = items[0];
            Increase = items[1] == "inc";
            Value = int.Parse(items[2]);

            ComparisonRegister = items[4];
            Comparator = items[5];
            ComparisonValue = int.Parse(items[6]);
        }
    }
}
