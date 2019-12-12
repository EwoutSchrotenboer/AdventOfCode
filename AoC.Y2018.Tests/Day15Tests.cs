using AoC.Helpers.Utils;
using AoC.Y2018.Days;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace AoC.Y2018.Tests.Days
{
    [TestClass]
    public class Day15Tests
    {
        private List<string> testInput = new List<string>()
            {
                "#######",
                "#.G...#",
                "#...EG#",
                "#.#.#G#",
                "#..G#E#",
                "#.....#",
                "#######",
            };

        [TestMethod]
        public void PartOneTest()
        {
            // Arrange
            var target = new Day15(testInput);

            // Act
            var result = target.Debug(Part.One);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(27730, result);
        }

        [TestMethod]
        public void PartTwoTest()
        {
            // Arrange
            var target = new Day15();

            // Act
            var result = target.Debug(Part.Two);

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void PartOne()
        {
            // Arrange
            var target = new Day15();

            // Act
            var result = target.Debug(Part.One);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(208960, result);
        }

        [TestMethod]
        public void PartTwo()
        {
            // Arrange
            var target = new Day15();

            // Act
            var result = target.Debug(Part.Two);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(49863, result);
        }
    }
}
