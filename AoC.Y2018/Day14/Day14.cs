using AoC.Helpers.Days;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC.Y2018.Days
{
    public class Day14 : BaseDay
    {
        private int FirstElfIndex = 0;
        private int SecondElfIndex = 1;
        private List<int> ScoreList = new List<int>() { 3, 7 };
        private int RecipesToMake;
        private int[] Sequence;
        public Day14() : base(2018, 14)
        {
            RecipesToMake = 793031;
            Sequence = new int[] { 7, 9, 3, 0, 3, 1 };
        }

        public Day14(IEnumerable<string> inputLines) : base(2018, 14, inputLines)
        {
            RecipesToMake = int.Parse(inputLines.First());
            var input = inputLines.First();
            Sequence = new int[input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                Sequence[i] = (int)char.GetNumericValue(input[i]);
            }
        }

        protected override IConvertible PartOne()
        {
            for (int i = 0; i <= RecipesToMake + 10; i++)
            {
                NextRecipes();
                NextIndexes();
            }

            var scores = ScoreList.Skip(RecipesToMake).Take(10);
            var output = string.Concat(scores);

            return output;
        }

        protected override IConvertible PartTwo()
        {
            var checkPosition = 0;
            var index = 0;
            var notFound = true;

            while (notFound)
            {
                NextRecipes();
                NextIndexes();

                while (index + checkPosition < ScoreList.Count)
                {
                    if (Sequence[checkPosition] == ScoreList[index + checkPosition])
                    {
                        if (checkPosition == Sequence.Length - 1)
                        {
                            notFound = false;
                            break;
                        }

                        checkPosition++;
                    }
                    else
                    {
                        checkPosition = 0;
                        index++;
                    }
                }
            }

            return index;
        }

        private void NextRecipes()
        {
            var firstRecipe = ScoreList[FirstElfIndex];
            var secondRecipe = ScoreList[SecondElfIndex];
            var recipeScore = firstRecipe + secondRecipe;

            if (recipeScore < 10)
            {
                ScoreList.Add(recipeScore);
            }
            else
            {
                ScoreList.Add(1);
                ScoreList.Add(recipeScore - 10);
            }
        }

        private void NextIndexes()
        {

            FirstElfIndex = (FirstElfIndex + 1 + ScoreList[FirstElfIndex]) % ScoreList.Count;
            SecondElfIndex = (SecondElfIndex + 1 + ScoreList[SecondElfIndex]) % ScoreList.Count;
        }
    }
}