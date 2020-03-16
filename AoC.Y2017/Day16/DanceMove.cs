using System;
using System.Collections.Generic;
using System.Text;

namespace AoC.Y2017.Days
{
    internal class DanceMove
	{
		public string Name { get; set; }
		public string A { get; set; }
		public string B { get; set; }

		public DanceMove(string input)
		{
			Name = input[0].ToString();

			var parameters = input.Substring(1).Split('/');
			A = parameters[0];

			if (parameters.Length > 1)
			{
				B = parameters[1];
			}
		}
	}
}
