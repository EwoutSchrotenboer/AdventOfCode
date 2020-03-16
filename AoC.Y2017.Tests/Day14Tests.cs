using AoC.Helpers.Utils;
using AoC.Y2017.Days;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AoC.Y2017.Tests.Days
{
    [TestClass]
    public class Day14Tests
    {
        [TestMethod]
        [DataRow("flqrgnkx", 8108)]
        public void PartOneTest(string input, int expected)
        {
            // Arrange
            var target = new Day14(new string[] { input });

            // Act
            var result = target.Debug(Part.One);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow("flqrgnkx", 1242)]
        public void PartTwoTest(string input, int expected)
        {
            // Arrange
            var target = new Day14(new string[] { input });

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
            var target = new Day14();

            // Act
            var result = target.Debug(Part.One);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(8316, result);
        }

        [TestMethod]
        public void PartTwo()
        {
            // Arrange
            var target = new Day14();

            // Act
            var result = target.Debug(Part.Two);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1074, result);
        }
    }
}
