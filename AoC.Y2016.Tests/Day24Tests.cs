using AoC.Helpers.Utils;
using AoC.Y2016.Days;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AoC.Y2016.Tests.Days
{
    [TestClass]
    public class Day24Tests
    {
        [TestMethod]
        [DataRow(new string[] { "###########", "#0.1.....2#", "#.#######.#", "#4.......3#", "###########" }, 14)]
        public void PartOneTest(string[] input, int expected)
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
        public void PartOne()
        {
            // Arrange
            var target = new Day24();

            // act
            var result = target.Debug(Part.One);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(518, result);
        }

        [TestMethod]
        public void PartTwo()
        {
            // Arrange
            var target = new Day24();

            // Act
            var result = target.Debug(Part.Two);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(716, result);
        }
    }
}
