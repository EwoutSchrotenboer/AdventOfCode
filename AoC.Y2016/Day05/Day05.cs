using AoC.Helpers.Days;
using AoC.Helpers.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AoC.Y2016.Days
{
    public class Day05 : BaseDay
    {
        public Day05() : base(2016, 5)
        {
        }

        public Day05(IEnumerable<string> inputLines) : base(2016, 5, inputLines)
        {
        }

        protected override IConvertible PartOne() => GetPassword(inputLines.Single(), true);

        protected override IConvertible PartTwo() => GetPassword(inputLines.Single(), false);

        private static string GetPassword(string input, bool staticPosition)
        {
            var md5 = MD5.Create();
            var num = 0;
            var password = new char[8];
            var charactersFound = 0;

            while (charactersFound < 8)
            {
                var inputBytes = Encoding.ASCII.GetBytes(input + num);
                var hash = md5.ComputeHash(inputBytes);

                if ((hash[0] == 0) && (hash[1] == 0) && (hash[2] >> 4 & 0xF) == 0)
                {
                    if (staticPosition)
                    {
                        password[charactersFound] = hash[2].ToString("x2")[1];
                        charactersFound++;
                    }
                    else if (hash[2] >= 0 && hash[2] < 8 && password[hash[2]] == '\0')
                    {
                        password[hash[2]] = hash[3].ToString("x2")[0];
                        charactersFound++;
                    }
                }

                num++;
            }

            return new string(password);
        }
    }
}
