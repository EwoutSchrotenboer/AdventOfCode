using AoC.Helpers.Utils;
using AoC.Y2015.Days;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AoC.Y2015.Tests.Days
{
    [TestClass]
    public class Day19Tests
    {
        [TestMethod]
        [DataRow(new string[] { "H => HO", "H => OH", "O => HH", "HOH" }, 4)]
        [DataRow(new string[] { "H => HO", "H => OH", "O => HH", "HOHOHO" }, 7)]
        public void PartOneTest(string[] input, int expected)
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
        public void PartOne()
        {
            // Arrange
            var target = new Day19();

            // Act
            var result = target.Debug(Part.One);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(576, result);
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
            Assert.AreEqual(207, result);
        }
    }
}
