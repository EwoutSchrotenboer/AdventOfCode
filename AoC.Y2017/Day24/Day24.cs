using AoC.Helpers.Days;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC.Y2017.Days
{
    public class Day24 : BaseDay
    {
        public Day24() : base(2017, 24)
        {
        }

        public Day24(IEnumerable<string> inputLines) : base(2017, 24, inputLines)
        {
        }

        protected override IConvertible PartOne()
        {
            var components = ParseInput(inputLines);
            var bridges = BuildBridges(components);
            return GetStrongestBridge(bridges);
        }

        protected override IConvertible PartTwo()
        {
            var components = ParseInput(inputLines);
            var bridges = BuildBridges(components);
            var longest = GetLongestBridges(bridges, bridges.Max(b => b.Count()));
            return GetStrongestBridge(longest);
        }

        private static List<List<(int, int)>> BuildBridges(List<(int A, int B)> components)
        {
            var startItems = components.Where(c => c.A == 0 || c.B == 0);
            var bridges = new List<List<(int A, int B)>>();

            foreach (var start in startItems)
            {
                var currentComponents = new List<(int A, int B)>() { start };
                var current = start.A == 0 ? start.B : start.A;
                var usableComponents = components.Where(c => c != start).ToList();
                bridges.AddRange(CreateBridges(currentComponents, current, usableComponents));
            }

            return bridges;
        }

        private static List<List<(int, int)>> CreateBridges(List<(int, int)> currentComponents, int current, List<(int A, int B)> usableComponents)
        {
            var bridges = new List<List<(int, int)>>();
            bridges.Add(currentComponents);

            var viableComponents = usableComponents.Where(c => c.A == current || c.B == current);

            if (!viableComponents.Any())
            {
                return bridges;
            }

            foreach (var viableComponent in viableComponents)
            {
                var newBridge = currentComponents.Select(c => c).ToList();
                newBridge.Add(viableComponent);
                var nextPort = viableComponent.A == current ? viableComponent.B : viableComponent.A;
                var nextComponents = usableComponents.Where(c => c != viableComponent).ToList();
                bridges.AddRange(CreateBridges(newBridge, nextPort, nextComponents));
            }

            return bridges;
        }

        private static List<List<(int, int)>> GetLongestBridges(List<List<(int A, int B)>> bridges, int maxLength) => bridges.Where(b => b.Count() == maxLength).ToList();

        private static int GetStrongestBridge(List<List<(int A, int B)>> bridges)
        {
            var strongest = 0;

            foreach (var bridge in bridges)
            {
                var strength = bridge.Sum(b => b.A + b.B);

                if (strength > strongest)
                {
                    strongest = strength;
                }
            }

            return strongest;
        }

        private static List<(int, int)> ParseInput(IEnumerable<string> inputLines)
        {
            var components = new List<(int, int)>();

            foreach (var line in inputLines)
            {
                var items = line.Split('/');
                components.Add((int.Parse(items[0]), int.Parse(items[1])));
            }

            return components;
        }
    }
}
