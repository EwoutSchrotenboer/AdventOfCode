using AoC.Helpers.Utils;
using AoC.Y2019.Days;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace AoC.Y2019.Tests.Days
{
    [TestClass]
    public class Day17Tests
    {
        [TestMethod]
        public void PartOneTest()
        {
            // Arrange
            var target = new Day17();

            // Act
            var result = target.Debug(Part.One);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(5620, result);
        }

        [TestMethod]
        public void PartTwoTest()
        {
            // Arrange
            var target = new Day17();

            // Act
            var result = target.Debug(Part.Two);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual((long)768115, result);
        }
    }
}
