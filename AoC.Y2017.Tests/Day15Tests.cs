using AoC.Helpers.Utils;
using AoC.Y2017.Days;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AoC.Y2017.Tests.Days
{
    [TestClass]
    public class Day15Tests
    {
        [TestMethod]
        [DataRow(new string[] { "Generator A starts with 65", "Generator B starts with 8921" }, 588)]
        public void PartOneTest(string[] input, int expected)
        {
            // Arrange
            var target = new Day15(input);

            // Act
            var result = target.Debug(Part.One);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow(new string[] { "Generator A starts with 65", "Generator B starts with 8921" }, 309)]
        public void PartTwoTest(string[] input, int expected)
        {
            // Arrange
            var target = new Day15(input);

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
            var target = new Day15();

            // Act
            var result = target.Debug(Part.One);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(612, result);
        }

        [TestMethod]
        public void PartTwo()
        {
            // Arrange
            var target = new Day15();

            // Act
            var result = target.Debug(Part.Two);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(285, result);
        }
    }
}
