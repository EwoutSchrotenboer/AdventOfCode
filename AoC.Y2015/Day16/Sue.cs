namespace AoC.Y2015.Days
{
    internal class Sue
    {
        public int Akitas { get; private set; } = -1;
        public int AuntNumber { get; }

        public int Cars { get; private set; } = -1;
        public int Cats { get; private set; } = -1;
        public int Children { get; private set; } = -1;
        public int Goldfish { get; private set; } = -1;
        public int Perfumes { get; private set; } = -1;
        public int Pomeranians { get; private set; } = -1;
        public int Samoyeds { get; private set; } = -1;
        public int Trees { get; private set; } = -1;
        public int Vizslas { get; private set; } = -1;

        public Sue(string inputLine)
        {
            var items = inputLine.Replace(":", "").Replace(",", "").Split(' ');
            AuntNumber = int.Parse(items[1]);
            SetValue(items[2], items[3]);
            SetValue(items[4], items[5]);
            SetValue(items[6], items[7]);
        }

        private void SetValue(string name, string value)
        {
            switch (name)
            {
                case "children": Children = int.Parse(value); break;
                case "cats": Cats = int.Parse(value); break;
                case "akitas": Akitas = int.Parse(value); break;
                case "pomeranians": Pomeranians = int.Parse(value); break;
                case "samoyeds": Samoyeds = int.Parse(value); break;
                case "vizslas": Vizslas = int.Parse(value); break;
                case "goldfish": Goldfish = int.Parse(value); break;
                case "trees": Trees = int.Parse(value); break;
                case "cars": Cars = int.Parse(value); break;
                case "perfumes": Perfumes = int.Parse(value); break;
                default: break;
            }
        }
    }
}
