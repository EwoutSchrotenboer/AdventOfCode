using AoC.Helpers.Utils;
using AoC.Y2017.Days;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AoC.Y2017.Tests.Days
{
    [TestClass]
    public class Day20Tests
    {
        [TestMethod]
        [DataRow(new string[] { "p=< 3,0,0>, v=< 2,0,0>, a=<-1,0,0>", "p=< 4,0,0>, v=< 0,0,0>, a=<-2,0,0>" }, 0)]
        public void PartOneTest(string[] input, int expected)
        {
            // Arrange
            var target = new Day20(input);

            // Act
            var result = target.Debug(Part.One);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow(new string[] { "p=<-6,0,0>, v=< 3,0,0>, a=< 0,0,0>", "p=<-4,0,0>, v=< 2,0,0>, a=< 0,0,0>", "p=<-2,0,0>, v=< 1,0,0>, a=< 0,0,0>", "p=< 3,0,0>, v=<-1,0,0>, a=< 0,0,0>" }, 1)]
        public void PartTwoTest(string[] input, int expected)
        {
            // Arrange
            var target = new Day20(input);

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
            var target = new Day20();

            // Act
            var result = target.Debug(Part.One);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(157, result);
        }

        [TestMethod]
        public void PartTwo()
        {
            // Arrange
            var target = new Day20();

            // Act
            var result = target.Debug(Part.Two);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(499, result);
        }
    }
}
