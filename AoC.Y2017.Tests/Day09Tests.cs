using AoC.Helpers.Utils;
using AoC.Y2017.Days;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AoC.Y2017.Tests.Days
{
    [TestClass]
    public class Day09Tests
    {
        [TestMethod]
        [DataRow("{}", 1)]
        [DataRow("{{{}}}", 6)]
        [DataRow("{{},{}}", 5)]
        [DataRow("{{{},{},{{}}}}", 16)]
        [DataRow("{<a>,<a>,<a>,<a>}", 1)]
        [DataRow("{{<ab>},{<ab>},{<ab>},{<ab>}}", 9)]
        [DataRow("{{<!!>},{<!!>},{<!!>},{<!!>}}", 9)]
        [DataRow("{{<a!>},{<a!>},{<a!>},{<ab>}}", 3)]
        public void PartOneTest(string input, int expected)
        {
            // Arrange
            var target = new Day09(new string[] { input });

            // Act
            var result = target.Debug(Part.One);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow("{<>}", 0)]
        [DataRow("{<random characters>}", 17)]
        [DataRow("{<<<<>,}", 3)]
        [DataRow("{<{!>}>}", 2)]
        [DataRow("{<!!>}", 0)]
        [DataRow("{<!!!>>}", 0)]
        [DataRow("{<{o\"i!a,<{i<a>}", 10)]
        public void PartTwoTest(string input, int expected)
        {
            // Arrange
            var target = new Day09(new string[] { input });

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
            Assert.AreEqual(10820, result);
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
            Assert.AreEqual(5547, result);
        }
    }
}
