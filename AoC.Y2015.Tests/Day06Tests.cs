using AoC.Helpers.Utils;
using AoC.Y2015.Days;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AoC.Y2015.Tests.Days
{
    [TestClass]
    public class Day06Tests
    {
        [TestMethod]
        [DataRow("turn on 0,0 through 999,999", 1_000_000)]
        [DataRow("toggle 0,0 through 999,0", 1000)]
        [DataRow("turn off 499,499 through 500,500", 0)]
        public void PartOneTest(string input, int expected)
        {
            // Arrange
            var target = new Day06(new string[] { input });

            // Act
            var result = target.Debug(Part.One);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        [DataRow("turn on 0,0 through 0,0", 1)]
        [DataRow("toggle 0,0 through 999,999", 2_000_000)]
        public void PartTwoTest(string input, int expected)
        {
            // Arrange
            var target = new Day06(new string[] { input });

            // Act
            var result = target.Debug(Part.Two);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result, expected);
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
            Assert.AreEqual(569999, result);
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
            Assert.AreEqual(17836115, result);
        }
    }
}
