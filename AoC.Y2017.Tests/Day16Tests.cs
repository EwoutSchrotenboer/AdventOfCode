using AoC.Helpers.Utils;
using AoC.Y2017.Days;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AoC.Y2017.Tests.Days
{
    [TestClass]
    public class Day16Tests
    {
        [TestMethod]
        [DataRow("s1,x3/4,pe/b", "baedc")]
        public void PartOneTest(string input, string expected)
        {
            // Arrange
            var target = new Day16(new string[] { input });

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
            var target = new Day16();

            // Act
            var result = target.Debug(Part.One);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("doeaimlbnpjchfkg", result);
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
            Assert.AreEqual("agndefjhibklmocp", result);
        }
    }
}
