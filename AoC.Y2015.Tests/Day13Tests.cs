using AoC.Helpers.Utils;
using AoC.Y2015.Days;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AoC.Y2015.Tests.Days
{
    [TestClass]
    public class Day13Tests
    {
        [TestMethod]
        [DataRow(new string[] { "Alice would gain 54 happiness units by sitting next to Bob.", "Alice would lose 79 happiness units by sitting next to Carol.", 
                                "Alice would lose 2 happiness units by sitting next to David.", "Bob would gain 83 happiness units by sitting next to Alice.", 
                                "Bob would lose 7 happiness units by sitting next to Carol.", "Bob would lose 63 happiness units by sitting next to David.", 
                                "Carol would lose 62 happiness units by sitting next to Alice.", "Carol would gain 60 happiness units by sitting next to Bob.", 
                                "Carol would gain 55 happiness units by sitting next to David.", "David would gain 46 happiness units by sitting next to Alice.", 
                                "David would lose 7 happiness units by sitting next to Bob.", "David would gain 41 happiness units by sitting next to Carol.", }, 330)]
        public void PartOneTest(string[] input, int expected)
        {
            // Arrange
            var target = new Day13(input);

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
            var target = new Day13();

            // Act
            var result = target.Debug(Part.One);

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void PartTwo()
        {
            // Arrange
            var target = new Day13();

            // Act
            var result = target.Debug(Part.Two);

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
