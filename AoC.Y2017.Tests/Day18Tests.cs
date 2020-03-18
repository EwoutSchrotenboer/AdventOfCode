using AoC.Helpers.Utils;
using AoC.Y2017.Days;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AoC.Y2017.Tests.Days
{
    [TestClass]
    public class Day18Tests
    {
        [TestMethod]
        [DataRow(new string[] { "set a 1", "add a 2", "mul a a", "mod a 5", "snd a", "set a 0", "rcv a", "jgz a -1", "set a 1", "jgz a -2" }, 4)]
        public void PartOneTest(string[] input, long expected)
        {
            // Arrange
            var target = new Day18(input);

            // Act
            var result = target.Debug(Part.One);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow(new string[] { "snd 1", "snd 2", "snd p", "rcv a", "rcv b", "rcv c", "rcv d" }, 3)]
        public void PartTwoTest(string[] input, int expected)
        {
            // Arrange
            var target = new Day18(input);

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
            var target = new Day18();

            // Act
            var result = target.Debug(Part.One);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(8600L, result);
        }

        [TestMethod]
        public void PartTwo()
        {
            // Arrange
            var target = new Day18();

            // Act
            var result = target.Debug(Part.Two);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(7239, result);
        }
    }
}
