using AoC.Helpers.Utils;
using AoC.Y2017.Days;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AoC.Y2017.Tests.Days
{
    [TestClass]
    public class Day01Tests
    {
        [TestMethod]
        [DataRow("1122", 3)]
        [DataRow("1111", 4)]
        [DataRow("1234", 0)]
        [DataRow("91212129", 9)]
        public void PartOneTest(string input, int expected)
        {
            // Arrange
            var target = new Day01(new string[] { input });

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
            var target = new Day01();

            // Act
            var result = target.Debug(Part.One);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1029, result);
        }

        [TestMethod]
        [DataRow("1212", 6)]
        [DataRow("1221", 0)]
        [DataRow("123425", 4)]
        [DataRow("123123", 12)]
        [DataRow("12131415", 4)]
        public void PartTwoTest(string input, int expected)
        {
            // Arrange
            var target = new Day01(new string[] { input });

            // Act
            var result = target.Debug(Part.Two);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void PartTwo()
        {
            // Arrange
            var target = new Day01();

            // Act
            var result = target.Debug(Part.Two);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1220, result);
        }
    }
}
