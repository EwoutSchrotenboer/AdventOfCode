using AoC.Helpers.Utils;
using AoC.Y2019.Days;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AoC.Y2019.Tests.Days
{
    [TestClass]
    public class Day13Tests
    {
        [TestMethod]
        public void PartOne()
        {
            // Arrange
            var target = new Day13();

            // Act
            var result = target.Debug(Part.One);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(284, result);
        }

        [TestMethod]
        public void PartTwo()
        {
            // Arrange
            var target = new Day13();

            // Act
            var result = target.Debug(Part.Two);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(13581, result);
        }
    }
}