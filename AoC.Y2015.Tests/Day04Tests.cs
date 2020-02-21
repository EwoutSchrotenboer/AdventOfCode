using AoC.Helpers.Utils;
using AoC.Y2015.Days;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AoC.Y2015.Tests.Days
{
    [TestClass]
    public class Day04Tests
    {
        [TestMethod]
        [DataRow("abcdef", 609043)]
        [DataRow("pqrstuv", 1048970)]
        public void PartOneTest(string input, int expected)
        {
            // Arrange
            var target = new Day04(new string[] { input });

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
            var target = new Day04();

            // Act
            var result = target.Debug(Part.One);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(254575, result);
        }

        [TestMethod]
        public void PartTwo()
        {
            // Arrange
            var target = new Day04();

            // Act
            var result = target.Debug(Part.Two);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1038736, result);
        }
    }
}
