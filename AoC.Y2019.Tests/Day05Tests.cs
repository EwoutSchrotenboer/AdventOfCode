using AoC.Helpers.Utils;
using AoC.Y2019.Days;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace AoC.Y2019.Tests.Days
{
    [TestClass]
    public class Day05Tests
    {
        private List<string> input = new List<string>()
        {
            "3,21,1008,21,8,20,1005,20,22,107,8,21,20,1006,20,31, 1106,0,36,98,0,0,1002,21,125,20,4,20,1105,1,46,104, 999,1105,1,46,1101,1000,1,20,4,20,1105,1,46,98,99",
        };

        [TestMethod]
        public void PartOneTest()
        {
            // Arrange
            var target = new Day05();

            // Act

            var result = target.Debug(Part.One);

            // Assert

            Assert.IsNotNull(result);
            Assert.AreEqual((long)9431221, result);

        }

        [TestMethod]
        public void PartTwoTest()
        {
            // Arrange
            var target = new Day05();

            // Act

            var result = target.Debug(Part.Two);

            // Assert

            Assert.IsNotNull(result);
            Assert.AreEqual((long)1409363, result);
        }
    }
}