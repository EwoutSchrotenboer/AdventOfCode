using System;
using System.Collections.Generic;
using System.Text;

namespace AoC.Y2016.Days
{
    internal class Disc
    {
		public int Id { get; set; }
		public int Positions { get; set; }
		public int StartPosition { get; set; }

		public Disc(string input)
		{
			var items = input.Split(' ');
			Id = int.Parse(items[1].Replace("#", ""));
			Positions = int.Parse(items[3]);
			StartPosition = int.Parse(items[^1].Replace(".", ""));
		}

		public Disc(int id, int positions, int startPosition)
		{
			Id = id;
			Positions = positions;
			StartPosition = startPosition;
		}

		public int GetPosition(int time) => (StartPosition + time) % Positions;
	}
}
