using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace AoC.Helpers.Utils
{
    public static class Letters
    {
        public static string ParseLetters(Dictionary<Point, int> points)
        {
            var (minPos, maxPos) = points.Keys.GetDimensions();

            var output = new List<string>();

            for (int yPos = minPos.Y; yPos <= maxPos.Y; yPos++)
            {
                var sb = new StringBuilder();
                for (int xPos = minPos.X; xPos <= maxPos.X; xPos++)
                {
                    var pos = new Point(xPos, yPos);
                    sb.Append(points.ContainsKey(pos) ? points[pos] : 0);
                }

                output.Add(sb.ToString());
            }

            return ParseLetters(output);
        }

        public static string ParseLetters(List<string> input)
        {
            var letters = new List<string>();

            foreach (var line in input)
            {
                for (int i = 0; i < line.Length / 5; i++)
                {
                    if (letters.Count <= i)
                    {
                        letters.Add(string.Empty);
                    }

                    letters[i] += new string(line.Skip(i * 5).Take(4).ToArray());
                }
            }

            var output = string.Empty;

            foreach (var letter in letters)
            {
                var outputLetter = GetLetter(letter);

                if (!string.IsNullOrEmpty(outputLetter))
                {
                    output += outputLetter;
                }
            }

            return output.Trim();
        }


        // Expand when more letters are known
        private static string GetLetter(string letterString) =>
            letterString switch
            {
                "011010011001111110011001" => "A",
                "111010011110100110011110" => "B",
                "011010011000100010010110" => "C",
                "111110001110100010001111" => "E",
                "111110001110100010001000" => "F",
                "011010011000101110010111" => "G",
                "100110011111100110011001" => "H",
                "001100010001000110010110" => "J",
                "100110101100101010101001" => "K",
                "111010011001111010001000" => "P",
                "111010011001111010101001" => "R",
                "011110001000011000011110" => "S",
                "100110011001100110010110" => "U",
                "111100010010010010001111" => "Z",
                _ => ""
            };
    }
}
