using AoC.Helpers.Utils;
using AoC.Y2017.Days;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AoC.Y2017.Tests.Days
{
    [TestClass]
    public class Day24Tests
    {
        [TestMethod]
        [DataRow(new string[] { "0/2", "2/2", "2/3", "3/4", "3/5", "0/1", "10/1", "9/10" }, 31)]
        public void PartOneTest(string[] input, int expected)
        {
            // Arrange
            var target = new Day24(input);

            // Act
            var result = target.Debug(Part.One);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow(new string[] { "0/2", "2/2", "2/3", "3/4", "3/5", "0/1", "10/1", "9/10" }, 19)]
        public void PartTwoTest(string[] input, int expected)
        {
            // Arrange
            var target = new Day24(input);

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
            var target = new Day24();

            // Act
            var result = target.Debug(Part.One);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1868, result);
        }

        [TestMethod]
        public void PartTwo()
        {
            // Arrange
            var target = new Day24();

            // Act
            var result = target.Debug(Part.Two);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1841, result);
        }
    }
}
