using AoC.Helpers.Utils;
using AoC.Y2019.Days;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace AoC.Y2019.Tests.Days
{
    [TestClass]
    public class Day02Tests
    {
        private List<string> input = new List<string>()
        {
            "1,9,10,3,2,3,11,0,99,30,40,50"
        };

        [TestMethod]
        public void PartOneTest()
        {
            // Arrange
            var target = new Day02();

            // Act

            var result = target.Debug(Part.One);

            // Assert

            Assert.IsNotNull(result);
            Assert.AreEqual((long)3716293, result);
        }

        [TestMethod]
        public void PartTwoTest()
        {
            // Arrange
            var target = new Day02();

            // Act

            var result = target.Debug(Part.Two);

            // Assert

            Assert.IsNotNull(result);
            Assert.AreEqual(6429, result);
        }
    }
}