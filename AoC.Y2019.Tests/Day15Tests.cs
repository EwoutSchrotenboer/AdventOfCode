using AoC.Helpers.Utils;
using AoC.Y2019.Days;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace AoC.Y2019.Tests.Days
{
    [TestClass]
    public class Day15Tests
    {
        private List<string> input = new List<string>()
        {
        };

        [TestMethod]
        public void PartOne()
        {
            // Arrange
            var target = new Day15();

            // Act

            var result = target.Debug(Part.One);

            // Assert

            Assert.IsNotNull(result);
            Assert.AreEqual((long)404, result);
        }

        [TestMethod]
        public void PartTwo()
        {
            // Arrange
            var target = new Day15();

            // Act

            var result = target.Debug(Part.Two);

            // Assert

            Assert.IsNotNull(result);
            Assert.AreEqual((long)406, result);
        }
    }
}
