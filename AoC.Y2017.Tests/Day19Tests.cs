using AoC.Helpers.Utils;
using AoC.Y2017.Days;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AoC.Y2017.Tests.Days
{
    [TestClass]
    public class Day19Tests
    {
        [TestMethod]
        [DataRow(new string[] { "     |          ", "     |  +--+    ", "     A  |  C    ", " F---|----E|--+ ", "     |  |  |  D ", "     +B-+  +--+ " }, "ABCDEF")]
        public void PartOneTest(string[] input, string expected)
        {
            // Arrange
            var target = new Day19(input);

            // Act
            var result = target.Debug(Part.One);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow(new string[] { "     |          ", "     |  +--+    ", "     A  |  C    ", " F---|----E|--+ ", "     |  |  |  D ", "     +B-+  +--+ " }, 38)]
        public void PartTwoTest(string[] input, int expected)
        {
            // Arrange
            var target = new Day19(input);

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
            var target = new Day19();

            // Act
            var result = target.Debug(Part.One);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("AYRPVMEGQ", result);
        }

        [TestMethod]
        public void PartTwo()
        {
            // Arrange
            var target = new Day19();

            // Act
            var result = target.Debug(Part.Two);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(16408, result);
        }
    }
}
