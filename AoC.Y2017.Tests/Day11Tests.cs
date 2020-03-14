using AoC.Helpers.Utils;
using AoC.Y2017.Days;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AoC.Y2017.Tests.Days
{
    [TestClass]
    public class Day11Tests
    {
        [TestMethod]
        [DataRow("ne,ne,ne", 3)]
        [DataRow("ne,ne,sw,sw", 0)]
        [DataRow("ne,ne,s,s", 2)]
        [DataRow("se,sw,se,sw,sw", 3)]
        public void PartOneTest(string input, int expected)
        {
            // Arrange
            var target = new Day11(new string[] { input });

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
            var target = new Day11();

            // Act
            var result = target.Debug(Part.One);

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void PartTwo()
        {
            // Arrange
            var target = new Day11();

            // Act
            var result = target.Debug(Part.Two);

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
