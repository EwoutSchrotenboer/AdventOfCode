using AoC.Helpers.Days;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC.Y2015.Days
{
    public class Day11 : BaseDay
    {
        public Day11() : base(2015, 11)
        {
        }

        public Day11(IEnumerable<string> inputLines) : base(2015, 11, inputLines)
        {
        }

        protected override IConvertible PartOne()
        {
            var currentPassword = inputLines.Single();
            return GenerateNext(currentPassword);
        }

        protected override IConvertible PartTwo()
        {
            var currentPassword = inputLines.Single();
            var nextPassword = GenerateNext(currentPassword);
            return GenerateNext(nextPassword);
        }

        private static string GenerateNext(string password)
        {
            var validPass = false;
            var nextPass = password.ToCharArray();

            while (!validPass)
            {
                nextPass = IncreasePassword(nextPass);
                validPass = ValidPassword(nextPass);
            }

            return nextPass.ToString();
        }

        private static char[] IncreasePassword(char[] nextPass)
        {
            for (int i = nextPass.Length - 1; i > 0; i--)
            {
                if (nextPass[i] >= 'z') 
                {
                    nextPass[i] = 'a';
                }
                else
                {
                    nextPass[i]++;
                    return nextPass;
                }

            }

            return nextPass;
        }

        private static bool ValidPassword(char[] password)
        {
            var increasingStraight = false;
            var firstPairChar = '0';
            var firstPairFound = false;
            var secondPairFound = false;

            if (!ValidChar(password[^1])) { return false; }

            for (int i = 0; i < password.Length - 1; i++)
            {
                if (!ValidChar(password[i])) { return false; }

                if (password[i] == password[i + 1])
                {
                    if (!firstPairFound)
                    {
                        firstPairFound = true;
                        firstPairChar = password[i];
                    }
                    else if (password[i] != firstPairChar)
                    {
                        secondPairFound = true;
                    }
                }

                if (!increasingStraight && password[i] < password.Length - 2)
                {
                    var f = password[i];
                    var s = password[i + 1];
                    var t = password[i + 2];

                    if (f == (char)(s - 1) && f == (char)(t - 2)) { increasingStraight = true; }
                }
            }

            return increasingStraight && secondPairFound;
        }

        private static bool ValidChar(char input) => input != 'i' && input != 'o' && input != 'l';
    }
}
