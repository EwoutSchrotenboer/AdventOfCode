using AoC.Helpers.Utils;
using AoC.Y2017.Days;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AoC.Y2017.Tests.Days
{
    [TestClass]
    public class Day04Tests
    {
        [TestMethod]
        [DataRow("aa bb cc dd ee", 1)]
        [DataRow("aa bb cc dd aa", 0)]
        [DataRow("aa bb cc dd aaa", 1)]
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
        [DataRow("abcde fghij", 1)]
        [DataRow("abcde xyz ecdab", 0)]
        [DataRow("a ab abc abd abf abj", 1)]
        [DataRow("iiii oiii ooii oooi oooo", 1)]
        [DataRow("oiii ioii iioi iiio", 0)]
        public void PartTwoTest(string input, int expected)
        {
            // Arrange
            var target = new Day04(new string[] { input });

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
            var target = new Day04();

            // Act
            var result = target.Debug(Part.One);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(451, result);
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
            Assert.AreEqual(223, result);
        }
    }
}
