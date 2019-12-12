using AoC.Helpers.Days;
using AoC.Helpers.Utils;
using static AoC.Helpers.Utils.Manhattan;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using AoC.Helpers.Input;

namespace AoC.Y2019.Days
{
    public class Day06 : BaseDay
    {
        public Day06() : base(2019, 6)
        {
        }

        public Day06(IEnumerable<string> inputLines) : base(2019, 6, inputLines)
        {
        }

        protected override IConvertible PartOne()
        {
			var orbits = ParseInput(inputLines);

			var source = orbits.Single(o => o.Parent == null);

			return source.GetChildOrbitCounts();
        }

        protected override IConvertible PartTwo()
        {
            var orbits = ParseInput(inputLines);
            var you = orbits.Single(o => o.Name == "YOU");
            var santa = orbits.Single(o => o.Name == "SAN");

            var youParents = you.GetOrbitsToSource(new List<Orbit>());
            var santaParents = santa.GetOrbitsToSource(new List<Orbit>());
            var ancestorId = -1;

            for (int i = 0; i < youParents.Count; i++)
            {
                if (santaParents.Contains(youParents[i]))
                {
                    ancestorId = i;
                    break;
                }
            }

            var santaAncestorIndex = santaParents.IndexOf(youParents[ancestorId]);

            return santaAncestorIndex + ancestorId;
        }

		private static List<Orbit> ParseInput(IEnumerable<string> inputLines)
		{

			var orbitList = new List<Orbit>();

			foreach (var value in inputLines)
			{
                var split = value.Split(')');

                if (!orbitList.Any(o => o.Name == split[0])) {
                    orbitList.Add(new Orbit(split[0]));
                }

                if (!orbitList.Any(o => o.Name == split[1]))
                {
                    orbitList.Add(new Orbit(split[1]));
                }
            }

            foreach (var initializedValue in inputLines)
            {
                var split = initializedValue.Split(')');

                var parent = orbitList.Single(o => o.Name == split[0]);
                var child = orbitList.Single(o => o.Name == split[1]);

                parent.Children.Add(child);
                child.Parent = parent;
            }

			return orbitList;
		}
	}
}