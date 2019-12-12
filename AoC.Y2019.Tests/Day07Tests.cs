using AoC.Helpers.Utils;
using AoC.Y2019.Days;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace AoC.Y2019.Tests.Days
{
    [TestClass]
    public class Day07Tests
    {


        [TestMethod]
        [DataRow("3,15,3,16,1002,16,10,16,1,16,15,15,4,15,99,0,0", 43210)]
        [DataRow("3,23,3,24,1002,24,10,24,1002,23,-1,23,101,5,23,23,1,24,23,23,4,23,99,0,0", 54321)]
        [DataRow("3,31,3,32,1002,32,10,32,1001,31,-2,31,1007,31,0,33,1002,33,7,33,1,33,31,31,1,32,31,31,4,31,99,0,0,0", 65210)]
        public void PartOneTest(string input, long value)
        {
            // Arrange
            var target = new Day07(new List<string>() { input });

            // Act

            var result = target.Debug(Part.One);

            // Assert

            Assert.IsNotNull(result);
            Assert.AreEqual(value, result);
        }

        [TestMethod]
        public void PartTwoTest()
        {
            // Arrange
            var target = new Day07();

            // Act

            var result = target.Debug(Part.Two);

            // Assert

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void PartOne()
        {
            // Arrange
            var target = new Day07();

            // Act

            var result = target.Debug(Part.One);

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void PartTwo()
        {
            // Arrange
            var target = new Day07();

            // Act

            var result = target.Debug(Part.Two);

            // Assert

            Assert.IsNotNull(result);
        }
    }
}