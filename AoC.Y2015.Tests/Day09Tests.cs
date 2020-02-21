using AoC.Helpers.Utils;
using AoC.Y2015.Days;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AoC.Y2015.Tests.Days
{
    [TestClass]
    public class Day09Tests
    {
        [TestMethod]
        [DataRow(new string[] { "London to Dublin = 464","London to Belfast = 518","Dublin to Belfast = 141"}, 605)]
        public void PartOneTest(string[] input, int expected)
        {
            // Arrange
            var target = new Day09(input);

            // Act
            var result = target.Debug(Part.One);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow(new string[] { "London to Dublin = 464", "London to Belfast = 518", "Dublin to Belfast = 141" }, 982)]
        public void PartTwoTest(string[] input, int expected)
        {
            // Arrange
            var target = new Day09(input);

            // Act
            var result = target.Debug(Part.Two);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void PartOne()
        {
            // Arrange
            var target = new Day09();

            // Act
            var result = target.Debug(Part.One);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(141, result);
        }

        [TestMethod]
        public void PartTwo()
        {
            // Arrange
            var target = new Day09();

            // Act
            var result = target.Debug(Part.Two);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(736, result);
        }
    }
}
