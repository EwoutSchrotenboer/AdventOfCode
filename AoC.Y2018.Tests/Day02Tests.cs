using AoC.Helpers.Utils;
using AoC.Y2018.Days;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace AoC.Y2018.Tests.Days
{
    [TestClass]
    public class Day02Tests
    {
        private List<string> input = new List<string>()
            {
                "abcde",
                "fghij",
                "klmno",
                "pqrst",
                "fguij",
                "axcye",
                "wvxyz"
            };

        [TestMethod]
        public void PartOneTest()
        {
            // Arrange
            var target = new Day02();

            // Act
            var result = target.Execute(Part.One);

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void PartTwoTest()
        {
            // Arrange
            var target = new Day02();

            // Act
            var result = target.Execute(Part.Two);

            // Assert
            Assert.IsNotNull(result);
        }
    }
}