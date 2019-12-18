using AoC.Helpers.Utils;
using AoC.Y2019.Days;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace AoC.Y2019.Tests.Days
{
    [TestClass]
    public class Day18Tests
    {

        [TestMethod]
        [DataRow(new string[] { "#########", "#b.A.@.a#", "#########" }, 8)]
        [DataRow(new string[] { "########################", "#f.D.E.e.C.b.A.@.a.B.c.#", "######################.#", "#d.....................#", "########################" }, 86)]
        [DataRow(new string[] { "########################", "#...............b.C.D.f#", "#.######################", "#.....@.a.B.c.d.A.e.F.g#", "########################" }, 132)]
        [DataRow(new string[] { "#################", "#i.G..c...e..H.p#", "########.########", "#j.A..b...f..D.o#", "########@########", "#k.E..a...g..B.n#", "########.########", "#l.F..d...h..C.m#", "#################" }, 136)]
        [DataRow(new string[] { "########################", "#@..............ac.GI.b#", "###d#e#f################", "###A#B#C################", "###g#h#i################", "########################" }, 81)]
        public void PartOneTest(string[] input, int expected)
        {
            // Arrange
            var target = new Day18(input);

            // Act
            var result = target.Debug(Part.One);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow(new string[] { "#######", "#a.#Cd#", "##@#@##", "#######", "##@#@##", "#cB#Ab#", "#######" }, 8)]
        [DataRow(new string[] { "###############", "#d.ABC.#.....a#", "######@#@######", "###############", "######@#@######", "#b.....#.....c#", "###############" }, 24)]
        // [DataRow(new string[] { "#############", "#DcBa.#.GhKl#", "#.###@#@#I###", "#e#d#####j#k#", "###C#@#@###J#", "#fEbA.#.FgHi#", "#############" }, 32)]
        [DataRow(new string[] { "#############", "#g#f.D#..h#l#", "#F###e#E###.#", "#dCba@#@BcIJ#", "#############", "#nK.L@#@G...#", "#M###N#H###.#", "#o#m..#i#jk.#", "#############" }, 72)]
        public void PartTwoTest(string[] input, int expected)
        {
            // Arrange
            var target = new Day18(input);

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
            var target = new Day18();

            // Act
            var result = target.Debug(Part.One);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(4248, result);
        }

        [TestMethod]
        public void PartTwo()
        {
            // Arrange
            var target = new Day18();

            // Act
            var result = target.Debug(Part.Two);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1878, result);
        }
    }
}
