using AoC.Helpers.Utils;
using AoC.Y2015.Days;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AoC.Y2015.Tests.Days
{
    [TestClass]
    public class Day11Tests
    {
        [TestMethod]
        public void PartOne()
        {
            // Arrange
            var target = new Day11();

            // Act
            var result = target.Debug(Part.One);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("hxbxxyzz", result);
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
            Assert.AreEqual("hxcaabcc", result);
        }
    }
}
