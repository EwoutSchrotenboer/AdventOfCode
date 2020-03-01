using AoC.Helpers.Utils;
using AoC.Y2016.Days;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AoC.Y2016.Tests.Days
{
    [TestClass]
    public class Day12Tests
    {
        [TestMethod]
        [DataRow(new string[] { "cpy 41 a", "inc a", "inc a", "dec a", "jnz a 2", "dec a" }, 42)]
        public void PartOneTest(string[] input, int expected)
        {
            // Arrange
            var target = new Day12(input);

            // Act
            var result = target.Debug(Part.One);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void PartOne()
        {
            // Arrange
            var target = new Day12();

            // Act
            var result = target.Debug(Part.One);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(318007, result);
        }

        [TestMethod]
        public void PartTwo()
        {
            // Arrange
            var target = new Day12();

            // Act
            var result = target.Debug(Part.Two);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(9227661, result);
        }
    }
}
