using AoC.Helpers.Utils;
using AoC.Y2018.Days;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace AoC.Y2018.Tests.Days
{
    [TestClass]
    public class Day14Tests
    {
        private List<string> testInput = new List<string>()
            {
            };

        [TestMethod]
        [DataRow(5, "0124515891")]
        [DataRow(9, "5158916779")]
        [DataRow(18, "9251071085")]
        [DataRow(2018, "5941429882")]
        public void PartOneTest(int input, string output)
        {
            // Arrange
            var target = new Day14(new List<string>() { input.ToString() });

            // Act
            var result = target.Debug(Part.One);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(output, result);
        }

        [TestMethod]
        [DataRow("01245", 5)]
        [DataRow("51589", 9)]
        [DataRow("92510", 18)]
        [DataRow("59414", 2018)]
        public void PartTwoTest(string input, int output)
        {
            // Arrange
            var target = new Day14(new List<string>() { input });

            // Act
            var result = target.Debug(Part.Two);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(output, result);
        }

        [TestMethod]
        public void PartOne()
        {
            // Arrange
            var target = new Day14();

            // Act
            var result = target.Debug(Part.One);

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void PartTwo()
        {
            // Arrange
            var target = new Day14();

            // Act
            var result = target.Debug(Part.Two);

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
