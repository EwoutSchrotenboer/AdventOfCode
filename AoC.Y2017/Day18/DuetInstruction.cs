using System;
using System.Collections.Generic;
using System.Text;

namespace AoC.Y2017.Days
{
    internal class DuetInstruction
    {
		public string Name { get; set; }
		public string A { get; set; }
		public string B { get; set; }

		public DuetInstruction(string input)
		{
			var items = input.Split(' ');

			Name = items[0];
			A = items[1];

			if (items.Length == 3)
			{
				B = items[2];
			}
		}
	}
}
