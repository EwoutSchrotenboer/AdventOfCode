using AoC.Helpers.Days;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC.Y2015.Days
{
    public class Day15 : BaseDay
    {
        public Day15() : base(2015, 15)
        {
        }

        public Day15(IEnumerable<string> inputLines) : base(2015, 15, inputLines)
        {
        }

		protected override IConvertible PartOne() => CalculateBestRecipe(ParseInput(inputLines), false, 0);

		protected override IConvertible PartTwo() => CalculateBestRecipe(ParseInput(inputLines), true, 500);

		private static int CalculateBestRecipe(List<int[]> ingredients, bool calorieCount, int maxCalories)
		{
			var sprinkles = ingredients[0];
			var peanutButter = ingredients[1];
			var frosting = ingredients[2];
			var sugar = ingredients[3];

			var highestScore = 0;

			for (int spc = 0; spc < 100; spc++)
			{
				for (int pbc = 0; pbc < 100 - spc; pbc++)
				{
					for (int frc = 0; frc < 100 - spc - pbc; frc++)
					{
						var suc = 100 - spc - pbc - frc;

						if (calorieCount && (sprinkles[4] * spc
										   + peanutButter[4] * pbc
										   + frosting[4] * frc
										   + sugar[4] * suc
										   != maxCalories)) { continue; }

						var capacity = Math.Max(sprinkles[0] * spc + peanutButter[0] * pbc + frosting[0] * frc + sugar[0] * suc, 0);
						var durability = Math.Max(sprinkles[1] * spc + peanutButter[1] * pbc + frosting[1] * frc + sugar[1] * suc, 0);
						var flavor = Math.Max(sprinkles[2] * spc + peanutButter[2] * pbc + frosting[2] * frc + sugar[2] * suc, 0);
						var texture = Math.Max(sprinkles[3] * spc + peanutButter[3] * pbc + frosting[3] * frc + sugar[3] * suc, 0);

						var score = capacity * durability * flavor * texture;

						if (score > highestScore)
						{
							highestScore = score;
						}

					}
				}
			}

			return highestScore;
		}

		private static List<int[]> ParseInput(IEnumerable<string> inputLines)
		{
			var ingredients = new List<int[]>();

			foreach (var line in inputLines)
			{
				var items = line.Replace(",", "").Replace(":", "").Split(' ');
				ingredients.Add(new int[] { int.Parse(items[2]), int.Parse(items[4]), int.Parse(items[6]), int.Parse(items[8]), int.Parse(items[10]) });
			}

			return ingredients;
		}
	}
}
