using System;
using System.Collections.Generic;
using System.Text;

namespace AoC.Y2019.Days
{
    class Asteroid
	{
		public int X { get; set; }
		public int Y { get; set; }
		public List<Asteroid> Visible { get; set; } = new List<Asteroid>();
		public double Angle { get; set; } = 0;

		public Asteroid(int x, int y)
		{
			this.X = x;
			this.Y = y;
		}

		public override string ToString()
		{
			return "(" + X + ", " + Y + ")";
		}
	}
}
