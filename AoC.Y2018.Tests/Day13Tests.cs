using AoC.Helpers.Utils;
using AoC.Y2018.Days;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace AoC.Y2018.Tests.Days
{
    [TestClass]
    public class Day13Tests
    {
        private List<string> testInput1 = new List<string>()
            {
            @"/->-\        ",
            @"|   |  /----\",
            @"| /-+--+-\  |",
            @"| | |  | v  |",
            @"\-+-/  \-+--/",
            @"  \------/   ",
            };

        private List<string> testInput2 = new List<string>()
        {
            @"/>-<\  ",
            @"|   |  ",
            @"| /<+-\",
            @"| | | v",
            @"\>+</ |",
            @"  |   ^",
            @"  \<->/"
        };

        [TestMethod]
        public void PartOneTest()
        {
            // Arrange
            var target = new Day13(testInput1);

            // Act
            var result = target.Debug(Part.One);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("7,3", result);
        }

        [TestMethod]
        public void PartTwoTest()
        {
            // Arrange
            var target = new Day13(testInput2);

            // Act
            var result = target.Debug(Part.Two);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("6,4", result);
        }

        [TestMethod]
        public void PartOne()
        {
            // Arrange
            var target = new Day13();

            // Act
            var result = target.Debug(Part.One);

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void PartTwo()
        {
            // Arrange
            var target = new Day13();

            // Act
            var result = target.Debug(Part.Two);

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
