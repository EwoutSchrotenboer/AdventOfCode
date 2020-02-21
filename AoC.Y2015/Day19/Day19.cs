using AoC.Helpers.Days;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AoC.Y2015.Days
{
    public class Day19 : BaseDay
    {
        public Day19() : base(2015, 19)
        {
        }

        public Day19(IEnumerable<string> inputLines) : base(2015, 19, inputLines)
        {
        }

        protected override IConvertible PartOne()
        {
            var (replacements, molecule) = ParseInput(inputLines);
            return GetReplaceOnePermutations(replacements, molecule).Count;
        }

        protected override IConvertible PartTwo() 
        {
            var (replacements, molecule) = ParseInput(inputLines);
            return GetMoleculeSteps(replacements, molecule);
        }

        private static HashSet<string> GetReplaceOnePermutations(List<(string, string)> replacements, string molecule)
        {
            var permutations = new HashSet<string>();

            foreach (var (input, output) in replacements)
            {
                var match = Regex.Match(molecule, input);

                while (match.Success)
                {
                    var currentMolecule = molecule;
                    currentMolecule = currentMolecule.Remove(match.Index, input.Length);
                    currentMolecule = currentMolecule.Insert(match.Index, output);

                    if (!permutations.Contains(currentMolecule))
                    {
                        permutations.Add(currentMolecule);
                    }

                    match = match.NextMatch();
                }
            }

            return permutations;
        }

        private static int GetMoleculeSteps(List<(string, string)> replacements, string molecule)
        {
            // I was able to see the structure on paper, but could not get it a generic code solution.
            // I did not like brute forcing it, so I went to the internet for some explanation/data
            // It was fun to see a context free grammar however!
            // Based on "the internet", and reddit-user askalski:

            // e => XX, X => XX
            // X => X Rn X Ar | X Rn X Y X Ar | X Rn X Y X Y X Ar
            // X => X (X) | X (X, X) | X (X, X, X)

            // X => XX == N tokens - 1
            // X => X(X) == N tokens - ( "(" tokens + ")" tokens) - 1
            // X => X(X, X) == N tokens - ( "(" tokens + ")" tokens) - (2 * "," tokens) - 1

            // Which results in the following set:
            var elements = molecule.Count(c => char.IsUpper(c));

            var parentheses = Regex.Matches(molecule, "Rn").Count;
            parentheses += Regex.Matches(molecule, "Ar").Count;
            var commas = Regex.Matches(molecule, "Y").Count;

            // N tokens - ( "(" tokens + ")" tokens) - (2 * "," tokens) - 1
            return elements - (parentheses) - (2 * commas) - 1;
        }

        private static (List<(string, string)>, string) ParseInput(IEnumerable<string> inputLines)
        {
            var replacements = new List<(string, string)>();
            var molecule = string.Empty;

            foreach (var line in inputLines)
            {
                var items = line.Split(' ');

                if (items.Length == 1) { molecule = line; }
                else { replacements.Add((items[0], items[2])); }
            }

            return (replacements, molecule);
        }
    }
}
