using AoC.Helpers.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace AoC.Y2015.Days
{
    internal sealed class LightingInstruction
    {
		public AoCPoint Origin { get; }
		public AoCPoint End { get; }
		public Switch Switch { get; }

		public LightingInstruction(int ox, int oy, int ex, int ey, string change)
		{
			Origin = new AoCPoint(ox, oy);
			End = new AoCPoint(ex, ey);
			Switch = Enum.Parse<Switch>(change, true);
		}
	}
}
