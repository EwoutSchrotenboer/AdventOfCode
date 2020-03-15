using AoC.Helpers.Utils;
using AoC.Y2017.Days;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AoC.Y2017.Tests.Days
{
    [TestClass]
    public class Day13Tests
    {
        [TestMethod]
        [DataRow(new string[] { "0: 3", "1: 2", "4: 4", "6: 4" }, 24)]
        public void PartOneTest(string[] input, int expected)
        {
            // Arrange
            var target = new Day13(input);

            // Act
            var result = target.Debug(Part.One);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow(new string[] { "0: 3", "1: 2", "4: 4", "6: 4" }, 10)]
        public void PartTwoTest(string[] input, int expected)
        {
            // Arrange
            var target = new Day13(input);

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
            var target = new Day13();

            // Act
            var result = target.Debug(Part.One);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1580, result);
        }

        [TestMethod]
        public void PartTwo()
        {
            // Arrange
            var target = new Day13();

            // Act
            var result = target.Debug(Part.Two);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(3943252, result);
        }
    }
}
