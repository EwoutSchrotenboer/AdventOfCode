using AoC.Helpers.Utils;
using AoC.Y2015.Days;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AoC.Y2015.Tests.Days
{
    [TestClass]
    public class Day01Tests
    {
        [TestMethod]
        [DataRow("(())", 0)]
        [DataRow("()()", 0)]
        [DataRow("(((", 3)]
        [DataRow("(()(()(", 3)]
        [DataRow("))(((((", 3)]
        [DataRow("())", -1)]
        [DataRow("))(", -1)]
        [DataRow(")))", -3)]
        [DataRow(")())())", -3)]
        public void PartOneTest(string input, int expected)
        {
            // Arrange
            var target = new Day01(new string[] { input });

            // Act
            var result = target.Debug(Part.One);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow(")", 1)]
        [DataRow("()())", 5)]
        public void PartTwoTest(string input, int expected)
        {
            // Arrange
            var target = new Day01(new string[] { input });

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
            var target = new Day01();

            // Act
            var result = target.Debug(Part.One);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(280, result);
        }

        [TestMethod]
        public void PartTwo()
        {
            // Arrange
            var target = new Day01();

            // Act
            var result = target.Debug(Part.Two);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1797, result);
        }
    }
}
