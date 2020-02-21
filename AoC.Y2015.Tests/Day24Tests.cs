using AoC.Helpers.Utils;
using AoC.Y2015.Days;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AoC.Y2015.Tests.Days
{
    [TestClass]
    public class Day24Tests
    {
        [TestMethod]
        [DataRow(new string[] { "1", "2", "3", "4", "5", "7", "8", "9", "10", "11" }, 99)]
        public void PartOneTest(string[] inputLines, long expected)
        {
            // Arrange
            var target = new Day24(inputLines);

            // Act
            var result = target.Debug(Part.One);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow(new string[] { "1", "2", "3", "4", "5", "7", "8", "9", "10", "11" }, 44)]
        public void PartTwoTest(string[] inputLines, long expected)
        {
            // Arrange
            var target = new Day24(inputLines);

            // Act
            var result = target.Debug(Part.Two);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void PartOne()
        {
            // Arrange
            var target = new Day24();

            // Act
            var result = target.Debug(Part.One);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(11266889531L, result);
        }

        [TestMethod]
        public void PartTwo()
        {
            // Arrange
            var target = new Day24();

            // Act
            var result = target.Debug(Part.Two);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(77387711L, result);
        }
    }
}
