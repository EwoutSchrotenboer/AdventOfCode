using System;
using System.Collections.Generic;
using System.Text;

namespace AoC.Y2015.Days
{
	internal class Character
	{
		public int Hp { get; }
		public int Armor { get; }
		public int Damage { get; }

		public Character(int hp, int armor, int damage)
		{
			Hp = hp;
			Armor = armor;
			Damage = damage;
		}
	}
}
