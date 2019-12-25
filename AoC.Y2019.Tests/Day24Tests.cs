using AoC.Helpers.Utils;
using AoC.Y2019.Days;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace AoC.Y2019.Tests.Days
{
    [TestClass]
    public class Day24Tests
    {

        [TestMethod]
        [DataRow(new string[] { "....#", "#..#.", "#..##", "..#..", "#...." }, 2129920)]
        public void PartOneTest(string[] input, long expected)
        {
            // Arrange
            var target = new Day24(input);

            // Act
            var result = target.Debug(Part.One);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void PartTwoTest()
        {
            // Arrange
            var target = new Day24();

            // Act

            var result = target.Debug(Part.Two);

            // Assert

            Assert.IsNotNull(result);
            Assert.AreEqual(1959, result);
        }

        [TestMethod]
        public void PartOne()
        {
            // Arrange
            var target = new Day24();

            // Act
            var result = target.Debug(Part.One);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual((long)18375063, result);
        }
    }
}
