using AoC.Helpers.Utils;
using AoC.Y2019.Days;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace AoC.Y2019.Tests.Days
{
    [TestClass]
    public class Day16Tests
    {
        private List<string> testInput = new List<string>()
            {
            };

        [TestMethod]
        [DataRow(new string[] { "80871224585914546619083218645595" }, "24176176")]
        [DataRow(new string[] { "19617804207202209144916044189917" }, "73745418")]
        [DataRow(new string[] { "69317163492948606335995924319873" }, "52432133")]
        public void PartOneTest(string[] input, string expected)
        {
            // Arrange
            var target = new Day16(input.ToList());

            // Act
            var result = target.Debug(Part.One);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow(new string[] { "03036732577212944063491565474664" }, "84462026")]
        [DataRow(new string[] { "02935109699940807407585447034323" }, "78725270")]
        [DataRow(new string[] { "03081770884921959731165446850517" }, "53553731")]
        public void PartTwoTest(string[] input, string expected)
        {
            // Arrange
            var target = new Day16(input.ToList());

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
            var target = new Day16();

            // Act
            var result = target.Debug(Part.One);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("82435530", result);
        }

        [TestMethod]
        public void PartTwo()
        {
            // Arrange
            var target = new Day16();

            // Act
            var result = target.Debug(Part.Two);

            // Assert
            Assert.IsNotNull(result);
           Assert.AreEqual("83036156", result);
        }
    }
}
