using AoC.Helpers.Days;
using AoC.Helpers.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AoC.Y2019.Days
{
    public class Day24 : BaseDay
    {
        public Day24() : base(2019, 24)
        {
        }

        public Day24(IEnumerable<string> inputLines) : base(2019, 24, inputLines)
        {
        }

        protected override IConvertible PartOne()
        {
            var map = ParseInput(inputLines.ToList());
            return GetBioDiversityRating(map);
        }

        protected override IConvertible PartTwo()
        {
            var map = ParseInput(inputLines.ToList());
            return GetBugCount(map, 200);
        }

        private static int GetBugCount(Dictionary<AoCPoint, int> map, int minutes)
        {
            var layers = InitializeLayers(minutes, map);

            for (int i = 0; i < minutes; i++)
            {
                var newLayers = InitializeLayers(minutes);

                for (int layerIndex = -minutes; layerIndex <= minutes; layerIndex++)
                {
                    newLayers[layerIndex] = UpdateLayer(layers[layerIndex], layers[layerIndex - 1], layers[layerIndex + 1]);
                }

                layers = newLayers;
            }

            return layers.SelectMany(l => l.Value).Count(l => l.Value == 1);
        }

        private static Dictionary<AoCPoint, int> UpdateLayer(Dictionary<AoCPoint, int> layer, Dictionary<AoCPoint, int> outer, Dictionary<AoCPoint, int> inner)
        {
            var newLayer = new Dictionary<AoCPoint, int>();

            foreach (var point in layer)
            {
                var count = 0;
                if (point.Key.X == 2 && point.Key.Y == 2) { continue; }

                // Default
                var up = layer.ContainsKey(point.Key.Up()) ? layer[point.Key.Up()] : 0;
                var right = layer.ContainsKey(point.Key.Right()) ? layer[point.Key.Right()] : 0;
                var left = layer.ContainsKey(point.Key.Left()) ? layer[point.Key.Left()] : 0;
                var down = layer.ContainsKey(point.Key.Down()) ? layer[point.Key.Down()] : 0;

                // Outer edges
                if (point.Key.X == 0) { left = outer[new AoCPoint(1, 2)]; }
                if (point.Key.X == 4) { right = outer[new AoCPoint(3, 2)]; }
                if (point.Key.Y == 0) { up = outer[new AoCPoint(2, 1)]; }
                if (point.Key.Y == 4) { down = outer[new AoCPoint(2, 3)]; }

                // Inner edges
                if (point.Key.X == 1 && point.Key.Y == 2) { right = inner.Where(l => l.Key.X == 0).Sum(l => l.Value); }
                if (point.Key.X == 3 && point.Key.Y == 2) { left = inner.Where(l => l.Key.X == 4).Sum(l => l.Value); }
                if (point.Key.X == 2 && point.Key.Y == 1) { down = inner.Where(l => l.Key.Y == 0).Sum(l => l.Value); }
                if (point.Key.X == 2 && point.Key.Y == 3) { up = inner.Where(l => l.Key.Y == 4).Sum(l => l.Value); }

                count = up + down + left + right;
                if (point.Value == 1) { newLayer.Add(point.Key, count == 1 ? 1 : 0); }
                else { newLayer.Add(point.Key, (count == 1 || count == 2) ? 1 : 0); }
            }

            return newLayer;
        }

        private static long GetBioDiversityRating(Dictionary<AoCPoint, int> map)
        {
            var states = new HashSet<long>();

            while (true)
            {
                map = UpdateMap(map);
                var score = GetScore(map);
                if (states.Contains(score)) { return score; }
                else { states.Add(score); }
            }
        }

        private static Dictionary<AoCPoint, int> UpdateMap(Dictionary<AoCPoint, int> map)
        {
            var newMap = new Dictionary<AoCPoint, int>();

            foreach (var point in map)
            {
                var count = 0;

                foreach (var adjacent in point.Key.Adjacent())
                {
                    if (map.ContainsKey(adjacent) && map[adjacent] == 1) { count++; }
                }

                if (point.Value == 1) { newMap.Add(point.Key, count == 1 ? 1 : 0); }
                else { newMap.Add(point.Key, (count == 1 || count == 2) ? 1 : 0); }
            }

            return newMap;
        }

        // Where the magic happens - create a binary string of the map, convert it to a number
        private static long GetScore(Dictionary<AoCPoint, int> map) => Convert.ToInt64(new string(string.Concat(map.Select(m => m.Value)).Reverse().ToArray()).PadRight(map.Count(), '0'), 2);

        private static Dictionary<int, Dictionary<AoCPoint, int>> InitializeLayers(int minutes, Dictionary<AoCPoint, int> zero = null)
        {
            var layers = new Dictionary<int, Dictionary<AoCPoint, int>>();

            for (int i = -(minutes + 1); i <= (minutes + 1); i++)
            {
                layers.Add(i, CreateMap());
            }

            if (zero != null) { layers[0] = zero; }
            return layers;
        }

        private static Dictionary<AoCPoint, int> CreateMap()
        {
            var map = new Dictionary<AoCPoint, int>();
            for (int x = 0; x < 5; x++)
            {
                for (int y = 0; y < 5; y++)
                {
                    map.Add(new AoCPoint(x, y), 0);
                }
            }

            return map;
        }

        private static Dictionary<AoCPoint, int> ParseInput(List<string> inputLines)
        {
            var map = new Dictionary<AoCPoint, int>();

            for (int yPos = 0; yPos < inputLines.Count(); yPos++)
            {
                for (int xPos = 0; xPos < inputLines.First().Length; xPos++)
                {
                    map.Add(new AoCPoint(xPos, yPos), inputLines[yPos][xPos] == '#' ? 1 : 0);
                }
            }

            return map;
        }
    }
}