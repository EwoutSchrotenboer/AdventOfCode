using AoC.Helpers.Utils;
using AoC.Y2018.Days;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace AoC.Y2018.Tests.Days
{
    [TestClass]
    public class Day03Tests
    {
        private List<string> testInput = new List<string>()
            {
                "#1 @ 1,3: 4x4",
                "#2 @ 3,1: 4x4",
                "#3 @ 5,5: 2x2"
            };

        [TestMethod]
        public void PartOneTest()
        {
            // Arrange
            var target = new Day03();

            // Act
            var result = target.Execute(Part.One);

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void PartTwoTest()
        {
            // Arrange
            var target = new Day03();

            // Act
            var result = target.Execute(Part.Two);

            // Assert
            Assert.IsNotNull(result);
        }
    }
}