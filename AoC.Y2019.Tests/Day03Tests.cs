using AoC.Helpers.Utils;
using AoC.Y2019.Days;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace AoC.Y2019.Tests.Days
{
    [TestClass]
    public class Day03Tests
    {
        private List<string> input = new List<string>()
        {
            "R8,U5,L5,D3",
            "U7,R6,D4,L4"
        };

        [TestMethod]
        public void PartOneTest()
        {
            // Arrange
            var target = new Day03(input);

            // Act

            var result = target.Debug(Part.One);

            // Assert

            Assert.IsNotNull(result);
            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void PartTwoTest()
        {
            // Arrange
            var target = new Day03(input);

            // Act

            var result = target.Debug(Part.Two);

            // Assert

            Assert.IsNotNull(result);
            Assert.AreEqual(40, result);
        }

        [TestMethod]
        public void PartOne()
        {
            // Arrange
            var target = new Day03();

            // Act

            var result = target.Debug(Part.One);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(293, result);
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
        }
    }
}