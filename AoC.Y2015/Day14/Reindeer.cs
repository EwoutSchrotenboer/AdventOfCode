namespace AoC.Y2015.Days
{
    internal class Reindeer
    {
        public int Burst { get; }
        public int BurstRemaining { get; set; }
        public int Distance { get; set; }
        public string Name { get; }
        public int Rest { get; }
        public int RestRemaining { get; set; }
        public int Score { get; set; }
        public int Speed { get; }

        public Reindeer(string rawInput)
        {
            var split = rawInput.Split();
            Name = split[0];
            Speed = int.Parse(split[3]);
            Burst = int.Parse(split[6]);
            BurstRemaining = int.Parse(split[6]);
            Rest = int.Parse(split[13]);
            RestRemaining = 0;
            Distance = 0;
            Score = 0;
        }
    }
}
