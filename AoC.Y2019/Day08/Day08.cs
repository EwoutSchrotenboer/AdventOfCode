using AoC.Helpers.Days;
using AoC.Helpers.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AoC.Y2019.Days
{
    public class Day08 : BaseDay
    {
        public Day08() : base(2019, 8)
        {
        }

        public Day08(IEnumerable<string> inputLines) : base(2019, 8, inputLines)
        {
        }

        protected override IConvertible PartOne()
        {
            var width = 25;
            var height = 6;

            var values = ParseInput(inputLines);
            var layersData = GetLayersData(values, width * height);

            var leastZeroes = layersData.OrderBy(l => l.Count(p => p == 0)).First();

            return leastZeroes.Count(p => p == 1) * leastZeroes.Count(p => p == 2);     
        }

        protected override IConvertible PartTwo()
        {
            var width = 25;
            var height = 6;
            var values = ParseInput(inputLines);
            var layers = GetLayers(values, width, height);
            var imageLayer = GetImage(layers, width, height);
            PrintImage(imageLayer, width, height);
            return "Image output";
        }

        private static List<List<int>> GetLayersData(List<int> values, int splitSize)
        {
            var layers = new List<List<int>>();

            for (int i = 0; i < values.Count; i += splitSize)
            {
                layers.Add(values.GetRange(i, Math.Min(splitSize, values.Count - i)));
            }

            return layers;
        }

        private void PrintImage(char[,] imageData, int width, int height)
        {
            var imageLines = new List<string>();

            for (int i = 0; i < height; i++)
            {
                var sb = new StringBuilder();
                for (int j = 0; j < width; j++)
                {
                    sb.Append(imageData[i, j]);
                }

                imageLines.Add(sb.ToString());
            }

            Console.WriteLine("Y2019 Day 8 Part Two visual:");
            foreach (var imageLine in imageLines)
            {
                Console.WriteLine(imageLine);
            }
        }

        private static char[,] GetImage(List<int[,]> layers, int width, int height)
        {
            var imageLayer = InitImageLayer(width, height);

            foreach (var layer in layers)
            {
                for (int yPos = 0; yPos < height; yPos++)
                {
                    for (int xPos = 0; xPos < width; xPos++)
                    {
                        if (imageLayer[yPos, xPos] == '.' && layer[yPos, xPos] != 2)
                        {
                            imageLayer[yPos, xPos] = layer[yPos, xPos] == 0 ? ' ' : '█';
                        }
                    }
                }
            }

            return imageLayer;
        }

        private static List<int[,]> GetLayers(List<int> values, int width, int height)
        {
            var layers = new List<int[,]>();

            var index = 0;

            while (index < values.Count)
            {
                var layer = new int[height, width];

                for (int yPos = 0; yPos < height; yPos++)
                {
                    for (int xPos = 0; xPos < width; xPos++)
                    {
                        layer[yPos, xPos] = values[index];
                        index++;
                    }
                }

                layers.Add(layer);
            }

            return layers;
        }

        private static char[,] InitImageLayer(int width, int height)
        {
            var finalLayer = new char[height, width];

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    finalLayer[i, j] = '.';
                }
            }

            return finalLayer;
        }

        private static List<int> ParseInput(IEnumerable<string> input)
        {
            var first = input.First();
            var values = new List<int>();

            foreach (var character in first)
            {
                values.Add((int)char.GetNumericValue(character));
            }

            return values;
        }
    }
}