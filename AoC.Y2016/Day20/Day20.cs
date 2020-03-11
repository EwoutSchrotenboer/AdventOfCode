using AoC.Helpers.Days;
using AoC.Helpers.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC.Y2016.Days
{
    public class Day20 : BaseDay
    {
        public Day20() : base(2016, 20)
        {
        }

        public Day20(IEnumerable<string> inputLines) : base(2016, 20, inputLines)
        {
        }

        protected override IConvertible PartOne() => GetWhitelistedAddresses(ParseInput(inputLines)).First();

		protected override IConvertible PartTwo() => GetWhitelistedAddresses(ParseInput(inputLines)).Count();

		private static List<uint> GetWhitelistedAddresses(List<Range<uint>> blockedRanges)
		{
			var ordered = blockedRanges.OrderBy(r => r.Lower);
			var consolidatedList = new List<Range<uint>>();

			foreach (var o in ordered)
			{
				var overlapping = consolidatedList.SingleOrDefault(l => l.Upper >= o.Lower);

				if (overlapping != null)
				{
					overlapping.Upper = Math.Max(overlapping.Upper, o.Upper);
				}
				else
				{
					consolidatedList.Add(o);
				}
			}

			var whiteListed = new List<uint>();
			for (int i = 0; i < consolidatedList.Count() - 1; i++)
			{
				for (uint j = consolidatedList[i].Upper + 1; j < consolidatedList[i + 1].Lower; j++)
				{
					whiteListed.Add(j);
				}
			}

			return whiteListed;
		}

		private static List<Range<uint>> ParseInput(IEnumerable<string> inputLines)
		{
			var ranges = new List<Range<uint>>();

			foreach (var inputLine in inputLines)
			{
				var items = inputLine.Split('-');
				ranges.Add(new Range<uint>() { Lower = uint.Parse(items[0]), Upper = uint.Parse(items[1]) });
			}

			return ranges;
		}
	}
}
