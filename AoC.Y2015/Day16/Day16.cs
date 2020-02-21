using AoC.Helpers.Days;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC.Y2015.Days
{
    public class Day16 : BaseDay
    {
        public Day16() : base(2015, 16)
        {
        }

        public Day16(IEnumerable<string> inputLines) : base(2015, 16, inputLines)
        {
        }

        protected override IConvertible PartOne() => ParseInput(inputLines).Single(s => FirstMFCSAM(s)).AuntNumber;

        protected override IConvertible PartTwo() => ParseInput(inputLines).Single(s => SecondMFCSAM(s)).AuntNumber;

        private static bool FirstMFCSAM(Sue sue) =>
               (sue.Children == 3 || sue.Children == -1)
            && (sue.Cats == 7 || sue.Cats == -1)
            && (sue.Samoyeds == 2 || sue.Samoyeds == -1)
            && (sue.Pomeranians == 3 || sue.Pomeranians == -1)
            && (sue.Akitas == 0 || sue.Akitas == -1)
            && (sue.Vizslas == 0 || sue.Vizslas == -1)
            && (sue.Goldfish == 5 || sue.Goldfish == -1)
            && (sue.Trees == 3 || sue.Trees == -1)
            && (sue.Cars == 2 || sue.Cars == -1)
            && (sue.Perfumes == 1 || sue.Perfumes == -1);

        private static bool SecondMFCSAM(Sue sue) =>
               (sue.Children == 3 || sue.Children == -1)
            && (sue.Cats > 7 || sue.Cats == -1)
            && (sue.Samoyeds == 2 || sue.Samoyeds == -1)
            && (sue.Pomeranians < 3 || sue.Pomeranians == -1)
            && (sue.Akitas == 0 || sue.Akitas == -1)
            && (sue.Vizslas == 0 || sue.Vizslas == -1)
            && (sue.Goldfish < 5 || sue.Goldfish == -1)
            && (sue.Trees > 3 || sue.Trees == -1)
            && (sue.Cars == 2 || sue.Cars == -1)
            && (sue.Perfumes == 1 || sue.Perfumes == -1);

        private static List<Sue> ParseInput(IEnumerable<string> inputLines) => inputLines.Select(l => new Sue(l)).ToList();
    }
}
