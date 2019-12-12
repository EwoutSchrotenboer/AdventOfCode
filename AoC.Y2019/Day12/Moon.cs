using AoC.Helpers.Utils;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace AoC.Y2019.Days
{
	public class Moon
	{
		public Moon Clone() => new Moon(X, Y, Z, VX, VY, VZ);
		public int X { get; private set; }
		public int Y { get; private set; }
		public int Z { get; private set; }

		public int VX { get; private set; } = 0;
		public int VY { get; private set; } = 0;
		public int VZ { get; private set; } = 0;

		public Moon(string input)
		{
			var split = input.RemoveChars(new char[] { '<', '>', '=', 'x', 'y', 'z' }).Split(',');
			X = int.Parse(split[0]);
			Y = int.Parse(split[1]);
			Z = int.Parse(split[2]);
		}

		public Moon (int x, int y, int z, int vx, int vy, int vz)
		{
			X = x;
			Y = y;
			Z = z;

			VX = vx;
			VY = vy;
			VZ = vz;
		}

		public void UpdateVelocity(int dVX, int dVY, int dVZ)
		{
			DXV(dVX);
			DYV(dVY);
			DZV(dVZ);
		}

		public void DXV(int dVX) => VX += dVX;

		public void DYV(int dVY) => VY += dVY;

		public void DZV(int dVZ) => VZ += dVZ;

		public void UpdateCoordinates()
		{
			X += VX;
			Y += VY;
			Z += VZ;
		}

		public int TotalEnergy() => PotentialEnergy() * KineticEnergy();

		public int PotentialEnergy() => Energy(X, Y, Z);

		public int KineticEnergy() => Energy(VX, VY, VZ);

		private int Energy(int x, int y, int z) => Math.Abs(x) + Math.Abs(y) + Math.Abs(z);
	}
}
