using AoC.Helpers.Days;
using AoC.Helpers.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC.Y2016.Days
{
    public class Day04 : BaseDay
    {
        public Day04() : base(2016, 4)
        {
        }

        public Day04(IEnumerable<string> inputLines) : base(2016, 4, inputLines)
        {
        }

        protected override IConvertible PartOne() => DetermineRealRooms(ParseInput(inputLines));

        protected override IConvertible PartTwo() => DetermineNorthPoleRoom(ParseInput(inputLines));

        private static int DetermineRealRooms(List<(string room, int id, string checksum)> rooms)
        {
            var sum = 0;

            foreach(var (room, id, checksum) in rooms)
            {
                var characters = new Dictionary<char, int>();

                foreach (var character in room)
                {
                    if (character != '-')
                    {
                        if (!characters.ContainsKey(character)) { characters.Add(character, 0); }
                        characters[character]++;
                    }
                }

                var top = characters.OrderByDescending(c => c.Value)
                                    .ThenBy(c => c.Key)
                                    .Take(5)
                                    .Select(c => c.Key).ToArray();

                if (new string(top).Equals(checksum)) { sum += id; }
            }

            return sum;
        }

        private int DetermineNorthPoleRoom(List<(string room, int id, string checksum)> list)
        {
            foreach (var (room, id, _) in list)
            {
                var rotation = id % 26;
                var decrypted = new string(room.Select(r => Rotate(r, rotation)).ToArray());
                if (decrypted.Contains("object"))  { return id; }
            }

            return -1;
        }

        private static char Rotate(char c, int r) => c == '-' ? ' ' : (char)(97 + (((c - 97) + r) % 26));

        private static List<(string room, int id, string checksum)> ParseInput(IEnumerable<string> inputLines)
        {
            var rooms = new List<(string, int, string)>();

            foreach (var line in inputLines)
            {
                var parts = line.Split('[');
                var checksum = parts[1].RemoveChar(']');
                var sectorId = int.Parse(parts[0].Substring(parts[0].Length - 3));
                var room = parts[0].Substring(0, parts[0].Length - 4);

                rooms.Add((room, sectorId, checksum));
            }

            return rooms;
        }
    }
}
