using AoC.Helpers.Utils;
using AoC.Y2018.Days;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace AoC.Y2018.Tests.Days
{
    [TestClass]
    public class Day08Tests
    {
        private List<string> testInput = new List<string>()
        {
           "2 3 0 3 10 11 12 1 1 0 1 99 2 1 1 2"
        };

        [TestMethod]
        public void PartOneTest()
        {
            // Arrange
            var target = new Day08(testInput);

            // Act
            var result = target.Debug(Part.One);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(138, result);
        }

        [TestMethod]
        public void PartTwoTest()
        {
            // Arrange
            var target = new Day08(testInput);

            // Act
            var result = target.Debug(Part.Two);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(66, result);
        }

        [TestMethod]
        public void PartOne()
        {
            // Arrange
            var target = new Day08();

            // Act
            var result = target.Debug(Part.One);

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void PartTwo()
        {
            // Arrange
            var target = new Day08();

            // Act
            var result = target.Debug(Part.Two);

            // Assert
            Assert.IsNotNull(result);
        }
    }
}