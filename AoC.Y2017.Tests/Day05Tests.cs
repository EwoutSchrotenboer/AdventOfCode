using AoC.Helpers.Utils;
using AoC.Y2017.Days;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AoC.Y2017.Tests.Days
{
    [TestClass]
    public class Day05Tests
    {
        [TestMethod]
        [DataRow(new string[] { "0", "3", "0", "1", "-3" }, 5)]
        public void PartOneTest(string[] input, int expected)
        {
            // Arrange
            var target = new Day05(input);

            // Act
            var result = target.Debug(Part.One);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void PartOne()
        {
            // Arrange
            var target = new Day05();

            // Act
            var result = target.Debug(Part.One);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(359348, result);
        }

        [TestMethod]
        [DataRow(new string[] { "0", "3", "0", "1", "-3" }, 10)]
        public void PartTwoTest(string[] input, int expected)
        {
            // Arrange
            var target = new Day05(input);

            // Act
            var result = target.Debug(Part.Two);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void PartTwo()
        {
            // Arrange
            var target = new Day05();

            // Act
            var result = target.Debug(Part.Two);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(27688760, result);
        }
    }
}
