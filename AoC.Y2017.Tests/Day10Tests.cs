using AoC.Helpers.Utils;
using AoC.Y2017.Days;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AoC.Y2017.Tests.Days
{
    [TestClass]
    public class Day10Tests
    {
        [TestMethod]
        [DataRow("3,4,1,5", 12)]
        public void PartOneTest(string input, int expected)
        {
            // Arrange
            var target = new Day10(new string[] { input });

            // Act
            var result = target.Debug(Part.One);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow("", "a2582a3a0e66e6e86e3812dcb672a272")]
        [DataRow("AoC 2017", "33efeb34ea91902bb2f59c9920caa6cd")]
        [DataRow("1,2,3", "3efbe78a8d82f29979031a4aa0b16a9d")]
        [DataRow("1,2,4", "63960835bcdc130f0b66d7ff4f6a5a8e")]
        public void PartTwoTest(string input, string expected)
        {
            // Arrange
            var target = new Day10(new string[] { input });

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
            var target = new Day10();

            // Act
            var result = target.Debug(Part.One);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(54675, result);
        }

        [TestMethod]
        public void PartTwo()
        {
            // Arrange
            var target = new Day10();

            // Act
            var result = target.Debug(Part.Two);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("a7af2706aa9a09cf5d848c1e6605dd2a", result);
        }
    }
}
