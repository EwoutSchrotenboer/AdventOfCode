using AoC.Helpers.Utils;
using AoC.Y2019.Days;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace AoC.Y2019.Tests.Days
{
    [TestClass]
    public class Day21Tests
    {
        private List<string> testInput = new List<string>()
            {
            };

        [TestMethod]
        public void PartOne()
        {
            // Arrange
            var target = new Day21();

            // Act
            var result = target.Debug(Part.One);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(19359996, result);
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
            Assert.AreEqual(1143330711, result);
        }
    }
}
