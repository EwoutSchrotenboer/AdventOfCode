using AoC.Helpers.Utils;
using AoC.Y2019.Days;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace AoC.Y2019.Tests.Days
{
    [TestClass]
    public class Day19Tests
    {
        [TestMethod]
        public void PartOne()
        {
            // Arrange
            var target = new Day19();

            // Act
            var result = target.Debug(Part.One);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(194, result);
        }

        [TestMethod]
        public void PartTwo()
        {
            // Arrange
            var target = new Day19();

            // Act
            var result = target.Debug(Part.Two);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(10110555, result);
        }
    }
}
