﻿using AoC.Helpers.Utils;
using AoC.Y2018.Days;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace AoC.Y2018.Tests.Days
{
    [TestClass]
    public class Day11Tests
    {
        private List<string> testInput = new List<string>()
            {
            };

        [TestMethod]
        public void PartOne()
        {
            // Arrange
            var target = new Day11();

            // Act
            var result = target.Debug(Part.One);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("235,60", result);
        }

        [TestMethod]
        public void PartTwo()
        {
            // Arrange
            var target = new Day11();

            // Act
            var result = target.Debug(Part.Two);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("233,282,11", result);
        }
    }
}
