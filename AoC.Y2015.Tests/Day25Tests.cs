using AoC.Helpers.Utils;
using AoC.Y2015.Days;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AoC.Y2015.Tests.Days
{
    [TestClass]
    public class Day25Tests
    {
        [TestMethod]
        [DataRow(new string[] { "row 2, column 1." }, 31916031)]
        [DataRow(new string[] { "row 1, column 2." }, 18749137)]
        [DataRow(new string[] { "row 3, column 1." }, 16080970)]
        [DataRow(new string[] { "row 2, column 2." }, 21629792)]
        [DataRow(new string[] { "row 1, column 3." }, 17289845)]
        public void PartOneTest(string[] input, long expected)
        {
            // Arrange
            var target = new Day25(input);

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
            var target = new Day25();

            // Act
            var result = target.Debug(Part.One);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(19980801L, result);
        }
    }
}
