using AoC.Helpers.Utils;
using AoC.Y2016.Days;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AoC.Y2016.Tests.Days
{
    [TestClass]
    public class Day03Tests
    {
        [TestMethod]
        public void PartOne()
        {
            // Arrange
            var target = new Day03();

            // Act
            var result = target.Debug(Part.One);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1050, result);
        }

        [TestMethod]
        public void PartTwo()
        {
            // Arrange
            var target = new Day03();

            // Act
            var result = target.Debug(Part.Two);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1921, result);
        }
    }
}
