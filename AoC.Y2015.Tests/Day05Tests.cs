using AoC.Helpers.Utils;
using AoC.Y2015.Days;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AoC.Y2015.Tests.Days
{
    [TestClass]
    public class Day05Tests
    {
        [TestMethod]
        [DataRow("ugknbfddgicrmopn", 1)]
        [DataRow("jchzalrnumimnmhp", 0)]
        [DataRow("haegwjzuvuyypxyu", 0)]
        [DataRow("dvszwmarrgswjxmb", 0)]
        public void PartOneTest(string input, int expected)
        {
            // Arrange
            var target = new Day05(new string[] { input });

            // Act
            var result = target.Debug(Part.One);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow("qjhvhtzxzqqjkmpb", 1)]
        [DataRow("xxyxx", 1)]
        [DataRow("uurcxstgmygtbstg", 0)]
        [DataRow("ieodomkazucvgmuy", 0)]
        public void PartTwoTest(string input, int expected)
        {
            // Arrange
            var target = new Day05(new string[] { input });

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
            var target = new Day05();

            // Act
            var result = target.Debug(Part.One);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(238, result);
        }

        [TestMethod]
        public void PartTwo()
        {
            // Arrange
            var target = new Day05();

            // Act
            var result = target.Debug(Part.Two);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(69, result);
        }
    }
}
