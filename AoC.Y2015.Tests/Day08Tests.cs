using AoC.Helpers.Utils;
using AoC.Y2015.Days;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AoC.Y2015.Tests.Days
{
    [TestClass]
    public class Day08Tests
    {
        [TestMethod]
        public void PartOne()
        {
            // Arrange
            var target = new Day08();

            // Act
            var result = target.Debug(Part.One);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1342, result);
        }

        [TestMethod]
        public void PartTwo()
        {
            // Arrange
            var target = new Day08();

            // Act
            var result = target.Debug(Part.Two);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2074, result);
        }
    }
}
