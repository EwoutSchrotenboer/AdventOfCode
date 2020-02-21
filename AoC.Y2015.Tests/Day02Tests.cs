using AoC.Helpers.Utils;
using AoC.Y2015.Days;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AoC.Y2015.Tests.Days
{
    [TestClass]
    public class Day02Tests
    {
        [TestMethod]
        [DataRow("2x3x4", 58)]
        [DataRow("1x1x10", 43)]
        public void PartOneTest(string input, int expected)
        {
            // Arrange
            var target = new Day02(new string[] { input });

            // Act
            var result = target.Debug(Part.One);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow("2x3x4", 34)]
        [DataRow("1x1x10", 14)]
        public void PartTwoTest(string input, int expected)
        {
            // Arrange
            var target = new Day02(new string[] { input });

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
            var target = new Day02();

            // Act
            var result = target.Debug(Part.One);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1598415, result);
        }

        [TestMethod]
        public void PartTwo()
        {
            // Arrange
            var target = new Day02();

            // Act
            var result = target.Debug(Part.Two);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(3812909, result);
        }
    }
}
