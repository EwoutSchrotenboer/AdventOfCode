using AoC.Helpers.Utils;
using AoC.Y2017.Days;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AoC.Y2017.Tests.Days
{
    [TestClass]
    public class Day22Tests
    {
        [TestMethod]
        [DataRow(new string[] { "..#", "#..", "..." }, 5587)]
        public void PartOneTest(string[] input, int expected)
        {
            // Arrange
            var target = new Day22(input);

            // Act
            var result = target.Debug(Part.One);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow(new string[] { "..#", "#..", "..." }, 2511944)]
        public void PartTwoTest(string[] input, int expected)
        {
            // Arrange
            var target = new Day22(input);

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
            var target = new Day22();

            // Act
            var result = target.Debug(Part.One);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(5259, result);
        }

        [TestMethod]
        public void PartTwo()
        {
            // Arrange
            var target = new Day22();

            // Act
            var result = target.Debug(Part.Two);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2511722, result);
        }
    }
}
