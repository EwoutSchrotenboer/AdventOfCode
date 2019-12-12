using System;
using System.Collections.Generic;
using System.Text;

namespace AoC.Helpers.IntComputer
{
    public static class Operations
    {
        public static Response ExecuteOperation(Instruction instruction) =>
            instruction.OpCode switch
            {
                OpCode.ADD => Add(instruction),
                OpCode.MUL => Multiply(instruction),
                OpCode.SET => Set(instruction),
                OpCode.GET => Get(instruction),
                OpCode.JIT => JumpIfTrue(instruction),
                OpCode.JIF => JumpIfFalse(instruction),
                OpCode.LT => LessThan(instruction),
                OpCode.EQ => Equal(instruction),
                OpCode.REL => Relative(instruction),
                OpCode.EXIT => Exit(instruction, 0),
                _ => Exit(instruction, -1),
            };

        // 1 - Add - Day 02
        private static Response Add(Instruction instruction)
        {
            var (first, second, outputPos, nextIp) = GetParameters(instruction);
            instruction.Memory[outputPos.Value] = first.Value + second.Value;
            return new Response(instruction.Memory, nextIp, instruction.RelativeBase, false, null);
        }

        // 2 - Multiply - Day 02
        private static Response Multiply(Instruction instruction)
        {
            var (first, second, outputPos, nextIp) = GetParameters(instruction);
            instruction.Memory[outputPos.Value] = first.Value * second.Value;
            return new Response(instruction.Memory, nextIp, instruction.RelativeBase, false, null);
        }

        // 3 - Set - Day 05 Pt 1
        private static Response Set(Instruction instruction)
        {
            var (_, _, outputPos, nextIp) = GetParameters(instruction);
            instruction.Memory[outputPos.Value] = instruction.Input;
            return new Response(instruction.Memory, nextIp, instruction.RelativeBase, false, null);
        }

        // 4 - Get - Day 05 Pt 1
        private static Response Get(Instruction instruction)
        {
            var (first, _, _, nextIp) = GetParameters(instruction);
            return new Response(instruction.Memory, nextIp, instruction.RelativeBase, false, first);
        }

        // 5 - Jump if true - Day 05 Pt 2
        private static Response JumpIfTrue(Instruction instruction)
        {
            var (first, second, _, nextIp) = GetParameters(instruction);
            var newIp = first != 0 ? second.Value : nextIp;
            return new Response(instruction.Memory, newIp, instruction.RelativeBase, false, null);
        }

        // 6 - Jump if false - Day 05 Pt 2
        private static Response JumpIfFalse(Instruction instruction)
        {
            var (first, second, _, nextIp) = GetParameters(instruction);
            var newIp = first == 0 ? second.Value : nextIp;
            return new Response(instruction.Memory, newIp, instruction.RelativeBase, false, null);
        }

        // 7 - Less than - Day 05 Pt 2
        private static Response LessThan(Instruction instruction)
        {
            var (first, second, outputPos, nextIp) = GetParameters(instruction);
            instruction.Memory[outputPos.Value] = first.Value < second.Value ? 1 : 0;
            return new Response(instruction.Memory, nextIp, instruction.RelativeBase, false, null);
        }

        // 8 - Equals  - Day 05 Pt 2
        private static Response Equal(Instruction instruction)
        {
            var (first, second, outputPos, nextIp) = GetParameters(instruction);
            instruction.Memory[outputPos.Value] = first.Value == second.Value ? 1 : 0;
            return new Response(instruction.Memory, nextIp, instruction.RelativeBase, false, null);
        }

        // 9 - Set relative base - Day 09 Pt 1
        private static Response Relative(Instruction instruction)
        {
            var (first, _, _, nextIp) = GetParameters(instruction);
            var rb = instruction.RelativeBase + first.Value;
            return new Response(instruction.Memory, nextIp, rb, false, null, false);
        }

        // 99 - Exit - Day 02
        private static Response Exit(Instruction instruction, int exitCode) => new Response(instruction.Memory, instruction.InstructionPointer, instruction.RelativeBase, true, exitCode);

        private static long GetValue(long[] memory, long pos, long rb, ParamMode mode) =>
            mode switch
            {
            ParamMode.Immediate => memory[pos],
            ParamMode.Position  => memory[memory[pos]],
            ParamMode.Relative  => memory[memory[pos] + rb],
                              _ => -1
            };

        private static (long? first, long? second, long? outputPos, long defaultNextIp) GetParameters(Instruction instruction)
        {
            var (inputs, output) = GetParameterCount(instruction.OpCode);
            var memory = instruction.Memory;
            var ip = instruction.InstructionPointer;
            var rb = instruction.RelativeBase;

            var outputPosition = ip + inputs + 1;
            long? firstVal = null, secondVal = null, outputPos = null;

            if (output) 
            {
                var mode = ParamMode.Position;
                if (inputs == 2) mode = instruction.ThirdMode;
                if (inputs == 1) mode = instruction.SecondMode;
                if (inputs == 0) mode = instruction.FirstMode;
                outputPos = mode == ParamMode.Relative ? memory[outputPosition] + rb : memory[outputPosition];
            }
            if (inputs >= 2) { secondVal = GetValue(memory, ip + 2, rb, instruction.SecondMode); }
            if (inputs >= 1) { firstVal = GetValue(memory, ip + 1, rb, instruction.FirstMode); }

            // use default offsets when not explicitly overwriting the pointer
            var defaultNewIp =  ip + (output ? inputs + 2 : inputs + 1);

            return (firstVal, secondVal, outputPos, defaultNewIp);
        }

        private static (long inputs, bool output) GetParameterCount(OpCode opCode) =>
            opCode switch
            {
                OpCode.ADD => (2, true),
                OpCode.MUL => (2, true),
                OpCode.SET => (0, true),
                OpCode.GET => (1, false),
                OpCode.JIT => (2, false),
                OpCode.JIF => (2, false),
                OpCode.LT => (2, true),
                OpCode.EQ => (2, true),
                OpCode.REL => (1, false),
                OpCode.EXIT => (0, false),
                _ => (0, false)
            };
    }
}
