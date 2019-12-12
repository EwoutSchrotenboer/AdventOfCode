using AoC.Helpers.IntComputer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AoC.Y2019.Tests
{
    [TestClass]
    public class IntCodeTests
    {
        [TestMethod]
        [DataRow("1,9,10,3,2,3,11,0,99,30,40,50", 0, 3500)]
        [DataRow("1,0,0,0,99", 0, 2)]
        [DataRow("2,3,0,3,99", 3, 6)]
        [DataRow("2,4,4,5,99,0", 5, 9801)]
        [DataRow("1,1,1,4,99,5,6,0,99", 0, 30)]
        [DataRow("1,1,1,4,99,5,6,0,99", 4, 2)]
        public void AddAndMultiplyTest(string program, long register, long output)
        {
            var computer = new Computer(program);

            var (states, _) = computer.Run();

            var lastState = states.Last();
            Assert.AreEqual(output, lastState.Memory[register]);
        }

        [TestMethod]
        [DataRow("3,0,4,0,99", 2)]
        [DataRow("3,0,4,0,99", -1)]
        [DataRow("3,0,4,0,99", 0)]
        public void InputOutputTest(string program, long input)
        {
            var computer = new Computer(program, input);

            var (_, outputs) = computer.Run();
            Assert.AreEqual(input, outputs.Single());

        }

        [TestMethod]
        [DataRow("1002,4,3,4,33", 4, 99)]
        [DataRow("1002,4,10,4,50", 4, 500)]
        public void ImmediatePositionTest(string program, long register, long output)
        {
            var computer = new Computer(program);

            var (states, _) = computer.Run();

            var lastState = states.Last();
            Assert.AreEqual(output, lastState.Memory[register]);
        }

        [TestMethod]
        [DataRow("3,9,8,9,10,9,4,9,99,-1,8", 8, 1)] // position, equal to 8 - true
        [DataRow("3,9,8,9,10,9,4,9,99,-1,8", 9, 0)] // position, equal to 8 - false
        [DataRow("3,9,7,9,10,9,4,9,99,-1,8", 5, 1)] // position, less than 8 - true
        [DataRow("3,9,7,9,10,9,4,9,99,-1,8", 10, 0)] // position, less than 8 - false
        [DataRow("3,9,7,9,10,9,4,9,99,-1,8", 8, 0)] // position, less than 8 - false
        [DataRow("3,12,6,12,15,1,13,14,13,4,13,99,-1,0,1,9", 0, 0)] // position, 0 if zero
        [DataRow("3,12,6,12,15,1,13,14,13,4,13,99,-1,0,1,9", 1, 1)] // position, 1 if one
        public void JumpTestPosition(string program, long input, long output)
        {
            var computer = new Computer(program, input);

            var (_, outputs) = computer.Run();

            Assert.AreEqual(output, outputs.Single());
        }

        [TestMethod]
        [DataRow("3,3,1108,-1,8,3,4,3,99", 8, 1)] // immediate, equal to 8 - true
        [DataRow("3,3,1108,-1,8,3,4,3,99", 10, 0)] // immediate, equal to 8 - false
        [DataRow("3,3,1107,-1,8,3,4,3,99", 5, 1)] // immediate, less than 8 - true
        [DataRow("3,3,1107,-1,8,3,4,3,99", 10, 0)] // immediate, less than 8 - false
        [DataRow("3,3,1107,-1,8,3,4,3,99", 8, 0)] // immediate, less than 8 - false
        [DataRow("3,3,1105,-1,9,1101,0,0,12,4,12,99,1", 0, 0)] // position, 0 if zero
        [DataRow("3,3,1105,-1,9,1101,0,0,12,4,12,99,1", 1, 1)]// position, 1 if one
        public void JumpTestImmediate(string program, long input, long output)
        {
            var computer = new Computer(program, input);

            var (_, outputs) = computer.Run();

            Assert.AreEqual(output, outputs.Single());
        }

        [TestMethod]
        [DataRow("3,21,1008,21,8,20,1005,20,22,107,8,21,20,1006,20,31,1106,0,36,98,0,0,1002,21,125,20,4,20,1105,1,46,104,999,1105,1,46,1101,1000,1,20,4,20,1105,1,46,98,99", 4, 999)]
        [DataRow("3,21,1008,21,8,20,1005,20,22,107,8,21,20,1006,20,31,1106,0,36,98,0,0,1002,21,125,20,4,20,1105,1,46,104,999,1105,1,46,1101,1000,1,20,4,20,1105,1,46,98,99", 8, 1000)]
        [DataRow("3,21,1008,21,8,20,1005,20,22,107,8,21,20,1006,20,31,1106,0,36,98,0,0,1002,21,125,20,4,20,1105,1,46,104,999,1105,1,46,1101,1000,1,20,4,20,1105,1,46,98,99", 12, 1001)]
        public void EqualsEight(string program, long input, long output)
        {
            var computer = new Computer(program, input);

            var (_, outputs) = computer.Run();

            Assert.AreEqual(output, outputs.Single());
        }

        [TestMethod]
        [DataRow("1102,34915192,34915192,7,4,7,99,0", 1219070632396864)]
        [DataRow("104,1125899906842624,99", 1125899906842624)]
        public void RelativeOutputTest(string program, long output)
        {
            var computer = new Computer(program);
            var (_, outputs) = computer.Run();

            Assert.AreEqual(output, outputs.Last());
        }

        [TestMethod]
        [DataRow("109,1,204,-1,1001,100,1,100,1008,100,16,101,1006,101,0,99", new long[] { 109, 1, 204, -1, 1001, 100, 1, 100, 1008, 100, 16, 101, 1006, 101, 0, 99 })]
        public void QuineTest(string program, long[] expected)
        {
            var computer = new Computer(program);
            var (_, outputs) = computer.Run();

            var expectedList = expected.ToList();
            Assert.IsTrue(expectedList.SequenceEqual(outputs));
        }
    }
}
