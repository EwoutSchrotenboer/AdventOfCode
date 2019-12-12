using AoC.Helpers.Utils;
using AoC.Y2018.Days;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace AoC.Y2018.Tests.Days
{
    [TestClass]
    public class Day09Tests
    {
        private List<string> testInput = new List<string>()
            {
            };

        [TestMethod]
        [DataRow(9, 25, 32)]
        [DataRow(10, 1618, 8317)]
        [DataRow(13, 7999, 146373)]
        [DataRow(17, 1104, 2764)]
        [DataRow(21, 6111, 54718)]
        [DataRow(30, 5807, 37305)]
        public void PartOneTest(long players, long lastMarble, long expected)
        {
            // Arrange
            var input = new List<string>() { $"{players} players; last marble is worth {lastMarble} points" };
            var target = new Day09(input);

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
            var target = new Day09();

            // Act
            var result = target.Debug(Part.Two);

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void PartOne()
        {
            // Arrange
            var target = new Day09();

            // Act
            var result = target.Debug(Part.One);

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void PartTwo()
        {
            // Arrange
            var target = new Day09();

            // Act
            var result = target.Debug(Part.Two);

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
