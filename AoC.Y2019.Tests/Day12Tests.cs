using AoC.Helpers.Utils;
using AoC.Y2019.Days;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace AoC.Y2019.Tests.Days
{
    [TestClass]
    public class Day12Tests
    {

        [TestMethod]
        [DataRow(new string[] { "<x=-8, y=-10, z=0>", "<x=5, y=5, z=10>", "<x=2, y=-7, z=3>", "<x=9, y=-8, z=-3>" }, 1940)]
        public void PartOneTest(string[] input, int expected)
        {
            // Arrange
            var target = new Day12(input.ToList());

            // Act

            var result = target.Debug(Part.One);

            // Assert

            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow(new string[] { "<x=-8, y=-10, z=0>", "<x=5, y=5, z=10>", "<x=2, y=-7, z=3>", "<x=9, y=-8, z=-3>" }, 4686774924)]
        public void PartTwoTest(string[] input, long expected)
        {
            // Arrange
            var target = new Day12(input);

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

            var result = target.Debug(Part.One);

            // Assert

            Assert.IsNotNull(result);
            Assert.AreEqual(14606, result);
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
            Assert.AreEqual(543673227860472, result);
        }
    }
}
