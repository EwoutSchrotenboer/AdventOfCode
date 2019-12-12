using AoC.Helpers.IntComputer;
using AoC.Helpers.Utils;
using AoC.Y2019.Days;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace AoC.Y2019.Tests.Days
{
    [TestClass]
    public class Day09Tests
    {
        private List<string> input = new List<string>()
        {
        };

        [TestMethod]
        public void PartOneTest()
        {
            // Arrange
            var target = new Day09();

            // Act

            var result = target.Debug(Part.One);

            // Assert

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void PartTwoTest()
        {
            // Arrange
            var target = new Day09();

            // Act

            var result = target.Debug(Part.Two);

            // Assert

            Assert.IsNotNull(result);
        }
    }
}
