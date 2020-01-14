using AoC.Helpers.Utils;
using AoC.Y2015.Days;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AoC.Y2015.Tests.Days
{
    [TestClass]
    public class Day07Tests
    {
        [TestMethod]
        [DataRow(new string[] { "123 -> x", "456 -> y", "x AND y -> d", "x OR y -> e", "x LSHIFT 2 -> f", "y RSHIFT 2 -> g", "NOT x -> h", "NOT y -> i" }, 65079)]
        public void PartOneTest(string[] input, int expected)
        {
            // Arrange
            var target = new Day07(input);

            // Act
            var result = target.Debug(Part.One);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expected, (ushort)result);
        }

        [TestMethod]
        public void PartOne()
        {
            // Arrange
            var target = new Day07();

            // Act
            var result = target.Debug(Part.One);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(16076, (ushort)result);
        }

        [TestMethod]
        public void PartTwo()
        {
            // Arrange
            var target = new Day07();

            // Act
            var result = target.Debug(Part.Two);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2797, (ushort)result);
        }
    }
}
