using AoC.Helpers.Utils;
using AoC.Y2017.Days;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AoC.Y2017.Tests.Days
{
    [TestClass]
    public class Day02Tests
    {
        [TestMethod]
        [DataRow(new string[] { "5\t1\t9\t5", "7\t5\t3", "2\t4\t6\t8" }, 18)]
        public void PartOneTest(string[] input, int expected)
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
        public void PartOne()
        {
            // Arrange
            var target = new Day02();

            // Act
            var result = target.Debug(Part.One);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(58975, result);
        }

        [TestMethod]
        [DataRow(new string[] { "5\t9\t2\t8", "9\t4\t7\t3", "3\t8\t6\t5" }, 9)]
        public void PartTwoTest(string[] input, int expected)
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
        public void PartTwo()
        {
            // Arrange
            var target = new Day02();

            // Act
            var result = target.Debug(Part.Two);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(308, result);
        }
    }
}
