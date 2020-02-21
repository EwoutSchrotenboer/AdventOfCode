using AoC.Helpers.Utils;
using AoC.Y2016.Days;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AoC.Y2016.Tests.Days
{
    [TestClass]
    public class Day02Tests
    {
        [TestMethod]
        [DataRow(new string[] { "ULL", "RRDDD", "LURDL", "UUUUD" }, "1985")]
        public void PartOneTest(string[] input, string expected)
        {
            // Arrange
            var target = new Day02(input);

            // Act
            var result = target.Debug(Part.One);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow(new string[] { "ULL", "RRDDD", "LURDL", "UUUUD" }, "5DB3")]
        public void PartTwoTest(string[] input, string expected)
        {
            // Arrange
            var target = new Day02(input);

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
            Assert.AreEqual("38961", result);
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
            Assert.AreEqual("46C92", result);
        }
    }
}
