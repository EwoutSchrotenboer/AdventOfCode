using System;
using System.Linq;

namespace AoC.Y2017.Days
{
    internal class Particle
    {
        public int Id { get; }
        public (int x, int y, int z) Acceleration { get; }
        public (int x, int y, int z) Position { get; private set; }
        public (int x, int y, int z) Velocity { get; private set; }

        public Particle(int id, string input)
        {
            Id = id;
            var items = input.Split(", ");

            Position = ParseGroup(items[0]);
            Velocity = ParseGroup(items[1]);
            Acceleration = ParseGroup(items[2]);
        }

        public int Manhattan((int x, int y, int z) group) => Math.Abs(group.x) + Math.Abs(group.y) + Math.Abs(group.z);

        public void Update()
        {
            Velocity = UpdateGroup(Velocity, Acceleration);
            Position = UpdateGroup(Position, Velocity);
        }

        private static (int, int, int) ParseGroup(string input)
        {
            var items = input.Split('=')[1]
            .Replace("<", "")
            .Replace(">", "")
            .Split(',')
            .Select(i => int.Parse(i)).ToArray();

            return (items[0], items[1], items[2]);
        }

        private (int, int, int) UpdateGroup((int x, int y, int z) receiving, (int x, int y, int z) adding)
        {
            receiving.x += adding.x;
            receiving.y += adding.y;
            receiving.z += adding.z;

            return receiving;
        }
    }
}
