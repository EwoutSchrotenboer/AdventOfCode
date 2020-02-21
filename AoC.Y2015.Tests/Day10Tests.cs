using AoC.Helpers.Utils;
using AoC.Y2015.Days;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AoC.Y2015.Tests.Days
{
    [TestClass]
    public class Day10Tests
    {
        [TestMethod]
        public void PartOne()
        {
            // Arrange
            var target = new Day10();

            // Act
            var result = target.Debug(Part.One);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(360154, result);
        }

        [TestMethod]
        public void PartTwo()
        {
            // Arrange
            var target = new Day10();

            // Act
            var result = target.Debug(Part.Two);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(5103798, result);
        }
    }
}
