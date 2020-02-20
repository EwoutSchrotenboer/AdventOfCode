using AoC.Helpers.Days;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC.Y2015.Days
{
    public class Day21 : BaseDay
    {
        public Day21() : base(2015, 21)
        {
        }

        public Day21(IEnumerable<string> inputLines) : base(2015, 21, inputLines)
        {
        }

        protected override IConvertible PartOne() => SimulateFights(ParseInput(inputLines)).Where(f => f.win == true).OrderBy(f => f.cost).First().cost;

		protected override IConvertible PartTwo() => SimulateFights(ParseInput(inputLines)).Where(f => f.win == false).OrderByDescending(f => f.cost).First().cost;

		private static List<(int cost, bool win)> SimulateFights(Character boss)
		{
			var stats = new List<(int, bool)>();
			var gearCombinations = GetCombinations();
			foreach (var gear in gearCombinations)
			{
				var player = new Character(100, gear.armor, gear.damage);

				var bossDeath = CalculateZeroTurn(boss.Hp, boss.Armor, player.Damage);
				var playerDeath = CalculateZeroTurn(player.Hp, player.Armor, boss.Damage);
				var win = bossDeath <= playerDeath;
				stats.Add((gear.cost, win));
			}

			return stats;
		}


		private static List<(int cost, int armor, int damage)> GetCombinations()
		{
			var combinations = new List<(int, int, int)>();
			var count = 0;

			for (int weaponIndex = 0; weaponIndex < Weapons.Count(); weaponIndex++)
			{
				for (int gearIndex = 0; gearIndex < Gear.Count(); gearIndex++)
				{
					for (int firstRingIndex = 0; firstRingIndex < Rings.Count(); firstRingIndex++)
					{
						for (int secondRingIndex = firstRingIndex + 1; secondRingIndex < Rings.Count(); secondRingIndex++)
						{
							count++;
							var combination = GetCombinationStats(weaponIndex, gearIndex, firstRingIndex, secondRingIndex);
							combinations.Add(combination);
						}
					}
				}
			}

			return combinations;
		}

		private static (int, int, int) GetCombinationStats(int weaponIndex, int gearIndex, int firstRingIndex, int secondRingIndex)
		{
			var weapon = Weapons[weaponIndex];
			var gear = Gear[gearIndex];
			var firstRing = Rings[firstRingIndex];
			var secondRing = Rings[secondRingIndex];

			var cost = weapon.cost + gear.cost + firstRing.cost + secondRing.cost;
			var armor = gear.armor + firstRing.armor + secondRing.armor;
			var damage = weapon.damage + firstRing.damage + secondRing.damage;

			return (cost, armor, damage);
		}

		private static int CalculateZeroTurn(int hp, int armor, int damage)
		{
			var count = 0;

			while (hp > 0)
			{
				hp -= Math.Max(1, damage - armor);
				count++;
			}

			return count;
		}

		private static Character ParseInput(IEnumerable<string> inputLines)
		{
			var stats = inputLines.Select(l => int.Parse(l.Split(' ')[^1])).ToList();
			return new Character(stats[0], stats[2], stats[1]);
		}

		private static readonly List<(int cost, int damage)> Weapons = new List<(int, int)>() { (8, 4), (10, 5), (25, 6), (40, 7), (74, 8) };
		private static readonly List<(int cost, int armor)> Gear = new List<(int, int)>() { (0, 0), (13, 1), (31, 2), (53, 3), (75, 4), (102, 5) };
		private static readonly List<(int cost, int damage, int armor)> Rings = new List<(int, int, int)>() { (0, 0, 0), (0, 0, 0), (25, 1, 0), (50, 2, 0), (100, 3, 0), (20, 0, 1), (40, 0, 2), (80, 0, 3) };
	}
}
