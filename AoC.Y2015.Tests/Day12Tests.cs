using AoC.Helpers.Utils;
using AoC.Y2015.Days;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AoC.Y2015.Tests.Days
{
    [TestClass]
    public class Day12Tests
    {
        [TestMethod]
        [DataRow("[1,2,3]", 6)]
        [DataRow("{\"a\":2,\"b\":4}", 6)]
        [DataRow("[[[3]]]", 3)]
        [DataRow("{\"a\":{\"b\":4},\"c\":-1}", 3)]
        [DataRow("{\"a\":[-1,1]}", 0)]
        [DataRow("[-1,{\"a\":1}]", 0)]
        [DataRow("[]", 0)]
        [DataRow("{}", 0)]
        public void PartOneTest(string input, int expected)
        {
            // Arrange
            var target = new Day12(new string[] { input });

            // Act
            var result = target.Debug(Part.One);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow("[1,2,3]", 6)]
        [DataRow("[1,{\"c\":\"red\",\"b\":2},3]", 4)]
        [DataRow("{\"d\":\"red\",\"e\":[1,2,3,4],\"f\":5}", 0)]
        [DataRow("[1,\"red\",5]", 6)]
        public void PartTwoTest(string input, int expected)
        {
            // Arrange
            var target = new Day12(new string[] { input });

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
            var target = new Day12();

            // Act
            var result = target.Debug(Part.Two);

            // Assert
            Assert.IsNotNull(result);
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
        }
    }
}
