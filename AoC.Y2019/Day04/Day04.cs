using AoC.Helpers.Days;
using AoC.Helpers.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC.Y2019.Days
{
    public class Day04 : BaseDay
    {
        public Day04() : base(2019, 4) 
        {
            
        }

        public Day04(IEnumerable<string> inputLines) : base(2019, 4, inputLines) { }

        protected override IConvertible PartOne()
        {
            var (min, max) = ParseInput(inputLines);

            return PossiblePasswords(min, max, true).Count;
        }

        protected override IConvertible PartTwo()
        {
            var (min, max) = ParseInput(inputLines);

            return PossiblePasswords(min, max, false).Count;
        }

        private static List<string> PossiblePasswords(int min, int max, bool partOne)
        {
            var passwords = new List<string>();

            for (int i = min; i <= max; i++)
            {
                var password = i.ToString();
                var containsPair = partOne ? DeterminePair(password) : DetermineUniquePair(password);
                var onlyIncreases = DetermineOnlyIncreases(password);

                if (containsPair && onlyIncreases)
                {
                    passwords.Add(password);
                }
            }

            return passwords;
        }

        private static bool DeterminePair(string password)
        {
            for (int i = 0; i < password.Length - 1; i++)
            {
                if (password[i] == password[i + 1])
                {
                    return true;
                }
            }

            return false;
        }

        private static bool DetermineUniquePair(string password)
        {
            for (int i = 0; i < password.Length - 1; i++)
            {
                var match = password[i] == password[i + 1];
                if (i >= 1)
                {
                    match &= password[i] != password[i - 1];
                }

                if (i < password.Length - 2)
                {
                    match &= password[i] != password[i + 2];
                }

                if (match) { return true; }
            }

            return false;
        }

        private static bool DetermineOnlyIncreases(string password)
        {
            for (int i = 1; i < password.Length; i++)
            {
                if ((int)char.GetNumericValue(password[i]) - (int)char.GetNumericValue(password[i - 1]) < 0)
                {
                    return false;
                }
            }
           
            return true;
        }

        private (int min, int max) ParseInput(IEnumerable<string> inputLines)
        {
            var split = inputLines.First().Split('-');

            return (int.Parse(split[0]), int.Parse(split[1]));
        }
    }
}