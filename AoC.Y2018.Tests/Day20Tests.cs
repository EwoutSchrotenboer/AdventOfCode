using AoC.Helpers.Utils;
using AoC.Y2018.Days;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
namespace AoC.Y2018.Tests.Days
{
    [TestClass]
    public class Day20Tests
    {
        private List<string> testInput = new List<string>()
            {
            };

        [TestMethod]
        public void PartOneTest()
        {
            // Arrange
            var target = new Day20();

            // Act
            var result = target.Debug(Part.One);

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void PartTwoTest()
        {
            // Arrange
            var target = new Day20();

            // Act
            var result = target.Debug(Part.Two);

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
