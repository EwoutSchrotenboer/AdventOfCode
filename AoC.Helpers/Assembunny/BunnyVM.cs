using System.Collections.Generic;
using System.Linq;

namespace AoC.Helpers.Assembunny
{
    public static class BunnyVM
    {
        public static int RunProgram(List<BunnyInstruction> instructions, (int? register, int? value) input, bool optimize)
        {
            var registers = new int[] { 0, 0, 0, 0 };
            var output = new List<int>();

            if (input.register != null)
            {
                registers[input.register.Value] = input.value.Value;
            }

            var instructionPointer = 0;

            while (instructionPointer >= 0 && instructionPointer < instructions.Count)
            {
                var instruction = instructions[instructionPointer];

                // Day 23
                // Optimization of instructions 5-10 - multiplication
                //				 |do				|
                //			     |{					|
                //  (5) cpy b c  |  c = b; 			| Copy the value from register b to register c
                //			     |  do				|
                //			     |  {				|
                //  (6) inc a    |    a++; 			| Increase a and decrease c, while c is not 0, transferring the value from c to a
                //  (7) dec c    |    c--; 			|
                //			     |  }				|
                //  (8) jnz c -2 |  while (c != 0) 	| If c is 0, move on to the next subset of instructions.
                //  (9) dec d    |  d--; 			| The goal here is to decrease d and check if it is 0. If not, repeat the previous process by setting c to b again.
                //			     |}					| Because c is set to b, d times, and then transferred to A, we can conclude:
                // (10) jnz d -5 |while (d != 0) 	| A = B * D, and both C and D get set to 0.
                if (instructionPointer == 4 && optimize)
                {
                    registers[0] = registers[3] * registers[1];
                    registers[2] = 0;
                    registers[3] = 0;

                    // Update the pointer to point to the next set.
                    instructionPointer = 10;
                    continue;
                }

                switch (instruction.Name)
                {
                    case "cpy":
                        if (instruction.BIsReg)
                        {
                            registers[instruction.B] = instruction.AIsReg ? registers[instruction.A] : instruction.A;
                        }
                        break;

                    case "inc":
                        if (instruction.A >= 0 && instruction.A < 4)
                        {
                            registers[instruction.A] += 1;
                        }
                        break;

                    case "dec":
                        if (instruction.A >= 0 && instruction.A < 4)
                        {
                            registers[instruction.A] -= 1;
                        }
                        break;

                    case "jnz":
                        var aJnz = (instruction.AIsReg ? registers[instruction.A] : instruction.A);

                        if (aJnz != 0)
                        {
                            instructionPointer += instruction.BIsReg ? registers[instruction.B] : instruction.B;
                            continue;
                        }

                        break;

                    case "tgl":
                        var targetIndex = instructionPointer + (instruction.AIsReg ? registers[instruction.A] : instruction.A);

                        if (targetIndex >= 0 && targetIndex < instructions.Count())
                        {
                            var target = instructions[targetIndex];
                            target.ToggleInstruction();
                        }
                        break;
                    case "out":
                        var value = (instruction.AIsReg ? registers[instruction.A] : instruction.A);

                        if ((value == 1 || value == 0) && (output.Count() == 0 || output.Last() != value))
                        {
                            if (output.Count() > 10_000) { return input.value.Value; }
                            output.Add(value);
                        }
                        else
                        {
                            return -1;
                        }

                        break;
                }

                instructionPointer++;
            }

            return registers[0];
        }
    }
}
