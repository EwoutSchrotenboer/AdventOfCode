using AoC.Helpers.Utils;
using AoC.Y2017.Days;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace AoC.Y2017.Tests.Days
{
    [TestClass]
    public class Day21Tests
    {
        [TestMethod]
        public void PartOne()
        {
            // Arrange
            var target = new Day21();

            // Act
            var result = target.Debug(Part.One);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(171, result);
        }

        [TestMethod]
        public void PartTwo()
        {
            // Arrange
            var target = new Day21();

            // Act
            var result = target.Debug(Part.Two);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2498142, result);
        }
    }
}
