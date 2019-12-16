using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC.Helpers.Utils
{
    public static partial class Extensions
    {
        public static IEnumerable<int> GetNumbers(this string input) => input.Select(s => int.Parse(s.ToString()));
        
        public static IEnumerable<int> GetNumbers(this string input, char separator) => input.Split(separator, StringSplitOptions.RemoveEmptyEntries).Select(i => int.Parse(i));

        public static int GetPart(this string instruction, int skip, int take) => int.Parse(string.Concat(instruction.Skip(skip).Take(take)));

        public static string RemoveChar(this string value, char remove)
        {
            return value.Replace(remove.ToString(), string.Empty);
        }

        public static string RemoveChars(this string value, char[] remove)
        {
            foreach (var removeChar in remove)
            {
                value = value.Replace(removeChar.ToString(), string.Empty);
            }

            return value;
        }

        public static string ReplaceAt(this string input, int index, char newChar)
        {
            char[] chars = input.ToCharArray();
            chars[index] = newChar;
            return new string(chars);
        }

        public static List<string> SingleItemList(this string value)
        {
            return new List<string>(1) { value };
        }
    }
}