using AoC.Helpers.Utils;
using AoC.Y2015.Days;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AoC.Y2015.Tests.Days
{
    [TestClass]
    public class Day03Tests
    {
        [TestMethod]
        [DataRow(">", 2)]
        [DataRow("^>v<", 4)]
        [DataRow("^v^v^v^v^v", 2)]
        public void PartOneTest(string input, int expected)
        {
            // Arrange
            var target = new Day03(new string[] { input });

            // Act
            var result = target.Debug(Part.One);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow("^v", 3)]
        [DataRow("^>v<", 3)]
        [DataRow("^v^v^v^v^v", 11)]
        public void PartTwoTest(string input, int expected)
        {
            // Arrange
            var target = new Day03(new string[] { input });

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
            var target = new Day03();

            // Act
            var result = target.Debug(Part.One);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2592, result);
        }

        [TestMethod]
        public void PartTwo()
        {
            // Arrange
            var target = new Day03();

            // Act
            var result = target.Debug(Part.Two);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2360, result);
        }
    }
}
