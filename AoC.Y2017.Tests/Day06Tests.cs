using AoC.Helpers.Utils;
using AoC.Y2017.Days;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AoC.Y2017.Tests.Days
{
    [TestClass]
    public class Day06Tests
    {
        [TestMethod]
        [DataRow(new string[] { "0\t2\t7\t0" }, 5)]
        public void PartOneTest(string[] input, int expected)
        {
            // Arrange
            var target = new Day06(input);

            // Act
            var result = target.Debug(Part.One);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow(new string[] { "0\t2\t7\t0" }, 4)]
        public void PartTwoTest(string[] input, int expected)
        {
            // Arrange
            var target = new Day06(input);

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
            var target = new Day06();

            // Act
            var result = target.Debug(Part.One);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(5042, result);
        }

        [TestMethod]
        public void PartTwo()
        {
            // Arrange
            var target = new Day06();

            // Act
            var result = target.Debug(Part.Two);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1086, result);
        }
    }
}
