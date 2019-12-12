using AoC.Helpers.Utils;
using AoC.Y2019.Days;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace AoC.Y2019.Tests.Days
{
    [TestClass]
    public class Day10Tests
    {
        private List<string> input = new List<string>()
        {
        };

        [TestMethod]
        [DataRow(new string[] { ".#..#", ".....", "#####", "....#", "...##" }, 8)]
        [DataRow(new string[] { "......#.#.", "#..#.#....", "..#######.", ".#.#.###..", ".#..#.....", "..#....#.#", "#..#....#.", ".##.#..###", "##...#..#.", ".#....####" }, 33)]
        [DataRow(new string[] { "#.#...#.#.", ".###....#.", ".#....#...", "##.#.#.#.#", "....#.#.#.", ".##..###.#", "..#...##..", "..##....##", "......#...", ".####.###." }, 35)]
        [DataRow(new string[] { ".#..#..###", "####.###.#", "....###.#.", "..###.##.#", "##.##.#.#.", "....###..#", "..#.#..#.#", "#..#.#.###", ".##...##.#", ".....#.#.." }, 41)]
        [DataRow(new string[] { ".#..##.###...#######", "##.############..##.", ".#.######.########.#", ".###.#######.####.#.", "#####.##.#.##.###.##", "..#####..#.#########", "####################", "#.####....###.#.#.##", "##.#################", "#####.##.###..####..", "..######..##.#######", "####.##.####...##..#", ".#####..#.######.###", "##...#.##########...", "#.##########.#######", ".####.#.###.###.#.##", "....##.##.###..#####", ".#.#.###########.###", "#.#.#.#####.####.###", "###.##.####.##.#..##" }, 210)]
        public void PartOneTest(string[] input, int expected)
        {
            // Arrange
            var target = new Day10(input.ToList());

            // Act

            var result = target.Debug(Part.One);

            // Assert

            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void PartTwoTest()
        {
            // Arrange
            var target = new Day10();

            // Act

            var result = target.Debug(Part.Two);

            // Assert

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void PartOne()
        {
            // Arrange
            var target = new Day10();

            // Act

            var result = target.Debug(Part.One);

            // Assert

            Assert.IsNotNull(result);
        }
    }
}
