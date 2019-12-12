using AoC.Helpers.Days;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AoC.Y2018.Days
{
    public class Day10 : BaseDay
    {
        public Day10() : base(2018, 10)
        {
        }

        public Day10(IEnumerable<string> inputLines) : base(2018, 10, inputLines)
        {
        }

        protected override IConvertible PartOne()
        {
            var stars = GetStars(inputLines, 10, 18, 36, 40);
            var iteration = GetClosestFrame(stars);
            SetStarTime(stars, iteration); // fastforwards the process
            PrintStars(stars);

            // visually check output
            return 10124;
        }

        protected override IConvertible PartTwo()
        {
            var stars = GetStars(inputLines, 10, 18, 36, 40);
            return GetClosestFrame(stars);

        }

        private long GetClosestFrame(List<Star> stars)
        {
            var minArea = long.MaxValue;

            var iteration = 0;
            var runNextIteration = true;

            while (runNextIteration)
            {

                SetStarTime(stars, iteration);

                var minX = stars.Min(s => s.X);
                var maxX = stars.Max(s => s.X);
                var minY = stars.Min(s => s.Y);
                var maxY = stars.Max(s => s.Y);

                var width = maxX - minX;
                var height = maxY - minY;

                if (minArea >= width * height)
                {
                    minArea = width * height;
                    iteration++;
                }
                else
                {
                    runNextIteration = false;
                }
            }

            return iteration - 1;
        }

        private static void PrintStars(List<Star> stars)
        {
            var minX = stars.Min(s => s.X);
            var maxX = stars.Max(s => s.X);
            var minY = stars.Min(s => s.Y);
            var maxY = stars.Max(s => s.Y);

            var width = maxX - minX;
            var height = maxY - minY;

            var starMap = new bool[height + 1, width + 1];

            foreach (var star in stars)
            {
                starMap[maxY - star.Y, maxX - star.X] = true;
            }

            var legibleStarmap = new List<string>();

            for (int yPos = 0; yPos <= height; yPos++)
            {
                var sb = new StringBuilder();
                for (int xPos = 0; xPos <= width; xPos++)
                {
                    sb.Append(starMap[yPos, xPos] ? '#' : '.');
                }

                // reverse output
                var lineArr = sb.ToString().ToCharArray();
                Array.Reverse(lineArr);
                legibleStarmap.Add(new string(lineArr));
            }

            legibleStarmap.Reverse();

            Console.WriteLine("Y2018 Day 10 Visual output:");
            foreach (var line in legibleStarmap)
            {
                Console.WriteLine(line);
            }
        }

        private static void SetStarTime(List<Star> stars, long iteration)
        {
            foreach (var star in stars)
            {
                star.X = star.InitialX + (iteration * star.VX);
                star.Y = star.InitialY + (iteration * star.VY);
            }
        }

        private static List<Star> GetStars(IEnumerable<string> inputLines, int posX, int posY, int posVX, int posVY)
        {
            var stars = new List<Star>();

            foreach (var line in inputLines)
            {
                var x = long.Parse(line.Substring(posX, 6).Trim());
                var y = long.Parse(line.Substring(posY, 6).Trim());
                var vx = long.Parse(line.Substring(posVX, 2).Trim());
                var vy = long.Parse(line.Substring(posVY, 2).Trim());
                var point = new Star(x, y, vx, vy);
                stars.Add(point);
            }

            return stars;
        }
    }
}